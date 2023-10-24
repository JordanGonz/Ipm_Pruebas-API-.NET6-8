using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace IPM.Core.Dtos
{
    public class ProyectoDto
    {
        [JsonPropertyName("idproyecto")]
        public int IdProyecto { get; set; }

        [JsonPropertyName("idCliente")]
        public int IdCliente { get; set; }

        [JsonPropertyName("idLiderPrincipal")]
        public int IdLiderPrincipal { get; set; }

        [JsonPropertyName("CodigoProyecto")]
        public string CodigoProyecto { get; set; } = null!;

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = null!;

        [JsonPropertyName("fechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("fechaFin")]
        public DateTime? FechaFin { get; set; }

        [JsonPropertyName("estado")]
        public int Estado { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonPropertyName("usuarioCreacion")]
        public string UsuarioCreacion { get; set; } = null!;

        [JsonPropertyName("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [JsonPropertyName("usuarioModificacion")]
        public string? UsuarioModificacion { get; set; }

        
        


    }
}
