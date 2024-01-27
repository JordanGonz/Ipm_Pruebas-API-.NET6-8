using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Role
{
    public int RolId { get; set; }

    public string? Nombre { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<PaginaRol> PaginaRols { get; set; } = new List<PaginaRol>();

    public virtual ICollection<RolUsuario> RolUsuarios { get; set; } = new List<RolUsuario>();

    public virtual ICollection<RolesPermiso> RolesPermisos { get; set; } = new List<RolesPermiso>();
}
