using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class CatalogoDetalleDto
    {
        [JsonPropertyName("idCatalogoDetalle")]
        public int IdCatalogoDetalle { get; set; }

        [JsonPropertyName("idCatalogo")]
        public int IdCatalogo { get; set; }
        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }
        [JsonPropertyName("nemonico")]
        public string? Nemonico { get; set; }
        [JsonPropertyName("estado")]
        public string? Estado { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [JsonPropertyName("usuarioCreacion")]
        public string? UsuarioCreacion { get; set; }
        [JsonPropertyName("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; }
        [JsonPropertyName("usuarioModificacion")]
        public string? UsuarioModificacion { get; set; }
        [JsonPropertyName("tipoIdentificacion")]
        public string? TipoIdentificacion { get; set; }
        [JsonPropertyName("genero")]
        public string? Genero { get; set; }
        [JsonPropertyName("cargo")]
        public string? Cargo { get; set; }
    }
}