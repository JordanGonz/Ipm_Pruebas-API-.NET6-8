using IPM.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services.Reportes
{
    public interface IPaginaService
    {
        Task <List<PaginaDto>> ListaDePaginaPorRol(int rol);
        Task<List<PaginaUsuarioDto>> ListaDePaginaPorUsuario(int usuario);
    }

}
