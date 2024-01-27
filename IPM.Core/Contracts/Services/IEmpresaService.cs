using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDto>> ObtenerTodasLasEmpresaAsync();
        Task<EmpresaDto> ObtenerEmpresaPorIdAsync(int empresaId);
        Task<EmpresaDto> CrearEmpresaAsync(EmpresaDto empresaDto);
        Task<bool> ActualizarEmpresaAsync(int empresaId, EmpresaDto empresaDto);
        Task<bool> EliminarEmpresaAsync(int empresaId);
    }
}
