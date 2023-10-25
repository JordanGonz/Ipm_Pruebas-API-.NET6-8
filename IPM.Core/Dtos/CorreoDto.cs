using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class CorreoDto
    {
        [JsonPropertyName("Para")]
        public string Para { get; set; }
        [JsonPropertyName("Asunto")]
        public string Asunto { get; set; }
        [JsonPropertyName("Contenido")]
        public string Contenido { get; set; }
    }
}
