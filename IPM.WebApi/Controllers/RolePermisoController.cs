using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.Controllers
{
    [Route("api/rolespermiso")]
    [ApiController]
    public class RolesPermisoController : ControllerBase
    {
        private readonly IRolesPermisoService _rolesPermisoService;

        public RolesPermisoController(IRolesPermisoService rolesPermisoService)
        {
            _rolesPermisoService = rolesPermisoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var rolesPermisos = await _rolesPermisoService.ObtenerTodosLosRolesPermiso();
                return Ok(rolesPermisos);
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
                var rolesPermiso = await _rolesPermisoService.ObtenerRolePermisoPorId(id);
                if (rolesPermiso == null)
                {
                    return NotFound();
                }
                return Ok(rolesPermiso);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RolesPermisoDto rolesPermisoDto)
        {
            try
            {
                if (rolesPermisoDto == null)
                {
                    return BadRequest("Datos de rolesPermiso no proporcionados.");
                }

                var nuevoRolesPermiso = await _rolesPermisoService.CrearRolePermiso(rolesPermisoDto);

                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoRolesPermiso.RolId }, nuevoRolesPermiso);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] RolesPermisoDto rolesPermisoDto)
        {
            try
            {
                var rolesPermisoExistente = await _rolesPermisoService.ObtenerRolePermisoPorId(id);
                if (rolesPermisoExistente == null)
                {
                    return NotFound();
                }

                var rolesPermisoActualizado = await _rolesPermisoService.ActualizarRolePermiso(id, rolesPermisoDto);

                return Ok(rolesPermisoActualizado);
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
                var rolesPermisoExistente = await _rolesPermisoService.ObtenerRolePermisoPorId(id);
                if (rolesPermisoExistente == null)
                {
                    return NotFound();
                }

                await _rolesPermisoService.EliminarRolePermiso(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
