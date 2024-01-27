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
    public class LiderProfile : Profile
    {
        public LiderProfile()
        {
            CreateMap<Lidere, ObtenerLider>();
            CreateMap<LiderDto, Lidere>();
            CreateMap<EliminarLider, Lidere>();
            CreateMap<EditarLider, Lidere>();
        }
    }
}
