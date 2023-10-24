using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IProyectoDetalleService
    {
        Task<List<ProyectoDetalleDto>> ObtenerTodosLosProyectoDetalle();
        Task<ProyectoDetalleDto> ObtenerProyectoDetallePorId(int idProyectoDetalle);
        Task<ProyectoDetalleDto> CrearProyectoDetalle(ProyectoDetalleDto proyectoDetalleDto);
        Task<bool> ActualizarProyectoDetalle(int idProyectoDetalle, ProyectoDetalleDto proyectoDetalleDto);
        Task<bool> EliminarProyectoDetalle(int idProyectoDetalle);
    }
}
