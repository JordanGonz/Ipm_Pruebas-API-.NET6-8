using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IClienteService
    {
        Task<List<ConsultaCliente>> ObtenerTodosLosClienteAsync();
        Task<ConsultaCliente> ObtenerClientePorIdAsync(int clienteId);
        Task<bool> CrearClienteAsync(ClienteDto clienteDto);
        Task<bool> ActualizarClienteAsync(int clienteId, EditarCliente clienteDto);
        Task<bool> EliminarClienteAsync(int clienteId);
    }

}
