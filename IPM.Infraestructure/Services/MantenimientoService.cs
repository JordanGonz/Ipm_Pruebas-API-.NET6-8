using AutoMapper;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Constants;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MantenimientoService : IMantenimientoService
{
    private readonly IMantenimientoRepository _mantenimientoRepository;
    private readonly IMapper _mapper;

    public MantenimientoService(IMantenimientoRepository mantenimientoRepository, IMapper mapper)
    {
        _mantenimientoRepository = mantenimientoRepository;
        _mapper = mapper;
    }

    public async Task<List<MantenimientoDto>> ObtenerTodosLosMantenimientoAsync()
    {
        try
        {
            var mantenimientos = await _mantenimientoRepository.ObtenerTodosAsync();
            return _mapper.Map<List<MantenimientoDto>>(mantenimientos);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener todos los mantenimientos.", ex);
        }
    }

    public async Task<MantenimientoDto> ObtenerMantenimientoPorIdAsync(int idMantenimiento)
    {
        var mantenimiento = await _mantenimientoRepository.ObtenerPorIdAsync(idMantenimiento);
        return _mapper.Map<MantenimientoDto>(mantenimiento);
    }

    public async Task<bool> CrearMantenimientoAsync(MantenimientoCreacionDto mantenimientoDto)
    {
        var mantenimiento = _mapper.Map<Mantenimiento>(mantenimientoDto);
        mantenimiento.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _mantenimientoRepository.CrearAsync(mantenimiento);
    }

    public async Task<bool> ActualizarMantenimientoAsync(int idMantenimiento, MantenimientoDto mantenimientoDto)
    {
        var mantenimiento = await _mantenimientoRepository.ObtenerPorIdAsync(idMantenimiento);

        if (mantenimiento == null)
        {
            return false;
        }

        _mapper.Map(mantenimientoDto, mantenimiento);
        await _mantenimientoRepository.ActualizarAsync(mantenimiento);

        return true;
    }

    public async Task<bool> EliminarMantenimientoAsync(int idMantenimiento)
    {
        var mantenimiento = await _mantenimientoRepository.ObtenerPorIdAsync(idMantenimiento);

        if (mantenimiento == null)
        {
            return false;
        }

        mantenimiento.Estado = IPMConstants.ESTADO_INACTIVO;
        return await _mantenimientoRepository.EliminarAsync(idMantenimiento);
    }
}
