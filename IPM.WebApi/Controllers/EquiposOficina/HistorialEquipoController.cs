using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers.EquiposOficina;

[Route("api/historial-equipo")]
[ApiController]
[Authorize]
public class HistorialEquipoController : BaseApiController <HistorialEquipoController>
{
    private readonly IHistorialEquipoService _historialEquipoService;
    public HistorialEquipoController(IHistorialEquipoService historialEquipoService)
    {
        _historialEquipoService = historialEquipoService;
    }

    [HttpGet("{idEquipo}")]
    public async Task<IActionResult> ObtenerHistorialEquipoAsync(int idEquipo)
    {
        var response = new Response<HistorialEquipoDto>(true, "OK");

        try
        {
            var historialEquipo = await _historialEquipoService.ObtenerHistorialEquipoAsync(idEquipo);

            if (historialEquipo == null)
            {
                response.Update(false, "Historial del equipo no encontrado", null);
                return NotFound(response);
            }

            response.Data = historialEquipo;
            return Ok(response);
        }
        catch (Exception)
        {
            // Log the exception for debugging purposes
            // logger.LogError(ex, "An error occurred while fetching the team history.");

            response.Update(false, "Lo sentimos, ocurrió un error al obtener el historial del equipo.", null);
            return Conflict(response);
        }
    }



}
