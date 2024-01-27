using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IArticuloService
    {

        Task<List<ArticuloDto>> ObtenerTodosLosMantenimientoAsync();
        Task<ArticuloDto> ObtenerMantenimientoPorIdAsync(int IdArticulo);
        Task<bool> CrearMantenimientoAsync(ArticuloCreacionDto articuloDto);
        Task<bool> ActualizarMantenimientoAsync(int IdArticulo, ArticuloDto articuloDto);
        Task<bool> EliminarMantenimientoAsync(int IdArticulo);

    }
}
