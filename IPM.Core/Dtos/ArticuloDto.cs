using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class ArticuloDto
    {
        [JsonPropertyName("idArticulo")]
        public int IdArticulo { get; set; }

        [JsonPropertyName("tipoComplemento")]
        public string? TipoComplemento { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }

        

    }


    public class ArticuloCreacionDto
    {

        

        [JsonPropertyName("tipoComplemento")]
        public string? TipoComplemento { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }

    }
}
