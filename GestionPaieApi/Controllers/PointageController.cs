using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using GestionPaieApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointageController : ControllerBase
    {
        private readonly GenericRepository<Pointage> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeRepo;
        private readonly Db_context _context;

        public PointageController(GenericRepository<Pointage> genericRepository, 
            IMapper mapper, IEmployeeRepo employeRepo , Db_context context)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _employeRepo = employeRepo;
            _context = context;
        }

        [HttpGet("GetAllPointageToday")]
        public async Task<ActionResult<List<PointageDto>>> GetPointageToday()
        {
            try
            {
                var currentDate = DateTime.Today;

                var pointagesToday = await _context.Pointages
                    .Where(p => p.Date == currentDate)
                    .ToListAsync();

                var pointageDtos = _mapper.Map<List<PointageDto>>(pointagesToday);

                return Ok(pointageDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "An error occurred while retrieving today's attendance.");
            }
        }



        [HttpPost("PostPointage")]
        public async Task<IActionResult> PostPointage([FromBody] string employeeID)
        {
            try
            {
                
                if (!await _employeRepo.CheckEmployeeAsync(employeeID))
                {
                    return NotFound("Employee ID wrong or doesn't exist");
                }

                
                var currentTime = DateTime.Today;
                var currentDate = currentTime.Date;

                
                Pointage? pointage = await _genericRepository.GetByIdAsync(employeeID, currentDate);

                if (pointage == null)
                {
                    
                    if (currentTime.Hour < 12)
                    {
                        pointage = new Pointage
                        {
                            EmployeId = employeeID,
                            Date = currentDate,
                            DebutMatinee = currentTime.TimeOfDay
                        };
                        await _genericRepository.AddAsync(pointage);
                        return Ok("Pointage début matinée enregistré avec succès.");
                    }
                    else
                    {
                        return BadRequest("Error: Unable to save the record.");
                    }
                }

                
                else if (pointage.FinMatinee == null)
                {
                    return await HandleFinMatinee(pointage, currentTime);
                }

                else if (pointage.DebutApresMidi == null && currentTime.Hour >= 13 && currentTime.Hour < 16.5)
                {
                    return await HandleDebutApresMidi(pointage, currentTime);
                }

                else if (pointage.FinApresMidi == null)
                {
                    return await HandleFinApresMidi(pointage, currentTime);
                }

                return Ok("No record saved.");
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the person.");
            }
        }

        // Helper methods for specific cases
        private async Task<IActionResult> HandleFinMatinee(Pointage pointage, DateTime currentTime)
        {
            if (currentTime.Hour <= 12)
            {
                pointage.FinMatinee = currentTime.TimeOfDay;
            }
            else
            {
                pointage.FinMatinee = new TimeSpan(12, 0, 0);
            }

            await _genericRepository.Update(pointage);
            return Ok("Pointage fin matinée enregistré avec succès.");
        }

        private async Task<IActionResult> HandleDebutApresMidi(Pointage pointage, DateTime currentTime)
        {
            pointage.DebutApresMidi = currentTime.TimeOfDay;
            pointage.DureeDePause = pointage.DebutApresMidi - pointage.FinMatinee;

            await _genericRepository.Update(pointage);
            return Ok($"Pointage début après-midi enregistré ({pointage.DebutApresMidi}), pause de {pointage.DureeDePause}.");
        }

        private async Task<IActionResult> HandleFinApresMidi(Pointage pointage, DateTime currentTime)
        {
            if (currentTime.Hour > 16.5)
            {
                
                pointage.FinApresMidi = new TimeSpan(16, 30, 0);
                pointage.HeuresSupplementaires = currentTime.Hour - 16.5;
            }
            else
            {
                pointage.FinApresMidi = currentTime.TimeOfDay;
                pointage.HeuresSupplementaires = 0;
            }

            pointage.DureeDePause = pointage.DebutApresMidi - pointage.FinMatinee;
            pointage.HeuresTotales = EmployeeServices.GetTotalHours(pointage);
            await _genericRepository.Update(pointage);
            return Ok($"Pointage fin après-midi enregistré ({pointage.FinApresMidi}), pause de {pointage.DureeDePause}, heures supplémentaires: {pointage.HeuresSupplementaires}.");
        }

    }
}
