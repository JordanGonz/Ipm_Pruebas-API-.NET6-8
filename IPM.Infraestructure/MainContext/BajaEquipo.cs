using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class BajaEquipo
{
    public int IdBajaEquipo { get; set; }

    public int? IdEquipo { get; set; }

    public string? Observacion { get; set; }

    public string? MotivoBaja { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }
}
