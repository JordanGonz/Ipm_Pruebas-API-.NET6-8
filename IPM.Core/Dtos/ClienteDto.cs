using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class ClienteDto
    {


        public int IdEmpresa { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }

    }

    public class ConsultaCliente
    {

        public int IdCliente { get; set; }
        public int IdEmpresa { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }

    }

    public class EditarCliente
    {

        public int IdCliente { get; set; }
        public int IdEmpresa { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }

    }

    public class EliminarCliente
    {

        public int IdCliente { get; set; }
        public int IdEmpresa { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }

    }
}

