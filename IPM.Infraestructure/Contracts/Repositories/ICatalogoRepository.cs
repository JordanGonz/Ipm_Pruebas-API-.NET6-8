using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface ICatalogoRepository
    {
        Task<List<Catalogo>> ObtenerTodosAsync(string nemonico);
        Task<List<CatalogoMostrarNombre>> ObtenerTodosLosNombresAsync();
        Task<Catalogo> ObtenerPorIdAsync(int idCatalogo);
        Task <bool> CrearAsync(Catalogo catalogoCreacionDTO);
        Task<bool> ActualizarAsync(Catalogo catalogo);
        Task<bool> EliminarAsync(int catalogoId);
        
    }
}
