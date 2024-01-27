using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IEquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice
    {
        Task<List<AsignacionDto>> ObtenerTodasLasAsignacionesAsync();
        Task <List<AsignacionDto>> ObtenerLasAsignacionesPorUsuariosAsync(int iduser);
        Task<bool> CrearTodasLasAsignacionesAsync(AsignacionCrearDtos asignacionCrearDtos);
        Task<bool> ActualizarAsigancionesAsync(int asignacionId, AsignacionActualizarDtos asignacionActualizar);

        Task<bool> DeleteAsignacion(int id);

    }
}
