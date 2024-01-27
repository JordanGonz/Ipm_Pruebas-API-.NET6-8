using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers
{
    public class PermisoProfile : Profile
    {
        public PermisoProfile()
        {
            CreateMap<Permiso, PermisoDto>()
                .ForMember(dest => dest.PermisoId, opt => opt.MapFrom(src => src.PermisoId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));
        }
    }
}
