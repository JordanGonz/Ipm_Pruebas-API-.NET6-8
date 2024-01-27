using IPM.Core.Contracts.Services;
using IPM.Core.Contracts.Services.Reportes;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IPM.WebApi.Controllers.Pagina;
[Route("api/pagina")]
[ApiController]
[AllowAnonymous]

public class PaginaController : Controller
{

    private readonly IPaginaService _paginaService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PaginaController(IPaginaService paginaService, IHttpContextAccessor httpContextAccessor)
    {
        _paginaService = paginaService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("pagina-por-roles")]
    public async Task<IActionResult> ObtenerPaginaPorRol(int id)
    {
        var response = new Response<List<PaginaDto>>(true, "OK");
        try
        {
            response.Data = await _paginaService.ListaDePaginaPorRol(id);
            if (response.Data is null || response.Data.Count == 0)
            {
                response.Update(true, "Datos no encontrados", null);
                return Ok(response);
            }

            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado.", null));
        }
    }


    [HttpGet("pagina-por-usuarios")]
    public async Task<IActionResult> ObtenerPaginaPorUsuario()
    {
        var response = new Response<List<PaginaUsuarioDto>>(true, "OK");
        try
        {
            var roles = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value);

            response.Data = await _paginaService.ListaDePaginaPorUsuario(roles);
            if (response.Data is null || response.Data.Count == 0)
            {
                response.Update(true, "Datos no encontrados", null);
                return Ok(response);
            }
            //throw new Exception("caida ");
            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado.", null));
        }
    }


}
