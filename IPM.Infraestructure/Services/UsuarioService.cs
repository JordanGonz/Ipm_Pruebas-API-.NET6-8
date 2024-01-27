
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
﻿using IPM.Core.Contracts.Services;
using IPM.Core.Models.Seguridad;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using IPM.Core.Common.Security;
using Microsoft.Extensions.Configuration;
using IPM.Core.Constants;

namespace IPM.Services;

public class UsuarioService : IUsuarioService
{
 


    private readonly IntegrityProjectManagementContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public UsuarioService(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    public async Task<List<UsuarioDto>> ObtenerTodosLosUsuariosAsync()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        var usuariosDto = usuarios
            .Where (p => p.Estado== IPMConstants.ESTADO_ACTIVO)
            .Select(usuario => new UsuarioDto
        {
            UsuarioId = usuario.UsuarioId,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Contraseña = usuario.Contraseña,
            ConfirmarClave = usuario.ConfirmarClave,
            Restablecer = usuario.Restablecer,
            Confirmado = usuario.Confirmado,
            IdPersona = usuario.IdPersona,
            Estado = usuario.Estado
        }).ToList();
        return usuariosDto;
    }

    

    public async Task<UsuarioLoginDto> LoginAsync(string email, string password)
    {

        var usuario = await _context.Usuarios
           .Include(u => u.IdPersonaNavigation)
           .FirstOrDefaultAsync(u => ((u.IdPersonaNavigation.EmailCorporativo.ToLower().Trim() == email.ToLower().Trim() 
           || u.NombreUsuario.ToLower().Trim() == email.ToLower().Trim()) 
           && u.Contraseña == password.ToUpper() && u.Estado == IPMConstants.ESTADO_ACTIVO));
        
        if (usuario is null) return null;

        var usuarioDto = new UsuarioLoginDto
        {
            Id = usuario.UsuarioId,
            Nombre = usuario.Nombre,
            Email = usuario.IdPersonaNavigation.EmailCorporativo,
            Usuario = usuario.NombreUsuario,
            IdPersona = (int)usuario.IdPersona
        };

        return usuarioDto;
    }

