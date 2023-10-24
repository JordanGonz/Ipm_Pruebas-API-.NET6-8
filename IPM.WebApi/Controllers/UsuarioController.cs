using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var usuarios = await _usuarioService.ObtenerTodosLosUsuarios();
                return Ok(usuarios);
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
                var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                {
                    return BadRequest("Datos de usuario no proporcionados.");
                }

                var nuevoUsuario = await _usuarioService.CrearUsuario(usuarioDto);

                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoUsuario.UsuarioId }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuarioExistente = await _usuarioService.ObtenerUsuarioPorId(id);
                if (usuarioExistente == null)
                {
                    return NotFound();
                }

                var usuarioActualizado = await _usuarioService.ActualizarUsuario(id, usuarioDto);

                return Ok(usuarioActualizado);
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
                var usuarioExistente = await _usuarioService.ObtenerUsuarioPorId(id);
                if (usuarioExistente == null)
                {
                    return NotFound();
                }

                await _usuarioService.EliminarUsuario(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
