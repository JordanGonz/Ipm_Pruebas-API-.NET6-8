using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class PermisoDto
    {
        [JsonPropertyName(" id")]
        public int PermisoId { get; set; }

        [JsonPropertyName(" nombre")]

        public string Nombre { get; set; }

        [JsonPropertyName(" estado")]

        public bool Estado { get; set; }
    }
}
