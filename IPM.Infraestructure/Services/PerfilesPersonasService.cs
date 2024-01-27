using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Services
{
    public class PerfilesPersonasService : IPerfilesPersonasService
    {
        private readonly IPerfilesPersonasRepository _perfilesRepository;
        private readonly IMapper _mapper;
        public PerfilesPersonasService(IPerfilesPersonasRepository perfilesRepository, IMapper mapper)
        {
            _perfilesRepository = perfilesRepository;
            _mapper = mapper;
        }


        public async Task<InformacionPersonal> ObtenerInformacionPersonalAsync(int id)
        {
            var info = await _perfilesRepository.ObtenerInformacionPersonalAsync(id);
            return _mapper.Map<InformacionPersonal>(info);
        }
        public async Task<List<StackTecnologicoPerfil>> ObtenerListadoStackTecnologicoAsync(int id)
        {
            var info = await _perfilesRepository.ObtenerListadoStackTecnologicoAsync(id);
            return _mapper.Map<List<StackTecnologicoPerfil>>(info);
        }

        public async Task<List<HistorialLaboralPerfil>> ObtenerListadoHistorialLaboralAsync(int id)
        {

            var info = await _perfilesRepository.ObtenerListadoHistorialLaboralAsync(id);
            return _mapper.Map<List<HistorialLaboralPerfil>>(info);
        }


        public async Task<List<CursosTomadosPerfil>> ObtenerListadoCursosTomadosAsync(int id)
        {

            var info = await _perfilesRepository.ObtenerListadoCursosTomadosAsync(id);
            return _mapper.Map<List<CursosTomadosPerfil>>(info);
        }

        public async Task<List<FeedbackProgresoHistoricoPerfil>> ObtenerListadoFeedbackProgresoHistoricoAsync(int id)
        {

            var info = await _perfilesRepository.ObtenerListadoFeedbackProgresoHistoricoAsync(id);
            return _mapper.Map<List<FeedbackProgresoHistoricoPerfil>>(info);
        }
        public async Task<PerfilPersona> ObtenerTodaLaInformacionDePersonaAsync(int id)
        {
            PerfilPersona perfilPersona = new();
            var infopersonal = await ObtenerInformacionPersonalAsync(id);
            var satcktecno = await ObtenerListadoStackTecnologicoAsync(id);
            var historialabor = await ObtenerListadoHistorialLaboralAsync(id);
            var cursostomados = await ObtenerListadoCursosTomadosAsync(id);
            var feedback = await ObtenerListadoFeedbackProgresoHistoricoAsync(id);


            perfilPersona.InformacionPerfil = new Informacion
            {
                InformacionPersonal = infopersonal,
                StackTecnologico = satcktecno,
                HistorialLaboral = historialabor,
                CursosTomados = cursostomados,
                FeedbackProgresoHistorico = feedback
            };


            return perfilPersona;
        }



        public async Task<List<BusquedaDePerfiles>> ObtenerListadoDeBusquedaPerfilAsync(string busqueda)
        {

            var info = await _perfilesRepository.ObtenerListadoDeBusquedaPerfilAsync(busqueda);
            return _mapper.Map<List<BusquedaDePerfiles>>(info);
        }

    }
}
