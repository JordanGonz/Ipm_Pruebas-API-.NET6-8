using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IAsignacionArticuloRepository
    {
        Task<List<AsignacionArticulo>> ObtenerTodosLosArticulosAsignadosAsync();
        Task<bool> CrearAsignacionArticuloAsync(AsignacionArticulo asignacionArticulo);
        Task<bool> ActualizarAsignacionArticuloAsync(AsignacionActualizarArticuloDto asignacionArticuloActualizar);
        Task<bool> EliminarAsignacionArticuloAsync(int idAsignacionArticulo);
    }
}
