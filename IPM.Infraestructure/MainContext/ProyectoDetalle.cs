using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class ProyectoDetalle
{
    public int IdProyectoDetalle { get; set; }

    public int IdProyecto { get; set; }

    public int IdRecurso { get; set; }

    public int IdLider { get; set; }

    public int CargoRecurso { get; set; }

    public int Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatalogoDetalle CargoRecursoNavigation { get; set; } = null!;

    public virtual CatalogoDetalle EstadoNavigation { get; set; } = null!;

    public virtual Lider IdLiderNavigation { get; set; } = null!;

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;

    public virtual Persona IdRecursoNavigation { get; set; } = null!;
}
