
using IPM.Core.Models.EquiposOficina;

namespace IPM.Core.Dtos;

public class ArticulosDto
    {
        public string? tipo_complemento { get; set; }

        public string? marca { get; set; }

        public string? modelo { get; set; }
    }


public class HistorialAsignacionEquipos
    {
        public DateTime? FechaAsignacion { get; set; }
        public string? Persona { get; set; }
        
        public List<ArticulosDto> Articulos { get; set; }

    }
    public class HistorialMantenimientoEquipo
    {
        public string? Descripcion { get; set; }
        public decimal? Costo { get; set; }
        public string? NombreRespueto { get; set; }
        public string? NombreTecnico { get; set; }
        public DateTime? FechaMantenimineto { get; set; }
    }

    public class HistorialBajaEquipo
    {
        public string? Observacion { get; set; }

        public string? MotivoBaja { get; set; }
    }

    public class HistorialDetalleMovimientoEquipo
    {
        public List<HistorialAsignacionEquipos> HistorialAsignacionEquipos { get; set; }
        public List<HistorialMantenimientoEquipo> HistorialMantenimientoEquipo { get; set; }
        public List<HistorialBajaEquipo> HistorialBajaEquipo { get; set; }
    }

    public class HistorialEquipoDto
    {
        public EquipoOficina InformacionEquipo { get; set; }
        public HistorialDetalleMovimientoEquipo HistorialDetalleMovimientosEquipo { get; set; }
    }
    