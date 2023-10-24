using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Permiso
{
    public int PermisoId { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<RolesPermiso> RolesPermisos { get; set; } = new List<RolesPermiso>();
}
