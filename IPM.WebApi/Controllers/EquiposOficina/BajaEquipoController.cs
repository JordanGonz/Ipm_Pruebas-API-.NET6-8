using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/baja-equipo")]
[ApiController]
[Authorize]
public class BajaEquipoController : BaseApiController<BajaEquipoController>
{
    private readonly IBajaEquipoService _bajaEquipoService;

    public BajaEquipoController(IBajaEquipoService bajaEquipoService)
    {
        _bajaEquipoService = bajaEquipoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<BajaEquiposDto>>(true, "OK");
        try
        {
            response.Data = await _bajaEquipoService.ObtenerTodosBajaEquipoAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de BajaEquipos.", null));
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var response = new Response<List<BajaEquiposDto>>(true, "OK");
        try
        {
            var bajaEquipo = await _bajaEquipoService.ObtenerBajaEquipoPorIdAsync(id);
            if (bajaEquipo == null)
            {
                return NotFound(new ErrorResponse<BajaEquiposDto>
                {
                    Success = false,
                    Message = "Datos de BajaEquipo no proporcionados."
                });
            }
            return Ok(new SuccessResponse<BajaEquiposDto>
            {
                Success = true,
                Message = "OK",
                Data = bajaEquipo
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<BajaEquiposDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener BajaEquipos por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] BajaEquiposCreacionDto bajaEquipos)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (bajaEquipos == null)
            {
                response.Update(false, "Datos de BajaEquipos no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _bajaEquipoService.CrearBajaEquipoAsync(bajaEquipos);

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
    public async Task<IActionResult> Actualizar(int id, [FromBody] BajaEquiposDto bajaEquipoDto)
    {
        var response = new Response<List<BajaEquiposDto>>(true, "OK");
        try
        {
            var bajaEquipoExistente = await _bajaEquipoService.ObtenerBajaEquipoPorIdAsync(id);
            if (bajaEquipoExistente == null)
            {
                response.Update(false, "Datos de BajaEquipo no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _bajaEquipoService.ActualizarBajaEquipoAsync(id, bajaEquipoDto);
            response.Message = response.Success ? "BajaEquipo actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el BajaEquipo con id {id}";
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
        var response = new Response<List<BajaEquiposDto>>(true, "OK");
        try
        {
            var bajaEquipoExistente = await _bajaEquipoService.ObtenerBajaEquipoPorIdAsync(id);
            if (bajaEquipoExistente == null)
            {
                response.Update(false, "Datos de BajaEquipo no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _bajaEquipoService.EliminarBajaEquipoAsync(id);
            response.Message = response.Success ? "BajaEquipo borrado con éxito"
               : $"Lo sentimos, no se pudo borrar el BajaEquipo con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Eliminar.", null));
        }
    }
}
