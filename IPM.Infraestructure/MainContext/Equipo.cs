using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Equipo
{
    public int IdEquipo { get; set; }

    public string? Codigo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? ServiceTag { get; set; }

    public string? ExpressServiceCode { get; set; }

    public string? Color { get; set; }

    public string? Procesador { get; set; }

    public string? Memoria { get; set; }

    public string? DiscoDuro { get; set; }

    public string? SistemaOperativo { get; set; }

    public string? Lector { get; set; }

    public string? Conectividad { get; set; }

    public string? Camara { get; set; }

    public string? Pantalla { get; set; }

    public string? Usb { get; set; }

    public string? Batería { get; set; }

    public string? Office { get; set; }

    public string? CargadorModel { get; set; }

    public string? Serial { get; set; }

    public string? MarcaMouse { get; set; }

    public string? ModeloMouse { get; set; }

    public string? Estado { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public string? SerieMouse { get; set; }

    public string? NombreEquipo { get; set; }

    public virtual ICollection<BajaEquipo> BajaEquipos { get; set; } = new List<BajaEquipo>();

    public virtual ICollection<EquipoPersonaAsignacion> EquipoPersonaAsignacions { get; set; } = new List<EquipoPersonaAsignacion>();

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
}
