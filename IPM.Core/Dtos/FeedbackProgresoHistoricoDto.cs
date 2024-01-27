using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos;

public class FeedbackProgresoHistoricoDto
{
    public int IdPersona { get; set; }
    public string Entrevistas { get; set;}
    public string Observaciones { get; set;}
    public string Alertas { get; set;}
}

public class FeedBackEditar
{
    public int IdFeedBack { get; set; }
    public int IdPersona { get; set; }
    public string Entrevistas { get; set; }
    public string Observaciones { get; set; }
    public string Alertas { get; set; }
}

public class FeedBackEliminar 
{
    public int IdPersona { get; set; }
    public string Entrevistas { get; set; }
    public string Observaciones { get; set; }
    public string Alertas { get; set; }
}
