using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class LiderDto
    {
        public int IdLider { get; set; }

        public int IdCliente { get; set; }

        public int IdPersona { get; set; }

        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

    }
}