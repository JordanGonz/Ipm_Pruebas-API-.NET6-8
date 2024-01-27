using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{

    public class Asignacionitem
    {
        public string? tipo_complemento { get; set; }

        public string? marca { get; set; }

        public string? modelo { get; set; }
    }
    public class AsignacionDto
    {

        public DateTime? FechaAsignacion { get; set; }

        public string? Persona { get; set; }

        public string? NombreEquipo { get; set; }
        public string? codigo { get; set; }

        public string? marca { get; set; }
        public string? modelo { get; set; }

        public string? serviceTag { get; set; }
        public string? expressServiceCode { get; set; }

        public string? color { get; set; }
        public string? procesador { get; set; }

        public string? memoria { get; set; }
        public string? discoDuro { get; set; }

        public string? sistemaOperativo { get; set; }



        public string? lector { get; set; }

        public string? conectividad { get; set; }
        public string? camara { get; set; }

        public string? pantalla { get; set; }
        public string? usb { get; set; }

        public string? batería { get; set; }
        public string? office { get; set; }

        public string? cargadorModel { get; set; }



        public string? serial { get; set; }
        public string? marcaMouse { get; set; }

        public string? modeloMouse { get; set; }
        public string? serieMouse { get; set; }
        public List<Asignacionitem> Articulos { get; set; }



    }

    public class AsignacionPorIdDto
    {
        public int IdAsignacion { get; set; }

        public DateTime? FechaAsignacion { get; set; }

        public int? IdPersona { get; set; }

        public int? IdEquipo { get; set; }



    }
    public class AsignacionActualizarDtos 
    {
        public int IdAsignacion { get; set; }

        public DateTime? FechaAsignacion { get; set; }

        public int? IdPersona { get; set; }

        public int? IdEquipo { get; set; }

    }

    public class AsignacionCrearDtos
    {
        [JsonPropertyName("fechaAsignacion")]
        public DateTime? FechaAsignacion { get; set; }
        [JsonPropertyName("idPersona")]
        public int? IdPersona { get; set; }
        [JsonPropertyName("idEquipo")]
        public int? IdEquipo { get; set; }
        [JsonPropertyName("observacion")]
        public string Observacion { get; set; } = "";


    }
}
