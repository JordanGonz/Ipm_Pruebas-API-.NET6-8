using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/empresa")]
[ApiController]
[Authorize]
public class EmpresaController : BaseApiController<EmpresaController>
{
    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        try
        {
            var empresas = await _empresaService.ObtenerTodasLasEmpresaAsync();
            return Ok(empresas);
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
        try
        {
            var empresa = await _empresaService.ObtenerEmpresaPorIdAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] EmpresaDto empresaDto)
    {
        try
        {
            if (empresaDto == null)
            {
                return BadRequest("Datos de la empresa no proporcionados.");
            }

            var nuevaEmpresa = await _empresaService.CrearEmpresaAsync(empresaDto);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaEmpresa.IdEmpresa }, nuevaEmpresa);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] EmpresaDto empresaDto)
    {
        try
        {
            var empresaExistente = await _empresaService.ObtenerEmpresaPorIdAsync(id);
            if (empresaExistente == null)
            {
                return NotFound();
            }

            var empresaActualizada = await _empresaService.ActualizarEmpresaAsync(id, empresaDto);

            return Ok(empresaActualizada);
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
        try
        {
            var empresaExistente = await _empresaService.ObtenerEmpresaPorIdAsync(id);
            if (empresaExistente == null)
            {
                return NotFound();
            }

            await _empresaService.EliminarEmpresaAsync(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }
}
