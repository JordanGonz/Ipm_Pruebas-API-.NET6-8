using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IRolesPermisoService
    {
        Task<List<RolesPermisoDto>> ObtenerTodosLosRolesPermiso();
        Task<RolesPermisoDto> ObtenerRolePermisoPorId(int idRol);
        Task<RolesPermisoDto> CrearRolePermiso(RolesPermisoDto rolesPermisoDto);
        Task<bool> ActualizarRolePermiso(int idRol, RolesPermisoDto rolesPermisoDto);
        Task<bool> EliminarRolePermiso(int idRol);
    }
}
