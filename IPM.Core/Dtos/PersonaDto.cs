using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace IPM.Core.Dtos;

public class PersonaDto
{
    [JsonPropertyName("idPersona")]
    public int IdPersona { get; set; }

    [JsonPropertyName("tipoIdentificacion")]
    public int TipoIdentificacion { get; set; }

    [JsonPropertyName("numeroIdentificacion")]
    public string NumeroIdentificacion { get; set; } = null!;

    [JsonPropertyName("nombres")]
    public string Nombres { get; set; } = null!;

    [JsonPropertyName("apellidos")]
    public string Apellidos { get; set; } = null!;

    [JsonPropertyName("genero")]
    public int Genero { get; set; }

    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    [JsonPropertyName("emailPersonal")]
    public string EmailPersonal { get; set; } = null!;

    [JsonPropertyName("emailCorporativo")]
    public string? EmailCorporativo { get; set; }

    [JsonPropertyName("celular")]
    public string? Celular { get; set; }

    [JsonPropertyName("direccionDomicilio")]
    public string DireccionDomicilio { get; set; } = null!;

    [JsonPropertyName("estado")]
    public string Estado { get; set; }

    [JsonPropertyName("fechaCreacion")]
    public DateTime FechaCreacion { get; set; }

    [JsonPropertyName("usuarioCreacion")]
    public string UsuarioCreacion { get; set; } = null!;

    [JsonPropertyName("fechaModificacion")]
    public DateTime? FechaModificacion { get; set; }

    [JsonPropertyName("usuarioModificacion")]
    public string? UsuarioModificacion { get; set; }


}

public class PersonaCreacionDTO
{


    [JsonPropertyName("tipoIdentificacion")]
    public int TipoIdentificacion { get; set; }

    [JsonPropertyName("numeroIdentificacion")]
    public string NumeroIdentificacion { get; set; } = null!;

    [JsonPropertyName("nombres")]
    public string Nombres { get; set; } = null!;

    [JsonPropertyName("apellidos")]
    public string Apellidos { get; set; } = null!;

    [JsonPropertyName("genero")]
    public int Genero { get; set; }

    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    [JsonPropertyName("emailPersonal")]
    public string EmailPersonal { get; set; } = null!;

    [JsonPropertyName("emailCorporativo")]
    public string? EmailCorporativo { get; set; }

    [JsonPropertyName("celular")]
    public string? Celular { get; set; }
    [JsonPropertyName("imagen")]
    public IFormFile? Imagen { get; set; }

    [JsonPropertyName("direccionDomicilio")]
    public string DireccionDomicilio { get; set; } = null!;

}

public class InformacionPersonaDto
{
    public string Correo { get; set; }
    public string username { get; set; }
    public string Numero { get; set; }
    public string Linkedin { get; set; }
    public string Github { get; set; }
    public string Imagen { get; set; }
    public int Id { get; set; }


}

public class InformacionActualizarPersonaDto
{
    public int Id { get; set; }
    public string Correo { get; set; }
    public string username { get; set; }
    public string Numero { get; set; }
    public string Linkedin { get; set; }
    public string Github { get; set; }
  
}
