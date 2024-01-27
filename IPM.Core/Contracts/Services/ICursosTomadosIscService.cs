using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IPM.Core.Contracts.Services;

public interface ICursosTomadosIscService
{
    Task<bool> CreateCursosTomadosAsync(CursosTomadosIscDto cursosTomados);
    Task<bool> EditCursosTomadosAsync(int idCurso, CursosTomadosEdit cursosTomados);
    Task<bool> DeleteCursosTomadosAsync(int id);
}
