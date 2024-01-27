using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IAsignacionRepository
    {
        Task<List<AsignacionDto>> ObtenerTodasLasAsignacionesAsync();
        Task<List<AsignacionDto>> ObtenerLasAsignacionesPorUsuariosAsync(int iduser);
        Task<bool> CrearTodasLasAsignacionesAsync(EquipoPersonaAsignacion asignacionCrearDtos);
        Task<bool> ActualizarAsigancionesAsync(AsignacionActualizarDtos asignacionActualizar);
        Task<bool> DeleteAsignacion(int id);
    }
}
