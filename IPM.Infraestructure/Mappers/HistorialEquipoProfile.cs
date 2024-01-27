using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Mappers;

public class HistorialEquipoProfile : Profile
{
    public HistorialEquipoProfile()
    {
        
        CreateMap<HistorialAsignacionEquipos, AsignacionDto>();
        CreateMap<HistorialMantenimientoEquipo, MantenimientoDto>();
        
    }
}
