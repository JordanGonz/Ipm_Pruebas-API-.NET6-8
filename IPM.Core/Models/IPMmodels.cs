using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using static IPM.Core.Models.IPMmodels;

namespace IPM.Core.Models
{
    internal class IPMmodels
    {
        public class Usuarios
        {

            [JsonPropertyName("id")]
            public int UsuarioId { get; set; }

            [JsonPropertyName("usuario")]
            public string Usuario { get; set; }

            [JsonPropertyName("rol")]
            public int RoleId { get; set; }

            [JsonPropertyName("nombreRol")]
            public string NombreRol { get; set; }

            [JsonPropertyName("nombresCompletos")]
            public string NombresCompletos { get; set; }

            [JsonPropertyName("identificacion")]
            public string Identificacion { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("Contraseña")]
            public string Contraseña { get; set; }
            [JsonPropertyName("ConfirmarContraseña")]
            public string ConfirmarContraseña { get; set; }

            [JsonPropertyName("Restablecer")]
            public bool Restablecer { get; set; }

            [JsonPropertyName("Confirmado")]
            public bool Confirmado { get; set; }

            // Relación con Roles
            public ICollection<Rol> Roles { get; set; }
            public virtual ICollection<RolUsuario> RolUsuarios { get; set; }


        }

        public class Rol
        {

            [JsonPropertyName("RolId")]
            public int RolId { get; set; }

            [JsonPropertyName("Nombre")]
            public string Nombre { get; set; }

            [JsonPropertyName("Estado")]
            public bool Estado { get; set; }

            // Relación con Usuarios
            public ICollection<Usuarios>? Usuarios { get; set; }

            // Relación con Permisos a través de la tabla de asignación RolPermiso
            public ICollection<RolPermiso>? RolesPermisos { get; set; }

            public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
        }

        public class RolPermiso
        {
            [JsonPropertyName("RolPermisoID")]
            public int RolPermisoID { get; set; }
            [JsonPropertyName("AllowRead")]
            public bool AllowRead { get; set; }
            [JsonPropertyName("AllowCreate")]
            public bool AllowCreate { get; set; }
            [JsonPropertyName("AllowUpdate")]
            public bool AllowUpdate { get; set; }
            [JsonPropertyName("AllowDelete")]
            public bool AllowDelete { get; set; }
            [JsonPropertyName("Estado")]
            public bool Estado { get; set; }
            [JsonPropertyName("RolId")]

            public int RolId { get; set; }

        }


        public class RolUsuario
        {
            [JsonPropertyName("RolId")]
            public int RolUsuarioId { get; set; }
           
            // Clave foránea para Usuario
            [JsonPropertyName("UsuarioId")]
            public int UsuarioId { get; set; }
            [JsonPropertyName("Usuario")]
            public Usuarios Usuario { get; set; }
            [JsonPropertyName("RolId")]

            // Clave foránea para Rol
            public int RolId { get; set; }
            [JsonPropertyName("Rol")]
            public Rol Rol { get; set; }
        }


    }
}