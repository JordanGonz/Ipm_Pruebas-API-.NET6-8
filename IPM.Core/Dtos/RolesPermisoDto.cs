using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class RolesPermisoDto
    {
        [JsonPropertyName("idRolPermiso")]
        public int RolPermisoId { get; set; }

        [JsonPropertyName("idRol")]
        public int RolId { get; set; }

        [JsonPropertyName("idPermiso")]
        public int PermisoId { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }
    }


    public class RolesCreacionPermiso
    {

        [JsonPropertyName("idRol")]
        public int RolId { get; set; }

        [JsonPropertyName("idPermiso")]
        public int PermisoId { get; set; }

      

    }
}
