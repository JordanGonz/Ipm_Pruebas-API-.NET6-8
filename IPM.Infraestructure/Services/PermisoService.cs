using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;

namespace IPM.Services
{
    public class PermisoService : IPermisoService
    {
        private readonly IntegrityProjectManagementContext _context; 

        public PermisoService(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<List<PermisoDto>> ObtenerTodosLosPermisosAsync()
        {
            var permisos = await _context.Permisos.ToListAsync();
            var permisosDto = permisos.Select(permiso => new PermisoDto
            {
                PermisoId = permiso.PermisoId,
                Nombre = permiso.Nombre,
                Estado = (bool)permiso.Estado
            }).ToList();
            return permisosDto;
        }
        public async Task<PermisoDto> ObtenerPermisoPorIdAsync(int idPermiso)
        {
            var permiso = await _context.Permisos.FirstOrDefaultAsync(p => p.PermisoId == idPermiso);
            if (permiso != null)
            {
                return new PermisoDto
                {
                    PermisoId = permiso.PermisoId,
                    Nombre = permiso.Nombre,
                    Estado = (bool)permiso.Estado
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<PermisoDto> CrearPermisoAsync(PermisoDto permisoDto)
        {
            var nuevoPermiso = new Permiso
            {
                Nombre = permisoDto.Nombre,
                Estado = permisoDto.Estado
            };

            _context.Permisos.Add(nuevoPermiso);
            await _context.SaveChangesAsync();

            return new PermisoDto
            {
                PermisoId = nuevoPermiso.PermisoId,
                Nombre = nuevoPermiso.Nombre,
                Estado =(bool)nuevoPermiso.Estado
            };
        }

        public async Task<bool> ActualizarPermisoAsync(int idPermiso, PermisoDto permisoDto)

        {
            var permisoExistente = await _context.Permisos.FirstOrDefaultAsync(p => p.PermisoId == idPermiso);

            if (permisoExistente == null)
            {
                return false;
            }

            // Actualiza las propiedades del permiso existente con los valores del objeto PermisoDto
            permisoExistente.Nombre = permisoDto.Nombre;
            permisoExistente.Estado = permisoDto.Estado;

            _context.Permisos.Update(permisoExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarPermisoAsync(int idPermiso)
        {
            var permisoExistente = await _context.Permisos.FirstOrDefaultAsync(p => p.PermisoId == idPermiso);

            if (permisoExistente == null)
            {
                return false;
            }

            _context.Permisos.Remove(permisoExistente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
