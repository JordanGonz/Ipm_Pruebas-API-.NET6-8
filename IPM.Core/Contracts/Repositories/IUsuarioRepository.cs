using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioDto>> ObtenerTodos();
        Task<bool> Eliminar(int idUsuario);
        Task<bool> Existe(string email);
    }
}
