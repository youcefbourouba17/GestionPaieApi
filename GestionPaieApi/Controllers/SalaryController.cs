using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPaieApi.Controllers
{
    public class SalaryController : ControllerBase
    {
        private readonly GenericRepository<Employe> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeRepo;
        private readonly Db_context _context;

        public SalaryController(GenericRepository<Employe> genericRepository, IMapper mapper, IEmployeeRepo employeRepo, Db_context context)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _employeRepo = employeRepo;
            _context = context;
        }


        [HttpPost("CreateBulletinSalaire")]
        public async Task<IActionResult> CreateEmploye([FromBody] BulletinDeSalaireDTO BulletinDTO)
        {
            try
            {
                //if (await _employeRepo.chec(employeDto.NSS))
                //{
                //    return BadRequest("employee already exist");
                //}
                var fiche = await _context.FicheAttachemnts
                            .Where(c => c.EmployeeID == BulletinDTO.NSS_EMPLOYE &&
                                        c.Year == BulletinDTO.Year &&
                                        c.Month == BulletinDTO.Month)
                            .FirstOrDefaultAsync();
                var grileSalaaire = await _context.GrilleSalaires
                            .Where(c => c.NSS_EMPLOYE == BulletinDTO.NSS_EMPLOYE )
                            .FirstOrDefaultAsync();

                if (fiche != null && grileSalaaire!=null)
                {
                    
                    BulletinDeSalaire bultin = new BulletinDeSalaire
                    {
                        FicheAttachemnt = fiche,
                        GrilleSalaire=grileSalaaire,
                        GrilleSalaireID=grileSalaaire.GrilleSalaire_Id,
                        Salaire=5345345,
                        Id_FichAtachemnt=fiche.FaID
                    };

                    
                    _context.BulletinDeSalaires.Add(bultin);
                    await _context.SaveChangesAsync();
                }

                return Ok("Employee created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the employee: {ex.Message}");
            }
        }

    }
}
