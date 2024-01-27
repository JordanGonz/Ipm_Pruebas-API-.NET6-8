using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
     public  class BajaEquiposDto
    {
        [JsonPropertyName(" idBajaEquipo")]
        public int IdBajaEquipo { get; set; }

        [JsonPropertyName(" idEquipo")]
        public int? IdEquipo { get; set; }

        [JsonPropertyName(" observacion")]
        public string? Observacion { get; set; }

        [JsonPropertyName(" motivoBaja")]
        public string? MotivoBaja { get; set; }

        
    }

    public class BajaEquiposCreacionDto
    {
        

        [JsonPropertyName(" idEquipo")]
        public int? IdEquipo { get; set; }

        [JsonPropertyName(" observacion")]
        public string? Observacion { get; set; }

        [JsonPropertyName(" motivoBaja")]
        public string? MotivoBaja { get; set; }


    }
}
