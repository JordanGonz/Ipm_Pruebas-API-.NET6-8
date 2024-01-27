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
    public class LiderService : ILiderService
    {
        private readonly ILiderRepository _liderRepository;
        private readonly IMapper _mapper;
        public LiderService(ILiderRepository liderRepository, IMapper mappers) 
        {
            _liderRepository = liderRepository;
            _mapper = mappers;
        }

        public async Task<List<ObtenerLider>> ObtenerTodosLosLiderAsync()
        {
            try
            {
                var lider = await _liderRepository.ObtenerTodosLosLiderAsync();
                return _mapper.Map<List<ObtenerLider>>(lider);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos dl listado.", ex);
            }
        }

        public async Task<ObtenerLider> ObtenerLiderPorIdAsync(int liderDto)
        {
            var lider = await _liderRepository.ObtenerLiderPorIdAsync(liderDto);
            return _mapper.Map<ObtenerLider>(lider);
        }


        public async Task<bool> CrearLiderAsync(LiderDto liderDto)
        {
            if (liderDto == null)
            {
                // Manejar la situación en la que los datos son nulos
                return false;
            }

            var lider = _mapper.Map<Lidere>(liderDto);
            lider.Estado = IPMConstants.ESTADO_ACTIVO;

            return await _liderRepository.CrearLiderAsync(lider);
        }

        public async Task<bool> ActualizarLiderAsync(int liderId, EditarLider liderDto)
        {
            return await _liderRepository.ActualizarLiderAsync(liderDto);
        }

        public async Task<bool> EliminarLiderAsync(int liderDto)
        {
            return await _liderRepository.EliminarLiderAsync(liderDto);
        }


    }
}
