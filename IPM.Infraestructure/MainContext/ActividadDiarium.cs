using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class ActividadDiarium
{
    public int IdActividadDiaria { get; set; }

    public string? Descripcion { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdCatalogo { get; set; }

    public decimal? Hora { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaActividad { get; set; }

    public virtual Catalogo? IdCatalogoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
