using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services;

public interface IActividadDiariaService
{
    Task<bool> CreateActividadDiariumAsync(ActividadProyectoCreacionDto actividadProyectoCreacionDto);
    Task<List<ActividadDiariaConsulta>> GetActividadDiariaAsync(string Descripcion);
    Task<List<ActividadDiariaPorFecha>> GetActividadDiariaPorFecha(DateTime fechaInicio, DateTime fechaFin, int idUsuario);
    Task<List<ReporteExcelTimeReport>> GetActividadDiariaReporte(DateTime fechaInicio, DateTime fechaFin, int idUsuario);
    Task<List<ActividadDiariaConsulta>> GetActividadDiariaPorUsuario(int usuarioId);
    Task<IEnumerable<ActividadDiariaConsulta>> GetactividadProyectoCatalogodtos();
    Task<bool> ActualizarActividadAsync(int actividadDiariaId, ActividadDiariaDto actividadDiariaDto);
    Task<bool> DeleteA(int id);
    Task<List<ActividadDiariaPorDia>> DividirActividadPorDia(List<ActividadDiariaPorFecha> listaActividadesDiarias);
}