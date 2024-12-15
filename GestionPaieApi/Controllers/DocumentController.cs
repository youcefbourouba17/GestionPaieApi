using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using GestionPaieApi.Reposotories;
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

        #region Get
        [HttpGet("GetEmployeSignaletiqueByID/{NSS}")]
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
                                    c.Year == year)
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
        #endregion


        #region Post
        [HttpPost("PostDemendeChangemnt")]
        public async Task<IActionResult> Post([FromBody] LettreAccompagneeDto lettreDto)
        {

            try
            {
                var lettre = _mapper.Map<LettreAccompagnee>(lettreDto);
                await _genericRepository.AddAsync(lettre);
                return Ok("La lettre a été ajoutée avec succès.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the person.");
            }
        }



        [HttpPost("PostEmployeFA")]
        public async Task<IActionResult> PostEmployeFicheAttachemnt(FicheAttachemntDTO ficheAttachemntDTO,int month,int year)
        {
            try
            {
                var employee = await _employeRepo.GetEmployeeByID(ficheAttachemntDTO.EmployeeID);
                if (employee == null)
                {
                    return NotFound("employee doesnt exist.");
                }
                var ficheAttache = _mapper.Map<FicheAttachemnt>(ficheAttachemntDTO);
                ficheAttache.NomEtPrenom = $"{employee.Nom} {employee.Prenom}";

                ficheAttache.AllocationFamiliale = employee.NombreEnfants;
                ficheAttache.JourTravaillee =await _employeRepo.GetTotalWorkingDay(employee.NSS, year, month);
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
        #endregion


        #region Edit
        [HttpPut("EditLettreAccompagnee")]
        public async Task<IActionResult> EditLettreAccompagnee([FromBody] LettreAccompagneeDto lettre, int lettreID)
        {

            
            try
            {
                var existingLettre = await _genericRepository.GetByIdAsync(lettreID);
                if (existingLettre == null)
                    return NotFound("Lettre accompagnée introuvable.");

                _mapper.Map(lettre, existingLettre); 
                await _genericRepository.Update(existingLettre);

                return Ok(new { Message = "Lettre accompagnée mise à jour avec succès." });
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Une erreur est survenue lors de la mise à jour de la lettre accompagnée.");
            }
        }


        [HttpPut("EditEmployeFA")]
        public async Task<IActionResult> EditEmployeFicheAttachement(FicheAttachemntDTO ficheAttachemntDTO,int faID)
        {

            var employee = await _employeRepo.GetEmployeeByID(ficheAttachemntDTO.EmployeeID);
            if (employee == null)
                return NotFound("Employee doesn't exist.");

            var fiche = await _context.FicheAttachemnts
                                      .FirstOrDefaultAsync(f => f.FaID == faID);
            if (fiche == null)
                return NotFound("Fiche attachement not found.");

            
            _mapper.Map(ficheAttachemntDTO, fiche);

            
            fiche.NomEtPrenom = $"{employee.Nom} {employee.Prenom}";
            fiche.AllocationFamiliale = employee.NombreEnfants;

            
            try
            {
                await _context.SaveChangesAsync();
                return Ok("Fiche updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the fiche attachement,{ex.Message} ");
            }
        }




        #endregion


        #region Delete
        [HttpDelete("DeleteFicheAttachemnt/{id}")]
        public async Task<IActionResult> DeleteFicheAttachemnt(int id)
        {
            try
            {
                var fiche = await _context.FicheAttachemnts.FirstOrDefaultAsync(f => f.FaID == id);
                if (fiche == null)
                    return NotFound("Fiche attachement not found.");

                _context.FicheAttachemnts.Remove(fiche);
                await _context.SaveChangesAsync();

                return Ok("Fiche attachement deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the fiche attachement: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLettreAccompagnee/{id}")]
        public async Task<IActionResult> DeleteLettreAccompagnee(int id)
        {
            try
            {
                var lettre = await _genericRepository.GetByIdAsync(id);
                if (lettre == null)
                    return NotFound("Lettre accompagnée not found.");

                await _genericRepository.Delete(lettre);
                return Ok("Lettre accompagnée deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the lettre accompagnée: {ex.Message}");
            }
        }
        #endregion

    }
}
