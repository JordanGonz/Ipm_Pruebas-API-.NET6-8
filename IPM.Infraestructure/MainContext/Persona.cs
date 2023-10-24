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

    public int Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatalogoDetalle CargoNavigation { get; set; } = null!;

    public virtual CatalogoDetalle EstadoNavigation { get; set; } = null!;

    public virtual CatalogoDetalle GeneroNavigation { get; set; } = null!;

    public virtual ICollection<ProyectoDetalle> ProyectoDetalles { get; set; } = new List<ProyectoDetalle>();

    public virtual CatalogoDetalle TipoIdentificacionNavigation { get; set; } = null!;
}
