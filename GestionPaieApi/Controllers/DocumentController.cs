using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GestionPaieApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly GenericRepository<LettreAccompagnee> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeRepo;
        private readonly Db_context _context;

        public DocumentController(GenericRepository<LettreAccompagnee> genericRepository,
                                IMapper mapper, IEmployeeRepo employeRepo,
                                Db_context context)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _employeRepo = employeRepo;
            _context = context;
        }

        

        [HttpPost("PostDemendeChangemnt")]
        public async Task<IActionResult> Post([FromBody] LettreAccompagneeDto lettreDto)
        {

            try
            {
                var lettre = _mapper.Map < LettreAccompagnee >(lettreDto);
                await _genericRepository.AddAsync(lettre);
                return Ok("La lettre a été ajoutée avec succès.");
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the person.");
            }
        }

        [HttpGet("GetEmployeSignaletiqueByID")]
        public async Task<ActionResult<Employe>> GetEmployeSignaletique(String NSS)
        {
            try
            {


                var employe = await _employeRepo.GetEmployeeByID(NSS);
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

        [HttpGet("GetEmployeFA")]
        public async Task<ActionResult<Employe>> GetEmployeFicheAttachemnt(int month, int year)
        {
            try
            {


                var ficheAttachemnts = await _context.FicheAttachemnts.Where(c => c.Month == month &&
                                    c.Year==year)
                                     .ToListAsync();
                if (ficheAttachemnts == null)
                {
                    return NotFound("Aucun employé trouvé.");
                }
                return Ok(ficheAttachemnts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }

        [HttpPost("PostEmployeFA")]
        public async Task<IActionResult> PostEmployeFicheAttachemnt(FicheAttachemntDTO ficheAttachemntDTO)
        {
            try
            {
                var employee = await _employeRepo.GetEmployeeByID(ficheAttachemntDTO.EmployeeID);
                if (employee==null)
                {
                    return NotFound("employee doesnt exist.");
                }
                var ficheAttache = _mapper.Map<FicheAttachemnt>(ficheAttachemntDTO);
                ficheAttache.NomEtPrenom = $"{employee.Nom} {employee.Prenom}";
                
                ficheAttache.AllocationFamiliale = employee.NombreEnfants;
                if (_context.FicheAttachemnts.Contains(ficheAttache))
                {
                    return StatusCode(500, $"Fiche Employee ALready exist , try to edit it ");
                }
                await _context.FicheAttachemnts.AddAsync(ficheAttache);
               
                _context.SaveChanges();
                return Ok("saved");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }
    }
}
