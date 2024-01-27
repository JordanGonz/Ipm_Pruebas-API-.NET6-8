using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IPM.Infraestructure.Services;

public class ActividadDiariaService : IActividadDiariaService
{
    private readonly IActividadDiariaRepository _actividadProyectoRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ActividadDiariaService(IActividadDiariaRepository actividadProyectoRepository, IHttpContextAccessor httpContextAccessor)
    {
        _actividadProyectoRepository = actividadProyectoRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> CreateActividadDiariumAsync(ActividadProyectoCreacionDto actividadProyectoCreacionDto)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.PrimarySid)?.Value;
        var idPersonaClaim = _httpContextAccessor.HttpContext?.User.FindFirst(x => x.Type == "IdPersona")?.Value;

        var actividadDiarium = new ActividadDiariaTimeReport
        {
            Descripcion = actividadProyectoCreacionDto.Descripcion,
            Hora = actividadProyectoCreacionDto.Hora,
            IdProyecto = actividadProyectoCreacionDto.IdProyecto,
            IdTipoActividad = actividadProyectoCreacionDto.IdTipoActividad,
            UsuarioId = int.Parse(userIdClaim),
            IdPersona = int.Parse(idPersonaClaim),
            FechaActividad = actividadProyectoCreacionDto.FechaActividad,
            Estado = IPMConstants.ESTADO_ACTIVO
        };

        return await _actividadProyectoRepository.AddAsync(actividadDiarium);
    }

    public async Task<List<ActividadDiariaConsulta>> GetActividadDiariaAsync(string Descripcion)
    {
        return await _actividadProyectoRepository.GetActProyAsync(Descripcion);

    }

    public async Task<List<ActividadDiariaPorFecha>> GetActividadDiariaPorFecha(DateTime fechaInicio, DateTime fechaFin, int UsuarioId)
    {

        var actividades = await _actividadProyectoRepository.GetActividadesPorFecha(fechaInicio, fechaFin, UsuarioId);
        return actividades;
    }


    public async Task<List<ReporteExcelTimeReport>> GetActividadDiariaReporte(DateTime fechaInicio, DateTime fechaFin, int UsuarioId)
    {

        var actividades = await _actividadProyectoRepository.GetActividadesReporte(fechaInicio, fechaFin, UsuarioId);
        return actividades;
    }
    public async Task<List<ActividadDiariaConsulta>> GetActividadDiariaPorUsuario(int usuarioId)
    {
        return await _actividadProyectoRepository.GetActProyAsync(usuarioId);
    }

    public async Task<IEnumerable<ActividadDiariaConsulta>> GetactividadProyectoCatalogodtos()
    {
        return await _actividadProyectoRepository.GetActProyAsyncs();
    }

    public async Task<bool> ActualizarActividadAsync(int actividadDiariaId, ActividadDiariaDto actividadDiariaDto)
    {
        return await _actividadProyectoRepository.ActualizarAsync(actividadDiariaDto);
    }

    public async Task<bool> DeleteA(int id)
    {
        return await _actividadProyectoRepository.DeleteActi(id);
    }
    
    /// <summary>
    /// Agrupa una lista de actividad por día
    /// </summary>
    /// <param name="listaActividadesDiarias"></param>
    /// <returns></returns>
    public async Task<List<ActividadDiariaPorDia>> DividirActividadPorDia(List<ActividadDiariaPorFecha> listaActividadesDiarias)
    {
        if (listaActividadesDiarias == null || !listaActividadesDiarias.Any()) 
            return new List<ActividadDiariaPorDia>();

        var actividadesagrupadasPorFecha = listaActividadesDiarias
         .Where(a => a.FechaActividad.HasValue) // Asegurarse de que la fecha no es nula
         .GroupBy(a => a.FechaActividad.Value.Date) // Agrupar por la parte de la fecha
         .Select(grupo => new ActividadDiariaPorDia
         {
             FechaActividadPorDia = grupo.Key, // Establecer la fecha de la actividad
             ListaActividadDiaria = grupo.ToList() // Todas las actividades de esa fecha en una lista
         })
         .ToList();


        return actividadesagrupadasPorFecha;
    }

}