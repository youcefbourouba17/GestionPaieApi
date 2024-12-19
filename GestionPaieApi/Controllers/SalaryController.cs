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
    public class SalaryController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IBulletinSalaireRepo _bulletinRepo;
        private readonly Db_context _context;

        public SalaryController( IMapper mapper, IBulletinSalaireRepo bulletinRepo, Db_context context)
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

                
                var grilleSalaire = await _bulletinRepo.GetGrilleSalaireByEmployeID(bulletinDTO.NSS_EMPLOYE);
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

        [HttpGet("GetAllBultinSalaireByMonth")]
        public async Task<ActionResult<List<BulletinDeSalaireDTO>>> GetAllBultinSalaireByMonth(int month,int year)
        {
            try
            {


                var pointagesToday = _bulletinRepo.GetAllBulletinsAsyncByMonth(month, year);

                var pointageDtos = _mapper.Map<List<PointageDto>>(pointagesToday);

                return Ok(pointageDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "An error occurred while retrieving today's attendance.");
            }
        }




    }
}
