namespace IPM.Core.Models.EquiposOficina;

public sealed class EquipoOficina
{
    public int IdEquipo { get; set; }
 
    public string? NombreEquipo { get; set; }
    public string? codigo { get; set; }

    public string? marca { get; set; }
    public string? modelo { get; set; }

    public string? serviceTag { get; set; }
    public string? expressServiceCode { get; set; }

    public string? color { get; set; }
    public string? procesador { get; set; }

    public string? memoria { get; set; }
    public string? discoDuro { get; set; }

    public string? sistemaOperativo { get; set; }



    public string? lector { get; set; }

    public string? conectividad { get; set; }
    public string? camara { get; set; }

    public string? pantalla { get; set; }
    public string? usb { get; set; }

    public string? batería { get; set; }
    public string? office { get; set; }

    public string? cargadorModel { get; set; }



    public string? serial { get; set; }
    public string? marcaMouse { get; set; }

    public string? modeloMouse { get; set; }
    public string? serieMouse { get; set; }
}
