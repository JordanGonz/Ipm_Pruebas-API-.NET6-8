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
    public class PerfilesPersonasProfile: Profile
    {
        public PerfilesPersonasProfile() 
        {
            CreateMap<Persona, InformacionPersonal>();
            CreateMap<StackTecnologico, StackTecnologicoPerfil>();
            CreateMap<HistorialLaboral, HistorialLaboralPerfil>();
            CreateMap<CursosTomado, CursosTomadosPerfil>();
            CreateMap<FeedbackProgresoHistorico, FeedbackProgresoHistoricoPerfil>();
            CreateMap<BusquedaDePerfiles, BusquedaDePerfiles>();

                
            CreateMap<CursosTomadosIscDto, CursosTomado>();
            CreateMap<CursosTomadosEdit, CursosTomado>();
            CreateMap<CursosTomadosDelete, CursosTomado>();
            //CreateMap<Persona, BusquedaDePerfiles>();
            //CreateMap<Catalogo, BusquedaDePerfiles>();

        }

    }
}
