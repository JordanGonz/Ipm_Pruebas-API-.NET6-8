using IPM.Core.Models.Seguridad;

namespace IPM.Core.Contracts.Services
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated(UsuarioLogin request);
    }
}
