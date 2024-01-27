using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class StackTecnologico
{
    public int IdStackTecnologico { get; set; }

    public string? Tecnologias { get; set; }

    public int? IdCatalogoStack { get; set; }

    public int? IdNivelDominioTecnologico { get; set; }

    public int? IdPersona { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
