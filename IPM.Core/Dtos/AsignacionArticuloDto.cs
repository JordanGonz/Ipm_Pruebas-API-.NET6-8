using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class AsignacionArticuloDto
    {
        public int? IdAsignacion { get; set; }

        public int? IdArticulo { get; set; }
    }

    public class AsignacionConsultaArticuloDto
    {
        
        public int? IdAsignacion { get; set; }

        public int? IdArticulo { get; set; }
    }
    public class AsignacionActualizarArticuloDto
    {
        public int IdAsignacionArticulo { get; set; }
        public int? IdAsignacion { get; set; }

        public int? IdArticulo { get; set; }
    }
}
