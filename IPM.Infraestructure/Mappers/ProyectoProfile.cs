using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers
{
    public class ProyectoProfile : Profile
    {
        public ProyectoProfile()
        {
            CreateMap<Proyecto, ProyectoDto>()
                .ForMember(dest => dest.IdProyecto, opt => opt.MapFrom(src => src.IdProyecto))
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdLiderPrincipal, opt => opt.MapFrom(src => src.IdLiderPrincipal))
                .ForMember(dest => dest.CodigoProyecto, opt => opt.MapFrom(src => src.CodigoProyecto))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio))
                .ForMember(dest => dest.FechaFin, opt => opt.MapFrom(src => src.FechaFin));
                
                //.ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion))
                //.ForMember(dest => dest.UsuarioCreacion, opt => opt.MapFrom(src => src.UsuarioCreacion))
                //.ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.FechaModificacion))
                //.ForMember(dest => dest.UsuarioModificacion, opt => opt.MapFrom(src => src.UsuarioModificacion));
        }
    }
}
