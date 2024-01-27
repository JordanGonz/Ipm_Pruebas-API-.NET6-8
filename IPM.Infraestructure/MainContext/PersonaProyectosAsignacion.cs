using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class PersonaProyectosAsignacion
{
    public int IdPersonaProyectos { get; set; }

    public int ProyectoId { get; set; }

    public int PersonaId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaEliminacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
