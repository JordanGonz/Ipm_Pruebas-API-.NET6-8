using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IActividadDiariaRepository
    {
        Task<bool> AddAsync(ActividadDiariaTimeReport actividadDiarium);
        Task<List<ActividadDiariaConsulta>> GetActProyAsync(string Descripcion);
        Task<List<ActividadDiariaPorFecha>> GetActividadesPorFecha(DateTime Fecha, DateTime FechaFin, int idUsuario);
        Task<List<ReporteExcelTimeReport>> GetActividadesReporte(DateTime Fecha, DateTime FechaFin, int idUsuario);
        Task<List<ActividadDiariaConsulta>> GetActProyAsync(int usuarioId);
        Task<IEnumerable<ActividadDiariaConsulta>> GetActProyAsyncs();
        Task<bool> ActualizarAsync(ActividadDiariaDto actividadProyectoDto);
        Task<bool> DeleteActi(int id);
    }
}