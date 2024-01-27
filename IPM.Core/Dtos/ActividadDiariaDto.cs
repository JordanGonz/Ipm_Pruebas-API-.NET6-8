using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{

    public class ActividadProyectoCreacionDto
    {
        
        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("idProyecto")]
        public int IdProyecto { get; set; }

        [JsonPropertyName("idTipoActividad")]
        public int IdTipoActividad { get; set; }

        [JsonPropertyName("hora")]
        public decimal? Hora { get; set; }

        [JsonPropertyName("fechaActividad")]
        public DateTime? FechaActividad { get; set; }

    }
    public class ActividadDiariaDto
    {
        [JsonPropertyName(" idActividadDiaria")]
        public int IdActividadDiaria { get; set; }
        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }
        [JsonPropertyName("idProyecto")]
        public int IdProyecto { get; set; }
        [JsonPropertyName("idTipoActividad")]
        public int IdCatalogo { get; set; }
        [JsonPropertyName("hora")]
        public decimal? Hora { get; set; }

        [JsonPropertyName("fechaActividad")]
        public DateTime? FechaActividad { get; set; }




    }



    public class ActividadDiariaConsulta
    {
        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("hora")]
        public decimal? Hora { get; set; }
        [JsonPropertyName("codigoProyecto")]
        public string? CodigoProyecto { get; set; }
        [JsonPropertyName("nombreProyecto")]
        public string? NombreProyecto { get; set; }
        [JsonPropertyName("tipoActividad")]
        public string? TipoActividad { get; set; }
        [JsonPropertyName("fechaActividad")]
        public DateTime? FechaActividad { get; set; }
        [JsonPropertyName("idUsuario")]
        public int? UsuarioId { get; set; }
    }

    public class ActividadDiariaPorDia
    {
        [JsonPropertyName("fechaActividadPorDia")]
        public DateTime? FechaActividadPorDia { get; set; }
        
        [JsonPropertyName("listaActividadesDelDia")]
        public List<ActividadDiariaPorFecha>? ListaActividadDiaria { get; set; }
    }

    public class ActividadDiariaPorFecha
    {
        [JsonPropertyName("descripcionActividad")]
        public string? DescripcionActividad { get; set; }

        [JsonPropertyName("cantidadHoras")]
        public decimal? CantidadHoras { get; set; }

        [JsonPropertyName("codigoProyecto")]
        public string? CodigoProyecto { get; set; }
        [JsonPropertyName("liderProyecto")]
        public string[]? NombreLideres { get; set; }

        [JsonPropertyName("nombreProyecto")]
        public string? NombreProyecto { get; set; }

        [JsonPropertyName("tipoActividad")]
        public string? TipoActividad { get; set; }
       
        [JsonPropertyName("fechaActividad")]
        public DateTime? FechaActividad { get; set; }
        
    }

    public class ReporteExcelTimeReport
    {
        [JsonPropertyName("descripcionActividad")]
        public string? DescripcionActividad { get; set; }

        [JsonPropertyName("cantidadHoras")]
        public decimal? CantidadHoras { get; set; }

        [JsonPropertyName("codigoProyecto")]
        public string? CodigoProyecto { get; set; }
        [JsonPropertyName("liderProyecto")]
        public string[]? NombreLideres { get; set; }

        [JsonPropertyName("nombreProyecto")]
        public string? NombreProyecto { get; set; }

        [JsonPropertyName("tipoActividad")]
        public string? TipoActividad { get; set; }

        [JsonPropertyName("fechaActividad")]
        public DateTime? FechaActividad { get; set; }

        [JsonPropertyName("nombreUsuario")]
        public string? Nombre { get; set; }

        [JsonPropertyName("clienteProyecto")]
        public string? cliente { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime FechaDesde { get; set; }

        [JsonPropertyName("fechaHasta")]
        public DateTime FechaHasta { get; set; }

    }

    public class CalendarioPorfechayUsuario
    {
        public int  IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
