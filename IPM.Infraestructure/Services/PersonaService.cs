using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IPM.Core.Constants;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IPM.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IntegrityProjectManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public PersonaService(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<List<PersonaDto>> ObtenerTodosLosPersonaAsync()
        {
            var personas = await _context.Personas.ToListAsync();
            var personasDto = personas
                .Where(p => p.Estado == IPMConstants.ESTADO_ACTIVO)
                .Select(persona => new PersonaDto
            {
                IdPersona = persona.IdPersona,
                TipoIdentificacion = persona.TipoIdentificacion,
                NumeroIdentificacion = persona.NumeroIdentificacion,
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                Genero = persona.Genero,
                Cargo = persona.Cargo,
                EmailPersonal = persona.EmailPersonal,
                EmailCorporativo = persona.EmailCorporativo,
                Celular = persona.Celular,
                DireccionDomicilio = persona.DireccionDomicilio,
                
               
            }).ToList();
            return personasDto;
        }


            public async Task<InformacionPersonaDto> ObtenerInformacionUsuario(int usuario)
            {
                var actividades = await _context.Personas
                    .Include(a => a.Usuarios)
                    .Where(a => a.Usuarios.Any(u => u.UsuarioId == usuario))
                    .Select(a => new InformacionPersonaDto
                    {
                        Correo = a.EmailCorporativo,
                        username = a.Usuarios.FirstOrDefault().NombreUsuario,
                        Numero = a.NumeroIdentificacion,
                        Linkedin = a.Linkedin,
                        Github = a.Github,
                        Imagen = a.Imagen,
                        Id = a.IdPersona
                    })
                    .FirstOrDefaultAsync();

                return actividades;
            }


        public async Task<bool> ActualizarInformacionPerfil(int idpersona, InformacionActualizarPersonaDto infoActPerfil)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var personaExistente = await _context.Personas
                .Include(p => p.Usuarios)
                .FirstOrDefaultAsync(p => p.IdPersona == idpersona);

            if (personaExistente == null)
            {
                return false;
            }


            // Accede al primer usuario en la colección y actualiza el NombreUsuario
            var primerUsuario = personaExistente.Usuarios.FirstOrDefault();
            if (primerUsuario != null)
            {
                primerUsuario.NombreUsuario = infoActPerfil.username;
            }
            personaExistente.EmailCorporativo = infoActPerfil.Correo;
            personaExistente.IdPersona = infoActPerfil.Id;
            personaExistente.Celular = infoActPerfil.Numero;
            personaExistente.Linkedin = infoActPerfil.Linkedin;
            personaExistente.Github = infoActPerfil.Github;

            _context.Personas.Update(personaExistente);
            await _context.SaveChangesAsync();
            return true;
        }
   
        

        public async Task<PersonaDto> ObtenerPersonaPorIdAsync(int personaId)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.IdPersona == personaId && p.Estado== IPMConstants.ESTADO_ACTIVO);
            if (persona != null)
            {
                return new PersonaDto
                {
                    IdPersona = persona.IdPersona,
                    TipoIdentificacion = persona.TipoIdentificacion,
                    NumeroIdentificacion = persona.NumeroIdentificacion,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    Genero = persona.Genero,
                    Cargo = persona.Cargo,
                    EmailPersonal = persona.EmailPersonal,
                    EmailCorporativo = persona.EmailCorporativo,
                    Celular = persona.Celular,
                    DireccionDomicilio = persona.DireccionDomicilio,

                   
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CrearPersonaAsync(PersonaCreacionDTO personaDto)
        {
            int rowAffected = 0;
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;

            var pathFromConfig = _configuration["Path:FotosPerfil"];
           

            if (personaDto.Imagen != null && personaDto.Imagen.Length > 0)
            {
                // Generar un nombre único para la imagen
                var nombreUnico = Guid.NewGuid().ToString() + Path.GetExtension(personaDto.Imagen.FileName);
                var rutaCompleta = Path.Combine(pathFromConfig, nombreUnico);

                // Asegúrate de que el directorio exista
                Directory.CreateDirectory(Path.GetDirectoryName(rutaCompleta));

                // Guardar la imagen en el sistema de archivos
                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await personaDto.Imagen.CopyToAsync(stream);
                }

                var nuevaPersona = new Persona
                {
                    TipoIdentificacion = personaDto.TipoIdentificacion,
                    NumeroIdentificacion = personaDto.NumeroIdentificacion,
                    Nombres = personaDto.Nombres,
                    Apellidos = personaDto.Apellidos,
                    Genero = personaDto.Genero,
                    Cargo = personaDto.Cargo,
                    EmailPersonal = personaDto.EmailPersonal,
                    EmailCorporativo = personaDto.EmailCorporativo,
                    Celular = personaDto.Celular,
                    DireccionDomicilio = personaDto.DireccionDomicilio,
                    Imagen = rutaCompleta,
                    UsuarioCreacion = (userName),
                    FechaCreacion = DateTime.Now,
                    Estado = IPMConstants.ESTADO_ACTIVO
                };

                _context.Personas.Add(nuevaPersona);
                rowAffected = await _context.SaveChangesAsync();
            }
            else
            {
               

                var nuevaPersona = new Persona
                {
                    TipoIdentificacion = personaDto.TipoIdentificacion,
                    NumeroIdentificacion = personaDto.NumeroIdentificacion,
                    Nombres = personaDto.Nombres,
                    Apellidos = personaDto.Apellidos,
                    Genero = personaDto.Genero,
                    Cargo = personaDto.Cargo,
                    EmailPersonal = personaDto.EmailPersonal,
                    EmailCorporativo = personaDto.EmailCorporativo,
                    Celular = personaDto.Celular,
                    DireccionDomicilio = personaDto.DireccionDomicilio,
                    Imagen = Path.Combine("IPM.WebApi", "perfilimg.png"), 
                    UsuarioCreacion = (userName),
                    FechaCreacion = DateTime.Now,
                    Estado = IPMConstants.ESTADO_ACTIVO
                };

                _context.Personas.Add(nuevaPersona);
                rowAffected = await _context.SaveChangesAsync();
            }

            return rowAffected > 0;

        }



        public async Task<bool> ActualizaPersonaAsync(int personaId, PersonaDto personaDto)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var personaExistente = await _context.Personas.FirstOrDefaultAsync(p => p.IdPersona == personaId);

            if (personaExistente == null)
            {
                return false;
            }

            personaExistente.TipoIdentificacion = personaDto.TipoIdentificacion;
            personaExistente.NumeroIdentificacion = personaDto.NumeroIdentificacion;
            personaExistente.Nombres = personaDto.Nombres;
            personaExistente.Apellidos = personaDto.Apellidos;
            personaExistente.Genero = personaDto.Genero;
            personaExistente.Cargo = personaDto.Cargo;
            personaExistente.EmailPersonal = personaDto.EmailPersonal;
            personaExistente.EmailCorporativo = personaDto.EmailCorporativo;
            personaExistente.Celular = personaDto.Celular;
            personaExistente.DireccionDomicilio = personaDto.DireccionDomicilio;
            personaExistente.FechaModificacion = DateTime.Now;
            personaExistente.UsuarioModificacion = (userName);

            _context.Personas.Update(personaExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarPersonaAsync(int personaId)
        {
            var personaExistente = await _context.Personas.FirstOrDefaultAsync(p => p.IdPersona == personaId);

            if (personaExistente == null)
            {
                return false;
            }

            personaExistente.Estado = IPMConstants.ESTADO_INACTIVO;
            int filasafectadas= await _context.SaveChangesAsync();
            return filasafectadas > 0;
        }
    }
}
