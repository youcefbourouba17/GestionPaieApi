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
    public class ToolsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly Db_context _context;

        public ToolsController(IMapper mapper, Db_context context)
        {
            _mapper = mapper;
            _context = context;
        }

        #region Get Methods
        [HttpGet("GetAllEmployes")]
        public async Task<ActionResult<ICollection<ResponsabiliteAdministrative>>> GetAllResponsabilites()
        {
            try
            {
                var v1 = await _context.ResponsabilitesAdministratives.ToListAsync();

                if (v1.IsNullOrEmpty())
                {
                    return NotFound("Aucun employé trouvé.");
                }
                return Ok(v1);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur: {ex.Message}");
            }
        }
        #endregion

        #region Post Method
        [HttpPost("CreateResponsabilite")]
        public async Task<IActionResult> CreateEmploye([FromBody] ResponsibiliteDTO responsabiliteDTO)
        {
            try
            {
                if (await _context.ResponsabilitesAdministratives.FindAsync(responsabiliteDTO.ResponsabiliteID) != null)
                {
                    return BadRequest("Reponsabilite already exists");
                }
                var respo = _mapper.Map<ResponsabiliteAdministrative>(responsabiliteDTO);
                await _context.AddAsync(respo);
                await _context.SaveChangesAsync();

                return Ok("Employee created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the employee: {ex.Message}");
            }
        }
        #endregion

        #region Put Method
        [HttpPut("UpdateResponsabilite/{id}")]
        public async Task<IActionResult> UpdateResponsabilite(int id, [FromBody] ResponsabiliteAdministrative updatedResponsabilite)
        {
            try
            {
                var existingResponsabilite = await _context.ResponsabilitesAdministratives.FindAsync(id);

                if (existingResponsabilite == null)
                {
                    return NotFound("ResponsabiliteAdministrative not found.");
                }

                _mapper.Map(updatedResponsabilite, existingResponsabilite);
                _context.ResponsabilitesAdministratives.Update(existingResponsabilite);
                await _context.SaveChangesAsync();

                return Ok("ResponsabiliteAdministrative updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the employee: {ex.Message}");
            }
        }
        #endregion

        #region Delete Method
        [HttpDelete("DeleteResponsabilite/{id}")]
        public async Task<IActionResult> DeleteResponsabilite(int id)
        {
            try
            {
                var responsabilite = await _context.ResponsabilitesAdministratives.FindAsync(id);

                if (responsabilite == null)
                {
                    return NotFound("ResponsabiliteAdministrative not found.");
                }

                _context.ResponsabilitesAdministratives.Remove(responsabilite);
                await _context.SaveChangesAsync();

                return Ok("ResponsabiliteAdministrative deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the employee: {ex.Message}");
            }
        }
        #endregion
    }
}
