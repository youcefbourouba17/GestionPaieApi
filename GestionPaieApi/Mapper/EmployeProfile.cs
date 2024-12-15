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
            CreateMap<EmployeDisplayDto, Employe>();
            CreateMap<Employe, EmployeEditDto>()
                .ForMember(dest => dest.EmployeResponsabilites, opt => opt.MapFrom(src => src.EmployeResponsabilites.Select(er => er.ResponsabiliteID).ToList())); // Explicitly mapping responsibilities
            CreateMap<EmployeEditDto, Employe>()
                .ForMember(dest => dest.EmployeResponsabilites, opt => opt.Ignore()); // Ignore responsibilities when updating from DTO
        }
    }
}
