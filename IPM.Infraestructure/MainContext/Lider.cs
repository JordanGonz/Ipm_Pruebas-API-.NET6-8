using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Lider
{
    public int IdLider { get; set; }

    public int IdCliente { get; set; }

    public int IdPersona { get; set; }

    public int Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatalogoDetalle EstadoNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ProyectoDetalle> ProyectoDetalles { get; set; } = new List<ProyectoDetalle>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
