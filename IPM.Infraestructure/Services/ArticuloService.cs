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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class ArticuloService : IArticuloService
{
    private readonly IArticuloRepository _articuloRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ArticuloService(IArticuloRepository articuloRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _articuloRepository = articuloRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<ArticuloDto>> ObtenerTodosLosMantenimientoAsync()
    {
        try
        {
            var articulos = await _articuloRepository.ObtenerTodosAsync();
            return _mapper.Map<List<ArticuloDto>>(articulos);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener todos los artículos.", ex);
        }
    }

    public async Task<ArticuloDto> ObtenerMantenimientoPorIdAsync(int idArticulo)
    {
        var articulo = await _articuloRepository.ObtenerPorIdAsync(idArticulo);
        return _mapper.Map<ArticuloDto>(articulo);
    }

    public async Task<bool> CrearMantenimientoAsync(ArticuloCreacionDto articuloDto)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var articulo = _mapper.Map<Articulo>(articuloDto);
        articulo.UsuarioCreacion = (userName);
        articulo.Fechacreacion= DateTime.Now;
        articulo.Estado = IPMConstants.ESTADO_ACTIVO;

        return await _articuloRepository.CrearAsync(articulo);
    }

    public async Task<bool> ActualizarMantenimientoAsync(int idArticulo, ArticuloDto articuloDto)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var articuloExistente = await _articuloRepository.ObtenerPorIdAsync(idArticulo);

        if (articuloExistente == null)
        {
            return false;
        }
        articuloExistente.UsuarioModificacion = (userName);
        articuloExistente.FechaModificacion = DateTime.Now;
        _mapper.Map(articuloDto, articuloExistente);
        await _articuloRepository.ActualizarAsync(articuloExistente);

        return true;
    }

    public async Task<bool> EliminarMantenimientoAsync(int idArticulo)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var articuloExistente = await _articuloRepository.ObtenerPorIdAsync(idArticulo);

        if (articuloExistente == null)
        {
            return false;
        }
        articuloExistente.FechaEliminacion = DateTime.Now;
        articuloExistente.UsuarioEliminacion = (userName);
        articuloExistente.Estado = IPMConstants.ESTADO_INACTIVO;
        return await _articuloRepository.EliminarAsync(idArticulo);
    }
}
