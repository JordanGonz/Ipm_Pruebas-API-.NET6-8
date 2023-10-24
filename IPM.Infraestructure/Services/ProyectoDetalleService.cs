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
    public class ProyectoDetalleService : IProyectoDetalleService
    {
        private readonly IntegrityProjectManagementContext _context;

        public ProyectoDetalleService(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<List<ProyectoDetalleDto>> ObtenerTodosLosProyectoDetalle()
        {
            var detalles = await _context.ProyectoDetalles
                .ToListAsync();

            var detallesDto = detalles.Select(detalle => new ProyectoDetalleDto
            {
                IdProyectoDetalle = detalle.IdProyectoDetalle,
                IdProyecto = detalle.IdProyecto,
                IdRecurso = detalle.IdRecurso,
                IdLider = detalle.IdLider,
                CargoRecurso = detalle.CargoRecurso,
                Estado = detalle.Estado,
                FechaCreacion = detalle.FechaCreacion,
                UsuarioCreacion = detalle.UsuarioCreacion,
                FechaModificacion = detalle.FechaModificacion,
                UsuarioModificacion = detalle.UsuarioModificacion
            }).ToList();

            return detallesDto;
        }

        public async Task<ProyectoDetalleDto> ObtenerProyectoDetallePorId(int idProyectoDetalle)
        {
            var detalle = await _context.ProyectoDetalles
                .FirstOrDefaultAsync(detalle => detalle.IdProyectoDetalle == idProyectoDetalle);

            if (detalle != null)
            {
                return new ProyectoDetalleDto
                {
                    IdProyectoDetalle = detalle.IdProyectoDetalle,
                    IdProyecto = detalle.IdProyecto,
                    IdRecurso = detalle.IdRecurso,
                    IdLider = detalle.IdLider,
                    CargoRecurso = detalle.CargoRecurso,
                    Estado = detalle.Estado,
                    FechaCreacion = detalle.FechaCreacion,
                    UsuarioCreacion = detalle.UsuarioCreacion,
                    FechaModificacion = detalle.FechaModificacion,
                    UsuarioModificacion = detalle.UsuarioModificacion
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<ProyectoDetalleDto> CrearProyectoDetalle(ProyectoDetalleDto proyectoDetalleDto)
        {
            var nuevoDetalle = new ProyectoDetalle
            {
                IdProyecto = proyectoDetalleDto.IdProyecto,
                IdRecurso = proyectoDetalleDto.IdRecurso,
                IdLider = proyectoDetalleDto.IdLider,
                CargoRecurso = proyectoDetalleDto.CargoRecurso,
                Estado = proyectoDetalleDto.Estado,
                FechaCreacion = proyectoDetalleDto.FechaCreacion,
                UsuarioCreacion = proyectoDetalleDto.UsuarioCreacion,
                FechaModificacion = proyectoDetalleDto.FechaModificacion,
                UsuarioModificacion = proyectoDetalleDto.UsuarioModificacion
            };

            _context.ProyectoDetalles.Add(nuevoDetalle);
            await _context.SaveChangesAsync();

            return new ProyectoDetalleDto
            {
                IdProyectoDetalle = nuevoDetalle.IdProyectoDetalle,
                IdProyecto = nuevoDetalle.IdProyecto,
                IdRecurso = nuevoDetalle.IdRecurso,
                IdLider = nuevoDetalle.IdLider,
                CargoRecurso = nuevoDetalle.CargoRecurso,
                Estado = nuevoDetalle.Estado,
                FechaCreacion = nuevoDetalle.FechaCreacion,
                UsuarioCreacion = nuevoDetalle.UsuarioCreacion,
                FechaModificacion = nuevoDetalle.FechaModificacion,
                UsuarioModificacion = nuevoDetalle.UsuarioModificacion
            };
        }

        public async Task<bool> ActualizarProyectoDetalle(int idProyectoDetalle, ProyectoDetalleDto proyectoDetalleDto)
        {
            var detalleExistente = await _context.ProyectoDetalles
                .FirstOrDefaultAsync(detalle => detalle.IdProyectoDetalle == idProyectoDetalle);

            if (detalleExistente == null)
            {
                return false;
            }

            detalleExistente.IdProyecto = proyectoDetalleDto.IdProyecto;
            detalleExistente.IdRecurso = proyectoDetalleDto.IdRecurso;
            detalleExistente.IdLider = proyectoDetalleDto.IdLider;
            detalleExistente.CargoRecurso = proyectoDetalleDto.CargoRecurso;
            detalleExistente.Estado = proyectoDetalleDto.Estado;
            detalleExistente.FechaCreacion = proyectoDetalleDto.FechaCreacion;
            detalleExistente.UsuarioCreacion = proyectoDetalleDto.UsuarioCreacion;
            detalleExistente.FechaModificacion = proyectoDetalleDto.FechaModificacion;
            detalleExistente.UsuarioModificacion = proyectoDetalleDto.UsuarioModificacion;

            _context.ProyectoDetalles.Update(detalleExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarProyectoDetalle(int idProyectoDetalle)
        {
            var detalleExistente = await _context.ProyectoDetalles
                .FirstOrDefaultAsync(detalle => detalle.IdProyectoDetalle == idProyectoDetalle);

            if (detalleExistente == null)
            {
                return false;
            }

            _context.ProyectoDetalles.Remove(detalleExistente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
