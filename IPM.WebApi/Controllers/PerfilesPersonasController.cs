using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;

[Authorize]

public class PerfilesPersonasController : BaseApiController<PerfilesPersonasController>
{
    private readonly IPerfilesPersonasService _perfilPersona;
    public PerfilesPersonasController (IPerfilesPersonasService perfilPersona)
    {
        _perfilPersona = perfilPersona;

    }



    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerInformacionPersonal(int id)
    {
        var response = new Response<PerfilPersona>(true, "OK");

        try
        {
            var perfilPersonas = await _perfilPersona.ObtenerTodaLaInformacionDePersonaAsync(id);

            if (perfilPersonas == null )
            {
                response.Update(false, "Perfil no encontrado", null);
                return NotFound(response);
            }

            response.Data = perfilPersonas;
            return Ok(response);
        }
        catch (Exception)
        {
            response.Update(false, "Lo sentimos, ocurrió un error al obtener el perfil de la persona.", null);
            return Conflict(response);
        }
    }

    [HttpGet("busqueda-perfiles")]


    public async Task<IActionResult> ObtenerPerfilesPersonas(string busqueda)
    {
        var response = new Response<List<BusquedaDePerfiles>>(true, "OK");

        try
        {
            var perfilPersonas = await _perfilPersona.ObtenerListadoDeBusquedaPerfilAsync(busqueda);

            if (perfilPersonas == null)
            {
                response.Update(false, "Perfil no encontrado", null);
                return NotFound(response);
            }

            response.Data = perfilPersonas;
            return Ok(response);
        }
        catch (Exception)
        {

            response.Update(false, "Lo sentimos, ocurrió un error al obtener el perfil de la persona.", null);
            return Conflict(response);
        }
    }
}
