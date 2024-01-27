using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services.Reportes.Excel;

public interface IExcelService
{
    Task<string> CrearExcel(IEnumerable<Object> data, string rutaExcel, int numeroMes);
    Task<List<CalendarioDto>> ObtenerEstructuraTimeReportDiasDelMes(int numeroMes);

}
