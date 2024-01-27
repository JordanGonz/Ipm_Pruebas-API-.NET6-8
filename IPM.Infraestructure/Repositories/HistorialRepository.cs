using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using IPM.Infraestructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Repositories;

internal class HistorialRepository : IHistorialEquipoRepository
{

    private readonly IntegrityProjectManagementContext _context;

    public HistorialRepository(IntegrityProjectManagementContext context)
    {
        _context = context;
    }
  

    public async Task<List<HistorialAsignacionEquipos>> ObtenerAsignacionesPorEquipoAsync(int idEquipo)
    {

        var asignaciones = await _context.AsignacionArticulos
                .Include(a => a.IdArticuloNavigation)
                .Include(a => a.IdAsignacionNavigation)
                .Where(a => a.IdAsignacionNavigation.IdEquipoNavigation.IdEquipo == idEquipo)
                .GroupBy(a => new
                {
                    FechaAsignacion = a.IdAsignacionNavigation.FechaAsignacion,
                    Persona = a.IdAsignacionNavigation.IdPersonaNavigation.Nombres + " " + a.IdAsignacionNavigation.IdPersonaNavigation.Apellidos,
                    
                })
                .Select(g => new HistorialAsignacionEquipos
                {
                    FechaAsignacion = g.Key.FechaAsignacion,
                    Persona = g.Key.Persona,
                   

                    Articulos = g.Select(a => new ArticulosDto
                    {
                        tipo_complemento = a.IdArticuloNavigation.TipoComplemento,
                        marca = a.IdArticuloNavigation.Marca,
                        modelo = a.IdArticuloNavigation.Modelo
                    }).ToList()


                })
                .ToListAsync();
        return asignaciones;


    }

    public async Task<List<HistorialMantenimientoEquipo>> ObtenerMantenimientosPorEquipoAsync(int idEquipo)
    {
        var asignaciones = await _context.Mantenimientos
                .Where(a => a.IdEquipoNavigation.IdEquipo == idEquipo)
                .GroupBy(a => new
                {
                    Descripcion = a.Descripcion,
                    Costo = a.Costo,
                    NombreRespueto = a.NombreRespueto,
                    NombreTecnico = a.NombreTecnico,
                    FechaMantenimineto = a.FechaMantenimineto,
                })
                .Select(g => new HistorialMantenimientoEquipo
                {
                    Descripcion = g.Key.Descripcion,
                    Costo = g.Key.Costo,
                    NombreRespueto = g.Key.NombreRespueto,
                    NombreTecnico = g.Key.NombreTecnico,
                    FechaMantenimineto = g.Key.FechaMantenimineto,


                })
                .ToListAsync();
        return asignaciones;

    }
    public async Task<List<HistorialBajaEquipo>> ObtenerBajasPorEquipoAsync(int idEquipo)
    {
        var asignaciones = await _context.BajaEquipos
                .Where(a => a.IdEquipoNavigation.IdEquipo == idEquipo)

                .Select(g => new HistorialBajaEquipo
                {
                    Observacion = g.Observacion,
                    MotivoBaja = g.MotivoBaja,



                })
                .ToListAsync();
        return asignaciones;
    }
}
