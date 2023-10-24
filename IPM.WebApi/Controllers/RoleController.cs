using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var roles = await _roleService.ObtenerTodosLosRoles();
                return Ok(roles);
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
                var role = await _roleService.ObtenerRolePorId(id);
                if (role == null)
                {
                    return NotFound();
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RoleDto roleDto)
        {
            try
            {
                if (roleDto == null)
                {
                    return BadRequest("Datos de rol no proporcionados.");
                }

                var nuevoRole = await _roleService.CrearRol(roleDto);

                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoRole.RolId }, nuevoRole);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] RoleDto roleDto)
        {
            try
            {
                var roleExistente = await _roleService.ObtenerRolePorId(id);
                if (roleExistente == null)
                {
                    return NotFound();
                }

                var roleActualizado = await _roleService.ActualizarRol(id, roleDto);

                return Ok(roleActualizado);
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
                var roleExistente = await _roleService.ObtenerRolePorId(id);
                if (roleExistente == null)
                {
                    return NotFound();
                }

                var eliminado = await _roleService.EliminarRol(id);

                if (eliminado)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo eliminar el rol.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
