using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class LiderProyecto
{
    public int IdLiderProyecto { get; set; }

    public int? IdLider { get; set; }

    public int? IdProyecto { get; set; }

    public virtual Lidere? IdLiderNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }
}
