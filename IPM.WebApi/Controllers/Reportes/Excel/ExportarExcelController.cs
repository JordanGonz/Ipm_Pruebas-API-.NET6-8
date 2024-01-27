using Microsoft.AspNetCore.Mvc;
using IPM.Core.Contracts.Services;
using IPM.Infraestructure.Services.Reportes.Excel;
using IPM.Core.Dtos;
using IPM.Infraestructure.Validations.Timereport;
namespace IPM.WebApi.Controllers.Reportes.Excel;

[Route("api/excel/report")]
[ApiController]

public class ExportarExcelController : ControllerBase
{
    private readonly IActividadDiariaService _actividadProyectoCatalogoservice;
    private readonly ExcelService _excelService;

    public ExportarExcelController(IActividadDiariaService actividadProyectoCatalogoservice, ExcelService excelService)
    {
        _actividadProyectoCatalogoservice = actividadProyectoCatalogoservice;
        _excelService = excelService;
    }


    [HttpPost("exportar-time-report")]
    public async Task<IActionResult> ExportarActividadesDiariaExcel([FromBody] CalendarioPorfechayUsuario datos )
    {
        try
        {
            // Validar los datos antes de procesar
            var validator = new ReporteExcelActividadDiariaValidator();
            var result = validator.Validate(datos);

            if (!result.IsValid)
            {
                // Si la validación falla, devolver mensajes de error
                return BadRequest(result.Errors.Select(error => error.ErrorMessage));
            }

            DateTime fechaInicio = datos.FechaInicio;
            DateTime fechaFin = datos.FechaFin;
            int idUsuario = datos.IdUsuario;

            int mesActividadParaObtenerDiasSemana = fechaInicio.Month;

            // Obtener las actividades desde el servicio correspondiente
            var actividadesTask = _actividadProyectoCatalogoservice.GetActividadDiariaReporte( fechaInicio,  fechaFin, idUsuario);
            var actividades = await actividadesTask;

            // Obtener una ruta temporal para guardar el archivo Excel
            var rutaExcelTemporal = Path.Combine(Path.GetTempPath(), "TimeReport.xlsx");

            // Llamar al servicio de Excel para generar el archivo Excel
            var filePath = await _excelService.CrearExcel(actividades, rutaExcelTemporal, mesActividadParaObtenerDiasSemana);

            // Devolver el archivo Excel como respuesta
            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Time Report.xlsx");
        }
        catch (Exception ex)
        {
            // Manejo de errores
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }





}
