using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class ProyectoDetalleDto
    {
        [JsonPropertyName("idProyectoDetalle")]
        public int IdProyectoDetalle { get; set; }

        [JsonPropertyName("idProyecto")]
        public int IdProyecto { get; set; }

        [JsonPropertyName("idRecurso")]
        public int IdRecurso { get; set; }

        [JsonPropertyName("idLider")]
        public int IdLider { get; set; }

        [JsonPropertyName("crgoRecurso")]
        public int CargoRecurso { get; set; }

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
