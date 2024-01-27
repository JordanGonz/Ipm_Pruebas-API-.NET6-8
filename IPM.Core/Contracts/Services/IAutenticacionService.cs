using IPM.Core.Dtos;
using IPM.Core.Models.Seguridad;

namespace IPM.Core.Contracts.Services;

public interface IAuthenticationService
{
    Task<RolesUsuarioPorToken> IsAuthenticated(LoginDto request);
    bool IsAuthenticated(UserLogin request);
}