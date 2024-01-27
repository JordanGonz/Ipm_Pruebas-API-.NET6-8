using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace IPM.Infraestructure.Repositories
{
    public class AsignacionArticuloRepository : IAsignacionArticuloRepository
    {
        private readonly IntegrityProjectManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AsignacionArticuloRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AsignacionArticulo>> ObtenerTodosLosArticulosAsignadosAsync()
        {
            return await _context.AsignacionArticulos
                 .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .ToListAsync();
        }


        public async Task<bool> CrearAsignacionArticuloAsync(AsignacionArticulo asignacionArticulo)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;

            _context.AsignacionArticulos.Add(asignacionArticulo);

            asignacionArticulo.UsuarioModificacion = (userName);
            asignacionArticulo.Fechacreacion = DateTime.Now;
            int result = await _context.SaveChangesAsync();       
            return result > 0;
        }

        public async Task<bool> ActualizarAsignacionArticuloAsync(AsignacionActualizarArticuloDto asignacionArticuloActualizar)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var entidadExistente = await _context.AsignacionArticulos

            .FirstOrDefaultAsync(a => a.IdAsignacionArticulo == asignacionArticuloActualizar.IdAsignacionArticulo);

            if (entidadExistente == null)
            {
                return false;
            }

            // Actualizar solo las propiedades específicasentidadExistente.IdAsignacion = asignacionArticuloActualizar.IdAsignacion;
            entidadExistente.IdArticulo = asignacionArticuloActualizar.IdArticulo;
            entidadExistente.UsuarioModificacion = (userName);
            entidadExistente.FechaModificacion= DateTime.Now;
 

            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> EliminarAsignacionArticuloAsync(int idAsignacionArticulo)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var asignacion = await _context.AsignacionArticulos.FindAsync(idAsignacionArticulo);
            if (asignacion is null)
            {
                return false;
            }

            asignacion.UsuarioEliminacion = (userName);
            asignacion.FechaEliminacion= DateTime.Now;
            asignacion.Estado = IPMConstants.ESTADO_INACTIVO;
            int filasAfectadas = await _context.SaveChangesAsync();

            return filasAfectadas > 0;
        }
    }
}
