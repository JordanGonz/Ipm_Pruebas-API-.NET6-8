using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.Controllers
{
    [Route("api/proyectos")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoService _proyectoService;

        public ProyectoController(IProyectoService proyectoService)
        {
            _proyectoService = proyectoService ;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var proyectos = await _proyectoService.ObtenerTodosLosProyectos();
                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var proyecto = await _proyectoService.ObtenerProyectoPorId(id);
                if (proyecto == null)
                {
                    return NotFound();
                }
                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProyectoDto proyectoDto)
        {
            try
            {
                if (proyectoDto == null)
                {
                    return BadRequest("Datos de proyecto no proporcionados.");
                }

                var nuevoProyecto = await _proyectoService.CrearProyecto(proyectoDto);

                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoProyecto.IdProyecto }, nuevoProyecto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ProyectoDto proyectoDto)
        {
            try
            {
                var proyectoExistente = await _proyectoService.ObtenerProyectoPorId(id);
                if (proyectoExistente == null)
                {
                    return NotFound();
                }

                var proyectoActualizado = await _proyectoService.ActualizarProyecto(id, proyectoDto);

                return Ok(proyectoActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var proyectoExistente = await _proyectoService.ObtenerProyectoPorId(id);
                if (proyectoExistente == null)
                {
                    return NotFound();
                }

                await _proyectoService.EliminarProyecto(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
