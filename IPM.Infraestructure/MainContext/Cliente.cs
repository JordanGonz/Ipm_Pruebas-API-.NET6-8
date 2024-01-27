namespace IPM.Infraestructure.MainContext;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdEmpresa { get; set; }

    public int TipoIdentificacion { get; set; }

    public string NumeroIdentificacion { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string? NombreComercial { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
