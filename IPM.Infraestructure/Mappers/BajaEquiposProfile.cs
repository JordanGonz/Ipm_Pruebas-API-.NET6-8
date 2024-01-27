using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

public class BajaEquiposProfile : Profile
{
    public  BajaEquiposProfile()
    {
        CreateMap<BajaEquipo, BajaEquiposDto>();

        CreateMap<BajaEquiposDto, BajaEquipo>();

        CreateMap<BajaEquipo, BajaEquiposCreacionDto>();

        CreateMap<BajaEquiposCreacionDto, BajaEquipo>();

    }
}
