using IPM.Core.Contracts.Repositories;
using IPM.Core.Dtos;

namespace IPM.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<bool> Eliminar(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Existe(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioDto>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
