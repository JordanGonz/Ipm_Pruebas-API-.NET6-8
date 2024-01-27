using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace IPM.Core.Dtos
{
    public class UsuarioLoginDto
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idPersona")]
        public int IdPersona { get; set; }

        [JsonPropertyName("usuario")]
        public string Usuario { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }
       
    }
    public class UsuarioDto
    {
        [JsonPropertyName("id")]   
        public int UsuarioId { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonIgnore]
        public string? Contraseña { get; set; }

        [JsonPropertyName("confirmarClave")]
        public string? ConfirmarClave { get; set; }

        [JsonPropertyName("restablecer")]
        public bool? Restablecer { get; set; }

        [JsonPropertyName("confirmado")]
        public bool? Confirmado { get; set; }


        [JsonPropertyName("token")]
        public string? Token { get; set; }


        public string? Estado { get; set; }

        [JsonPropertyName("IdPersona")]
        public int? IdPersona { get; set; }
    }

    public class UsuarioCreacionDto
    {
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("contraseña")]
        public string? Contraseña { get; set; }

    }

    public class LoginDto
    {

        [JsonPropertyName("email")]
        public string Email { get; set; } = "";

        [JsonPropertyName("password")]
        public string Contraseña { get; set; } = "";
    }


    public class RegistroCompletoDto
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailCorporativo { get; set; }
        public string Celular { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Contrasena { get; set; }
        public IFormFile? Imagen { get; set; }
        public List<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();

    }







    public class RecuperarClave
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public int MyProperty { get; set; }
    }

    public class CodigoClave
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class CambioClave
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("newPassword")]
        public string NewPassword { get; set; }
    }




    public class VerifyCodeResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ChangePasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
