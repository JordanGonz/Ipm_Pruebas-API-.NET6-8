using AutoMapper;
using IPM.Core.Dtos;
using IPM.Core.Models.EquiposOficina;
using IPM.Infraestructure.MainContext;

public class EquipoProfile :Profile
{
    public  EquipoProfile ()
    {

        CreateMap<Equipo, EquipoDto>();

        CreateMap<EquipoDto, Equipo>();

        CreateMap<Equipo, EquipoCreacionDto>();

        CreateMap<EquipoCreacionDto, Equipo>();

        CreateMap<Equipo, EquipoSistemOperativo>();

        CreateMap<EquipoSistemOperativo, Equipo>();

        CreateMap<Equipo, EquipoOficina>();
    }
}
