using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class EquipoPersonaAsignacion
{
    public int IdAsignacion { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public int? IdPersona { get; set; }

    public int? IdEquipo { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public string? Observacion { get; set; }

    public virtual ICollection<AsignacionArticulo> AsignacionArticulos { get; set; } = new List<AsignacionArticulo>();

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
