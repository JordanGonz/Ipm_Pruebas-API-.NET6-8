using AutoMapper;
using Azure.Identity;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.EquiposOficina;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using IPM.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Services;

public class HistorialEquipoService : IHistorialEquipoService
{
        private readonly IHistorialEquipoRepository _historialEquipoRepository;
        private readonly IEquipoRepostirory _iEquipoRepostirory;
        private readonly IMapper _mapper;

    public HistorialEquipoService(IHistorialEquipoRepository historialEquipoRepository, IEquipoRepostirory iEquipoRepostirory, IMapper mapper)
    {
        _historialEquipoRepository = historialEquipoRepository;
        _iEquipoRepostirory = iEquipoRepostirory;
        _mapper = mapper;

    }

    public async Task<List<HistorialAsignacionEquipos>> ObtenerHistorialAsignacionEquiposAync(int idEquipo)
    {
        var asignacion = await _historialEquipoRepository.ObtenerAsignacionesPorEquipoAsync(idEquipo);
        return _mapper.Map<List<HistorialAsignacionEquipos>>(asignacion);
    }

    public async Task<List<HistorialMantenimientoEquipo>> ObtenerHistoriallMantenimientoEquipoAsync(int idEquipo)
    {
        var asignacion = await _historialEquipoRepository.ObtenerMantenimientosPorEquipoAsync(idEquipo);
        return _mapper.Map<List<HistorialMantenimientoEquipo>>(asignacion);
    }
    public async Task<List<HistorialBajaEquipo>> ObtenerHistoriaBajaEquipoAsync(int idEquipo)
    {
        var asignacion = await _historialEquipoRepository.ObtenerBajasPorEquipoAsync(idEquipo);
        return _mapper.Map<List<HistorialBajaEquipo>>(asignacion);
    }
    public async Task<HistorialEquipoDto> ObtenerHistorialEquipoAsync(int idEquipo)
    {
        HistorialEquipoDto historialEquipo = new();


        //TODO: Obtener datos o detalles del equipo de EquipoService
        //mapearlas al objeto EquipoOficina.
        var equipo = await _iEquipoRepostirory.ObtenerPorIdAsync(idEquipo);
        var infoEquipo = _mapper.Map<EquipoOficina>(equipo); //resultado del mapper 
        historialEquipo.InformacionEquipo = infoEquipo;


        var historialAsignacionEquipos = await ObtenerHistorialAsignacionEquiposAync(idEquipo);
        var historialMantenimientoEquipo = await ObtenerHistoriallMantenimientoEquipoAsync(idEquipo);
        var historialBajaEquipo = await ObtenerHistoriaBajaEquipoAsync(idEquipo);


        historialEquipo.HistorialDetalleMovimientosEquipo = new HistorialDetalleMovimientoEquipo
        {
            HistorialAsignacionEquipos = historialAsignacionEquipos,
            HistorialMantenimientoEquipo = historialMantenimientoEquipo,
            HistorialBajaEquipo = historialBajaEquipo
        };


        return historialEquipo;
    }
}

        //HistorialEquipoDto responseHistorialEquipo = new();
        ////TODO: llamar al metodo del service de equiposRepository para traer los datos del equipo por ID
        ////responseHistorialEquipo.IdEquipo = idEquipo;

        ////TODO: llamar al método del service AsignacionRepository para traer el historial de asignacion
        //responseHistorialEquipo.HistorialDetalleMovimientosEquipo = new();
        ////responseHistorialEquipo.HistorialDetalleMovimientosEquipo.HistorialAsignacionEquipos = responseServiceAsignacionEquipos,
    
            //var historialDetalle = await _historialEquipoRepository.ObtenerHistorialEquipoAsync(idEquipo);

            //if (historialDetalle == null)
            //{
            //    // Puedes manejar la lógica si no se encuentra el historial del equipo
            //    return null;
            //}

            //// Mapeo de HistorialEquipo a HistorialEquipoDto
            //var historialEquipoDto = new HistorialEquipoDto
            //{
            //    IdEquipo = historialDetalle.Id,
            //    HistorialDetalleMovimientosEquipo = new HistorialDetalleMovimientoEquipo
            //    {
            //        HistorialAsignacionEquipos = asignaciones
            //            .Select(a => new HistorialAsignacionEquipos
            //            {
            //                NombrePersona = a.IdPersonaNavigation.Nombres,
            //                Fecha = a.FechaAsignacion
            //            })
            //            .ToList(),
            //        HistorialMantenimientoEquipo = mantenimientos
            //            .Select(m => new HistorialMantenimientoEquipo
            //            {
            //                NombreTecnico = m.NombreTecnico,
            //                NombreRespuesto = m.NombreRespueto
            //            })
            //            .ToList(),
            //        HistorialBajaEquipo = bajas
            //            .Select(b => new HistorialBajaEquipo
            //            {
            //                Observacion = b.Observacion,
            //                MotivoBaja = b.MotivoBaja
            //            })
            //            .ToList()
            //    }
            //};

            //return historialEquipoDto;
        