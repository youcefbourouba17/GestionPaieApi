using AutoMapper;
using GestionPaieApi.DTOs;
using GestionPaieApi.Models;

namespace GestionPaieApi.Mapper
{
    public class DocumentsProfile : Profile
    {
        public DocumentsProfile() {
            CreateMap<LettreAccompagnee, LettreAccompagneeDto>();
            CreateMap<LettreAccompagneeDto, LettreAccompagnee>();

            CreateMap<FicheAttachemnt, FicheAttachemntDTO>();
            CreateMap<FicheAttachemntDTO, FicheAttachemnt>();

            CreateMap<ResponsabiliteAdministrative, ResponsibiliteDTO>();
            CreateMap<ResponsibiliteDTO, ResponsabiliteAdministrative>();


            CreateMap<Pointage, PointageDto>();

            CreateMap<BulletinDeSalaire, BulletinDeSalaireDTO>();
            CreateMap<BulletinDeSalaireDTO, BulletinDeSalaire>();
        }
        
    }
}
