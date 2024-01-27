
using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

public class CatalogoProfile : Profile
{
    public CatalogoProfile()
    {
        CreateMap<Catalogo, CatalogoDto>();
         
        CreateMap<CatalogoDto, Catalogo>();

        CreateMap<Catalogo, CatalogoCreacionDTO>();

        CreateMap<CatalogoCreacionDTO, Catalogo>();

        CreateMap<Catalogo, CatalogoMostrarNombre>();


    }
}
