using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class EquipoRepository : IEquipoRepostirory
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EquipoRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Equipo>> ObtenerTodosAsync()
    {
        return await _context.Equipos
             .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
            .ToListAsync();
    }

    public async Task<List<Equipo>> ObtenerTodosSistemaOperativosAsync(string SistemaOperativo)
    {
        return await _context.Equipos
            .Where(s => s.SistemaOperativo == SistemaOperativo && s.Estado == IPMConstants.ESTADO_ACTIVO)
            .ToListAsync();
    }

    public async Task<Equipo> ObtenerPorIdAsync(int idEquipo)
    {
        return await _context.Equipos.FirstOrDefaultAsync(e => e.IdEquipo == idEquipo && e.Estado == IPMConstants.ESTADO_ACTIVO);
    }

    public async Task<bool> CrearAsync(Equipo equipo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Equipos.Add(equipo);
        equipo.UsuarioCreacion = (userName);
        equipo.Fechacreacion= DateTime.Now;
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ActualizarAsync(Equipo equipo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Entry(equipo).State = EntityState.Modified;
        equipo.UsuarioModificacion= (userName);
        equipo.FechaModificacion= DateTime.Now;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }

    public async Task<bool> EliminarAsync(int idEquipo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var equipo = await _context.Equipos.FindAsync(idEquipo);

        if (equipo == null)
        {
            return false;
        }
        equipo.UsuarioEliminacion= (userName);
        equipo.FechaEliminacion = DateTime.Now;
        equipo.Estado = IPMConstants.ESTADO_INACTIVO;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }
}
