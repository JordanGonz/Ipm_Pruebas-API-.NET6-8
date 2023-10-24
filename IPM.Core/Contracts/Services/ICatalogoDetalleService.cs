using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface ICatalogoDetalleService
    {
        Task<List<CatalogoDetalleDto>> ObtenerTodosLosCatalogoDetalleAsync();
        Task<CatalogoDetalleDto> ObteneCatalogoDetallePorIdAsync(int catalogoDetlleId);
        Task<CatalogoDetalleDto> CrearCatalogoDetalleAsync(CatalogoDetalleDto catalogoDetalleDto);
        Task<bool> ActualizaCatalogoDetalleAsync(int catalogoDetelleId, CatalogoDetalleDto catalogoDetalleDto);
        Task<bool> EliminarCatalogoDetalleAsync(int catalogoDetalleId);
    }
}