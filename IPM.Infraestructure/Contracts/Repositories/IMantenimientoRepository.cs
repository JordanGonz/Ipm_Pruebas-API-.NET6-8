using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public  interface IMantenimientoRepository
    {
        Task<List<Mantenimiento>> ObtenerTodosAsync();
        Task<Mantenimiento> ObtenerPorIdAsync(int IdMantenimiento);
        Task<bool> CrearAsync(Mantenimiento mantenimiento);
        Task<bool> ActualizarAsync(Mantenimiento mantenimiento);
        Task<bool> EliminarAsync(int IdMantenimiento);

    }
}
