using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBulletinSalaireRepo _bulletinRepo;
        private readonly Db_context _context;

        public SalaryController(IMapper mapper, IBulletinSalaireRepo bulletinRepo, Db_context context)
        {
            _mapper = mapper;
            _bulletinRepo = bulletinRepo;
            _context = context;
        }

        [HttpPost("CreateBulletinSalaire")]
        public async Task<IActionResult> CreateBulletinSalaire([FromBody] BulletinDeSalaireDTO bulletinDTO)
        {
            try
            {
                if (bulletinDTO == null)
                {
                    return BadRequest("Invalid request payload.");
                }

                var fiche = await _context.FicheAttachemnts
                    .FirstOrDefaultAsync(c => c.EmployeeID == bulletinDTO.NSS_EMPLOYE &&
                                              c.Year == bulletinDTO.Year &&
                                              c.Month == bulletinDTO.Month);

                if (fiche == null)
                {
                    return NotFound("Attachment (FicheAttachemnt) not found for the specified employee and date.");
                }

                //var grilleSalaire = await _bulletinRepo.GetGrilleSalaireByEmployeID(bulletinDTO.NSS_EMPLOYE);
                var grilleSalaire = await _bulletinRepo.GetGrilleSalaireByEmployeIDAsync(bulletinDTO.NSS_EMPLOYE);
                if (grilleSalaire == null)
                {
                    return NotFound("Salary grid (GrilleSalaire) not found for the specified employee.");
                }

                var bulletin = new BulletinDeSalaire
                {
                    FicheAttachemnt = fiche,
                    GrilleSalaire = grilleSalaire,
                    GrilleSalaireID = grilleSalaire.GrilleSalaire_Id,
                    Id_FichAtachemnt = fiche.FaID
                };

                bulletin.Salaire = BulletinSalaireSevice.Calcul_Salaie(bulletin);

                _context.BulletinDeSalaires.Add(bulletin);
                await _context.SaveChangesAsync();

                return Ok("Bulletin saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while creating the bulletin: {ex.Message}");
            }
        }

        [HttpGet("GetAllBulletinsByMonth")]
        public async Task<ActionResult<List<BulletinDeSalaireDTO>>> GetAllBulletinsByMonth(int month, int year)
        {
            try
            {
                var bulletinList = await _bulletinRepo.GetAllBulletinsAsyncByMonthAsync(month, year);
                if (bulletinList == null || !bulletinList.Any())
                {
                    return NotFound("No bulletins found for the given month and year.");
                }

                var bulletinDtos = _mapper.Map<List<BulletinDeSalaireDTO>>(bulletinList);
                return Ok(bulletinDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"An error occurred while retrieving bulletins: {ex.Message}");
            }
        }

        [HttpGet("GetBulletinsByID/{bulttinId}")]
        public async Task<ActionResult<List<BulletinDeSalaire>>> GetBulletinsByID(int bulttinId)
        {
            try
            {
                var bulletin = await _bulletinRepo.GetBulletinDeSalaireByIDAsync(bulttinId);
                if (bulletin == null )
                {
                    return NotFound("No bulletins found for the specified employee.");
                }



                return Ok(bulletin);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"An error occurred while retrieving bulletins for employee: {ex.Message}");
            }
        }

        [HttpGet("GetBulletinsByEmployeeID/{employeeId}")]
        public async Task<ActionResult<List<BulletinDeSalaire>>> GetBulletinsByEmployeeID(string employeeId)
        {
            try
            {
                var bulletinList = await _bulletinRepo.GetAllBulletinsByEmployeIDAsync(employeeId);
                if (bulletinList == null || !bulletinList.Any())
                {
                    return NotFound("No bulletins found for the specified employee.");
                }

                
                
                return Ok(bulletinList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"An error occurred while retrieving bulletins for employee: {ex.Message}");
            }
        }

        [HttpGet("CheckBulletinExists/{employeeId}")]
        public async Task<ActionResult<bool>> CheckBulletinExists(string employeeId)
        {
            try
            {
                var exists = await _bulletinRepo.CheckBulletinExistsAsync(employeeId);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"An error occurred while checking bulletin existence: {ex.Message}");
            }
        }

        [HttpGet("GetGrilleSalaireByEmployeeID/{employeeId}")]
        public async Task<ActionResult<GrilleSalaireDTO>> GetGrilleSalaireByEmployeeID(string employeeId)
        {
            try
            {
                var grilleSalaire = await _bulletinRepo.GetGrilleSalaireByEmployeIDAsync(employeeId);
                if (grilleSalaire == null)
                {
                    return NotFound("Salary grid (GrilleSalaire) not found for the specified employee.");
                }

                var grilleSalaireDto = _mapper.Map<GrilleSalaireDTO>(grilleSalaire);
                return Ok(grilleSalaireDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"An error occurred while retrieving salary grid for employee: {ex.Message}");
            }
        }

        [HttpGet("GetUntachedEmployeeBulletins")]
        public async Task<ActionResult<List<EmployeDisplayDto>>> GetUntachedEmployeeBulletins(int month, int year)
        {
            try
            {
                var employees = await _bulletinRepo.GetUntachedEmployeeBulletinsAsync(month, year);
                if (employees == null || !employees.Any())
                {
                    return NotFound("No employees found without attached bulletins for the specified month and year.");
                }

                var employeeDtos = _mapper.Map<List<EmployeDisplayDto>>(employees);
                return Ok(employeeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"An error occurred while retrieving untached employee bulletins: {ex.Message}");
            }
        }
    }
}
