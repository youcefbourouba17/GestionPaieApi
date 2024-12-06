using AutoMapper;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using GestionPaieApi.Reposotories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GestionPaieApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeController : ControllerBase
    {
        private readonly GenericRepository<Employe> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeRepo;

        public EmployeController(GenericRepository<Employe> genericRepository,IMapper mapper, IEmployeeRepo employeRepo)
        {
            _genericRepository=genericRepository;
            _mapper = mapper;
            _employeRepo=employeRepo;
        }
        [HttpGet("GetAllEmployes")]
        public async Task<ActionResult<ICollection<Employe>>> GetAllEmployee()
        {
            try
            {
               

                var employeList = _mapper.Map<List<EmployeDisplayDto>>(await _genericRepository.GetAllAsync());

                if (employeList.IsNullOrEmpty())
                {
                    return NotFound("Aucun employé trouvé.");
                }
                return Ok(employeList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeByID")]
        public async Task<ActionResult<Employe>> GetEmployeByID(String NSS)
        {
            try
            {


                var employe= await _genericRepository.GetByIdAsync(NSS);
                if (employe==null)
                {
                    return NotFound("Aucun employé trouvé.");
                }
                return Ok(employe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeeResponsabilitiesByID")]
        public async Task<ActionResult<Employe>> GetEmployeResponsibiliesByID(String NSS)
        {
            try
            {


                var employe = await _employeRepo.GetEmployeeResponsabilitiesByID(NSS);
                if (employe == null)
                {
                    return NotFound("Aucun Responsibilies trouvé.");
                }
                return Ok(employe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        [HttpGet("GetFilter")]
        public async Task<ActionResult<Employe>> GetFilterBy(String searchTerm)
        {
            try
            {


                var employe = _mapper.Map<List<EmployeDisplayDto>>(await _employeRepo.SearchUsersAsync(searchTerm));
                if (employe == null)
                {
                    return NotFound("Aucun Employee trouvé.");
                }
                return Ok(employe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }



    }
}
