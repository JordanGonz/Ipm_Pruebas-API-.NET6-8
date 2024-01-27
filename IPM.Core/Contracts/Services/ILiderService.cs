using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface ILiderService
    {
        Task<List<ObtenerLider>> ObtenerTodosLosLiderAsync();
        Task<ObtenerLider> ObtenerLiderPorIdAsync(int liderDto);
        Task<bool> CrearLiderAsync(LiderDto liderDto);
        Task<bool> ActualizarLiderAsync(int liderId, EditarLider liderDto);
        Task<bool> EliminarLiderAsync(int liderDto);
    }
}
