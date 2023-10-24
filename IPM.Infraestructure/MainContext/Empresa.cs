using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Empresa
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

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual CatalogoDetalle EstadoNavigation { get; set; } = null!;
}
