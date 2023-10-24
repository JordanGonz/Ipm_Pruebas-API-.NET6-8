using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.Controllers
{
    [Route("api/permisos")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoService _permisoService;

        public PermisoController(IPermisoService permisoService)
        {
            _permisoService = permisoService ;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var permisos = await _permisoService.ObtenerTodosLosPermisosAsync();
                return Ok(permisos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{permisoId}")]
        public async Task<IActionResult> ObtenerPorId(int permisoId)
        {
            try
            {
                var permiso = await _permisoService.ObtenerPermisoPorIdAsync(permisoId);
                if (permiso == null)
                {
                    return NotFound();
                }
                return Ok(permiso);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PermisoDto permisoDto)
        {
            try
            {
                if (permisoDto == null)
                {
                    return BadRequest("Datos de permiso no proporcionados.");
                }

                var nuevoPermiso = await _permisoService.CrearPermisoAsync(permisoDto);

                return CreatedAtAction(nameof(ObtenerPorId), new { permisoId = nuevoPermiso.PermisoId }, nuevoPermiso);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{permisoId}")]
        public async Task<IActionResult> Actualizar(int permisoId, [FromBody] PermisoDto permisoDto)
        {
            try
            {
                var permisoExistente = await _permisoService.ObtenerPermisoPorIdAsync(permisoId);
                if (permisoExistente == null)
                {
                    return NotFound();
                }

                var permisoActualizado = await _permisoService.ActualizarPermisoAsync(permisoId, permisoDto);

                return Ok(permisoActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{permisoId}")]
        public async Task<IActionResult> Eliminar(int permisoId)
        {
            try
            {
                var permisoExistente = await _permisoService.ObtenerPermisoPorIdAsync(permisoId);
                if (permisoExistente == null)
                {
                    return NotFound();
                }

                await _permisoService.EliminarPermisoAsync(permisoId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
