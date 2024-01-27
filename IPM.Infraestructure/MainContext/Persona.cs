using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Persona
{
    public int IdPersona { get; set; }

    public int TipoIdentificacion { get; set; }

    public string NumeroIdentificacion { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public int Genero { get; set; }

    public int Cargo { get; set; }

    public string EmailPersonal { get; set; } = null!;

    public string? EmailCorporativo { get; set; }

    public string? Celular { get; set; }

    public string DireccionDomicilio { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string? Estado { get; set; }

    public string? Imagen { get; set; }

    public string? Linkedin { get; set; }

    public string? Github { get; set; }

    public DateTime? FechaClave { get; set; }

    public virtual ICollection<ActividadDiariaTimeReport> ActividadDiariaTimeReports { get; set; } = new List<ActividadDiariaTimeReport>();

    public virtual ICollection<CursosTomado> CursosTomados { get; set; } = new List<CursosTomado>();

    public virtual ICollection<EquipoPersonaAsignacion> EquipoPersonaAsignacions { get; set; } = new List<EquipoPersonaAsignacion>();

    public virtual ICollection<FeedbackProgresoHistorico> FeedbackProgresoHistoricos { get; set; } = new List<FeedbackProgresoHistorico>();

    public virtual ICollection<HistorialLaboral> HistorialLaborals { get; set; } = new List<HistorialLaboral>();

    public virtual ICollection<Lidere> Lideres { get; set; } = new List<Lidere>();

    public virtual ICollection<PersonaProyectosAsignacion> PersonaProyectosAsignacions { get; set; } = new List<PersonaProyectosAsignacion>();

    public virtual ICollection<StackTecnologico> StackTecnologicos { get; set; } = new List<StackTecnologico>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
