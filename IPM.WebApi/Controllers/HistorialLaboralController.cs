using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;
[Authorize]
public class HistorialLaboralController : BaseApiController<HistorialLaboralController>
{
    private readonly IHistorialLaboralService _historialLaboral;
    public HistorialLaboralController(IHistorialLaboralService historialLaboral)
    {
        _historialLaboral = historialLaboral;
    }

    [HttpPost("crear-historial-laboral")]
    public async Task<IActionResult> Crear([FromBody] HistorialLaboralDto historial)
    {
        var response = new Response<List<HistorialLaboralDto>>(true, "OK");
        try
        {
            if (historial == null)
            {
                response.Update(true, "Datos no proporcionado", null);
                return Ok(response);
            }
            await _historialLaboral.CreearHistoriaLaboralAsync(historial);
            return Created("", response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo crear.", null));
        }


    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(int id, [FromBody] EditarHistoriaLaboral historial)
    {

        var response = new Response<string>(true, "OK");

        try
        {
            // Lógica para actualizar la actividad
            var actualizado = await _historialLaboral.EditarHistoriaLaboralAsync(id, historial);

            if (!actualizado)
            {
                response.Update(false, $"No se pudo actualizar el dato con id {id}.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "Curso actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el dato con id {id}";

            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar el dato.", null));
        }
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        var response = new Response<List<EliinarHistoriaLaboral>>(true, "OK");
        try
        {

            response.Success = await _historialLaboral.EliminarHistoriaLaboralAsync(id);
            response.Message = response.Success ? "se elimino correctamente"
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
