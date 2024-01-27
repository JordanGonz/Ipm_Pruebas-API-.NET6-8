using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public  interface IEquipoRepostirory
    {

        Task<List<Equipo>> ObtenerTodosAsync();
        Task<List<Equipo>> ObtenerTodosSistemaOperativosAsync(string sistemaOperativo);
        Task<Equipo> ObtenerPorIdAsync(int idEquipo);
        Task<bool> CrearAsync(Equipo equipo);
        Task<bool> ActualizarAsync(Equipo equipo);
        Task<bool> EliminarAsync(int idEquipo);
    }
}
