using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class ClienteDto
    {

        public int IdCliente { get; set; }
        public int IdEmpresa { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}