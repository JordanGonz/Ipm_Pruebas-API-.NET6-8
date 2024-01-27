using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class HistorialLaboral
{
    public int IdHistorialPerfiles { get; set; }

    public int? IdPersona { get; set; }

    public string? Empresa { get; set; }

    public DateTime? FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public string? Cargo { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public string? DescripcionSalida { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
