using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _cliente;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository cliente, IMapper mapper)
        {
            _cliente = cliente;
            _mapper = mapper;

        }
        public async Task<List<ConsultaCliente>> ObtenerTodosLosClienteAsync()
        {
            try
            {
                var cliente = await _cliente.ObtenerTodosLosClienteAsync();
                return _mapper.Map<List<ConsultaCliente>>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos dl listado.", ex);
            }
        }

        public async Task<ConsultaCliente> ObtenerClientePorIdAsync(int clienteId)
        {
            var cliente = await _cliente.ObtenerClientePorIdAsync(clienteId);
            return _mapper.Map<ConsultaCliente>(cliente);
        }


        public async Task<bool> CrearClienteAsync(ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                // Manejar la situación en la que los datos son nulos
                return false;
            }

            var asignacion = _mapper.Map<Cliente>(clienteDto);
            asignacion.Estado = IPMConstants.ESTADO_ACTIVO;

            return await _cliente.CrearClienteAsync(asignacion);
        }

        public async Task<bool> ActualizarClienteAsync(int clienteId, EditarCliente clienteDto)
        {
            return await _cliente.ActualizarClienteAsync(clienteDto);
        }

        public async Task<bool> EliminarClienteAsync(int clienteId)
        {
            return await _cliente.EliminarClienteAsync(clienteId);
        }


    }
}
