using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class CatalogoDto
    {
        [JsonPropertyName("id")]
        public int IdCatalogo { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = null!;
        [JsonPropertyName("nemonico")]
        public string? Nemonico { get; set; }
        [JsonPropertyName("estado")]
        public string Estado { get; set; } = null!;
        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [JsonPropertyName("Usuario creacion")]
        public string UsuarioCreacion { get; set; } = null!;
        [JsonPropertyName("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }
        [JsonPropertyName("UsuarioModificacion")]
        public string? UsuarioModificacion { get; set; }
    }
}