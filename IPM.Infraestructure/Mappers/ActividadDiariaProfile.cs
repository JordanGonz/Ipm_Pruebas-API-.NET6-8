using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;




public class ActividadDiariaProfile : Profile
{
    public ActividadDiariaProfile()
    {
        

        CreateMap<ActividadDiarium, ActividadProyectoCreacionDto>();

        CreateMap<ActividadProyectoCreacionDto, ActividadDiarium>();


        CreateMap<ActividadDiarium, ActividadDiariaConsulta>();

        CreateMap<ActividadDiariaConsulta, ActividadDiarium>();


        CreateMap<ActividadDiarium, ActividadDiariaPorFecha>();

        CreateMap<ActividadDiariaPorFecha, ActividadDiarium>();


        CreateMap<ActividadDiarium, ReporteExcelTimeReport>();

        CreateMap<ReporteExcelTimeReport, ActividadDiarium>();
    }
}


