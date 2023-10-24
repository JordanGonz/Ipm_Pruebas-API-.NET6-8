using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;

namespace IPM.Services
{
    public class RoleService : IRoleService
    {
        private readonly IntegrityProjectManagementContext _context;

        public RoleService(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDto>> ObtenerTodosLosRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            var rolesDto = roles.Select(role => new RoleDto
            {
                RolId = role.RolId,
                Nombre = role.Nombre,
                Estado = role.Estado
            }).ToList();
            return rolesDto;
        }



        public async Task<RoleDto> ObtenerRolePorId(int idRol)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RolId == idRol);
            if (role != null)
            {
                return new RoleDto
                {
                    RolId = role.RolId,
                    Nombre = role.Nombre,
                    Estado = role.Estado
                };
            }
            else
            {
                return null;
            }
        }



        public async Task<RoleDto> CrearRol(RoleDto roleDto)
        {
            
            var nuevoRol = new Role
            {
                Nombre = roleDto.Nombre,
                Estado = roleDto.Estado
            };

            _context.Roles.Add(nuevoRol);
            await _context.SaveChangesAsync();

            // Mapea la entidad de rol nuevamente a un objeto RoleDto y devuélvelo
            return new RoleDto
            {
                RolId = nuevoRol.RolId,
                Nombre = nuevoRol.Nombre,
                Estado = nuevoRol.Estado
            };
        }

        public async Task<bool> ActualizarRol(int idRol, RoleDto roleDto)
        {
            var rolExistente = await _context.Roles.FirstOrDefaultAsync(r => r.RolId == idRol);

            if (rolExistente == null)
            {
                return false;
            }

            // Actualiza las propiedades del rol existente con los valores del objeto RoleDto
            rolExistente.Nombre = roleDto.Nombre;
            rolExistente.Estado = roleDto.Estado;

            _context.Roles.Update(rolExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarRol(int idRol)
        {
            var rolExistente = await _context.Roles.FirstOrDefaultAsync(r => r.RolId == idRol);

            if (rolExistente == null)
            {
                return false;
            }

            _context.Roles.Remove(rolExistente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
