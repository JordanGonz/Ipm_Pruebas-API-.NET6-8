using AutoMapper;
using IPM.Core.Contracts.Services.Reportes;
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
    public class PaginaService : IPaginaService
    {
        private readonly IPaginaRepository _paginaRepository;
        private readonly IMapper _mapper;

        public PaginaService(IPaginaRepository paginaRepository, IMapper mapper)
        {
            _paginaRepository = paginaRepository;
            _mapper = mapper;
        }

        public async Task<List<PaginaDto>> ListaDePaginaPorRol(int rol)
        {
            var pagina = await _paginaRepository.ListaDePaginaPorRol(rol);
            return _mapper.Map<List<PaginaDto>>(pagina);
        }


        public async Task<List<PaginaUsuarioDto>> ListaDePaginaPorUsuario(int usuario)
        {
            var pagina = await _paginaRepository.ListaDePaginaPorRol(usuario);
            return _mapper.Map<List<PaginaUsuarioDto>>(pagina);
        }


    }
}
