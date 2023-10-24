using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IRoleService
    {
        Task<List<RoleDto>> ObtenerTodosLosRoles();
        Task<RoleDto> ObtenerRolePorId(int idRol);
        Task<RoleDto> CrearRol(RoleDto roleDto);
        Task<bool> ActualizarRol(int idRol, RoleDto roleDto);
        Task<bool> EliminarRol(int idRol);
    }
}
