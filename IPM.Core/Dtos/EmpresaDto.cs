using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class EmpresaDto
    {

        public int IdEmpresa { get; set; }

        public string NumeroRuc { get; set; } = null!;

        public string RazonSocial { get; set; } = null!;

        public string? NombreComercial { get; set; }

        public string Email { get; set; } = null!;

        public string? Celular { get; set; }

        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}