using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IPM.Infraestructure.Repositories;

public class CursosTomadosIscRepository: ICursosTomadosIscRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CursosTomadosIscRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> CreateCursosTomadosAsync(CursosTomado cursosTomados)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.CursosTomados.Add(cursosTomados);
        var porcentaje = (cursosTomados.HoraCursoAvance / cursosTomados.HorasCurso) * 100;
        string resultado = $"{porcentaje:F0}%";
        if (porcentaje > 100)
        {
            throw new Exception("el avance no puede ser mayor a las horas totales");
        }
        cursosTomados.UsuarioCreacion = (userName);
        cursosTomados.HoraCursoAvance = 0;
        cursosTomados.ProgresoPorcentaje = resultado;
        cursosTomados.Fechacreacion = DateTime.Now;
        int result = await _context.SaveChangesAsync();

        return result > 0;
       
    }


    public async Task<bool> EditCursosTomadosAsync(CursosTomadosEdit cursosTomados)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacionExistente = await _context.CursosTomados
        .FirstOrDefaultAsync(a => a.IdCursosTomadosPerfiles == cursosTomados.IdCurso);
        if (asignacionExistente == null)
        {
            // Log o manejo de la situación donde no se encuentra la asignación
            return false;
        }
        var porcentaje = (cursosTomados.HoraCursoAvance / cursosTomados.Hora) * 100;

        string resultado = $"{porcentaje:F0}%";

        if (porcentaje > 100)
        {
            throw new Exception("el avance no puede ser mayor a las horas totales");
        }

        asignacionExistente.UsuarioModificacion = (userName);
        asignacionExistente.FechaModificacion = DateTime.Now;
        asignacionExistente.NombreCurso = cursosTomados.Curso;
        asignacionExistente.HorasCurso = cursosTomados.Hora;
        asignacionExistente.ProgresoPorcentaje = resultado;
        asignacionExistente.HoraCursoAvance = cursosTomados.HoraCursoAvance;
        asignacionExistente.IdPersona = cursosTomados.IdPersona;
        asignacionExistente.FechaDesde = cursosTomados.FechaDesde;
        asignacionExistente.FechaHasta = cursosTomados.FechaHasta;
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }


    public async Task<bool> DeleteCursosTomadosAsync(int id)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacion = await _context.CursosTomados.FindAsync(id);
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
