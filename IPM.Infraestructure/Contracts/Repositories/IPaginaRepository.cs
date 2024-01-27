using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Contracts.Repositories
{
    public interface IPaginaRepository
    {
        Task<List<PaginaDto>> ListaDePaginaPorRol(int rol);
    }
}
