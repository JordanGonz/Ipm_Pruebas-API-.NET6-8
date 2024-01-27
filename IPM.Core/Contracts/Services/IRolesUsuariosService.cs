using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IRolesUsuariosService
    {
        Task<List<RolesUsuarioDto>> ObtenerTodosLosRolesPermisoAsync();
        Task<RolesUsuarioPorToken> ObtenerRolesPorToken(int usuario);
        Task<RolesUsuarioDto> ObtenerRolePermisoPorIdAsync(int RolesRolId);
        Task<bool> CrearRolePermisoAsync(RolesUsuarioDto rolesUsuarioDto);
        Task<bool> ActualizarRolePermisoAsync(int RolesRolId, RolesUsuarioDto rolesUsuarioDto);
        Task<bool> EliminarRolePermisoAsync(int RolesRolId);
    }
}
