using AutoMapper;
using GestionPaieApi.Data;
using GestionPaieApi.Interfaces;
using GestionPaieApi.Models;
using GestionPaieApi.Repositories;
using Microsoft.AspNetCore.Mvc;

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


    }
}
