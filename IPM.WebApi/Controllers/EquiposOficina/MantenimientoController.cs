using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IPM.WebApi.Controllers;

[Route("api/mantenimiento")]
[ApiController]
[Authorize]
public class MantenimientoController : BaseApiController<MantenimientoController>
{
    private readonly IMantenimientoService _mantenimientoService;

    public MantenimientoController(IMantenimientoService mantenimientoService)
    {
        _mantenimientoService = mantenimientoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<MantenimientoDto>>(true, "OK");
        try
        {
            response.Data = await _mantenimientoService.ObtenerTodosLosMantenimientoAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Mantenimientos.", null));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var response = new Response<List<MantenimientoDto>>(true, "OK");
        try
        {
            var mantenimiento = await _mantenimientoService.ObtenerMantenimientoPorIdAsync(id);
            if (mantenimiento == null)
            {
                return NotFound(new ErrorResponse<MantenimientoDto>
                {
                    Success = false,
                    Message = "Datos de Mantenimiento no proporcionados."
                });
            }
            return Ok(new SuccessResponse<MantenimientoDto>
            {
                Success = true,
                Message = "OK",
                Data = mantenimiento
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<MantenimientoDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Mantenimiento por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] MantenimientoCreacionDto mantenimientoDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (mantenimientoDto == null)
            {
                response.Update(false, "Datos de Mantenimiento no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _mantenimientoService.CrearMantenimientoAsync(mantenimientoDto);

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
    public async Task<IActionResult> Actualizar(int id, [FromBody] MantenimientoDto mantenimientoDto)
    {
        var response = new Response<List<MantenimientoDto>>(true, "OK");
        try
        {
            var mantenimientoExistente = await _mantenimientoService.ObtenerMantenimientoPorIdAsync(id);
            if (mantenimientoExistente == null)
            {
                response.Update(false, "Datos de Mantenimiento no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _mantenimientoService.ActualizarMantenimientoAsync(id, mantenimientoDto);
            response.Message = response.Success ? "Mantenimiento actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el Mantenimiento con id {id}";
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
        var response = new Response<List<MantenimientoDto>>(true, "OK");
        try
        {
            var mantenimientoExistente = await _mantenimientoService.ObtenerMantenimientoPorIdAsync(id);
            if (mantenimientoExistente == null)
            {
                response.Update(false, "Datos de Mantenimiento no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _mantenimientoService.EliminarMantenimientoAsync(id);
            response.Message = response.Success ? "Mantenimiento borrado con éxito"
                : $"Lo sentimos, no se pudo borrar el Mantenimiento con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Eliminar.", null));
        }
    }
}
