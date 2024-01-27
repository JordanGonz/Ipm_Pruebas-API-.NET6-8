using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using AutoMapper;

namespace IPM.Infraestructure.Mappers
{
    public class PaginaProfile : Profile
    {
        public PaginaProfile() 
        {
            CreateMap<Pagina, PaginaDto>();
            CreateMap<PaginaDto, PaginaUsuarioDto>();
            
        }
    }
}
