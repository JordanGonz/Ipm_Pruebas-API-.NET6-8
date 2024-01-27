using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Services;

public class FeedbackProgresoHistoricoService : IFeedbackProgresoHistoricoService
{
    private readonly IFeedbackProgresoHistoricoRepository _feedBack; 
    private readonly IMapper _mapper;
    public FeedbackProgresoHistoricoService(IFeedbackProgresoHistoricoRepository feedBack, IMapper mapper)
    {
        _feedBack = feedBack;
        _mapper = mapper;


    }
      
    public async Task<bool> CreearFeedbackProgresoHistoricoAsync(FeedbackProgresoHistoricoDto fedBack)
    {
        if (fedBack == null)
        {
            // Manejar la situación en la que los datos son nulos
            return false;
        }

        var asignacion = _mapper.Map<FeedbackProgresoHistorico>(fedBack);
        asignacion.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _feedBack.CreearFeedbackProgresoHistoricoAsync(asignacion);
    }

    public async Task<bool> EditarFeedbackProgresoHistoricoAsync(int id, FeedBackEditar feedBack)
    {
        return await _feedBack.EditarFeedbackProgresoHistoricoAsync(feedBack);
    }

    public async Task<bool> EliminarFeedbackProgresoHistoricoAsync(int id)
    {
        return await _feedBack.EliminarFeedbackProgresoHistoricoAsync(id);
    }

}
