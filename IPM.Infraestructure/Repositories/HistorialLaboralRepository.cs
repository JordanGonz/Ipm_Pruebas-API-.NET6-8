using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Repositories;

public class HistorialLaboralRepository : IHistorialLaboralRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HistorialLaboralRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> CreearHistoriaLaboralAsync(HistorialLaboral historial)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.HistorialLaborals.Add(historial);

        historial.UsuarioCreacion = (userName);
        historial.Fechacreacion = DateTime.Now;
        int result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> EditarHistoriaLaboralAsync(EditarHistoriaLaboral historial)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacionExistente = await _context.HistorialLaborals
        .FirstOrDefaultAsync(a => a.IdHistorialPerfiles == historial.IdHistorial);
        if (asignacionExistente == null)
        {
            // Log o manejo de la situación donde no se encuentra la asignación
            return false;
        }
        
        asignacionExistente.UsuarioModificacion = (userName);
        asignacionExistente.FechaModificacion = DateTime.Now;
        asignacionExistente.IdPersona = historial.IdPersona;
        asignacionExistente.Empresa = historial.Empresa;
        asignacionExistente.FechaDesde = historial.FechaDesde;
        asignacionExistente.FechaHasta = historial.FechaHasta;
        asignacionExistente.Cargo = historial.Cargo;
        asignacionExistente.DescripcionSalida = historial.DescripcionSalida;
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> EliminarHistoriaLaboralAsync(int id)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacion = await _context.HistorialLaborals.FindAsync(id);
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
