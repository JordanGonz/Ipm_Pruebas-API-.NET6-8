using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.Controllers
{
    [Route("api/proyectodetalle")]
    [ApiController]
    public class ProyectoDetalleController : ControllerBase
    {
        private readonly IProyectoDetalleService _proyectoDetalleService;

        public ProyectoDetalleController(IProyectoDetalleService proyectoDetalleService)
        {
            _proyectoDetalleService = proyectoDetalleService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var detalles = await _proyectoDetalleService.ObtenerTodosLosProyectoDetalle();
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{idProyectoDetalle}")]
        public async Task<IActionResult> ObtenerPorId(int idProyectoDetalle)
        {
            try
            {
                var detalle = await _proyectoDetalleService.ObtenerProyectoDetallePorId(idProyectoDetalle);
                if (detalle == null)
                {
                    return NotFound();
                }
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProyectoDetalleDto proyectoDetalleDto)
        {
            try
            {
                if (proyectoDetalleDto == null)
                {
                    return BadRequest("Datos de detalle de proyecto no proporcionados.");
                }

                var nuevoDetalle = await _proyectoDetalleService.CrearProyectoDetalle(proyectoDetalleDto);

                return CreatedAtAction(nameof(ObtenerPorId), new { idProyectoDetalle = nuevoDetalle.IdProyectoDetalle }, nuevoDetalle);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{idProyectoDetalle}")]
        public async Task<IActionResult> Actualizar(int idProyectoDetalle, [FromBody] ProyectoDetalleDto proyectoDetalleDto)
        {
            try
            {
                var detalleExistente = await _proyectoDetalleService.ObtenerProyectoDetallePorId(idProyectoDetalle);
                if (detalleExistente == null)
                {
                    return NotFound();
                }

                var detalleActualizado = await _proyectoDetalleService.ActualizarProyectoDetalle(idProyectoDetalle, proyectoDetalleDto);

                return Ok(detalleActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{idProyectoDetalle}")]
        public async Task<IActionResult> Eliminar(int idProyectoDetalle)
        {
            try
            {
                var detalleExistente = await _proyectoDetalleService.ObtenerProyectoDetallePorId(idProyectoDetalle);
                if (detalleExistente == null)
                {
                    return NotFound();
                }

                await _proyectoDetalleService.EliminarProyectoDetalle(idProyectoDetalle);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
