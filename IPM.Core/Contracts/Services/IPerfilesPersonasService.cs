using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services
{
    public interface IPerfilesPersonasService
    {
        Task<InformacionPersonal> ObtenerInformacionPersonalAsync(int id);
        Task<List<StackTecnologicoPerfil>> ObtenerListadoStackTecnologicoAsync(int id);
        Task<List<HistorialLaboralPerfil>> ObtenerListadoHistorialLaboralAsync(int id);
        Task<List<CursosTomadosPerfil>> ObtenerListadoCursosTomadosAsync(int id);
        Task<List<FeedbackProgresoHistoricoPerfil>> ObtenerListadoFeedbackProgresoHistoricoAsync(int id);
        Task<List<BusquedaDePerfiles>> ObtenerListadoDeBusquedaPerfilAsync(string busqueda);

        Task<PerfilPersona> ObtenerTodaLaInformacionDePersonaAsync(int id);
    }
}
