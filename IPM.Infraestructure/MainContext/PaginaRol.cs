using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class PaginaRol
{
    public int IdPaginaRol { get; set; }

    public int? IdRol { get; set; }

    public int? IdPagina { get; set; }

    public virtual Pagina? IdPaginaNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
