using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Lidere
{
    public int IdLider { get; set; }

    public int IdPersona { get; set; }

    public bool EsLiderIntegritySolutions { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaEliminacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<LiderProyecto> LiderProyectos { get; set; } = new List<LiderProyecto>();
}
