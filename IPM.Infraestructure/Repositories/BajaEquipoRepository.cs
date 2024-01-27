using IPM.Core.Constants;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class BajaEquipoRepository : IBajaRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BajaEquipoRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<BajaEquipo>> ObtenerTodosAsync()
    {
        return await _context.BajaEquipos
             .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
            .ToListAsync();
    }

    public async Task<BajaEquipo> ObtenerPorIdAsync(int idBajaEquipo)
    {
        return await _context.BajaEquipos.FirstOrDefaultAsync(b => b.IdBajaEquipo == idBajaEquipo && b.Estado == IPMConstants.ESTADO_ACTIVO);
        
    }

    public async Task<bool> CrearAsync(BajaEquipo bajaequipo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.BajaEquipos.Add(bajaequipo);

        bajaequipo.UsuarioCreacion = (userName);
        bajaequipo.Fechacreacion= DateTime.Now;
        bajaequipo.Estado = IPMConstants.ESTADO_ACTIVO;
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ActualizarAsync(BajaEquipo bajaequipo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Entry(bajaequipo).State = EntityState.Modified;
        bajaequipo.UsuarioModificacion= (userName);
        bajaequipo.FechaModificacion = DateTime.Now;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }

    public async Task<bool> EliminarAsync(int idBajaEquipo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var bajaequipo = await _context.BajaEquipos.FindAsync(idBajaEquipo);

        if (bajaequipo == null)
        {
            return false;
        }
        bajaequipo.UsuarioEliminacion = (userName);
        bajaequipo.FechaEliminacion= DateTime.Now;
        bajaequipo.Estado = IPMConstants.ESTADO_INACTIVO;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }
}


