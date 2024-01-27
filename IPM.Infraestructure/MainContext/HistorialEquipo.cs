using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class HistorialEquipo
{
    public int IdHistorialE { get; set; }

    public string? TipoMantenimiento { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion1 { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
