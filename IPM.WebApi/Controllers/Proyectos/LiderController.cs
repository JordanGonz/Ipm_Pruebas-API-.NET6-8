using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/lider")]
[ApiController]
[Authorize]
public class LiderController : BaseApiController<LiderController>
{
    private readonly ILiderService _liderService;

    public LiderController(ILiderService liderService)
    {
        _liderService = liderService;
    }

    [HttpGet("obtener-todo")]
    public async Task<IActionResult> ObtenerTodosLosLideres()
    {
        var response = new Response<List<ObtenerLider>>(true, "OK");
        try
        {
            response.Data = await _liderService.ObtenerTodosLosLiderAsync();

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }




    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var response = new Response<ObtenerLider>(true, "OK");
        try
        {
            response.Data = await _liderService.ObtenerLiderPorIdAsync(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] LiderDto liderDto)
    {
        var response = new Response<List<ClienteDto>>(true, "OK");
        try
        {
            if (liderDto == null)
            {
                response.Update(true, "Datos  no proporcionado", null);
                return Ok(response);
            }
            await _liderService.CrearLiderAsync(liderDto);
            return Created("", response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] EditarLider liderDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            // Lógica para actualizar la actividad
            var actualizado = await _liderService.ActualizarLiderAsync(id, liderDto);

            if (!actualizado)
            {
                response.Update(false, $"No se pudo actualizar el dato con id {id}.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "dato actualizado con éxito"
            : $"No se pudo actualizar el dato con id {id}";

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var response = new Response<List<EliminarLider>>(true, "OK");
        try
        {

            response.Success = await _liderService.EliminarLiderAsync(id);
            response.Message = response.Success ? "Dato eliminado con exito"
                : $"No se elimino el dato con id {id}";
            //throw new Exception("test");
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }
}
