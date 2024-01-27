using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IAsignacionArticuloService
    {
        Task<List<AsignacionConsultaArticuloDto>> ObtenerTodosLosArticulosAsignadosAsync();
        Task<bool> CrearAsignacionArticuloAsync(AsignacionArticuloDto asignacionArticuloCrearDto);
        Task<bool> ActualizarAsignacionArticuloAsync(int idAsignacionArticulo, AsignacionActualizarArticuloDto asignacionArticuloActualizarDto);
        Task<bool> EliminarAsignacionArticuloAsync(int idAsignacionArticulo);
    }
}
