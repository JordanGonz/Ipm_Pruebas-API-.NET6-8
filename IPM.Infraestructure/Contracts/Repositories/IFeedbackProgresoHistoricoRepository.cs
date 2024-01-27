using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories;

public interface IFeedbackProgresoHistoricoRepository
{
    Task<bool> CreearFeedbackProgresoHistoricoAsync(FeedbackProgresoHistorico fedBack);
    Task<bool> EditarFeedbackProgresoHistoricoAsync(FeedBackEditar feedBack);
    Task<bool> EliminarFeedbackProgresoHistoricoAsync(int id);
}
