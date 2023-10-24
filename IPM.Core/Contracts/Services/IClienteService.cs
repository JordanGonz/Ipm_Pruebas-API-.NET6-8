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
        Task<List<ClienteDto>> ObtenerTodosLosClienteAsync();
        Task<ClienteDto> ObteneClientePorIdAsync(int clienteId);
        Task<ClienteDto> CrearClienteAsync(ClienteDto clienteDto);
        Task<bool> ActualizaClienteAsync(int clienteId, ClienteDto clienteDto);
        Task<bool> EliminarClienteAsync(int clienteId);
    }

}