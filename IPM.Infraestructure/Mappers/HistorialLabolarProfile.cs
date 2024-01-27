using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;


namespace IPM.Infraestructure.Mappers;

public class HistorialLabolarProfile : Profile
{
    public HistorialLabolarProfile()
    {
        CreateMap<HistorialLaboralDto,HistorialLaboral>();
        CreateMap<EditarHistoriaLaboral, HistorialLaboral>();
        CreateMap<EliinarHistoriaLaboral, HistorialLaboral>();
    }
}
