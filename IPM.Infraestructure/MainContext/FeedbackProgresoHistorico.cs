using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class FeedbackProgresoHistorico
{
    public int IdFeedbackProgresoHistoricoPerfiles { get; set; }

    public int? IdPersona { get; set; }

    public string? Entrevistas { get; set; }

    public string? Observaciones { get; set; }

    public string? Alertas { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
