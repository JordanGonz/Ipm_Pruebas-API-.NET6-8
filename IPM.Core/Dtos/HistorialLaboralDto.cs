using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos;

public class HistorialLaboralDto
{
    public int? IdPersona { get; set; }

    public string? Empresa { get; set; }

    public DateTime? FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public string? Cargo { get; set; }

    public string? DescripcionSalida { get; set; }

}

public class EditarHistoriaLaboral
{
    public int? IdHistorial { get; set; }
    public int? IdPersona { get; set; }

    public string? Empresa { get; set; }

    public DateTime? FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public string? Cargo { get; set; }

    public string? DescripcionSalida { get; set; }
}

public class EliinarHistoriaLaboral
{
    public int? IdPersona { get; set; }

    public string? Empresa { get; set; }

    public DateTime? FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public string? Cargo { get; set; }

    public string? DescripcionSalida { get; set; }
}
