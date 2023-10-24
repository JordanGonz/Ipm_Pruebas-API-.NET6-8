using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class RolesPermiso
{
    public int RolId { get; set; }

    public int PermisoId { get; set; }

    public int RolPermisoId { get; set; }

    public virtual Permiso Permiso { get; set; } = null!;

    public virtual Role Rol { get; set; } = null!;
}
