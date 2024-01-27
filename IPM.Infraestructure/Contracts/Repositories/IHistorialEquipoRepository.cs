using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories;

public interface IHistorialEquipoRepository
{
    Task<List<HistorialAsignacionEquipos>> ObtenerAsignacionesPorEquipoAsync(int idEquipo);
    Task<List<HistorialMantenimientoEquipo>> ObtenerMantenimientosPorEquipoAsync(int idEquipo);
    Task<List<HistorialBajaEquipo>> ObtenerBajasPorEquipoAsync(int idEquipo);
    //Task<HistorialEquipo> ObtenerHistorialEquipoAsync(int idEquipo);

}
