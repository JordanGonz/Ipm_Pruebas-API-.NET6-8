using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public string? TipoComplemento { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<AsignacionArticulo> AsignacionArticulos { get; set; } = new List<AsignacionArticulo>();
}
