using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace IPM.Core.Dtos
{
    public class RoleDto
    {
        [JsonPropertyName("idRol")]
        public int RolId { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }
    }


    public class RoleCreacionDto
    {

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }


    }
}
