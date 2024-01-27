using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPM.Services
{
    public class RolePermisoService : IRolesPermisoService
    {
        private readonly IntegrityProjectManagementContext _context;

        public RolePermisoService(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<List<RolesPermisoDto>> ObtenerTodosLosRolesPermiso()
        {
            var rolesPermisos = await _context.RolesPermisos.ToListAsync();
            var rolesPermisosDto = rolesPermisos.Select(rp => new RolesPermisoDto
            {
                RolId = rp.RolId,
                PermisoId = rp.PermisoId,
                RolPermisoId = rp.RolPermisoId,
                Estado = rp.Estado
            }).ToList();
            return rolesPermisosDto;
        }

        public async Task<RolesPermisoDto> ObtenerRolePermisoPorId(int idRolePermiso)
        {
            var rolePermiso = await _context.RolesPermisos.FirstOrDefaultAsync(rp => rp.RolPermisoId == idRolePermiso);
            if (rolePermiso != null)
            {
                return new RolesPermisoDto
                {
                    RolId = rolePermiso.RolId,
                    PermisoId = rolePermiso.PermisoId,
                    RolPermisoId = rolePermiso.RolPermisoId,
                    Estado = rolePermiso.Estado
                };
            }
            else
            {
                return null;
            }
        }

        

        public async Task<bool> CrearRolePermiso(RolesCreacionPermiso rolesPermisoDto)
        {
            var nuevoRolePermiso = new RolesPermiso
            {
                RolId = rolesPermisoDto.RolId,
                PermisoId = rolesPermisoDto.PermisoId,
                Estado = IPMConstants.ESTADO_ACTIVO

        };
            
            _context.RolesPermisos.Add(nuevoRolePermiso);
            int resp= await _context.SaveChangesAsync();

           
            return resp > 0;
            
        }

        public async Task<bool> ActualizarRolePermiso(int idRolePermiso, RolesPermisoDto rolesPermisoDto)
        {
            var rolePermisoExistente = await _context.RolesPermisos.FirstOrDefaultAsync(rp => rp.RolPermisoId == idRolePermiso);

            if (rolePermisoExistente == null)
            {
                return false;
            }

            // Actualiza las propiedades del RolePermiso existente con los valores del objeto RolesPermisoDto
            rolePermisoExistente.RolId = rolesPermisoDto.RolId;
            rolePermisoExistente.PermisoId = rolesPermisoDto.PermisoId;

            _context.RolesPermisos.Update(rolePermisoExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarRolePermiso(int idRolePermiso)
        {
            var rolePermisoExistente = await _context.RolesPermisos.FirstOrDefaultAsync(rp => rp.RolPermisoId == idRolePermiso);

            if (rolePermisoExistente == null)
            {
                return false;
            }

            rolePermisoExistente.Estado = IPMConstants.ESTADO_INACTIVO;
          
            int filasAfectadas= await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }
    }
}
