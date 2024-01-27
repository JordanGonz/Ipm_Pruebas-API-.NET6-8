using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class CatalogoItemDto
    {
        [JsonPropertyName("id")]
        public int IdCatalogo { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("nemonico")]
        public string? Nemonico { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [JsonPropertyName("usuarioCreacion")]
        public string UsuarioCreacion { get; set; } = null!;


    }

    public class CatalogoDto
    {
        [JsonPropertyName("id")]
        public int IdCatalogo { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

       
    }


    public class CatalogoCreacionDTO
    {


        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = null!;

        [JsonPropertyName("nemonico")]
        public string? Nemonico { get; set; }
        [JsonPropertyName("nombre")]
        public string NombreMostrar { get; set; }


    }

    public class CatalogoMostrarNombre
    {

        [JsonPropertyName("nemonico")]
        public string? Nemonico { get; set; }

        [JsonPropertyName("nombre")]
        public string? NombreMostrar { get; set; }


    }
}

