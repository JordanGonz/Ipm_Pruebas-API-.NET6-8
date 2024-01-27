using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Mantenimiento
{
    public int IdMantenimiento { get; set; }

    public int? IdEquipo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public string? NombreRespueto { get; set; }

    public string? NombreTecnico { get; set; }

    public DateTime? FechaMantenimineto { get; set; }

    public string? Estado { get; set; }

    public string? NumeroFactura { get; set; }

    public string? UsuarioCreacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioEliminacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }
}
