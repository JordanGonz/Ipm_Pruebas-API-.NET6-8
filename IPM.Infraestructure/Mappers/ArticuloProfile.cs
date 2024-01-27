using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

public class ArticuloProfile :Profile
{
    public ArticuloProfile ()
    {

        CreateMap<Articulo, ArticuloDto>();

        CreateMap<ArticuloDto, Articulo>();

        CreateMap<Articulo, ArticuloCreacionDto>();

        CreateMap<ArticuloCreacionDto, Articulo>();
    }
}
