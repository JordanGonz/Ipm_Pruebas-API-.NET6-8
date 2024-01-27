using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;
[Authorize]
public class FeedbackProgresoHistoricoController : Controller
{
    private readonly IFeedbackProgresoHistoricoService _feedback;
    public FeedbackProgresoHistoricoController(IFeedbackProgresoHistoricoService feedback)
    {
        _feedback = feedback;
    }

    [HttpPost("crear-feedback-progreso")]
    public async Task<IActionResult> Crear([FromBody] FeedbackProgresoHistoricoDto feedback)
    {
        var response = new Response<List<HistorialLaboralDto>>(true, "OK");
        try
        {
            if (feedback == null)
            {
                response.Update(true, "Datos no proporcionado", null);
                return Ok(response);
            }
            await _feedback.CreearFeedbackProgresoHistoricoAsync(feedback);
            return Created("", response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo crear.", null));
        }


    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(int id, [FromBody] FeedBackEditar feedback)
    {

        var response = new Response<string>(true, "OK");

        try
        {
            // Lógica para actualizar la actividad
            var actualizado = await _feedback.EditarFeedbackProgresoHistoricoAsync(id, feedback);

            if (!actualizado)
            {
                response.Update(false, $"No se pudo actualizar el dato con id {id}.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "dato actualizado con éxito"
                : $"No se pudo actualizar el dato con id {id}";

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
        var response = new Response<List<FeedBackEliminar>>(true, "OK");
        try
        {

            response.Success = await _feedback.EliminarFeedbackProgresoHistoricoAsync(id);
            response.Message = response.Success ? "Dato eliminado con exito"
                : $"No se elimino el dato con id {id}";
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
