using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class MantenimientoDto
    {
        [JsonPropertyName("idMantenimiento")]
        public int IdMantenimiento { get; set; }

        [JsonPropertyName("idEquipo")]
        public int? IdEquipo { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("costo")]
        public decimal? Costo { get; set; }

        [JsonPropertyName("nombreRespueto")]
        public string? NombreRespueto { get; set; }

        [JsonPropertyName("nombreTecnico")]
        public string? NombreTecnico { get; set; }

        [JsonPropertyName("fechaMantenimineto")]
        public DateTime? FechaMantenimineto { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }

        [JsonPropertyName("numeroFactura")]
        public string? NumeroFactura { get; set; }

        
        
    }

    public class MantenimientoCreacionDto
    {
       

        [JsonPropertyName("idEquipo")]
        public int? IdEquipo { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("costo")]
        public decimal? Costo { get; set; }

        [JsonPropertyName("nombreRespueto")]
        public string? NombreRespueto { get; set; }

        [JsonPropertyName("nombreTecnico")]
        public string? NombreTecnico { get; set; }

        [JsonPropertyName("fechaMantenimineto")]
        public DateTime? FechaMantenimineto { get; set; }

        [JsonPropertyName("numeroFactura")]
        public string? NumeroFactura { get; set; }


    }
    
}
