using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class AsignacionArticulo
{
    public int IdAsignacionArticulo { get; set; }

    public int? IdAsignacion { get; set; }

    public int? IdArticulo { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Articulo? IdArticuloNavigation { get; set; }

    public virtual EquipoPersonaAsignacion? IdAsignacionNavigation { get; set; }
}
