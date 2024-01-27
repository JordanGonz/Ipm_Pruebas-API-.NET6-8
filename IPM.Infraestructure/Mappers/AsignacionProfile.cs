using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers;

public class AsignacionProfile: Profile
{
    public AsignacionProfile()
    {
        CreateMap<EquipoPersonaAsignacion, AsignacionDto>(); 
        CreateMap<EquipoPersonaAsignacion, AsignacionCrearDtos>();
        CreateMap<EquipoPersonaAsignacion, AsignacionPorIdDto>();
        CreateMap<AsignacionCrearDtos, EquipoPersonaAsignacion>();

        CreateMap<AsignacionActualizarDtos, EquipoPersonaAsignacion>();

    }
}
