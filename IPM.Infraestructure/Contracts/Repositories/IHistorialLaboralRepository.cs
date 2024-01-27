using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories;

public interface IHistorialLaboralRepository
{
    Task<bool> CreearHistoriaLaboralAsync(HistorialLaboral historial);
    Task<bool> EditarHistoriaLaboralAsync( EditarHistoriaLaboral historial);
    Task<bool> EliminarHistoriaLaboralAsync(int id);
}
