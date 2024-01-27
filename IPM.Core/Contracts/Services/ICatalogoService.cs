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
        Task<List<CatalogoDto>> ObtenerTodosLosCatalogoAsync(string nemonico);
        Task<List<CatalogoMostrarNombre>> ObtenerTodosLosNombresdeSuNemonico();
        Task<CatalogoDto> ObtenerCatalogoPorIdAsync(int idCatalogo);
        Task<bool> CrearCatalogoAsync(CatalogoCreacionDTO catalogoCreacionDTO);
        Task<bool> ActualizarCatalogoAsync(int catalogoId, CatalogoDto catalogoDto);
        Task<bool> EliminarCatalogoAsync(int catalogoId);
    }
}
