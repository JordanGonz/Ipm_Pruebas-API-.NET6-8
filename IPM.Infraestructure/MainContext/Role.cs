using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Role
{
    public int RolId { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<RolesPermiso> RolesPermisos { get; set; } = new List<RolesPermiso>();

    public virtual ICollection<Usuario> UsuariosUsuarios { get; set; } = new List<Usuario>();
}
