using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IEquipoService
    {
        Task<List<EquipoDto>> ObtenerTodosLosEquipoAsync();
        Task<List<EquipoSistemOperativo>> ObtenerTodosLosEquipoSistemaOperativoAsync(string sistemaOperativo);
        Task<EquipoDto> ObtenerEquipoPorIdAsync(int idEquipo);
        Task<bool> CrearEquipoAsync(EquipoCreacionDto equipoCreacionDto);
        Task<bool> ActualizarEquipoAsync(int  idEquipo, EquipoDto equipoDto);
        Task<bool> EliminarEquipoAsync(int idEquipo);
    }
}
