using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface ILiderRepository
    {
        Task<List<ObtenerLider>> ObtenerTodosLosLiderAsync();
        Task<ObtenerLider> ObtenerLiderPorIdAsync(int liderDto);
        Task<bool> CrearLiderAsync(Lidere liderDto);
        Task<bool> ActualizarLiderAsync( EditarLider liderDto);
        Task<bool> EliminarLiderAsync(int liderDto);
    }
}
