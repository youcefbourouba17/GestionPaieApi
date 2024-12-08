using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using GestionPaieApi.Reposotories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly Db_context _context;

        public EmployeController(GenericRepository<Employe> genericRepository,IMapper mapper, IEmployeeRepo employeRepo,Db_context context)
        {
            _genericRepository=genericRepository;
            _mapper = mapper;
            _employeRepo=employeRepo;
            _context = context;
        }

        [HttpPost("CreateEmploye")]
        public async Task<IActionResult> CreateEmploye([FromBody] EmployeEditDto employeDto)
        {
            try
            {
                

                var employe = _mapper.Map<Employe>(employeDto);
                var resposabilities = await _context.ResponsabilitesAdministratives
                            .Where(er => employeDto.EmployeResponsabilites.Contains(er.ResponsabiliteID))
                            .ToListAsync();
                List<EmployeResponsabilites> list = new List<EmployeResponsabilites>();
                foreach (var item in resposabilities)
                {
                    list.Add(new EmployeResponsabilites
                    {
                        EmployeID = employeDto.NSS,
                        ResponsabiliteID = item.ResponsabiliteID
                    });

                }
                // Save to repository
                await _genericRepository.AddAsync(employe);

                return Ok("Employee created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the employee: {ex.Message}");
            }
        }

        [HttpPut("EditEmploye/{id}")]
        public async Task<IActionResult> EditEmploye(string id, [FromBody] EmployeEditDto employeDto)
        {
            try
            {
                var employe = await _genericRepository.GetByIdAsync(id);
                if (employe == null)
                {
                    return NotFound($"Employe with ID {id} not found.");
                }

                // Map the DTO to the entity
                _mapper.Map(employeDto, employe);

                // Update in the repository
                await _genericRepository.Update(employe);

                return Ok("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the employee: {ex.Message}");
            }
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
