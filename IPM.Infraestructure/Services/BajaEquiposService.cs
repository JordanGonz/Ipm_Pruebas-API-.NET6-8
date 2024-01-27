using AutoMapper;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Constants;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BajaEquiposService : IBajaEquipoService
{
    private readonly IBajaRepository _bajaRepository;
    private readonly IMapper _mapper;

    public BajaEquiposService(IBajaRepository bajaRepository, IMapper mapper)
    {
        _bajaRepository = bajaRepository;
        _mapper = mapper;
    }

    public async Task<List<BajaEquiposDto>> ObtenerTodosBajaEquipoAsync()
    {
        try
        {
            var bajaEquipos = await _bajaRepository.ObtenerTodosAsync();
            return _mapper.Map<List<BajaEquiposDto>>(bajaEquipos);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener todos los equipos de baja.", ex);
        }
    }

    public async Task<BajaEquiposDto> ObtenerBajaEquipoPorIdAsync(int idBajaEquipo)
    {
        var bajaEquipo = await _bajaRepository.ObtenerPorIdAsync(idBajaEquipo);
        return _mapper.Map<BajaEquiposDto>(bajaEquipo);
    }

    public async Task<bool> CrearBajaEquipoAsync(BajaEquiposCreacionDto bajaEquiposCreacionDto)
    {
        var bajaEquipo = _mapper.Map<BajaEquipo>(bajaEquiposCreacionDto);
        bajaEquipo.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _bajaRepository.CrearAsync(bajaEquipo);
    }

    public async Task<bool> ActualizarBajaEquipoAsync(int idBajaEquipo, BajaEquiposDto bajaEquiposDto)
    {
        var bajaEquipo = await _bajaRepository.ObtenerPorIdAsync(idBajaEquipo);

        if (bajaEquipo == null)
        {
            return false;
        }

        _mapper.Map(bajaEquiposDto, bajaEquipo);
        await _bajaRepository.ActualizarAsync(bajaEquipo);

        return true;
    }

    public async Task<bool> EliminarBajaEquipoAsync(int idBajaEquipo)
    {
        var bajaEquipo = await _bajaRepository.ObtenerPorIdAsync(idBajaEquipo);

        if (bajaEquipo == null)
        {
            return false;
        }
        bajaEquipo.Estado = IPMConstants.ESTADO_INACTIVO;
        return await _bajaRepository.EliminarAsync(idBajaEquipo);
    }
}
