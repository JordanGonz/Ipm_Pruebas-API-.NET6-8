using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IMantenimientoService
    {

        Task<List<MantenimientoDto>> ObtenerTodosLosMantenimientoAsync();
        Task<MantenimientoDto> ObtenerMantenimientoPorIdAsync(int IdMantenimiento);
        Task<bool> CrearMantenimientoAsync(MantenimientoCreacionDto mantenimientoDto);
        Task<bool> ActualizarMantenimientoAsync(int IdMantenimiento, MantenimientoDto mantenimientoDto);
        Task<bool> EliminarMantenimientoAsync(int IdMantenimiento);
    }
}
