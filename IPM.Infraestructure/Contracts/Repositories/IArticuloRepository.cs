using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IArticuloRepository
    {
        Task<List<Articulo>> ObtenerTodosAsync();
        Task<Articulo> ObtenerPorIdAsync(int IdMantenimiento);
        Task<bool> CrearAsync(Articulo articulo);
        Task<bool> ActualizarAsync(Articulo articulo);
        Task<bool> EliminarAsync(int IdMantenimiento);
    }
}
