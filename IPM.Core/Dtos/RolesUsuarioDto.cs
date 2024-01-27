using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class RolesUsuarioDto
    {
        [JsonPropertyName("idRolesRol")]
        public int RolesRolId { get; set; }

        [JsonPropertyName("idUsuariosUsuario")]
        public int UsuariosUsuarioId { get; set; }

        [JsonPropertyName("estado")]
        public string? Estado { get; set; }
    }

    public class RolesUsuarioPorToken
    {
        [JsonPropertyName("rol")]
        public RolesUsuario[] Roles { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
    }

    public class RolesUsuario
    {
        public int IdRol { get; set; }
        public string? NombreRol { get; set; }

    }
}
