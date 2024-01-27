using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public int IdCliente { get; set; }

    public int IdLiderPrincipal { get; set; }

    public string CodigoProyecto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<ActividadDiariaTimeReport> ActividadDiariaTimeReports { get; set; } = new List<ActividadDiariaTimeReport>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<LiderProyecto> LiderProyectos { get; set; } = new List<LiderProyecto>();

    public virtual ICollection<PersonaProyectosAsignacion> PersonaProyectosAsignacions { get; set; } = new List<PersonaProyectosAsignacion>();
}
