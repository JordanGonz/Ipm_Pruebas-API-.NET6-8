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

public class FeedbackProgresoHistoricoRepository : IFeedbackProgresoHistoricoRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FeedbackProgresoHistoricoRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> CreearFeedbackProgresoHistoricoAsync(FeedbackProgresoHistorico fedBack)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.FeedbackProgresoHistoricos.Add(fedBack);

        fedBack.UsuarioCreacion = (userName);
        fedBack.Fechacreacion = DateTime.Now;
        int result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> EditarFeedbackProgresoHistoricoAsync(FeedBackEditar feedBack)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacionExistente = await _context.FeedbackProgresoHistoricos
        .FirstOrDefaultAsync(a => a.IdFeedbackProgresoHistoricoPerfiles == feedBack.IdFeedBack);
        if (asignacionExistente == null)
        {
            // Log o manejo de la situación donde no se encuentra la asignación
            return false;
        }

        asignacionExistente.UsuarioModificacion = (userName);
        asignacionExistente.FechaModificacion = DateTime.Now;
        asignacionExistente.IdPersona = feedBack.IdPersona;
        asignacionExistente.Entrevistas = feedBack.Entrevistas;
        asignacionExistente.Observaciones = feedBack.Observaciones;
        asignacionExistente.Alertas = feedBack.Alertas;
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> EliminarFeedbackProgresoHistoricoAsync(int id)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacion = await _context.FeedbackProgresoHistoricos.FindAsync(id);
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
