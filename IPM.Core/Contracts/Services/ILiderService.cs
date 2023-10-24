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
        Task<List<LiderDto>> ObtenerTodosLosLiderAsync();
        Task<LiderDto> ObteneLiderPorIdAsync(int liderId);
        Task<LiderDto> CrearLiderAsync(LiderDto liderDto);
        Task<bool> ActualizaLiderAsync(int liderId, LiderDto liderDto);
        Task<bool> EliminarLiderAsync(int liderId);
    }
}