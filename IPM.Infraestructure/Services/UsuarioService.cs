using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;

namespace IPM.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IntegrityProjectManagementContext _context;

        public UsuarioService(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioDto>> ObtenerTodosLosUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var usuariosDto = usuarios.Select(usuario => new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Contraseña = usuario.Contraseña,
                ConfirmarClave = usuario.ConfirmarClave,
                Restablecer = usuario.Restablecer,
                Confirmado = usuario.Confirmado,
                Token = usuario.Token  // Asegúrate de asignar el token
            }).ToList();
            return usuariosDto;
        }

        public async Task<UsuarioDto> ObtenerUsuarioPorId(int usuarioId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
            if (usuario != null)
            {
                return new UsuarioDto
                {
                    UsuarioId = usuario.UsuarioId,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Contraseña = usuario.Contraseña,
                    ConfirmarClave = usuario.ConfirmarClave,
                    Restablecer = usuario.Restablecer,
                    Confirmado = usuario.Confirmado,
                    Token = usuario.Token  // Asegúrate de asignar el token
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UsuarioDto> CrearUsuario(UsuarioDto usuarioDto)
        {
            // Genera un token aleatorio para el nuevo usuario
            usuarioDto.Token = GenerarTokenAleatorio();

            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Email = usuarioDto.Email,
                Contraseña = usuarioDto.Contraseña,
                ConfirmarClave = usuarioDto.ConfirmarClave,
                Restablecer = usuarioDto.Restablecer ?? false,
                Confirmado = usuarioDto.Confirmado ?? false,
                Token = usuarioDto.Token  // Asigna el token
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return new UsuarioDto
            {
                UsuarioId = nuevoUsuario.UsuarioId,
                Nombre = nuevoUsuario.Nombre,
                Email = nuevoUsuario.Email,
                Contraseña = nuevoUsuario.Contraseña,
                ConfirmarClave = nuevoUsuario.ConfirmarClave,
                Restablecer = nuevoUsuario.Restablecer,
                Confirmado = nuevoUsuario.Confirmado,
                Token = nuevoUsuario.Token  // Asegúrate de incluir el token
            };
        }

        public async Task<bool> ActualizarUsuario(int usuarioId, UsuarioDto usuarioDto)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);

            if (usuarioExistente == null)
            {
                return false;
            }

            usuarioExistente.Nombre = usuarioDto.Nombre;
            usuarioExistente.Email = usuarioDto.Email;
            usuarioExistente.Contraseña = usuarioDto.Contraseña;
            usuarioExistente.ConfirmarClave = usuarioDto.ConfirmarClave;
            usuarioExistente.Restablecer = usuarioDto.Restablecer ?? false;
            usuarioExistente.Confirmado = usuarioDto.Confirmado ?? false;

            _context.Usuarios.Update(usuarioExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarUsuario(int usuarioId)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);

            if (usuarioExistente == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuarioExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerarTokenAleatorio()
        {
            // Lógica para generar un token aleatorio 
            return Guid.NewGuid().ToString("N");
        }
    }
}
