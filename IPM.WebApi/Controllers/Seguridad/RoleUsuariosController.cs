using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/roles-usuarios")]
[ApiController]
[Authorize]
public class RolesUsuariosController : BaseApiController<RolesUsuariosController>
{
    private readonly IRolesUsuariosService _rolesUsuariosService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RolesUsuariosController(IRolesUsuariosService rolesUsuariosService, IHttpContextAccessor httpContextAccessor)
    {
        _rolesUsuariosService = rolesUsuariosService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<RolesUsuarioDto>>(true, "OK");

        try
        {
            response.Data = await _rolesUsuariosService.ObtenerTodosLosRolesPermisoAsync();

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de roles-usuarios.", null));
        }
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        try
        {
            var rolesUsuario = await _rolesUsuariosService.ObtenerRolePermisoPorIdAsync(id);
            if (rolesUsuario == null)
            {
                return NotFound(new ErrorResponse<RolesUsuarioDto>
                {
                    Success = false,
                    Message = "Datos de roles-usuario no proporcionados."
                });
            }

            return Ok(new SuccessResponse<RolesUsuarioDto>
            {
                Success = true,
                Message = "OK",
                Data = rolesUsuario
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<RolesUsuarioDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener roles-usuario por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] RolesUsuarioDto rolesUsuarioDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (rolesUsuarioDto == null)
            {
                response.Update(false, "Datos de roles-usuario no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _rolesUsuariosService.CrearRolePermisoAsync(rolesUsuarioDto);

            return Created(nameof(ObtenerPorId), response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, $"Lo sentimos, no se pudo Crear. {ex.Message}", null));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] RolesUsuarioDto rolesUsuarioDto)
    {
        var response = new Response<List<RolesUsuarioDto>>(true, "OK");
        try
        {
            var rolesUsuarioExistente = await _rolesUsuariosService.ObtenerRolePermisoPorIdAsync(id);
            if (rolesUsuarioExistente == null)
            {
                response.Update(false, "Datos de roles-usuario no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _rolesUsuariosService.ActualizarRolePermisoAsync(id, rolesUsuarioDto);

            response.Message = response.Success ? "Roles-usuario actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el roles-usuario con id {id}";

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, $"Lo sentimos, no se pudo actualizar. {ex.Message}", null));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var response = new Response<List<RolesUsuarioDto>>(true, "OK");
        try
        {
            var rolesUsuarioExistente = await _rolesUsuariosService.ObtenerRolePermisoPorIdAsync(id);
            if (rolesUsuarioExistente == null)
            {
                response.Update(false, "Datos de roles-usuario no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _rolesUsuariosService.EliminarRolePermisoAsync(id);

            response.Message = response.Success ? "Roles-usuario borrado con éxito"
                : $"Lo sentimos, no se pudo borrar el roles-usuario con id {id}";

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, $"Lo sentimos, no se pudo borrar. {ex.Message}", null));
        }
    }
}
