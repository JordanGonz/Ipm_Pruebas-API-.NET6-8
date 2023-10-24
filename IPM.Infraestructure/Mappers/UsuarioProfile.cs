using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
                .ForMember(dest => dest.ConfirmarClave, opt => opt.MapFrom(src => src.ConfirmarClave))
                .ForMember(dest => dest.Restablecer, opt => opt.MapFrom(src => src.Restablecer))
                .ForMember(dest => dest.Confirmado, opt => opt.MapFrom(src => src.Confirmado));
        }
    }
}
