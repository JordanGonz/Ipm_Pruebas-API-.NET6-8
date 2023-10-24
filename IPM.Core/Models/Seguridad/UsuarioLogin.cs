using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IPM.Core.Models.Seguridad
{
    public class UsuarioLogin
    {
        [Required]
        [JsonPropertyName("usuario")]
        public string Usuario { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}