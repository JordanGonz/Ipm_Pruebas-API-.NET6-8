using System;
using System.Collections.Generic;

namespace IPM.Infraestructure.MainContext;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Contraseña { get; set; }

    public string? ConfirmarClave { get; set; }

    public bool? Restablecer { get; set; }

    public bool? Confirmado { get; set; }

    public virtual ICollection<Role> RolesRols { get; set; } = new List<Role>();
}
