using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.Controllers;

[Route("api/permisos")]
[ApiController]
[Authorize]
public class PermisoController : BaseApiController<PermisoController>
{
    private readonly IPermisoService _permisoService;

    public PermisoController(IPermisoService permisoService)
    {
        _permisoService = permisoService ;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<PermisoDto>>(true, "OK");
        try
        {
            response.Data = await _permisoService.ObtenerTodosLosPermisosAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Permisos.", null));
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
                return NotFound(new ErrorResponse<PermisoDto>
                {
                    Success = false,
                    Message = "Datos de usuario no proporcionados."
                });
            }
            return Ok(new SuccessResponse<PermisoDto>
            {
                Success = true,
                Message = "OK",
                Data = permiso
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<UsuarioDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Permisos por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] PermisoCreacionDTO permisoDto)
    {
        var response = new Response <string>(true, "OK");
        try
        {
            if (permisoDto == null)
            {
                return BadRequest("Datos de permiso no proporcionados.");
            }

            response.Success = await _permisoService.CrearPermisoAsync(permisoDto);

            return CreatedAtAction(nameof(ObtenerPorId), response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Permisos.", null));
        }
    }

    [HttpPut("{permisoId}")]
    public async Task<IActionResult> Actualizar(int permisoId, [FromBody] PermisoDto permisoDto)
    {
        var response = new Response<List<PermisoDto>>(true, "OK");
        try
        {
            var permisoExistente = await _permisoService.ObtenerPermisoPorIdAsync(permisoId);
            if (permisoExistente == null)
            {
                response.Update(false, "Datos de Permsisos no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _permisoService.ActualizarPermisoAsync(permisoId, permisoDto);
            response.Message = response.Success ? "Permsisos actuaizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el Permsisos con id {permisoId}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar.", null));
        }
    }

    [HttpDelete("{permisoId}")]
    public async Task<IActionResult> Eliminar(int permisoId)
    {
        var response = new Response<List<PermisoDto>>(true, "OK");
        try
        {
            var permisoExistente = await _permisoService.ObtenerPermisoPorIdAsync(permisoId);
            if (permisoExistente == null)
            {
                response.Update(false, "Datos de Permisos no encontrados.", null);
                return NotFound(response);
            }

            response.Success= await _permisoService.EliminarPermisoAsync(permisoId);
            response.Message = response.Success ? "Usuario borrado con éxito"
              : $"Lo sentimos, no se pudo borrar el usuario con id {permisoId}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo borrar.", null));
        }
    }
}
