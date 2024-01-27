using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Mappers
{
    public class AsignacionArticuloProfile : Profile
    {
        public AsignacionArticuloProfile()
        {
            CreateMap<AsignacionArticulo, AsignacionConsultaArticuloDto>();
            CreateMap<AsignacionArticulo, AsignacionActualizarArticuloDto>();
            CreateMap<AsignacionArticulo, AsignacionArticuloDto>();

            CreateMap<AsignacionArticuloDto, AsignacionArticulo>();
            CreateMap<AsignacionActualizarArticuloDto, AsignacionArticulo>();
            CreateMap<AsignacionConsultaArticuloDto, AsignacionArticulo>();



        }
    }
}
