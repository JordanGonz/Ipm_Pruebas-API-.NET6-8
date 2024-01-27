using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class MantenimientoRepository : IMantenimientoRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public MantenimientoRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Mantenimiento>> ObtenerTodosAsync()
    {
        return await _context.Mantenimientos
            .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
            .ToListAsync();
    }

    public async Task<Mantenimiento> ObtenerPorIdAsync(int idMantenimiento)
    {
        return await _context.Mantenimientos.FirstOrDefaultAsync(m => m.IdMantenimiento == idMantenimiento && m.Estado == IPMConstants.ESTADO_ACTIVO);
    }

    public async Task<bool> CrearAsync(Mantenimiento mantenimiento)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Mantenimientos.Add(mantenimiento);
        mantenimiento.UsuarioCreacion = (userName);
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ActualizarAsync(Mantenimiento mantenimiento)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Entry(mantenimiento).State = EntityState.Modified;
        mantenimiento.UsuarioModificacion= (userName);
        mantenimiento.FechaModificacion=DateTime.Now;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }

    public async Task<bool> EliminarAsync(int idMantenimiento)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var mantenimiento = await _context.Mantenimientos.FindAsync(idMantenimiento);

        if (mantenimiento == null)
        {
            return false;
        }
        mantenimiento.UsuarioEliminacion= (userName);
        mantenimiento.FechaEliminacion= DateTime.Now;
        mantenimiento.Estado = IPMConstants.ESTADO_INACTIVO;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }
}
