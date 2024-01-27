using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/cliente")]
[ApiController]
[Authorize]
public class ClienteController : BaseApiController <ClienteController>
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet("obtener-todo")]
    public async Task<IActionResult> ObtenerTodasLosClientes()
    {
        var response = new Response<List<ConsultaCliente>>(true, "OK");
        try
        {
            response.Data = await _clienteService.ObtenerTodosLosClienteAsync();

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
        var response = new Response<ConsultaCliente>(true, "OK");
        try
        {
            response.Data = await _clienteService.ObtenerClientePorIdAsync(id);
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
    public async Task<IActionResult> Crear([FromBody] ClienteDto clienteDto)
    {
        var response = new Response<List<ClienteDto>>(true, "OK");
        try
        {
            if (clienteDto == null)
            {
                response.Update(true, "Datos  no proporcionado", null);
                return Ok(response);
            }
            await _clienteService.CrearClienteAsync(clienteDto);
            return Created("", response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] EditarCliente clienteDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            // Lógica para actualizar la actividad
            var actualizado = await _clienteService.ActualizarClienteAsync(id, clienteDto);

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
        var response = new Response<List<EliminarCliente>>(true, "OK");
        try
        {

            response.Success = await _clienteService.EliminarClienteAsync(id);
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
