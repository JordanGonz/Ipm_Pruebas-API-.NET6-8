using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IPM.Controllers;

[Route("api/proyectos")]
[ApiController]
[Authorize]
public class ProyectoController : BaseApiController<ProyectoController>
{
    private readonly IProyectoService _proyectoService;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public ProyectoController(IProyectoService proyectoService, IHttpContextAccessor httpContextAccessor)
    {
        _proyectoService = proyectoService ;
        _httpContextAccessor = httpContextAccessor;

    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var response = new Response<List<ProyectoDto>>(true, "OK");
        
        try
        {
            response.Data = await _proyectoService.ObtenerTodosLosProyectos();
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener la lista de Proyectos.", null));
        }
    }


    [HttpGet("obtener-proyecto-catalogo")]
    public async Task<IActionResult> ObtenerProyectosCatalogos()
    {
        var response = new Response<List<ProyectoCatalogoDto>>(true, "OK");
        try
        {
            var idPersona = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "IdPersona").Value);
            var proyectoCatalogoData = await _proyectoService.ObtenerTodosLosProyectosConCatalogos(idPersona);

            response.Data = proyectoCatalogoData;

            if (proyectoCatalogoData == null || proyectoCatalogoData.Count == 0)
            {
                return NotFound(new ErrorResponse<ProyectoCatalogoDto>
                {
                    Success = false,
                    Message = "No se encontraron proyectos con catálogos."
                });
            }

            return Ok(new SuccessResponse<List<ProyectoCatalogoDto>>
            {
                Success = true,
                Message = "OK",
                Data = response.Data
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<UsuarioDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Proyectos por ID.",
                ErrorCode = ex.Message
            });
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        
        try
        {
            var proyecto = await _proyectoService.ObtenerProyectoPorId(id);
            if (proyecto == null)
            {
                return NotFound(new ErrorResponse<ProyectoDto>
                {
                    Success = false,
                    Message = "Datos de Proyectos no proporcionados."
                });
            }
            return Ok(new SuccessResponse<ProyectoDto>
            {
                Success = true,
                Message = "OK",
                Data = proyecto
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<UsuarioDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Proyectos por ID.",
                ErrorCode = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] ProyectoCreacionDto proyectoDto)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (proyectoDto == null)
            {
                response.Update(false, "Datos de Proyectos no proporcionados.", "");
                return BadRequest(response);
            }

            response.Success = await _proyectoService.CrearProyecto(proyectoDto);

            return Created(nameof(ObtenerPorId),response );
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo agregar.", null));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ProyectoDto proyectoDto)
    {
        var response = new Response<List<ProyectoDto>>(true, "OK");
        try
        {
            var proyectoExistente = await _proyectoService.ObtenerProyectoPorId(id);
            if (proyectoExistente == null)
            {
                response.Update(false, "Datos de Proyectos no proporcionados.",null);
                return NotFound(response);
            }

            response.Success = await _proyectoService.ActualizarProyecto(id, proyectoDto);
            response.Message = response.Success ? "Proyecto actuaizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el Proyecto con id {id}";
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
        var response = new Response<List<ProyectoDto>>(true, "OK");
        try
        {
            var proyectoExistente = await _proyectoService.ObtenerProyectoPorId(id);
            if (proyectoExistente == null)
            {
                response.Update(false, "Datos de Proyecto no encontrados.", null);
                return NotFound(response);
            }

            response.Success=  await _proyectoService.EliminarProyecto(id);
            response.Message = response.Success ? "Usuario borrado con éxito"
               : $"Lo sentimos, no se pudo borrar el Proyecto con id {id}";
            //throw new Exception("test error");

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo eliminar.", null));
        }
    }
}
