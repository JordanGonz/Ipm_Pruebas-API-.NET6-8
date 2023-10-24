using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class UsuarioDto
    {
        [JsonPropertyName("idUsuario")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("contraseña")]
        public string? Contraseña { get; set; }

        [JsonPropertyName("confirmarClave")]
        public string? ConfirmarClave { get; set; }

        [JsonPropertyName("restablecer")]
        public bool? Restablecer { get; set; }

        [JsonPropertyName("confirmado")]
        public bool? Confirmado { get; set; }
    }
}
