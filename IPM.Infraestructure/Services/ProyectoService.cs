using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace IPM.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IntegrityProjectManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProyectoService(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ProyectoDto>> ObtenerTodosLosProyectos()
        {
            var proyectos = await _context.Proyectos.ToListAsync();
            var proyectosDto = proyectos
                .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .Select(proyecto => new ProyectoDto
            {
                IdProyecto = proyecto.IdProyecto,
                IdCliente = proyecto.IdCliente,
                IdLiderPrincipal = proyecto.IdLiderPrincipal,
                CodigoProyecto = proyecto.CodigoProyecto,
                Descripcion = proyecto.Descripcion,
                FechaInicio = proyecto.FechaInicio,
                FechaFin = proyecto.FechaFin,

            }).ToList();
            return proyectosDto;
        }
     


        public async Task<List<ProyectoCatalogoDto>> ObtenerTodosLosProyectosConCatalogos(int idPersona)
        {
            return await _context.PersonaProyectosAsignacions
                .Include(x => x.Proyecto)
                .Where(p => p.PersonaId == idPersona && p.Estado == IPMConstants.ESTADO_ACTIVO)
                .Select(proyecto => new ProyectoCatalogoDto
                {
                    IdProyecto = proyecto.ProyectoId,
                    Descripcion = proyecto.Proyecto.CodigoProyecto + " - " + proyecto.Proyecto.Descripcion
                }).ToListAsync();
        }


        public async Task<ProyectoDto> ObtenerProyectoPorId(int idProyecto)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(p => p.IdProyecto == idProyecto && p.Estado == IPMConstants.ESTADO_ACTIVO);
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
                  
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CrearProyecto(ProyectoCreacionDto proyectoDto)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var nuevoProyecto = new Proyecto
            {
                IdCliente = proyectoDto.IdCliente,
                IdLiderPrincipal = proyectoDto.IdLiderPrincipal,
                CodigoProyecto = proyectoDto.CodigoProyecto,
                Descripcion = proyectoDto.Descripcion,        
                UsuarioCreacion = (userName),
                FechaInicio = proyectoDto.FechaInicio,
                FechaFin = proyectoDto.FechaFin,
                FechaCreacion = DateTime.Now,
                Estado = IPMConstants.ESTADO_ACTIVO
        };
           
            _context.Proyectos.Add(nuevoProyecto);
            int resp =await _context.SaveChangesAsync();

            return resp > 0;
            
        }

        public async Task<bool> ActualizarProyecto(int idProyecto, ProyectoDto proyectoDto)
        {
            var proyectoExistente = await _context.Proyectos.FirstOrDefaultAsync(p => p.IdProyecto == idProyecto);
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
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
           
            proyectoExistente.FechaModificacion = DateTime.Now;
            proyectoExistente.UsuarioModificacion = (userName);
           

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

            proyectoExistente.Estado = IPMConstants.ESTADO_INACTIVO;
            int filasAfectadas= await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }
    }
}
