using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IBajaEquipoService
    {
        Task<List<BajaEquiposDto>> ObtenerTodosBajaEquipoAsync();
        Task<BajaEquiposDto> ObtenerBajaEquipoPorIdAsync(int IdBajaEquipo);
        Task<bool> CrearBajaEquipoAsync(BajaEquiposCreacionDto bajaEquipos);
        Task<bool> ActualizarBajaEquipoAsync(int IdBajaEquipo, BajaEquiposDto bajaEquipos);
        Task<bool> EliminarBajaEquipoAsync(int IdBajaEquipo);
    }
}
