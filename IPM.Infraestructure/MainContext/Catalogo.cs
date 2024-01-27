using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Catalogo
{
    public int IdCatalogo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Nemonico { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string? NombreMostrar { get; set; }
}
