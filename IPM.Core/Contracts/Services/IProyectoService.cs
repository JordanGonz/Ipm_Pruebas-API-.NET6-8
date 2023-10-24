using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IProyectoService
    {
        Task<List<ProyectoDto>> ObtenerTodosLosProyectos();
        Task<ProyectoDto> ObtenerProyectoPorId(int idProyecto);
        Task<ProyectoDto> CrearProyecto(ProyectoDto proyectoDto);
        Task<bool> ActualizarProyecto(int idProyecto, ProyectoDto proyectoDto);
        Task<bool> EliminarProyecto(int idProyecto);
    }
}
