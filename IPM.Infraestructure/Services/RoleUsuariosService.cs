using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class RolesUsuariosService : IRolesUsuariosService
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RolesUsuariosService(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;

    }

    public async Task<List<RolesUsuarioDto>> ObtenerTodosLosRolesPermisoAsync()
    {
        var rolesUsuarios = await _context.RolUsuarios.ToListAsync();
        var rolesUsuariosDto = rolesUsuarios.Select(rolesUsuario => new RolesUsuarioDto
        {
            RolesRolId = rolesUsuario.RolesRolId,
            UsuariosUsuarioId = rolesUsuario.UsuariosUsuarioId,
            Estado = rolesUsuario.Estado
        }).ToList();
        return rolesUsuariosDto;
    }

    public async Task<RolesUsuarioPorToken> ObtenerRolesPorToken(int usuario)
    {
        var response = new RolesUsuarioPorToken();

        var rolesUsuarioDto = await _context.RolUsuarios
        .Include(rolesUsuario => rolesUsuario.RolesRol) // Incluir la relación con la tabla de roles
        .Where(rolesUsuario => rolesUsuario.UsuariosUsuarioId == usuario)
        .Select(rolesUsuario => new RolesUsuario
        {
            IdRol = rolesUsuario.RolesRol.RolId,
            NombreRol = rolesUsuario.RolesRol.Nombre
        })
        .ToArrayAsync();

        response.Roles = rolesUsuarioDto;
        return response;
    }


    public async Task<RolesUsuarioDto> ObtenerRolePermisoPorIdAsync(int RolesRolId)
    {
        var rolesUsuario = await _context.RolUsuarios.FirstOrDefaultAsync(r => r.RolesRolId == RolesRolId);
        if (rolesUsuario != null)
        {
            return new RolesUsuarioDto
            {
                RolesRolId = rolesUsuario.RolesRolId,
                UsuariosUsuarioId = rolesUsuario.UsuariosUsuarioId,
                Estado = rolesUsuario.Estado
            };
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> CrearRolePermisoAsync(RolesUsuarioDto rolesUsuarioDto)
    {
        var nuevoRolesUsuario = new RolUsuario
        {
            RolesRolId = rolesUsuarioDto.RolesRolId,
            UsuariosUsuarioId = rolesUsuarioDto.UsuariosUsuarioId,
            Estado = rolesUsuarioDto.Estado ?? IPMConstants.ESTADO_ACTIVO
        };

        _context.RolUsuarios.Add(nuevoRolesUsuario);
        int resp = await _context.SaveChangesAsync();

        return resp > 0;
    }

    public async Task<bool> ActualizarRolePermisoAsync(int RolesRolId, RolesUsuarioDto rolesUsuarioDto)
    {
        var rolesUsuarioExistente = await _context.RolUsuarios.FirstOrDefaultAsync(r => r.RolesRolId == RolesRolId);

        if (rolesUsuarioExistente == null)
        {
            return false;
        }

        rolesUsuarioExistente.UsuariosUsuarioId = rolesUsuarioDto.UsuariosUsuarioId;
        rolesUsuarioExistente.Estado = rolesUsuarioDto.Estado ?? IPMConstants.ESTADO_ACTIVO;

        _context.RolUsuarios.Update(rolesUsuarioExistente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarRolePermisoAsync(int RolesRolId)
    {
        var rolesUsuarioExistente = await _context.RolUsuarios.FirstOrDefaultAsync(r => r.RolesRolId == RolesRolId);

        if (rolesUsuarioExistente == null)
        {
            return false;
        }

        rolesUsuarioExistente.Estado = IPMConstants.ESTADO_INACTIVO;
        int filasAfectadas = await _context.SaveChangesAsync();

        return filasAfectadas > 0;
    }
}
