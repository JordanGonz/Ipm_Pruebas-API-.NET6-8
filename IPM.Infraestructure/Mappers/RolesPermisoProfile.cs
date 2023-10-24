using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers
{
    public class RolesPermisoProfile : Profile
    {
        public RolesPermisoProfile()
        {
            CreateMap<RolesPermiso, RolesPermisoDto>()
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId))
                .ForMember(dest => dest.PermisoId, opt => opt.MapFrom(src => src.PermisoId))
                .ForMember(dest => dest.RolPermisoId, opt => opt.MapFrom(src => src.RolPermisoId));

            CreateMap<RolesPermisoDto, RolesPermiso>()
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId))
                .ForMember(dest => dest.PermisoId, opt => opt.MapFrom(src => src.PermisoId))
                .ForMember(dest => dest.RolPermisoId, opt => opt.MapFrom(src => src.RolPermisoId));
        }
    }
}
