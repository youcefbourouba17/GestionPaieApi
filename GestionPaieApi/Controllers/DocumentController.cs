using AutoMapper;
using GestionPaieApi.DTOs;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        public DocumentController(GenericRepository<LettreAccompagnee> genericRepository, IMapper mapper, IEmployeeRepo employeRepo)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _employeRepo = employeRepo;
        }

        [HttpGet("GetEmployeFS")]
        public async Task<ActionResult<Employe>> GetEmployeByID(String NSS)
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

    }
}
