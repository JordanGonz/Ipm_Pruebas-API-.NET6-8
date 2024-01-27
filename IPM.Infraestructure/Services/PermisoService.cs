using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPM.Core.Constants;
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
                Estado = permiso.Estado
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
                    Estado = permiso.Estado
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CrearPermisoAsync(PermisoCreacionDTO permisoDto)
        {
            var nuevoPermiso = new Permiso
            {
                Nombre = permisoDto.Nombre,
                Estado = IPMConstants.ESTADO_ACTIVO
        };

           
            _context.Permisos.Add(nuevoPermiso);
           int resp=  await _context.SaveChangesAsync();

            return resp > 0;
           
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

            permisoExistente.Estado = IPMConstants.ESTADO_INACTIVO;
            int filasafectadas= await _context.SaveChangesAsync();
            return filasafectadas > 0;
        }
    }
}
