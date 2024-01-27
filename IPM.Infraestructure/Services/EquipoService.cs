using AutoMapper;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Constants;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class EquipoService : IEquipoService
{
    private readonly IEquipoRepostirory _equipoRepository;
    private readonly IMapper _mapper;

    public EquipoService(IEquipoRepostirory equipoRepository, IMapper mapper)
    {
        _equipoRepository = equipoRepository;
        _mapper = mapper;
    }

    public async Task<List<EquipoDto>> ObtenerTodosLosEquipoAsync()
    {
        try
        {
            var equipos = await _equipoRepository.ObtenerTodosAsync();
            return _mapper.Map<List<EquipoDto>>(equipos);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener todos los equipos.", ex);
        }
    }

    public async Task<List<EquipoSistemOperativo>> ObtenerTodosLosEquipoSistemaOperativoAsync(string sistemaOperativo)
    {
        var sistemas = await _equipoRepository.ObtenerTodosSistemaOperativosAsync(sistemaOperativo);
        return _mapper.Map<List<EquipoSistemOperativo>>(sistemas);
    }

    public async Task<EquipoDto> ObtenerEquipoPorIdAsync(int idEquipo)
    {
        var equipo = await _equipoRepository.ObtenerPorIdAsync(idEquipo);
        return _mapper.Map<EquipoDto>(equipo);
    }

    public async Task<bool> CrearEquipoAsync(EquipoCreacionDto equipoCreacionDto)
    {
        var nuevoequipo = _mapper.Map<Equipo>(equipoCreacionDto);
        nuevoequipo.Estado = IPMConstants.ESTADO_ACTIVO;
        if (nuevoequipo != null)
        {
            return await _equipoRepository.CrearAsync(nuevoequipo);
        }
        return false;
        
    }

    public async Task<bool> ActualizarEquipoAsync(int idEquipo, EquipoDto equipoDto)
    {
        var equipo = await _equipoRepository.ObtenerPorIdAsync(idEquipo);

        if (equipo == null)
        {
            return false;
        }

        _mapper.Map(equipoDto, equipo);
        await _equipoRepository.ActualizarAsync(equipo);

        return true;
    }

    public async Task<bool> EliminarEquipoAsync(int idEquipo)
    {
        var equipo = await _equipoRepository.ObtenerPorIdAsync(idEquipo);

        if (equipo == null)
        {
            return false;
        }
        equipo.Estado = IPMConstants.ESTADO_INACTIVO;
        return await _equipoRepository.EliminarAsync(idEquipo);
    }
}
