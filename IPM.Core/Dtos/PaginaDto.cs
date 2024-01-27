using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class PaginaDto
    {
        public IEnumerable<int> IdRol { get; set; }
        public string? Ruta { get; set; }

        public string? Nombre { get; set; }

        public string? Codigo { get; set; }

        public string? RutaPadre { get; set; }

        public string? RutaUrl { get; set; }
    }


    public class PaginaUsuarioDto
    { 
       public string? Ruta { get; set; }

        public string? Nombre { get; set; }

        public string? Codigo { get; set; }

        public string? RutaPadre { get; set; }

        public string? RutaUrl { get; set; }
    }



}
