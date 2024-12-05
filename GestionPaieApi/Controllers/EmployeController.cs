using AutoMapper;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
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

        public EmployeController(GenericRepository<Employe> genericRepository,IMapper mapper)
        {
            _genericRepository=genericRepository;
            _mapper = mapper;
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

        [HttpGet("GetEmployeFicherSignaletique")]
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
    }
}
