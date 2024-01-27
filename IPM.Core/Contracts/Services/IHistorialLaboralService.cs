using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services;

public interface IHistorialLaboralService
{
    Task<bool> CreearHistoriaLaboralAsync(HistorialLaboralDto historial);
    Task<bool> EditarHistoriaLaboralAsync(int id, EditarHistoriaLaboral historial);
    Task<bool> EliminarHistoriaLaboralAsync(int id);
}
