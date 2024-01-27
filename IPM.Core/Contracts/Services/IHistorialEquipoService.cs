using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services;

public interface IHistorialEquipoService
{
    Task<List<HistorialAsignacionEquipos>> ObtenerHistorialAsignacionEquiposAync(int idEquipo);
    Task<List<HistorialMantenimientoEquipo>> ObtenerHistoriallMantenimientoEquipoAsync(int idEquipo);

    Task<List<HistorialBajaEquipo>> ObtenerHistoriaBajaEquipoAsync(int idEquipo);
    Task<HistorialEquipoDto> ObtenerHistorialEquipoAsync(int idEquipo);
}
