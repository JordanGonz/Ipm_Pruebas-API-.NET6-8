using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers
{
    public class ProyectoDetalleProfile : Profile
    {
        public ProyectoDetalleProfile()
        {
            CreateMap<ProyectoDetalle, ProyectoDetalleDto>()
                .ForMember(dest => dest.IdProyectoDetalle, opt => opt.MapFrom(src => src.IdProyectoDetalle))
                .ForMember(dest => dest.IdProyecto, opt => opt.MapFrom(src => src.IdProyecto))
                .ForMember(dest => dest.IdRecurso, opt => opt.MapFrom(src => src.IdRecurso))
                .ForMember(dest => dest.IdLider, opt => opt.MapFrom(src => src.IdLider))
                .ForMember(dest => dest.CargoRecurso, opt => opt.MapFrom(src => src.CargoRecurso))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion))
                .ForMember(dest => dest.UsuarioCreacion, opt => opt.MapFrom(src => src.UsuarioCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.FechaModificacion))
                .ForMember(dest => dest.UsuarioModificacion, opt => opt.MapFrom(src => src.UsuarioModificacion));
        }
    }
}
