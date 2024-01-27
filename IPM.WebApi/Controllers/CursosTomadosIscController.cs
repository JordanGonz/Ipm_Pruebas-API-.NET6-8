using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers;
[Authorize]

public class CursosTomadosIscController : BaseApiController<CursosTomadosIscController>
{
    private readonly ICursosTomadosIscService _cursosTomados;
    public CursosTomadosIscController(ICursosTomadosIscService cursosTomados)
    {
        _cursosTomados = cursosTomados;
    }
    [HttpPost("crear-cursos")]
    public async Task<IActionResult> Crear([FromBody] CursosTomadosIscDto cursos)
    {
        var response = new Response<List<CursosTomadosIscDto>>(true, "OK");
        try
        {
            if (cursos == null)
            {
                response.Update(true, "Datos de curso no proporcionado", null);
                return Ok(response);
            }
            await _cursosTomados.CreateCursosTomadosAsync(cursos);
            return Created("", response);
        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo crear el curso.", null));
        }


    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(int id, [FromBody] CursosTomadosEdit cursos)
    {

        var response = new Response<string>(true, "OK");

        try
        {
            // Lógica para actualizar la actividad
            var actualizado = await _cursosTomados.EditCursosTomadosAsync(id, cursos);

            if (!actualizado)
            {
                response.Update(false, $"No se pudo actualizar el curso con id {id}.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "Curso actualizado con éxito"
                : $"Lo sentimos, no se pudo actualizar el curso con id {id}";

            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar el curso.", null));
        }
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        var response = new Response<List<CursosTomadosDelete>>(true, "OK");
        try
        {

            response.Success = await _cursosTomados.DeleteCursosTomadosAsync(id);
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
