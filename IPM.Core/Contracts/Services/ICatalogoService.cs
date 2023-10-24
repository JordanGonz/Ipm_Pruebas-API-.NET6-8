using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface ICatalogoService
    {
        Task<List<CatalogoDto>> ObtenerTodosLosCatalogoAsync();
        Task<CatalogoDto> ObteneCatalogoPorIdAsync(int catalogoId);
        Task<CatalogoDto> CrearCatalogoAsync(CatalogoDto catalogoDto);
        Task<bool> ActualizaCatalogoAsync(int catalogoId, CatalogoDto catalogoDto);
        Task<bool> EliminarCatalogoAsync(int catalogoId);
    }
}