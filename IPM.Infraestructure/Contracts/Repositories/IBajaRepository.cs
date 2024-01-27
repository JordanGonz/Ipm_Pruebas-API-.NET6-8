using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IBajaRepository
    {
        Task<List<BajaEquipo>> ObtenerTodosAsync();
        Task<BajaEquipo> ObtenerPorIdAsync(int idBajaEquipo);
        Task<bool> CrearAsync(BajaEquipo bajaequipo);
        Task<bool> ActualizarAsync(BajaEquipo bajaequipo);
        Task<bool> EliminarAsync(int idBajaEquipo);
    }
}
