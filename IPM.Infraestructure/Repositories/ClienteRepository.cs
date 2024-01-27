using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Core.Models.Clientes;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IPM.Infraestructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public ClienteRepository(IntegrityProjectManagementContext context,
        IHttpContextAccessor httpContextAccessor) {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<int> Crear(ClienteCreacion clienteCreacion)
    {
        if (clienteCreacion == null)
            throw new ArgumentNullException(nameof(clienteCreacion));
        

        var nuevoCliente = new Cliente()
        {
            TipoIdentificacion = clienteCreacion.TipoIdentificacion,
            NumeroIdentificacion = clienteCreacion.NumeroIdentificacion,
            RazonSocial = clienteCreacion.RazonSocial,
            NombreComercial = clienteCreacion.NombreComercial,
            Celular = clienteCreacion.Celular,
            CorreoElectronico = clienteCreacion.CorreoElectronico,
            Estado = IPMConstants.ESTADO_ACTIVO,
            FechaCreacion = DateTime.Now,
            UsuarioCreacion = ""
        };

        await _context.Clientes.AddAsync(nuevoCliente);
        await _context.SaveChangesAsync();

        return nuevoCliente.IdCliente;
    }



public async Task<List<Cliente>> ObtenerTodosLosClienteAsync()
    {
        return await _context.Clientes
            .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
            .ToListAsync();
    }

    public async Task<Cliente> ObtenerClientePorIdAsync(int clienteId)
    {
        return await _context.Clientes.FirstOrDefaultAsync(b => b.IdCliente == clienteId && b.Estado == IPMConstants.ESTADO_ACTIVO);
    }

    public async Task<bool> CrearClienteAsync(Cliente clienteDto)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        _context.Clientes.Add(clienteDto);

        clienteDto.UsuarioCreacion = (userName);
        clienteDto.FechaCreacion = DateTime.Now;
        int result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> ActualizarClienteAsync(EditarCliente clienteDto)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacionExistente = await _context.Clientes
        .FirstOrDefaultAsync(a => a.IdCliente == clienteDto.IdCliente);
        if (asignacionExistente == null)
        {
            // Log o manejo de la situación donde no se encuentra la asignación
            return false;
        }

        asignacionExistente.UsuarioModificacion = (userName);
        asignacionExistente.FechaModificacion = DateTime.Now;
        asignacionExistente.IdEmpresa = clienteDto.IdEmpresa;
        asignacionExistente.TipoIdentificacion = clienteDto.TipoIdentificacion;
        asignacionExistente.NumeroIdentificacion = clienteDto.NumeroIdentificacion;
        asignacionExistente.RazonSocial = clienteDto.RazonSocial;
        asignacionExistente.NombreComercial = clienteDto.NombreComercial;
        asignacionExistente.CorreoElectronico = clienteDto.CorreoElectronico;
        asignacionExistente.Celular = clienteDto.Celular;
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> EliminarClienteAsync(int clienteId)
    {
        var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        var asignacion = await _context.Clientes.FindAsync(clienteId);
        if (asignacion is null)
        {
            return false;
        }
        asignacion.UsuarioEliminacion = (userName);
        asignacion.FechaEliminacion = DateTime.Now;
        asignacion.Estado = IPMConstants.ESTADO_INACTIVO;
        int filasAfectadas = await _context.SaveChangesAsync();

        return filasAfectadas > 0;
    }
}