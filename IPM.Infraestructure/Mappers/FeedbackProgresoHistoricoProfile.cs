using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Mappers;

public class FeedbackProgresoHistoricoProfile : Profile
{
    public FeedbackProgresoHistoricoProfile()
    {
        CreateMap<FeedbackProgresoHistoricoDto, FeedbackProgresoHistorico>();
        CreateMap<FeedBackEditar, FeedbackProgresoHistorico>();
        CreateMap<FeedBackEliminar, FeedbackProgresoHistorico>();
    }
}
