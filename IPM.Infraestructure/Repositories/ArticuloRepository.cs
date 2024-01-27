using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class ArticuloRepository : IArticuloRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ArticuloRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Articulo>> ObtenerTodosAsync()
    {
        return await _context.Articulos
         .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
         .ToListAsync();
    }

    public async Task<Articulo> ObtenerPorIdAsync(int idArticulo)
    {
        return await _context.Articulos.FirstOrDefaultAsync(a => a.IdArticulo == idArticulo && a.Estado == IPMConstants.ESTADO_ACTIVO);
    }

    public async Task<bool> CrearAsync(Articulo articulo)
    {
        _context.Articulos.Add(articulo);
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ActualizarAsync(Articulo articulo)
    {
        _context.Entry(articulo).State = EntityState.Modified;
        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }

    public async Task<bool> EliminarAsync(int idArticulo)
    {
        var articulo = await _context.Articulos.FindAsync(idArticulo);

        if (articulo == null)
        {
            return false;
        }

        
        articulo.Estado = IPMConstants.ESTADO_INACTIVO;

        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }
}
