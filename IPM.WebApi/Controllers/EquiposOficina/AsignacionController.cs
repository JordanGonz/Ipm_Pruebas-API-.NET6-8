using Microsoft.AspNetCore.Mvc;
using IPM.Core.Dtos; 

using IPM.Core.Models.ApiResponse;
using IPM.Core.Contracts.Services;
using IPM.Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;

namespace IPM.WebApi.Controllers.EquiposOficina;

[Route("api/asignacion")]
[ApiController]
[Authorize]
public class AsignacionController : BaseApiController <AsignacionController>
{

    private readonly IEquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice;
    public AsignacionController(IEquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice)
    {
        _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice = EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice;
    }


    [HttpGet("obtener-todo")]
    public async Task<IActionResult> ObtenerTodasLasAsignaciones()
    {
        var response = new Response<List<AsignacionDto>>(true, "OK");
        try
        {
            response.Data = await _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice.ObtenerTodasLasAsignacionesAsync();

            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado.", null));
        }
    }



    [HttpGet("obtener-por-id-usuario")]
    public async Task<IActionResult> ObtenerTodasLasAsignaciones(int id)
    {
        var response = new Response<List<AsignacionDto>>(true, "OK");
        try
        {
            response.Data = await _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice.ObtenerLasAsignacionesPorUsuariosAsync(id);
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

    [HttpPost("crear-asignacion")]
    public async Task<IActionResult> Crear([FromBody] AsignacionCrearDtos asignacionCrearDtos)
    {
        var response = new Response<List<AsignacionCrearDtos>>(true, "OK");
        try
        {
            if (asignacionCrearDtos == null )
            {
                response.Update(true, "Datos de asignaciones no proporcionado", null);
                return Ok(response);
            }
            await _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice.CrearTodasLasAsignacionesAsync(asignacionCrearDtos);
            return Created("", response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo crear la asigancion.", null));
        }


    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(int id, [FromBody] AsignacionActualizarDtos actualizardto)
    {

        var response = new Response <string>(true, "OK");

        try
        {
            // Lógica para actualizar la actividad
            var actualizado = await _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice.ActualizarAsigancionesAsync(id, actualizardto);

            if (!actualizado)
            {
                response.Update(false, $"No se pudo actualizar la actividad con id {id}.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "Actividad actualizada con éxito"
                : $"Lo sentimos, no se pudo actualizar la actividad con id {id}";

            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar la actividad.", null));
        }
    }

   

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsinacion(int id)
    {
        var response = new Response<List<AsignacionCrearDtos>>(true, "OK");
        try
        {

            response.Success = await _EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice.DeleteAsignacion(id);
            response.Message = response.Success ? "se borro"
                : $"no se borro id {id}";
            //throw new Exception("test");
            return Ok(response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo eliminar.", null));
        }
    }


}

