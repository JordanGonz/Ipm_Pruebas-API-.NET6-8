using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class PersonaDto
    {

        public int IdPersona { get; set; }

        public int TipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Nombres { get; set; } = null!;

        public int Genero { get; set; }

        public int Cargo { get; set; }

        public string EmailPersonal { get; set; } = null!;

        public string? EmailCorporativo { get; set; }

        public string? Celular { get; set; }

        public string DireccionDomicilio { get; set; } = null!;

        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}