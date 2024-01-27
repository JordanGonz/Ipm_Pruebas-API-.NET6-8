using IPM.Core.Constants;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using IPM.Core.Dtos;

public class CatalogoRepository : ICatalogoRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CatalogoRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Catalogo>> ObtenerTodosAsync(string nemonico )
    {
        return await _context.Catalogos
            .Where(c => c.Nemonico == nemonico && c.Estado == IPMConstants.ESTADO_ACTIVO)
            .ToListAsync();
    }
    public async Task<List<CatalogoMostrarNombre>> ObtenerTodosLosNombresAsync()
    {
        return await _context.Catalogos
        .Select(c => new CatalogoMostrarNombre
        {
            Nemonico = c.Nemonico,
            NombreMostrar = c.NombreMostrar
        })
        .Distinct()
        .ToListAsync();
    }

    public async Task<Catalogo> ObtenerPorIdAsync(int catalogoId)
    {
        var catalogo = await _context.Catalogos.FirstOrDefaultAsync(c => c.IdCatalogo == catalogoId && c.Estado == IPMConstants.ESTADO_ACTIVO);
        return catalogo;
    }

    public async Task<bool> CrearAsync(Catalogo catalogoCreacionDTO)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Catalogos.Add(catalogoCreacionDTO);
        catalogoCreacionDTO.UsuarioCreacion = (userName);
        catalogoCreacionDTO.FechaCreacion= DateTime.Now;
        int result = await _context.SaveChangesAsync();

        return result > 0;
    }


    public async Task<bool> ActualizarAsync(Catalogo catalogo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Entry(catalogo).State = EntityState.Modified;
        catalogo.UsuarioModificacion = (userName);
        catalogo.FechaModificacion= DateTime.Now;
       int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }

    public async Task<bool> EliminarAsync(int catalogoId)
    {
        var catalogo = await _context.Catalogos.FindAsync(catalogoId);

        if(catalogo == null)
        {
            return false;

        }
        
        catalogo.Estado = IPMConstants.ESTADO_INACTIVO;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
       
    }
}