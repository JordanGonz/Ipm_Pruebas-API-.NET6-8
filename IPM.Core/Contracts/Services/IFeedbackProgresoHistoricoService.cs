using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services;

public interface IFeedbackProgresoHistoricoService
{
    Task<bool> CreearFeedbackProgresoHistoricoAsync(FeedbackProgresoHistoricoDto fedBack);
    Task<bool> EditarFeedbackProgresoHistoricoAsync(int id, FeedBackEditar feedBack);
    Task<bool> EliminarFeedbackProgresoHistoricoAsync(int id);

}
