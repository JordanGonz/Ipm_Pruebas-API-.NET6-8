using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos;

public class CursosTomadosIscDto
{
    public int IdPersona { get; set; }
    public string NombreCurso { get; set; }
    public Decimal HorasCurso { get; set;}
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
}

public class CursosTomadosEdit
{
    public int IdCurso { get; set; }
    public int IdPersona { get; set; }
    public string Curso { get; set; }
    public Decimal Hora { get; set; }
    public Decimal HoraCursoAvance { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
}
public class CursosTomadosDelete
{
    public string Curso { get; set; }
    public Decimal Hora { get; set; }
    public string Porcentaje { get; set; }
}
