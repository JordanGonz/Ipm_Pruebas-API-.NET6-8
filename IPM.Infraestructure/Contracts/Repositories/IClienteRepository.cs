using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosLosClienteAsync();
        Task<Cliente> ObtenerClientePorIdAsync(int clienteId);
        Task<bool> CrearClienteAsync(Cliente clienteDto);
        Task<bool> ActualizarClienteAsync(EditarCliente clienteDto);
        Task<bool> EliminarClienteAsync(int clienteId);
    }
}
