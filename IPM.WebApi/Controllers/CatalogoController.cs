using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Infraestructure.Services;
using IPM.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IPM.Web.Controllers;

[Route("api/catalogo")]
[ApiController]
[Authorize]
public class CatalogoController : BaseApiController<CatalogoController>
{
    private readonly ICatalogoService _catalogoService;

    public CatalogoController(ICatalogoService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodosLosCatalogos(string nemonico)
    {
        var response = new Response<List<CatalogoDto>>(true, "OK");
        
        try
        {
            
            var catalogos = await _catalogoService.ObtenerTodosLosCatalogoAsync(nemonico);
            response.Data = catalogos;

            if (catalogos == null || catalogos.Count == 0)
            {
                return NotFound(new ErrorResponse<CatalogoDto>
                {
                    Success = false,
                    Message = "No se encontraron proyectos con catálogos."
                });
            }

            return Ok(new SuccessResponse<List<CatalogoDto>>
            {
                Success = true,
                Message = "OK",
                Data = response.Data
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<CatalogoDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener Proyectos por ID.",
                ErrorCode = ex.Message
            });
        }
    }



    [HttpGet("obtener-nombre")]
    public async Task<IActionResult> ObtenerTodoLosNombres()
    {
        var response = new Response<List<CatalogoMostrarNombre>>(true, "OK");
        try
        {
            response.Data = await _catalogoService.ObtenerTodosLosNombresdeSuNemonico();

            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado.", null));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerCatalogoPorId(int id)
    {
        try
        {
            var catalogo = await _catalogoService.ObtenerCatalogoPorIdAsync(id);
            if (catalogo is null )
            {
                return NotFound(new ErrorResponse<CatalogoDto>
                {
                    Success = false,
                    Message = "Datos de usuario no proporcionados."
                });
            }

            
            return Ok(new SuccessResponse<CatalogoDto>
            {
                Success = true,
                Message = "OK",
                Data = catalogo
            });
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(new ErrorResponse<CatalogoDto>
            {
                Success = false,
                Message = "Lo sentimos, no se pudo obtener usuarios por ID.",
                ErrorCode = ex.Message
            });
        }
    }




    [HttpPost]
    public async Task<IActionResult> CrearCatalogo([FromBody] CatalogoCreacionDTO catalogoDto)
    {

        var response = new Response<string>(true, "OK");
        try
        {
            if (catalogoDto == null)
            {
                response.Update(false, "Datos de Catalago no proporcionados.", "");
                return BadRequest(response);
            }

           response.Success = await _catalogoService.CrearCatalogoAsync(catalogoDto);

            if (!response.Success)
            {
                
                response.Message = "Lo sentimos, no se pudo Crear.";
                return Conflict(response);
            }
            
            return Created(nameof(ObtenerCatalogoPorId), response);

        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo Crear.", null));

        }
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarCatalogo(int id, [FromBody] CatalogoDto catalogoDto)
    {
        var response = new Response<CatalogoDto>(true, "OK");
        try
        {
            var actualizado = await _catalogoService.ActualizarCatalogoAsync(id, catalogoDto);
            if (!actualizado)
            {
                response.Update(false, "Datos de Catalagos no encontrados.", null);
                return NotFound(response);
            }
            response.Success = await _catalogoService.ActualizarCatalogoAsync(id, catalogoDto);

            response.Message = response.Success ? "Catalogo ctuaizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el usuario con id {id}";

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar.", null));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarCatalogo(int id)
    {
        var response = new Response<List<CatalogoDto>>(true, "OK");
        try
        {
            var eliminado = await _catalogoService.ObtenerCatalogoPorIdAsync(id);
            if (eliminado == null)
            {
                response.Update(false, "Datos de Catalogo no encontrados.", null);
                return NotFound(response); 
            }

            response.Success = await _catalogoService.EliminarCatalogoAsync(id);
            response.Message = response.Success ? "Catalogos borrado con éxito"
               : $"Lo sentimos, no se pudo borrar el Catalogos con id {id}";
            return Ok(response);

        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, no se pudo borrar.", null));

        }
    }
}
