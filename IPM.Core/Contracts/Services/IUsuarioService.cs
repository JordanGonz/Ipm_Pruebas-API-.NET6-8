using System.Collections.Generic;
using System.Threading.Tasks;
using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> ObtenerTodosLosUsuarios();
        Task<UsuarioDto> ObtenerUsuarioPorId(int usuarioId);
        Task<UsuarioDto> CrearUsuario(UsuarioDto usuarioDto);
        Task<bool> ActualizarUsuario(int usuarioId, UsuarioDto usuarioDto);
        Task<bool> EliminarUsuario(int usuarioId);
    }
}
