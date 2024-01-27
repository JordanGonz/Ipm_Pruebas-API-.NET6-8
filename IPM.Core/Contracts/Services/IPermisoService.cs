using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IPermisoService
    {
        Task<List<PermisoDto>> ObtenerTodosLosPermisosAsync();
        Task<PermisoDto> ObtenerPermisoPorIdAsync(int permisoId);
        Task<bool> CrearPermisoAsync(PermisoCreacionDTO permisoDto);
        Task<bool> ActualizarPermisoAsync(int permisoId, PermisoDto permisoDto);

        
        Task<bool> EliminarPermisoAsync(int permisoId);
    }
}
