using Microsoft.AspNetCore.Mvc;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Core.Contracts.Services;
using IPM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace IPM.WebApi.Controllers.EquiposOficina;

[Route("api/asignacion-articulo")]
[ApiController]
[Authorize]
public class AsignacionArticuloController : BaseApiController <AsignacionArticuloController>
{
    private readonly IAsignacionArticuloService _asignacionArticuloService;

    public AsignacionArticuloController(IAsignacionArticuloService asignacionArticuloService)
    {
        _asignacionArticuloService = asignacionArticuloService;
    }

    [HttpGet("obtener-todo")]
    public async Task<IActionResult> ObtenerTodosLosArticulosAsignados()
    {
        var response = new Response<List<AsignacionConsultaArticuloDto>>(true, "OK");

        try
        {
            response.Data = await _asignacionArticuloService.ObtenerTodosLosArticulosAsignadosAsync();

            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado.", null));
        }
    }

    [HttpPost("crear-asignacion-articulo")]
    public async Task<IActionResult> CrearAsignacionArticulo([FromBody] AsignacionArticuloDto asignacionArticuloCrearDto)
    {
        var response = new Response<bool>(true, "OK");

        try
        {
            if (asignacionArticuloCrearDto == null)
            {
                response.Update(true, "Datos de asignación de artículo no proporcionados", false);
                return Ok(response);
            }

            await _asignacionArticuloService.CrearAsignacionArticuloAsync(asignacionArticuloCrearDto);

            return Created("", response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo crear la asignación de artículo.", false));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarAsignacionArticulo(int id, [FromBody] AsignacionActualizarArticuloDto actualizarDto)
    {
        var response = new Response<string>(true, "OK");

        try
        {
            var actualizado = await _asignacionArticuloService.ActualizarAsignacionArticuloAsync(id, actualizarDto);

            if (!actualizado)
            {
                response.Update(false, $"No se pudo actualizar la asignación de artículo con id {id}.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "Asignación de artículo actualizada con éxito"
                : $"Lo sentimos, no se pudo actualizar la asignación de artículo con id {id}";

            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar la asignación de artículo.", null));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarAsignacionArticulo(int id)
    {
        var response = new Response<bool>(true, "OK");

        try
        {
            response.Success = await _asignacionArticuloService.EliminarAsignacionArticuloAsync(id);
            response.Message = response.Success ? "Asignación de artículo eliminada con éxito"
                : $"No se pudo eliminar la asignación de artículo con id {id}";

            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo eliminar la asignación de artículo.", false));
        }
    }
}
