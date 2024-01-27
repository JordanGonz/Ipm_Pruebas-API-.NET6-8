using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Contraseña { get; set; }

    public string? ConfirmarClave { get; set; }

    public bool? Restablecer { get; set; }

    public bool? Confirmado { get; set; }

    public int? IdPersona { get; set; }

    public string? Estado { get; set; }

    public string? Codigo { get; set; }

    public string? NombreUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? ActulizadaClave { get; set; }

    public virtual ICollection<ActividadDiariaTimeReport> ActividadDiariaTimeReports { get; set; } = new List<ActividadDiariaTimeReport>();

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<RolUsuario> RolUsuarios { get; set; } = new List<RolUsuario>();
}
