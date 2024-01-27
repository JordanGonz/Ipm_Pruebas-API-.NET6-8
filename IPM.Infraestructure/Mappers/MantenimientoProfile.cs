using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

public class MantenimientoProfile : Profile
{
    public  MantenimientoProfile ()
    {

        CreateMap<Mantenimiento, MantenimientoDto>();

        CreateMap<MantenimientoDto, Mantenimiento>();

        CreateMap<Mantenimiento, MantenimientoCreacionDto>();

        CreateMap<MantenimientoCreacionDto, Mantenimiento>();
    }
}
