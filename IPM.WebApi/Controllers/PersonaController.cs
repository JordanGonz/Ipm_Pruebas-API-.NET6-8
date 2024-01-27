using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace IPM.WebApi.Controllers;

[Route("api/persona")]
[ApiController]
[Authorize]
public class PersonaController : BaseApiController<PersonaController>
{
    private readonly IPersonaService _personaService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PersonaController(IPersonaService personaService, IHttpContextAccessor httpContextAccessor)
    {
        _personaService = personaService ?? throw new ArgumentNullException(nameof(personaService));
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<PersonaDto>>(true, "OK");
        try
        {
            response.Data = await _personaService.ObtenerTodosLosPersonaAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Listar Persona.", null));
        }
    }

    [HttpGet("informacion-perfil")]
    public async Task<IActionResult> ObtenerInformacionPerfil()
    {
        var response = new Response<InformacionPersonaDto>(true, "OK");
        try
        {
            var userName = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value);
            response.Data = await _personaService.ObtenerInformacionUsuario(userName);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Listar Persona.", null));
        }
    }

    [HttpPost("informacion-perfil/{id}")]
    public async Task<IActionResult> ActualizarActividad(int id, [FromBody] InformacionActualizarPersonaDto infoActPerfil)
    {
        var response = new Response<String>(true, "OK");

        try
        {
            var actualizado = await _personaService.ActualizarInformacionPerfil(id, infoActPerfil);

            if (actualizado == null)
            {
                response.Update(false, "No se pudo actualizar la actividad.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "Actividad actualizada con éxito"
                : $"Lo sentimos, no se pudo actualizar la actividad con id {id}";
            //throw new Exception("test");

            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar la actividad.", null));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var response = new Response<List<PersonaDto>>(true, "OK");
        try
        {
            var persona = await _personaService.ObtenerPersonaPorIdAsync(id);
            if (persona == null)
            {
                return NotFound(new ErrorResponse<PersonaDto>
                {
                    Success = false,
                    Message = "Datos de Persona no proporcionados."
                });
            }
            return Ok(new SuccessResponse<PersonaDto>
            {
                Success = true,
                Message = "OK",
                Data = persona
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<PersonaDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Personas por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] PersonaCreacionDTO personaDto)
    {
        
        var response = new Response <string>(true, "OK");
        try
        {
            if (personaDto == null)
            {
                response.Update(false, "Datos de Personas no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _personaService.CrearPersonaAsync(personaDto);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = -1 }, response);
        }
        catch (Exception ex)
        {

            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo agregar.", null));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] PersonaDto personaDto)
    {
        var response = new Response<List<PersonaDto>>(true, "OK");
        try
        {
            var personaExistente = await _personaService.ObtenerPersonaPorIdAsync(id);
            if (personaExistente == null)
            {
                response.Update(false, "Datos de usuario no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _personaService.ActualizaPersonaAsync(id, personaDto);
            response.Message = response.Success ? "Persona ctuaizado con éxito"
                : $"Lo sentimos, no se pudo actualizar la Persona con id {id}";
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
        var response = new Response<List<PersonaDto>>(true, "OK");
        try
        {
            // Implementa la lógica para eliminar una persona por su ID.
            var personaExistente = await _personaService.ObtenerPersonaPorIdAsync(id);
            if (personaExistente == null)
            {
                response.Update(false, "Datos de usuario no encontrados.", null);
                return NotFound(response);
            }

            response.Success=  await _personaService.EliminarPersonaAsync(id);
            response.Message = response.Success ? "Persona borrado con éxito"
               : $"Lo sentimos, no se pudo borrar la Persona con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Eliminar.", null));
        }
    }
}
