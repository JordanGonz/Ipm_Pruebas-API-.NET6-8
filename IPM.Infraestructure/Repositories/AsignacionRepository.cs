using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace IPM.Infraestructure.Repositories
{
    public class AsignacionRepository: IAsignacionRepository
    {
        private readonly IntegrityProjectManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AsignacionRepository(IntegrityProjectManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<List<AsignacionDto>> ObtenerTodasLasAsignacionesAsync()
        {
            var asignaciones = await _context.AsignacionArticulos
                .Include(a => a.IdArticuloNavigation)
                .Include(a => a.IdAsignacionNavigation)
                 .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .GroupBy(a => new
                {

                    FechaAsignacion = a.IdAsignacionNavigation.FechaAsignacion,
                    Persona = a.IdAsignacionNavigation.IdPersonaNavigation.Nombres + " " + a.IdAsignacionNavigation.IdPersonaNavigation.Apellidos,
                    NombreEquipo = a.IdAsignacionNavigation.IdEquipoNavigation.NombreEquipo,

                    codigo = a.IdAsignacionNavigation.IdEquipoNavigation.Codigo,

                    marca = a.IdAsignacionNavigation.IdEquipoNavigation.Marca,
                    modelo = a.IdAsignacionNavigation.IdEquipoNavigation.Modelo,
                    serviceTag = a.IdAsignacionNavigation.IdEquipoNavigation.ServiceTag,
                    expressServiceCode = a.IdAsignacionNavigation.IdEquipoNavigation.ExpressServiceCode,

                    color = a.IdAsignacionNavigation.IdEquipoNavigation.Color,
                    procesador = a.IdAsignacionNavigation.IdEquipoNavigation.Procesador,

                    memoria = a.IdAsignacionNavigation.IdEquipoNavigation.Memoria,
                    discoDuro = a.IdAsignacionNavigation.IdEquipoNavigation.DiscoDuro,

                    sistemaOperativo = a.IdAsignacionNavigation.IdEquipoNavigation.SistemaOperativo,



                    lector = a.IdAsignacionNavigation.IdEquipoNavigation.Lector,

                    conectividad = a.IdAsignacionNavigation.IdEquipoNavigation.Conectividad,
                    camara = a.IdAsignacionNavigation.IdEquipoNavigation.Camara,

                    pantalla = a.IdAsignacionNavigation.IdEquipoNavigation.Pantalla,
                    usb = a.IdAsignacionNavigation.IdEquipoNavigation.Usb,

                    batería = a.IdAsignacionNavigation.IdEquipoNavigation.Batería,
                    office = a.IdAsignacionNavigation.IdEquipoNavigation.Office,

                    cargadorModel = a.IdAsignacionNavigation.IdEquipoNavigation.CargadorModel,



                    serial = a.IdAsignacionNavigation.IdEquipoNavigation.Serial,
                    marcaMouse = a.IdAsignacionNavigation.IdEquipoNavigation.MarcaMouse,

                    modeloMouse = a.IdAsignacionNavigation.IdEquipoNavigation.ModeloMouse,
                    serieMouse = a.IdAsignacionNavigation.IdEquipoNavigation.SerieMouse,
                })
                .Select(g => new AsignacionDto
                {
                    FechaAsignacion = g.Key.FechaAsignacion,
                    Persona = g.Key.Persona,
                    NombreEquipo = g.Key.NombreEquipo,

                    codigo = g.Key.codigo,

                    marca = g.Key.marca,
                    modelo = g.Key.modelo,
                    serviceTag = g.Key.serviceTag,
                    expressServiceCode = g.Key.expressServiceCode,

                    color = g.Key.color,
                    procesador = g.Key.procesador,

                    memoria = g.Key.memoria,
                    discoDuro = g.Key.discoDuro,

                    sistemaOperativo = g.Key.sistemaOperativo,



                    lector = g.Key.lector,

                    conectividad = g.Key.conectividad,
                    camara = g.Key.camara,

                    pantalla = g.Key.pantalla,
                    usb = g.Key.usb,

                    batería = g.Key.batería,
                    office = g.Key.office,

                    cargadorModel = g.Key.cargadorModel,



                    serial = g.Key.serial,
                    marcaMouse = g.Key.marcaMouse,

                    modeloMouse = g.Key.modeloMouse,
                    serieMouse = g.Key.serieMouse,

                    Articulos = g.Select(a => new Asignacionitem
                    {
                        tipo_complemento = a.IdArticuloNavigation.TipoComplemento,
                        marca = a.IdArticuloNavigation.Marca,
                        modelo = a.IdArticuloNavigation.Modelo
                    }).ToList()


                })
                .ToListAsync();
            return asignaciones;

        }


        public async Task<List<AsignacionDto>> ObtenerLasAsignacionesPorUsuariosAsync(int iduser)
        {
            var asignaciones = await _context.AsignacionArticulos
                .Include(a => a.IdArticuloNavigation)
                .Include(a => a.IdAsignacionNavigation)
                .Where(a => a.IdAsignacionNavigation.IdPersonaNavigation.Usuarios.FirstOrDefault().UsuarioId == iduser && a.Estado == IPMConstants.ESTADO_ACTIVO)
                .GroupBy(a => new
                {
                    FechaAsignacion = a.IdAsignacionNavigation.FechaAsignacion,
                    Persona = a.IdAsignacionNavigation.IdPersonaNavigation.Nombres + " " + a.IdAsignacionNavigation.IdPersonaNavigation.Apellidos,
                    NombreEquipo = a.IdAsignacionNavigation.IdEquipoNavigation.NombreEquipo,

                    codigo = a.IdAsignacionNavigation.IdEquipoNavigation.Codigo,

                    marca = a.IdAsignacionNavigation.IdEquipoNavigation.Marca,
                    modelo = a.IdAsignacionNavigation.IdEquipoNavigation.Modelo,
                    serviceTag = a.IdAsignacionNavigation.IdEquipoNavigation.ServiceTag,
                    expressServiceCode = a.IdAsignacionNavigation.IdEquipoNavigation.ExpressServiceCode,

                    color = a.IdAsignacionNavigation.IdEquipoNavigation.Color,
                    procesador = a.IdAsignacionNavigation.IdEquipoNavigation.Procesador,

                    memoria = a.IdAsignacionNavigation.IdEquipoNavigation.Memoria,
                    discoDuro = a.IdAsignacionNavigation.IdEquipoNavigation.DiscoDuro,

                    sistemaOperativo = a.IdAsignacionNavigation.IdEquipoNavigation.SistemaOperativo,



                    lector = a.IdAsignacionNavigation.IdEquipoNavigation.Lector,

                    conectividad = a.IdAsignacionNavigation.IdEquipoNavigation.Conectividad,
                    camara = a.IdAsignacionNavigation.IdEquipoNavigation.Camara,

                    pantalla = a.IdAsignacionNavigation.IdEquipoNavigation.Pantalla,
                    usb = a.IdAsignacionNavigation.IdEquipoNavigation.Usb,

                    batería = a.IdAsignacionNavigation.IdEquipoNavigation.Batería,
                    office = a.IdAsignacionNavigation.IdEquipoNavigation.Office,

                    cargadorModel = a.IdAsignacionNavigation.IdEquipoNavigation.CargadorModel,



                    serial = a.IdAsignacionNavigation.IdEquipoNavigation.Serial,
                    marcaMouse = a.IdAsignacionNavigation.IdEquipoNavigation.MarcaMouse,

                    modeloMouse = a.IdAsignacionNavigation.IdEquipoNavigation.ModeloMouse,
                    serieMouse = a.IdAsignacionNavigation.IdEquipoNavigation.SerieMouse,
                })
                .Select(g => new AsignacionDto
                {
                    FechaAsignacion = g.Key.FechaAsignacion,
                    Persona = g.Key.Persona,
                    NombreEquipo = g.Key.NombreEquipo,

                    codigo = g.Key.codigo,

                    marca = g.Key.marca,
                    modelo = g.Key.modelo,
                    serviceTag = g.Key.serviceTag,
                    expressServiceCode = g.Key.expressServiceCode,

                    color = g.Key.color,
                    procesador = g.Key.procesador,

                    memoria = g.Key.memoria,
                    discoDuro = g.Key.discoDuro,

                    sistemaOperativo = g.Key.sistemaOperativo,



                    lector = g.Key.lector,

                    conectividad = g.Key.conectividad,
                    camara = g.Key.camara,

                    pantalla = g.Key.pantalla,
                    usb = g.Key.usb,

                    batería = g.Key.batería,
                    office = g.Key.office,

                    cargadorModel = g.Key.cargadorModel,



                    serial = g.Key.serial,
                    marcaMouse = g.Key.marcaMouse,

                    modeloMouse = g.Key.modeloMouse,
                    serieMouse = g.Key.serieMouse,

                    Articulos = g.Select(a => new Asignacionitem
                    {
                        tipo_complemento = a.IdArticuloNavigation.TipoComplemento,
                        marca = a.IdArticuloNavigation.Marca,
                        modelo = a.IdArticuloNavigation.Modelo
                    }).ToList()


                })
                .ToListAsync();
            return asignaciones;

        }


        public async Task<bool> CrearTodasLasAsignacionesAsync(EquipoPersonaAsignacion asignacionCrearDtos)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            _context.EquipoPersonaAsignacions.Add(asignacionCrearDtos);
            asignacionCrearDtos.UsuarioCreacion= (userName);
            asignacionCrearDtos.Fechacreacion = DateTime.Now;
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ActualizarAsigancionesAsync(AsignacionActualizarDtos asignacionActualizar)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var asignacionExistente = await _context.EquipoPersonaAsignacions
            .FirstOrDefaultAsync(a => a.IdAsignacion == asignacionActualizar.IdAsignacion);
            if (asignacionExistente == null)
            {
                // Log o manejo de la situación donde no se encuentra la asignación
                return false;
            }
            asignacionExistente.UsuarioModificacion = (userName);
            asignacionExistente.FechaModificacion= DateTime.Now;
            asignacionExistente.FechaAsignacion = asignacionActualizar.FechaAsignacion;
            asignacionExistente.IdPersona = asignacionActualizar.IdPersona;
            asignacionExistente.IdEquipo = asignacionActualizar.IdEquipo;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsignacion(int id)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var asignacion = await _context.EquipoPersonaAsignacions.FindAsync(id);
            if (asignacion is null)
            {
                return false;
            }
            asignacion.UsuarioEliminacion = (userName);
            asignacion.FechaEliminacion= DateTime.Now;
            asignacion.Estado = IPMConstants.ESTADO_INACTIVO;
            int filasAfectadas = await _context.SaveChangesAsync();

            return filasAfectadas > 0;
        }
    }
}
