using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos;

public class LiderDto
{
    public int IdPersona { get; set; }

    public bool EsLiderIntegritySolutions { get; set; }

}

public class ObtenerLider
{
    public int IdLider { get; set; }
    public string NombreLider { get; set; }

    public int IdPersona { get; set; }

    public bool EsLiderIntegritySolutions { get; set; }
}

public class EditarLider
{
    public int IdLider { get; set; }

    public int IdPersona { get; set; }

    public bool EsLiderIntegritySolutions { get; set; }
}

public class EliminarLider
{

    public int IdPersona { get; set; }

    public bool EsLiderIntegritySolutions { get; set; }
}