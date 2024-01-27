using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IPM.Infraestructure.Repositories
{
    public class LiderRepository : ILiderRepository
    {
        private readonly IntegrityProjectManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LiderRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ObtenerLider>> ObtenerTodosLosLiderAsync()
        {
            return await _context.Lideres
                .Include(l => l.IdPersonaNavigation) // Incluir la entidad Persona relacionada
                .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .Select(l => new ObtenerLider
                {
                    // Otras propiedades de Lidere que quieras incluir
                    IdLider = l.IdLider,
                    NombreLider = l.IdPersonaNavigation.Nombres + " " + l.IdPersonaNavigation.Apellidos,
                    IdPersona = l.IdPersona,
                    EsLiderIntegritySolutions = l.EsLiderIntegritySolutions
                })
                .ToListAsync();
        }

        public async Task<ObtenerLider> ObtenerLiderPorIdAsync(int liderDto)
        {
            return await _context.Lideres
                .Include(l => l.IdPersonaNavigation) 
                .Where(b => b.IdLider == liderDto && b.Estado == IPMConstants.ESTADO_ACTIVO)
                .Select(l => new ObtenerLider
                {
                    IdLider = l.IdLider,
                    NombreLider = l.IdPersonaNavigation.Nombres + " " + l.IdPersonaNavigation.Apellidos,
                    IdPersona = l.IdPersona,
                    EsLiderIntegritySolutions = l.EsLiderIntegritySolutions
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CrearLiderAsync(Lidere liderDto)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            _context.Lideres.Add(liderDto);

            liderDto.UsuarioCreacion = (userName);
            liderDto.FechaCreacion = DateTime.Now;
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ActualizarLiderAsync( EditarLider liderDto)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var asignacionExistente = await _context.Lideres
            .FirstOrDefaultAsync(a => a.IdLider == liderDto.IdLider);
            if (asignacionExistente == null)
            {
                // Log o manejo de la situación donde no se encuentra la asignación
                return false;
            }

            asignacionExistente.UsuarioModificacion = (userName);
            asignacionExistente.FechaModificacion = DateTime.Now;
            asignacionExistente.IdPersona = liderDto.IdPersona;
            asignacionExistente.EsLiderIntegritySolutions = liderDto.EsLiderIntegritySolutions;

            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EliminarLiderAsync(int liderDto)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var asignacion = await _context.Lideres.FindAsync(liderDto);
            if (asignacion is null)
            {
                return false;
            }
            asignacion.UsuarioEliminacion = (userName);
            asignacion.FechaEliminacion = DateTime.Now;
            asignacion.Estado = IPMConstants.ESTADO_INACTIVO;
            int filasAfectadas = await _context.SaveChangesAsync();

            return filasAfectadas > 0;
        }
    }
}
