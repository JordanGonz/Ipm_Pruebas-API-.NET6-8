using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IPM.WebApi.Controllers;

[Route("api/usuarios")]
[ApiController]
[Authorize]
public class UsuarioController : BaseApiController<UsuarioController>    {
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService ;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<UsuarioDto>>(true, "OK");

        try
        {
            response.Data = await _usuarioService.ObtenerTodosLosUsuariosAsync();

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de usuarios.", null));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        try
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new ErrorResponse<UsuarioDto>
                {
                    Success = false,
                    Message = "Datos de usuario no proporcionados."
                });
            }
            return Ok(new SuccessResponse<UsuarioDto>
            {
                Success = true,
                Message = "OK",
                Data = usuario
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<UsuarioDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener usuarios por ID.",
                ErrorCode = ex.Message
            });
        }
    }


    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] UsuarioCreacionDto usuarioDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (usuarioDto == null)
            {
                response.Update(false, "Datos de usuario no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _usuarioService.CrearUsuarioAsync(usuarioDto);
            return Created(nameof(ObtenerPorId), response);
            
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Crear.", null));
        }
    }



    [HttpPost("registro-completo")]
    public async Task<IActionResult> RegistroCompleto([FromForm] RegistroCompletoDto registroCompletoDto)
    {
        var response = new Response<string>(true, "OK");

        try
        {
                var registroExitoso = await _usuarioService.RegistrarUsuarioCompletoAsync(registroCompletoDto);

            if (registroExitoso)
            {
                return Created(nameof(ObtenerPorId), response.Update(true, "Registro completo exitoso", ""));
            }
            else
            {
                return Conflict(response.Update(false, "Lo sentimos, no se pudo completar el registro.", null));
            }
        }
        catch (Exception ex)
        {
                Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo completar el registro.", null));
        }
    }

    [HttpGet("registro-completo")]
    public async Task<IActionResult> ObtenerTodosLosRegistrosCompletos()
    {
        try
        {
            var registrosCompletos = await _usuarioService.ObtenerTodosLosRegistrosCompletosAsync();

            if (registrosCompletos == null || registrosCompletos.Count == 0)
            {
                return NotFound(new ErrorResponse<List<RegistroCompletoDto>>
                {
                    Success = false,
                    Message = "No se encontraron registros completos."
                });
            }

            return Ok(new SuccessResponse<List<RegistroCompletoDto>>
            {
                Success = true,
                Message = "OK",
                Data = registrosCompletos
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<List<RegistroCompletoDto>>
            {
                Success = false,
                Message = "Lo sentimos, no se pudieron obtener los registros completos.",
                ErrorCode = ex.Message
            });
        }
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] UsuarioDto usuarioDto)
    {
        var response = new Response<List<UsuarioDto>>(true, "OK");
        try
        {
            var usuarioExistente = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuarioExistente == null)
            {
                response.Update(false, "Datos de usuario no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _usuarioService.ActualizarUsuarioAsync(id, usuarioDto);

            response.Message = response.Success ? "Usuarioactuaizado con éxito" 
                : $"Lo sentimos, no se pudo actualizar el usuario con id {id}";
           // throw new Exception("test error");
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
        
        var response = new Response<List<UsuarioDto>>(true, "OK");
        try
        {
            var usuarioExistente = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuarioExistente == null)
            {
                response.Update(false, "Datos de usuario no encontrados.", null);
                return NotFound(response);
                
            }

            response.Success = await _usuarioService.EliminarUsuarioAsync(id);

            response.Message = response.Success ? "Usuario borrado con éxito"
               : $"Lo sentimos, no se pudo borrar el usuario con id {id}";
            return Ok(response);
        }
        catch (Exception ex )
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo borrar.", null));
        }
    }
}