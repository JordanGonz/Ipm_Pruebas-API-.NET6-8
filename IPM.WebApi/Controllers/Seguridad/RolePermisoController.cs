using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.Controllers;

[Route("api/roles-permiso")]
[ApiController]
[Authorize]
public class RolesPermisoController : BaseApiController<RolesPermisoController>
{
    private readonly IRolesPermisoService _rolesPermisoService;

    public RolesPermisoController(IRolesPermisoService rolesPermisoService)
    {
        _rolesPermisoService = rolesPermisoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<RolesPermisoDto>>(true, "OK");

        
        try
        {
            response.Data = await _rolesPermisoService.ObtenerTodosLosRolesPermiso();
            // throw new Exception("test error");
            return Ok(response);
        }
        catch (Exception ex )
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de RolePermiso.", null));
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
                return NotFound(new ErrorResponse<RolesPermisoDto>
                {
                    Success = false,
                    Message = "Datos de RolesPermiso no proporcionados."
                });
            }
            return Ok(new SuccessResponse<RolesPermisoDto>
            {
                Success = true,
                Message = "OK",
                Data = rolesPermiso
            });
        }
        catch (Exception ex )
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<RolesPermisoDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener  RolesPermiso por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] RolesCreacionPermiso rolesPermisoDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (rolesPermisoDto == null)
            {
                response.Update(false, "Datos de RolePermiso no proporcionados.", null);
                return BadRequest(response);
            }

            response.Success = await _rolesPermisoService.CrearRolePermiso(rolesPermisoDto);

            return Created(nameof(ObtenerPorId),response);
        }
        catch (Exception ex )
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo elimnar de RolePermisos.", null));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] RolesPermisoDto rolesPermisoDto)
    {
        var response = new Response<List<RolesPermisoDto>>(true, "OK");
        try
        {
            var rolesPermisoExistente = await _rolesPermisoService.ObtenerRolePermisoPorId(id);
            if (rolesPermisoExistente == null)
            {
                response.Update(false, "Datos de RolePermiso no encontrados.", null);
                return NotFound(response);
            }

            response.Success = await _rolesPermisoService.ActualizarRolePermiso(id, rolesPermisoDto);
            response.Message = response.Success ? "RolePermiso actuaizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el RolePermiso con id {id}";

            return Ok(response);
        }
        catch (Exception ex )
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar RolePermiso.", null));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var response = new Response<List<RolesPermisoDto>>(true, "OK");
        try
        {
            var rolesPermisoExistente = await _rolesPermisoService.ObtenerRolePermisoPorId(id);
            if (rolesPermisoExistente == null)
            {
                response.Update(false, "Datos de RolePermiso no encontrados.", null);
                return NotFound(response);
            }

            response.Success=  await _rolesPermisoService.EliminarRolePermiso(id);

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo eliminar RolePermiso ID.", null));
        }
    }
}
