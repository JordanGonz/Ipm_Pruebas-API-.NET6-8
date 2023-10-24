using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class CatalogoDetalle
{
    public int IdCatalogoDetalle { get; set; }

    public int IdCatalogo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Nemonico { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string TipoIdentificacion { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public virtual ICollection<Cliente> ClienteEstadoNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteTipoIdentificacionNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual Catalogo IdCatalogoNavigation { get; set; } = null!;

    public virtual ICollection<Lider> Liders { get; set; } = new List<Lider>();

    public virtual ICollection<Persona> PersonaCargoNavigations { get; set; } = new List<Persona>();

    public virtual ICollection<Persona> PersonaEstadoNavigations { get; set; } = new List<Persona>();

    public virtual ICollection<Persona> PersonaGeneroNavigations { get; set; } = new List<Persona>();

    public virtual ICollection<Persona> PersonaTipoIdentificacionNavigations { get; set; } = new List<Persona>();

    public virtual ICollection<ProyectoDetalle> ProyectoDetalleCargoRecursoNavigations { get; set; } = new List<ProyectoDetalle>();

    public virtual ICollection<ProyectoDetalle> ProyectoDetalleEstadoNavigations { get; set; } = new List<ProyectoDetalle>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
