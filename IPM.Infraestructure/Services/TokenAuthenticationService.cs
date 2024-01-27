using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.Seguridad;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IPM.Infraestructure.Services;

public class TokenAuthenticationService : IAuthenticationService
{
    private readonly TokenManagement _tokenManagement;
    private readonly IUsuarioService _userService;
    private readonly IRolesUsuariosService _rolesService;
    private readonly ILogger<TokenAuthenticationService> _logger;


    public TokenAuthenticationService(IOptions<TokenManagement> tokenManagement, IUsuarioService userService, IRolesUsuariosService roles, ILogger<TokenAuthenticationService> logger)
    {
        _tokenManagement = tokenManagement.Value;
        _userService = userService;
        _logger = logger;
        _rolesService = roles;
    }


    public async Task<RolesUsuarioPorToken> IsAuthenticated(LoginDto request)
    {
        string token = string.Empty;
        var user = await _userService.LoginAsync(request.Email, request.Contraseña);
        if (user == null) 
            throw new ApplicationException("los campos no pueden ser nulo");

        var roles = await _rolesService.ObtenerRolesPorToken(user.Id);


        var claims = new[]
        {
            new Claim(ClaimTypes.Role, string.Join(",", roles.Roles.Select(x => x.IdRol))),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Nombre),
            new Claim("IdPersona", user.IdPersona.ToString()),
            new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);

        roles.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return roles;
    }

    public bool IsAuthenticated(UserLogin request)
    {
        throw new NotImplementedException();
    }
}