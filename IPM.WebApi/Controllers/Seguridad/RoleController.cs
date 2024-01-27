using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Route("api/roles")]
[ApiController]
[Authorize]
public class RoleController : BaseApiController<RoleController>
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<RoleDto>>(true, "OK");
        try
        {
            response.Data = await _roleService.ObtenerTodosLosRoles();
            // throw new Exception("test error");
            return Ok(response);
        }
        catch (Exception ex )
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Roles.", null));
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
                return NotFound(new ErrorResponse<RoleDto>
                {
                    Success = false,
                    Message = "Datos de Roles no proporcionados."
                });
            }
            return Ok(new SuccessResponse<RoleDto>
            {
                Success = true,
                Message = "OK",
                Data = role
            });
        }

        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<RoleDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener  Roles por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] RoleCreacionDto roleDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (roleDto == null)
            {
                response.Update(false, "Datos de Roles no proporcionados.", null);
                return BadRequest(response);
            }

            response.Success = await _roleService.CrearRol(roleDto);

            return Created(nameof(ObtenerPorId), response);
        }
        catch (Exception ex)
        {

            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Crear Roles.", null));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] RoleDto roleDto)
    {
        var response = new Response<List<RoleDto>>(true, "OK");
        try
        {
            var roleExistente = await _roleService.ObtenerRolePorId(id);
            if (roleExistente == null)
            {
                response.Update(false, "Datos de Roles no proporcionados ID.", null);
                return NotFound(response);
            }

            response.Success = await _roleService.ActualizarRol(id, roleDto);

            response.Message = response.Success ? "Roles actuaizado con éxito"
               : $"Lo sentimos, no se pudo actualizar el Roles con id {id}";
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar Roles.", null));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var response = new Response<List<RoleDto>>(true, "OK");
        try
        {
            var roleExistente = await _roleService.ObtenerRolePorId(id);
            if (roleExistente == null)
            {
                response.Update(false, "Datos de Roles no proporcionados.", null);
                return NotFound(response);
            }
            response.Success = await _roleService.EliminarRol(id);
            //var eliminado = await _roleService.EliminarRol(id);

            //if (eliminado)
            //{

            //    response.Update(false, "Datos de Roles no proporcionados ID.", null);
            //    return NoContent();
            //}
            //return Conflict(response.Update(false, "No se pudo eliminar el rol.", null));

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo elminar Roles.", null));
        }
    }
}
