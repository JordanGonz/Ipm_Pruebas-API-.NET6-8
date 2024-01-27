namespace IPM.Core.Models.Clientes
{
    public record ClienteCreacion
    {
        public int TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string NombreComercial { get; set; }
        public string CorreoElectronico { get; set; } = null!;
        public string Celular { get; set; }
    }
}
