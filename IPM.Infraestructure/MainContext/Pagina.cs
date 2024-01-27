using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Pagina
{
    public int IdPagina { get; set; }

    public string? Ruta { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public string? RutaPadre { get; set; }

    public string? RutaUrl { get; set; }

    public virtual ICollection<PaginaRol> PaginaRols { get; set; } = new List<PaginaRol>();
}