    public async Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int usuarioId)
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
                Estado = usuario.Estado
            };
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> RegistrarUsuarioCompletoAsync(RegistroCompletoDto registroCompletoDto)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;

                // Lógica de creación de Persona
                var persona = new Persona
                {
                    Nombres = registroCompletoDto.Nombres,
                    Apellidos = registroCompletoDto.Apellidos,
                    EmailPersonal = registroCompletoDto.EmailPersonal,
                    EmailCorporativo = registroCompletoDto.EmailCorporativo,
                    Celular = registroCompletoDto.Celular,
                    Linkedin = registroCompletoDto.Linkedin,
                    Github = registroCompletoDto.Github,
                    Estado = IPMConstants.ESTADO_ACTIVO,
                    DireccionDomicilio = "",
                    TipoIdentificacion = 1,
                    Cargo = 1,
                    NumeroIdentificacion = registroCompletoDto.Identificacion,
                    Genero = 1,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = userName
                };

                // Agregar lógica de manejo de imágenes
                if (registroCompletoDto.Imagen != null && registroCompletoDto.Imagen.Length > 0)
                {
                    var pathFromConfig = _configuration["Path:FotosPerfil"];
                    var nombreUnico = Guid.NewGuid().ToString() + Path.GetExtension(registroCompletoDto.Imagen.FileName);
                    var rutaCompleta = Path.Combine(pathFromConfig, nombreUnico);

                    Directory.CreateDirectory(Path.GetDirectoryName(rutaCompleta));

                    using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        await registroCompletoDto.Imagen.CopyToAsync(stream);
                    }

                    persona.Imagen = rutaCompleta;
                }
                else
                {
                    // Si no se proporciona una imagen, puedes asignar un valor predeterminado o dejarlo en blanco
                    persona.Imagen = Path.Combine("IPM.WebApi", "perfilimg.png");
                }

                _context.Personas.Add(persona);
                await _context.SaveChangesAsync();

                // Lógica de creación de Usuario
                string hashedPassword = Security.GetSHA256(registroCompletoDto.Contrasena);
                var usuario = new Usuario
                {
                    Nombre = registroCompletoDto.Nombres,
                    Email = registroCompletoDto.EmailPersonal,
                    Contraseña = hashedPassword,
                    Estado = IPMConstants.ESTADO_ACTIVO,
                    IdPersona = persona.IdPersona
                };

                _context.Usuarios.Add(usuario);

                int result = await _context.SaveChangesAsync();

                // Commit la transacción si todo fue exitoso
                transaction.Commit();

                return result > 0;
            }
            catch (Exception)
            {
                // Revertir la transacción en caso de error
                transaction.Rollback();
                throw; // Puedes manejar el error o dejar que se propague
            }
        }
    }


    public async Task<List<RegistroCompletoDto>> ObtenerTodosLosRegistrosCompletosAsync()
    {
        var registrosCompletos = await _context.Personas
            .Include(p => p.Usuarios)
            .Where(p => p.Estado == IPMConstants.ESTADO_ACTIVO)
            .Select(p => new RegistroCompletoDto
            {
                Nombres = p.Nombres,
                Apellidos = p.Apellidos,
                EmailPersonal = p.EmailPersonal,
                EmailCorporativo = p.EmailCorporativo,
                Celular = p.Celular,
                Identificacion=p.NumeroIdentificacion,
                Linkedin = p.Linkedin,
                Github = p.Github,
                Usuarios = p.Usuarios.Select(u => new UsuarioDto
                {
                    UsuarioId = u.UsuarioId,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Contraseña = u.Contraseña,
                    ConfirmarClave = u.ConfirmarClave,
                    Restablecer = u.Restablecer,
                    Confirmado = u.Confirmado,
                    IdPersona = u.IdPersona,
                    Estado = u.Estado
                }).ToList() 
            })
            .ToListAsync();

        return registrosCompletos;
    }




    public async Task<bool> CrearUsuarioAsync(UsuarioCreacionDto usuarioDto)
    {
        // Genera un token aleatorio para el nuevo usuario
        //usuarioDto.Token = GenerarTokenAleatorio();
        string hashedPassword = Security.GetSHA256(usuarioDto.Contraseña);
        var nuevoUsuario = new Usuario
        {
            Nombre = usuarioDto.Nombre,
            Email = usuarioDto.Email,
            Contraseña = hashedPassword,
            //Token = usuarioDto.Token,
            Estado = IPMConstants.ESTADO_ACTIVO

        };

        

        _context.Usuarios.Add(nuevoUsuario);
        int resp = await _context.SaveChangesAsync();

        return resp > 0;
    }

    public async Task<bool> ActualizarUsuarioAsync(int usuarioId, UsuarioDto usuarioDto)
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

    public async Task<bool> EliminarUsuarioAsync(int usuarioId)
    {
        var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);

        if (usuarioExistente is null)
        {
            return false;
        }

        usuarioExistente.Estado = IPMConstants.ESTADO_INACTIVO;
        int filasAfectadas = await _context.SaveChangesAsync();

        return filasAfectadas > 0;
    }

    private string GenerarTokenAleatorio()
    {
        // Lógica para generar un token aleatorio 
        return Guid.NewGuid().ToString("N");
    }

    public CurrentUser GetByAuth(UserLogin req)
    {
        throw new NotImplementedException();
    }


    public bool Existe(string email)
    {
        var empleado = _context.Personas
       .Include(x => x.Usuarios)
       .Where(x =>
           (x.EmailCorporativo == email ||x.EmailPersonal == email) /* x.Usuarios.Any(u => u.NombreUsuario == email)*/
           && x.Estado == IPMConstants.ESTADO_ACTIVO
       )
       .FirstOrDefault();

        return empleado != null;
        //var employee = _context.Personas.Where(x => x.EmailCorporativo == email  && x.Estado == IPMConstants.ESTADO_ACTIVO).FirstOrDefault();
        //return employee != null;
    }

    public bool RegisterVerificationCode(string email, string code)
    {
        var usuario = _context.Personas
            .Include(x => x.Usuarios)
            .Where(x => (x.EmailCorporativo == email || x.EmailPersonal == email && x.Estado == IPMConstants.ESTADO_ACTIVO))
            .Select(x => x.Usuarios.FirstOrDefault())
            .FirstOrDefault();

        if (usuario is null)
            throw new ApplicationException("asdas ");

        usuario.Codigo = code;
        usuario.Fecha = DateTime.Now;
        _context.Usuarios.Update(usuario);
        var resp = _context.SaveChanges();
        return resp > 0;
    }

    public VerifyCodeResponse VerifyCode(string email, string code)
    {
        var response = new VerifyCodeResponse
        {
            IsSuccess = true,
            Message = "OK"
        };
        var rowPassword = _context.Personas
            .Where(x => x.EmailPersonal == email);
       
        var rowPasswordU = _context.Usuarios
            .OrderByDescending(x => x.Fecha).FirstOrDefault();
      

        if (rowPasswordU == null || rowPasswordU.Codigo != code)
        {
            response.IsSuccess = false;
            response.Message = "El código de verificación es incorrecto";
            return response;
        }

        return response;
    }

    public ChangePasswordResponse ChangePassword(string email, string newPassword)
    {
        var response = new ChangePasswordResponse
        {
            IsSuccess = true,
            Message = "OK"
        };

            var rowUserEmployee = (from users in _context.Usuarios
                                   join empl in _context.Personas
                                     on users.IdPersona equals empl.IdPersona
                                   where empl.EmailCorporativo == email ||users.NombreUsuario == email
                                   select new { users, empl }).FirstOrDefault();
   
        if (rowUserEmployee == null)
        {
            response.IsSuccess = false;
            response.Message = $"No se encontró un usuario con el correo {email}";
            return response;
        }

        var user = rowUserEmployee.users;
        //user.ModificadoEn = DateTime.Now;
        //user.UsuarioMod = "reset_password";
        user.Contraseña = newPassword;

        _context.Entry(user).State = EntityState.Modified;
        int resp = _context.SaveChanges();

        if (resp <= 0)
        {
            response.IsSuccess = false;
            response.Message = "Error en al actualizar la contraseña";
        }

        return response;
    }
}