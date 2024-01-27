using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories;

public interface ICursosTomadosIscRepository
{
    Task<bool> CreateCursosTomadosAsync(CursosTomado cursosTomados);
    Task<bool> EditCursosTomadosAsync(CursosTomadosEdit cursosTomados);
    Task<bool> DeleteCursosTomadosAsync(int id);
}
