using AutoMapper;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using IPM.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Services;

public class CursosTomadosIscService : ICursosTomadosIscService
{

    private readonly ICursosTomadosIscRepository _cursosTomadosIscRepository;
    private readonly IMapper _mapper;


    public CursosTomadosIscService (ICursosTomadosIscRepository cursosTomadosIscRepository, IMapper mapper)
    {
        _cursosTomadosIscRepository = cursosTomadosIscRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateCursosTomadosAsync(CursosTomadosIscDto cursosTomados)
    {
        if (cursosTomados == null)
        {
            // Manejar la situación en la que los datos son nulos
            return false;
        }

        var asignacion = _mapper.Map<CursosTomado>(cursosTomados);
        asignacion.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _cursosTomadosIscRepository.CreateCursosTomadosAsync(asignacion);
    }

    public async Task<bool> EditCursosTomadosAsync(int idCurso,CursosTomadosEdit cursosTomados)
    {
        return await _cursosTomadosIscRepository.EditCursosTomadosAsync(cursosTomados);
    }

    public async Task<bool> DeleteCursosTomadosAsync(int id)
    {
        return await _cursosTomadosIscRepository.DeleteCursosTomadosAsync(id);
    }

}
