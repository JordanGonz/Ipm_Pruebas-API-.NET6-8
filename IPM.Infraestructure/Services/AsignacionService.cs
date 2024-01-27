using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Services;

public class EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice : IEquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice
{
    private readonly IAsignacionRepository _asignacionRepository;
    private readonly IMapper _mapper;
    public EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice(IAsignacionRepository asignacionRepository, IMapper mapper)
    {
        _asignacionRepository = asignacionRepository;
        _mapper = mapper;
    }

    public async Task<List<AsignacionDto>> ObtenerTodasLasAsignacionesAsync()
    {
       var asignacion = await _asignacionRepository.ObtenerTodasLasAsignacionesAsync();
        return _mapper.Map<List<AsignacionDto>>(asignacion);
    }


    public async Task<List<AsignacionDto>> ObtenerLasAsignacionesPorUsuariosAsync(int iduser)
    {
        var asignacion = await _asignacionRepository.ObtenerLasAsignacionesPorUsuariosAsync(iduser);
        return _mapper.Map<List<AsignacionDto>>(asignacion);
    }



    public async Task<bool> CrearTodasLasAsignacionesAsync(AsignacionCrearDtos asignacionCrearDtos)
    {
        if (asignacionCrearDtos == null)
        {
            // Manejar la situación en la que los datos son nulos
            return false;
        }

        // Validar otros campos requeridos si es necesario

        var asignacion = _mapper.Map<EquipoPersonaAsignacion>(asignacionCrearDtos);
        asignacion.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _asignacionRepository.CrearTodasLasAsignacionesAsync(asignacion);
    }

    public async Task<bool> ActualizarAsigancionesAsync(int asignacionId, AsignacionActualizarDtos asignacionActualizar)
    {
        
        return await _asignacionRepository.ActualizarAsigancionesAsync(asignacionActualizar);


    }


    public async Task<bool> DeleteAsignacion(int id)
    {
        return await _asignacionRepository.DeleteAsignacion(id);


    }
}
