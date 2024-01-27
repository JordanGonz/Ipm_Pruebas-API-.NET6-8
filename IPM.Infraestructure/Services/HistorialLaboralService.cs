using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using IPM.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Services;

public class HistorialLaboralService : IHistorialLaboralService
{
    private readonly IHistorialLaboralRepository _historiaLaboral;
    private readonly IMapper _mapper;
    public HistorialLaboralService(IHistorialLaboralRepository historiaLaboral, IMapper mapper)
    {
        _historiaLaboral = historiaLaboral;
        _mapper = mapper;

    }

    public async Task<bool> CreearHistoriaLaboralAsync(HistorialLaboralDto historial)
    {
        if (historial == null)
        {
            // Manejar la situación en la que los datos son nulos
            return false;
        }

        var asignacion = _mapper.Map<HistorialLaboral>(historial);
        asignacion.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _historiaLaboral.CreearHistoriaLaboralAsync(asignacion);
    }

    public async Task<bool> EditarHistoriaLaboralAsync(int id, EditarHistoriaLaboral historial)
    {
        return await _historiaLaboral.EditarHistoriaLaboralAsync(historial);
    }

    public async Task<bool> EliminarHistoriaLaboralAsync(int id)
    {
        return await _historiaLaboral.EliminarHistoriaLaboralAsync(id);
    }


}
