using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class RolUsuario
{
    public int RolesRolId { get; set; }

    public int UsuariosUsuarioId { get; set; }

    public string? Estado { get; set; }

    public int RolUsuario1 { get; set; }

    public virtual Role RolesRol { get; set; } = null!;

    public virtual Usuario UsuariosUsuario { get; set; } = null!;
}
