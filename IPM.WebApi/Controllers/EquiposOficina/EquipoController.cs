using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/equipo")]
[ApiController]
[Authorize]
public class EquipoController : BaseApiController<EquipoController>
{
    private readonly IEquipoService _equipoService;

    public EquipoController(IEquipoService equipoService)
    {
        _equipoService = equipoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<EquipoDto>>(true, "OK");
        try
        {
            response.Data = await _equipoService.ObtenerTodosLosEquipoAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Equipos.", null));
        }
    }

    [HttpGet("obtener-equipos-sistema-operativo")]
    public async Task<IActionResult> ObtenerTodosLosCatalogos(string sistemaOperativo)
    {
        var response = new Response<List<EquipoSistemOperativo>>(true, "OK");

        try
        {

            var sistemas = await _equipoService.ObtenerTodosLosEquipoSistemaOperativoAsync(sistemaOperativo);
            response.Data = sistemas;

            if (sistemas == null || sistemas.Count == 0)
            {
                return NotFound(new ErrorResponse<EquipoSistemOperativo>
                {
                    Success = false,
                    Message = "No se encontraron Equipos con el Sistema Operativo."
                });
            }

            return Ok(new SuccessResponse<List<EquipoSistemOperativo>>
            {
                Success = true,
                Message = "OK",
                Data = response.Data
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<EquipoSistemOperativo>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Equipos con el Sistema Operativo por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var response = new Response<List<EquipoDto>>(true, "OK");
        try
        {
            var equipo = await _equipoService.ObtenerEquipoPorIdAsync(id);
            if (equipo == null)
            {
                return NotFound(new ErrorResponse<EquipoDto>
                {
                    Success = false,
                    Message = "Datos de Equipo no proporcionados."
                });
            }
            return Ok(new SuccessResponse<EquipoDto>
            {
                Success = true,
                Message = "OK",
                Data = equipo
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<EquipoDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Equipo por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] EquipoCreacionDto equipoDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (equipoDto == null)
            {
                response.Update(false, "Datos de Equipo no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _equipoService.CrearEquipoAsync(equipoDto);

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
    public async Task<IActionResult> Actualizar(int id, [FromBody] EquipoDto equipoDto)
    {
        var response = new Response<List<EquipoDto>>(true, "OK");
        try
        {
            var equipoExistente = await _equipoService.ObtenerEquipoPorIdAsync(id);
            if (equipoExistente == null)
            {
                response.Update(false, "Datos de Equipo no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _equipoService.ActualizarEquipoAsync(id, equipoDto);
            response.Message = response.Success ? "Equipo actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el Equipo con id {id}";
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
        var response = new Response<List<EquipoDto>>(true, "OK");
        try
        {
            var equipoExistente = await _equipoService.ObtenerEquipoPorIdAsync(id);
            if (equipoExistente == null)
            {
                response.Update(false, "Datos de Equipo no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _equipoService.EliminarEquipoAsync(id);
            response.Message = response.Success ? "Equipo borrado con éxito"
                : $"Lo sentimos, no se pudo borrar el Equipo con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Eliminar.", null));
        }
    }
}
