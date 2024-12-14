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
using System.Collections.Generic;

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

        public EmployeController(GenericRepository<Employe> genericRepository, IMapper mapper, IEmployeeRepo employeRepo, Db_context context)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _employeRepo = employeRepo;
            _context = context;
        }

        #region GET Methods

        [HttpGet("GetAllEmployes")]
        public async Task<ActionResult<ICollection<Employe>>> GetAllEmployee()
        {
            try
            {
                var v1 = await _genericRepository.GetAllAsync();
                var employeList = _mapper.Map<List<EmployeDisplayDto>>(v1);

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

        [HttpGet("GetEmployeeResponsabilitiesByID")]
        public async Task<ActionResult<Employe>> GetEmployeResponsibiliesByID(string NSS)
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

        [HttpGet("GetEmployeByID")]
        public async Task<ActionResult<Employe>> GetEmployeByID(string NSS)
        {
            try
            {
                var employe = await _genericRepository.GetByIdAsync(NSS);
                if (employe == null)
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

        [HttpGet("FilterByID")]
        public async Task<ActionResult<Employe>> GetFilterBy(string searchTerm)
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

        [HttpGet("GetUnattachedEmployeeFiche")]
        public async Task<ActionResult<List<EmployeDisplayDto>>> GetAllUnattachedEmployeeFiche(int month, int year)
        {
            try
            {
                var employe = await _employeRepo.GetUntachmntEmployeeFiche(month, year);
                if (employe == null)
                {
                    return NotFound("Aucun Employee trouvé.");
                }
                var employeDTO = _mapper.Map<List<EmployeDisplayDto>>(employe);

                return Ok(employeDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        #endregion

        #region POST Methods

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

        #endregion

        #region PUT Methods
        // todo-- djib klch w dir update
        [HttpPut("EditEmploye")]
        public async Task<IActionResult> EditEmploye([FromBody] EmployeEditDto employeDto)
        {
            try
            {
                var employe = await _employeRepo.GetEmployeeByIDFull(employeDto.NSS);
                if (employe == null)
                {
                    return NotFound($"Employe with ID {employeDto.NSS} not found.");
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

        #endregion

        #region DELETE Method
        [HttpDelete("DeleteEmploye")]
        public async Task<IActionResult> DeleteEmploye(string nss)
        {
            try
            {
               
                var employe = await _genericRepository.GetByIdAsync(nss);
                if (employe == null)
                {
                    return NotFound($"Employee with NSS {nss} not found.");
                }

                
                var responsibilities = await _context.EmployeResponsabilites
                                                    .Where(er => er.EmployeID == nss)
                                                    .ToListAsync();
                _context.EmployeResponsabilites.RemoveRange(responsibilities);

                
                await _genericRepository.Delete(employe);

                return Ok("Employee deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the employee: {ex.Message}");
            }
        }

        #endregion
    }
}
