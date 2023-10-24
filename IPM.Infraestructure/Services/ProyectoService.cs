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
    public class ProyectoService : IProyectoService
    {
        private readonly IntegrityProjectManagementContext _context;

        public ProyectoService(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<List<ProyectoDto>> ObtenerTodosLosProyectos()
        {
            var proyectos = await _context.Proyectos.ToListAsync();
            var proyectosDto = proyectos.Select(proyecto => new ProyectoDto
            {
                IdProyecto = proyecto.IdProyecto,
                IdCliente = proyecto.IdCliente,
                IdLiderPrincipal = proyecto.IdLiderPrincipal,
                CodigoProyecto = proyecto.CodigoProyecto,
                Descripcion = proyecto.Descripcion,
                FechaInicio = proyecto.FechaInicio,
                FechaFin = proyecto.FechaFin,
                Estado = proyecto.Estado,
                FechaCreacion = proyecto.FechaCreacion,
                UsuarioCreacion = proyecto.UsuarioCreacion,
                FechaModificacion = proyecto.FechaModificacion,
                UsuarioModificacion = proyecto.UsuarioModificacion
            }).ToList();
            return proyectosDto;
        }

        public async Task<ProyectoDto> ObtenerProyectoPorId(int idProyecto)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(p => p.IdProyecto == idProyecto);
            if (proyecto != null)
            {
                return new ProyectoDto
                {
                    IdProyecto = proyecto.IdProyecto,
                    IdCliente = proyecto.IdCliente,
                    IdLiderPrincipal = proyecto.IdLiderPrincipal,
                    CodigoProyecto = proyecto.CodigoProyecto,
                    Descripcion = proyecto.Descripcion,
                    FechaInicio = proyecto.FechaInicio,
                    FechaFin = proyecto.FechaFin,
                    Estado = proyecto.Estado,
                    FechaCreacion = proyecto.FechaCreacion,
                    UsuarioCreacion = proyecto.UsuarioCreacion,
                    FechaModificacion = proyecto.FechaModificacion,
                    UsuarioModificacion = proyecto.UsuarioModificacion
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<ProyectoDto> CrearProyecto(ProyectoDto proyectoDto)
        {
            var nuevoProyecto = new Proyecto
            {
                IdCliente = proyectoDto.IdCliente,
                IdLiderPrincipal = proyectoDto.IdLiderPrincipal,
                CodigoProyecto = proyectoDto.CodigoProyecto,
                Descripcion = proyectoDto.Descripcion,
                FechaInicio = proyectoDto.FechaInicio,
                FechaFin = proyectoDto.FechaFin,
                Estado = proyectoDto.Estado,
                FechaCreacion = proyectoDto.FechaCreacion,
                UsuarioCreacion = proyectoDto.UsuarioCreacion,
                FechaModificacion = proyectoDto.FechaModificacion,
                UsuarioModificacion = proyectoDto.UsuarioModificacion
            };

            _context.Proyectos.Add(nuevoProyecto);
            await _context.SaveChangesAsync();

            return new ProyectoDto
            {
                IdProyecto = nuevoProyecto.IdProyecto,
                IdCliente = nuevoProyecto.IdCliente,
                IdLiderPrincipal = nuevoProyecto.IdLiderPrincipal,
                CodigoProyecto = nuevoProyecto.CodigoProyecto,
                Descripcion = nuevoProyecto.Descripcion,
                FechaInicio = nuevoProyecto.FechaInicio,
                FechaFin = nuevoProyecto.FechaFin,
                Estado = nuevoProyecto.Estado,
                FechaCreacion = nuevoProyecto.FechaCreacion,
                UsuarioCreacion = nuevoProyecto.UsuarioCreacion,
                FechaModificacion = nuevoProyecto.FechaModificacion,
                UsuarioModificacion = nuevoProyecto.UsuarioModificacion
            };
        }

        public async Task<bool> ActualizarProyecto(int idProyecto, ProyectoDto proyectoDto)
        {
            var proyectoExistente = await _context.Proyectos.FirstOrDefaultAsync(p => p.IdProyecto == idProyecto);

            if (proyectoExistente == null)
            {
                return false;
            }

            proyectoExistente.IdCliente = proyectoDto.IdCliente;
            proyectoExistente.IdLiderPrincipal = proyectoDto.IdLiderPrincipal;
            proyectoExistente.CodigoProyecto = proyectoDto.CodigoProyecto;
            proyectoExistente.Descripcion = proyectoDto.Descripcion;
            proyectoExistente.FechaInicio = proyectoDto.FechaInicio;
            proyectoExistente.FechaFin = proyectoDto.FechaFin;
            proyectoExistente.Estado = proyectoDto.Estado;
            proyectoExistente.FechaCreacion = proyectoDto.FechaCreacion;
            proyectoExistente.UsuarioCreacion = proyectoDto.UsuarioCreacion;
            proyectoExistente.FechaModificacion = proyectoDto.FechaModificacion;
            proyectoExistente.UsuarioModificacion = proyectoDto.UsuarioModificacion;

            _context.Proyectos.Update(proyectoExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarProyecto(int idProyecto)
        {
            var proyectoExistente = await _context.Proyectos.FirstOrDefaultAsync(p => p.IdProyecto == idProyecto);

            if (proyectoExistente == null)
            {
                return false;
            }

            _context.Proyectos.Remove(proyectoExistente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
