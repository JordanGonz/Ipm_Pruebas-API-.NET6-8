﻿using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace IPM.WebApi.Controllers;

[Route("api/actividad-diaria")]
[ApiController]
[Authorize]
public class ActividadDiariaController : BaseApiController<ActividadDiariaController>
{
    private readonly IActividadDiariaService _actividadProyectoCatalogoservice;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ActividadDiariaController(IActividadDiariaService actividadProyectoCatalogoservice, IHttpContextAccessor httpContextAccessor)
    {
        _actividadProyectoCatalogoservice = actividadProyectoCatalogoservice;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] ActividadProyectoCreacionDto actividadProyectoCreacionDto)
    {
        var response = new Response<List<ActividadDiariaDto>>(true, "OK");
        try
        {
            if (actividadProyectoCreacionDto == null)
            {
                response.Update(false, "Datos de actividad no proporcionados.", null);
                return BadRequest(response);
            }

            await _actividadProyectoCatalogoservice.CreateActividadDiariumAsync(actividadProyectoCreacionDto);
            return Created("", response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo agregar.", null));
        }
    }


    [HttpGet("obtener-por-descripcion")]
    public async Task<IActionResult> GetActividadesDiariums(string Descripcion)
    {
        var response = new Response<List<ActividadDiariaConsulta>>(true, "OK");
        try
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                response.Update(false, "no se ingreso descripcion", null);
                return BadRequest(response);
            }

            response.Data = await _actividadProyectoCatalogoservice.GetActividadDiariaAsync(Descripcion);

            if (response.Data is null || response.Data.Count == 0)
            {
                response.Update(true, "Datos no encontrados", null);
                return Ok(response);
            }
            //throw new Exception("test")
            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado por descripcion.", null));
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetActividadesDiarium()
    {
        var response = new Response<IEnumerable<ActividadDiariaConsulta>>(true, "OK");
        try
        {
            response.Data = await _actividadProyectoCatalogoservice.GetactividadProyectoCatalogodtos();
            return Ok(response);


        }
        catch (Exception)
        {
            // Manejo de errores
            return Conflict(response.Update(false, "Lo sentimos, no se pudo obtener el filtrado.", null));
        }
    }




    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarActividad(int id, [FromBody] ActividadDiariaDto actividadProyectoDto)
    {
        var response = new Response<String>(true, "OK");

        try
        {
            var actualizado = await _actividadProyectoCatalogoservice.ActualizarActividadAsync(id, actividadProyectoDto);

            if (actualizado == null)
            {
                response.Update(false, "No se pudo actualizar la actividad.", null);
                return BadRequest(response);
            }

            response.Success = actualizado;
            response.Message = response.Success ? "Actividad actualizada con éxito"
                : $"Lo sentimos, no se pudo actualizar la actividad con id {id}";
            //throw new Exception("test");

            return Ok(response);
        }
        catch (Exception)
        {
            return Conflict(response.Update(false, "Lo sentimos, no se pudo actualizar la actividad.", null));
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> DeleteActividadDiarium(int id)
    {
        var response = new Response<List<ActividadDiariaDto>>(true, "OK");
        try
        {

            response.Success = await _actividadProyectoCatalogoservice.DeleteA(id);
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


    [HttpGet("obtener-por-fechas")]
    public async Task<IActionResult> GetActividadesDiarium(DateTime fechaInicio, DateTime fechaFin)
    {
        var actividadesResponse = new Response<List<ActividadDiariaPorDia>>(true, "OK");

        try
        {
            var idPersonaClaim = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "IdPersona").Value);

            var actividadDiariaPorFechas = await _actividadProyectoCatalogoservice.GetActividadDiariaPorFecha(fechaInicio, fechaFin, idPersonaClaim);

            var actividadesAgrupadasPorDias = await _actividadProyectoCatalogoservice.DividirActividadPorDia(actividadDiariaPorFechas);

            actividadesResponse.Data = actividadesAgrupadasPorDias;

            if (actividadesResponse.Data is null || actividadesResponse.Data.Count == 0)
            {
                actividadesResponse.Update(true, "Datos no encontrados", null);
                return Ok(actividadesResponse);
            }

            return Ok(actividadesResponse);
        }
        catch (Exception)
        {
            return Conflict(actividadesResponse.Update(false, "Lo sentimos, no se pudo obtener el filtrado por fecha.", null));
        }
    }




}
