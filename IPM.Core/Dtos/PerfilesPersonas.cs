using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IPM.Core.Dtos
{
    public class StackTecnologicoPerfil
    {
        public string? Tecnologias { get; set; }
        public string? IdCatalogoStack { get; set; }
        public string? IdNivelDominioTecnologico { get; set; }
        //public int IdPersona {  get; set; }

    }
    public class HistorialLaboralPerfil
    {
        public string Empresa {  get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string Cargo { get; set; }
        public string DescripcionSalida { get; set; }

    }
    public class CursosTomadosPerfil
    {
        public string  NombreCurso { get; set; }
        public decimal? HorasCurso { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string ProgresoPorcentaje {  get; set; }
    }
    public class FeedbackProgresoHistoricoPerfil
    {
        public string[] Entrevistas { get; set; }
        public string[] Observaciones { get; set; }
        public string[] Alertas { get; set; }

    }
    public class InformacionPersonal
    {
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public string Genero { get; set; }
        public string cargo { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
    }
    public class Informacion
    {
        public InformacionPersonal InformacionPersonal { get; set; }
        public List<StackTecnologicoPerfil> StackTecnologico { get; set; }
        public List<HistorialLaboralPerfil> HistorialLaboral { get; set; }
        public List<CursosTomadosPerfil> CursosTomados { get; set; }
        public List<FeedbackProgresoHistoricoPerfil> FeedbackProgresoHistorico { get; set; }
    }
    public class PerfilPersona
    {
       
        public Informacion InformacionPerfil { get; set; }

    }
    public class BusquedaDePerfiles
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Imagen {  get; set; }
        public string Apellido { get; set; }
        [JsonIgnore]
        public int IdCargo {  get; set; }
        public string Cargo { get; set; }
    }
}
