using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace IPM.Infrastructure.Services
{
    public class AsignacionArticuloService : IAsignacionArticuloService
    {
        private readonly IAsignacionArticuloRepository _asignacionArticuloRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AsignacionArticuloService(IAsignacionArticuloRepository asignacionArticuloRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _asignacionArticuloRepository = asignacionArticuloRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AsignacionConsultaArticuloDto>> ObtenerTodosLosArticulosAsignadosAsync()
        {
            var asignaciones = await _asignacionArticuloRepository.ObtenerTodosLosArticulosAsignadosAsync();
            return _mapper.Map<List<AsignacionConsultaArticuloDto>>(asignaciones);
        }

        public async Task<bool> CrearAsignacionArticuloAsync(AsignacionArticuloDto asignacionArticuloCrearDto)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
          
            var asignacionArticulo = _mapper.Map<AsignacionArticulo>(asignacionArticuloCrearDto);

            asignacionArticulo.UsuarioCreacion = (userName);
            asignacionArticulo.Fechacreacion= DateTime.Now;
            asignacionArticulo.Estado = IPMConstants.ESTADO_ACTIVO;
           

            return await _asignacionArticuloRepository.CrearAsignacionArticuloAsync(asignacionArticulo);
        }

        public async Task<bool> ActualizarAsignacionArticuloAsync(int idAsignacionArticulo, AsignacionActualizarArticuloDto asignacionArticuloActualizarDto)
        {

            return await _asignacionArticuloRepository.ActualizarAsignacionArticuloAsync(asignacionArticuloActualizarDto);
        }

        public async Task<bool> EliminarAsignacionArticuloAsync(int idAsignacionArticulo)
        {
            return await _asignacionArticuloRepository.EliminarAsignacionArticuloAsync(idAsignacionArticulo);
        }
    }
}
