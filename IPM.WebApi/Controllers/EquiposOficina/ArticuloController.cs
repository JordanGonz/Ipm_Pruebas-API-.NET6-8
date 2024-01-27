using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/articulo")]
[ApiController]
[Authorize]
public class ArticuloController : BaseApiController<ArticuloController>
{
    private readonly IArticuloService _articuloService;

    public ArticuloController(IArticuloService articuloService)
    {
        _articuloService = articuloService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<ArticuloDto>>(true, "OK");
        try
        {
            response.Data = await _articuloService.ObtenerTodosLosMantenimientoAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Articulos.", null));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var response = new Response<List<ArticuloDto>>(true, "OK");
        try
        {
            var articulo = await _articuloService.ObtenerMantenimientoPorIdAsync(id);
            if (articulo == null)
            {
                return NotFound(new ErrorResponse<ArticuloDto>
                {
                    Success = false,
                    Message = "Datos de Articulo no proporcionados."
                });
            }
            return Ok(new SuccessResponse<ArticuloDto>
            {
                Success = true,
                Message = "OK",
                Data = articulo
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<ArticuloDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Articulo por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] ArticuloCreacionDto articuloDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (articuloDto == null)
            {
                response.Update(false, "Datos de Articulo no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _articuloService.CrearMantenimientoAsync(articuloDto);

            if (!response.Success)
            {
                response.Message = "Lo sentimos, no se pudo Crear.";
                return Conflict(response);
            }

            return Created(nameof(ObtenerPorId), response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo agregar.", null));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ArticuloDto articuloDto)
    {
        var response = new Response<List<ArticuloDto>>(true, "OK");
        try
        {
            var articuloExistente = await _articuloService.ObtenerMantenimientoPorIdAsync(id);
            if (articuloExistente == null)
            {
                response.Update(false, "Datos de Articulo no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _articuloService.ActualizarMantenimientoAsync(id, articuloDto);
            response.Message = response.Success ? "Articulo actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el Articulo con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar.", null));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var response = new Response<List<ArticuloDto>>(true, "OK");
        try
        {
            var articuloExistente = await _articuloService.ObtenerMantenimientoPorIdAsync(id);
            if (articuloExistente == null)
            {
                response.Update(false, "Datos de Articulo no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _articuloService.EliminarMantenimientoAsync(id);
            response.Message = response.Success ? "Articulo borrado con éxito"
                : $"Lo sentimos, no se pudo borrar el Articulo con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Eliminar.", null));
        }
    }
}
