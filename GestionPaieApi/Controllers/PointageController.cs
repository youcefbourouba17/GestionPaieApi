using AutoMapper;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestionPaieApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointageController : ControllerBase
    {
        private readonly GenericRepository<Pointage> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeRepo;

        public PointageController(GenericRepository<Pointage> genericRepository, IMapper mapper, IEmployeeRepo employeRepo)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _employeRepo = employeRepo;
        }
        [HttpPost("PostPointage")]
        public async Task<IActionResult> PostPointage([FromBody] string employeeID)
        {

            try
            {
                if (!await _employeRepo.CheckUserAsync(employeeID))
                {
                    return NotFound("Employee ID wrong or doesnt exist");
                }

                var time = DateTime.Today.Add(new TimeSpan(13, 43, 0));
                
                Pointage lettre =await _genericRepository.GetByIdAsync(employeeID,time.Date);
                if (lettre==null )
                {
                    if (time.Hour < 12)
                    {
                        lettre = new Pointage
                        {
                            EmployeId = employeeID,
                            Date = time.Date,
                            DebutMatinee = time.TimeOfDay
                        };
                        await _genericRepository.AddAsync(lettre);
                        return Ok("La pointage debutMatine avec succès.");
                    }
                    else return BadRequest("Error cant save record");
                }
                else if (lettre.FinMatinee == null && time.Hour<=12)
                {

                    lettre.FinMatinee = time.TimeOfDay;
                    _genericRepository.Update(lettre);
                    return Ok("La pointage finMatinee avec succès.");
                }
                else if (lettre.FinMatinee == null && time.Hour > 12)
                {

                    lettre.FinMatinee =new TimeSpan(12,0,0);
                    _genericRepository.Update(lettre);
                    return Ok("La pointage finMatinee avec succès.");
                }
                else if (lettre.DebutApresMidi == null && time.Hour>=13 && time.Hour<16.5)
                {
                    
                    lettre.DebutApresMidi = time.TimeOfDay;
                    lettre.DureeDePause = lettre.DebutApresMidi - lettre.FinMatinee;
                    _genericRepository.Update(lettre);
                    return Ok($"La pointage DebutApresMidi {lettre.DebutApresMidi} et Pause de {lettre.DureeDePause} avec succès.");
                }
                else if (lettre.FinApresMidi == null && time.Hour <= 16.5)
                {

                    lettre.FinApresMidi = time.TimeOfDay;
                    lettre.DureeDePause = lettre.DebutApresMidi - lettre.FinMatinee;
                    lettre.HeuresSupplementaires =0;
                    _genericRepository.Update(lettre);
                    return Ok($"La pointage DebutApresMidi {lettre.DebutApresMidi} et Pause de {lettre.DureeDePause}" +
                        $" et heur supp {lettre.HeuresSupplementaires} avec succès.");
                }
                else if (lettre.FinApresMidi == null && time.Hour > 16.5)
                {
                    lettre.FinApresMidi =new TimeSpan(16, 30, 00);
                    lettre.DureeDePause = lettre.DebutApresMidi - lettre.FinMatinee;
                    lettre.HeuresSupplementaires = time.Hour-16.5;
                    _genericRepository.Update(lettre);
                    return Ok($"La pointage DebutApresMidi {lettre.DebutApresMidi} et Pause de {lettre.DureeDePause}" +
                        $" et heur supp {lettre.HeuresSupplementaires} avec succès.");
                }
                else
                {
                    return Ok("No record Saved.");
                }
                
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the person.");
            }
        }
    }
}
