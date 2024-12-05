using AutoMapper;
using GestionPaieApi.DTOs;
using GestionPaieApi.Models;

namespace GestionPaieApi.Mapper
{
    public class EmployeProfile : Profile
    {
        public EmployeProfile()
        {
            CreateMap<Employe, EmployeDisplayDto>();
        }
    }
}
