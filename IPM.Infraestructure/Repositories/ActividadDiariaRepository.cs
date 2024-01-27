using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;

public class ActividadDiariaRepository : IActividadDiariaRepository
{
    private readonly IntegrityProjectManagementContext _context;

    public ActividadDiariaRepository(IntegrityProjectManagementContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(ActividadDiariaTimeReport actividadDiarium)
    {
        _context.ActividadDiariaTimeReports.Add(actividadDiarium);
        int er = await _context.SaveChangesAsync();
        return er > 0;
    }

    public async Task<List<ActividadDiariaConsulta>> GetActProyAsync(string Descripcion)
    {
        var actividades = await (
         from report in _context.ActividadDiariaTimeReports
         join catalogo in _context.Catalogos on report.IdTipoActividad equals catalogo.IdCatalogo into grouping
         from catalogo in grouping.DefaultIfEmpty() 
         where report.Descripcion.Contains(Descripcion)
         select new ActividadDiariaConsulta
         {
             Descripcion = report.Descripcion,
             Hora = report.Hora,
             CodigoProyecto = report.IdProyectoNavigation.CodigoProyecto,
             NombreProyecto = report.IdProyectoNavigation.Descripcion,
             TipoActividad = catalogo != null ? catalogo.Descripcion : null, // Usar la descripción del catálogo si existe
             FechaActividad = report.FechaActividad,
             UsuarioId = report.UsuarioId
         }
     ).ToListAsync();

        return actividades;
    }

    public async Task<List<ActividadDiariaPorFecha>> GetActividadesPorFecha(DateTime FechaInicio, DateTime FechaFin, int idPersona)
    {
        var actividades = await (
             from report in _context.ActividadDiariaTimeReports
             join catalogo in _context.Catalogos on report.IdTipoActividad equals catalogo.IdCatalogo into catalogoGrouping
             from catalogo in catalogoGrouping.DefaultIfEmpty()
             where report.FechaActividad >= FechaInicio && report.FechaActividad <= FechaFin && report.IdPersona == idPersona 
             && report.Estado == IPMConstants.ESTADO_ACTIVO
             select new ActividadDiariaPorFecha
             {
                 DescripcionActividad = report.Descripcion,
                 CantidadHoras = report.Hora,
                 CodigoProyecto = report.IdProyectoNavigation.CodigoProyecto,
                 NombreLideres = report.IdProyectoNavigation.LiderProyectos
                     .Select(lp => lp.IdLiderNavigation.IdPersonaNavigation.Nombres + " " + lp.IdLiderNavigation.IdPersonaNavigation.Apellidos)
                     .ToArray(),
                 NombreProyecto = report.IdProyectoNavigation.Descripcion,
                 FechaActividad = report.FechaActividad,
                 TipoActividad = catalogo != null ? catalogo.Descripcion : null
             }
         ).ToListAsync();

        return actividades;
    }


    public async Task<List<ReporteExcelTimeReport>> GetActividadesReporte(DateTime FechaInicio, DateTime FechaFin, int idUsuario)
    {
        var actividades = await (
            from report in _context.ActividadDiariaTimeReports
            join catalogo in _context.Catalogos on report.IdTipoActividad equals catalogo.IdCatalogo into catalogoGrouping
            from catalogo in catalogoGrouping.DefaultIfEmpty()
            where report.FechaActividad >= FechaInicio && report.FechaActividad <= FechaFin && report.Usuario.UsuarioId == idUsuario && report.Estado == IPMConstants.ESTADO_ACTIVO
            select new ReporteExcelTimeReport
            {
                DescripcionActividad = report.Descripcion,
                CantidadHoras = report.Hora,
                CodigoProyecto = report.IdProyectoNavigation.CodigoProyecto,
                NombreLideres = report.IdProyectoNavigation.LiderProyectos
                    .Select(lp => lp.IdLiderNavigation.IdPersonaNavigation.Nombres + " " + lp.IdLiderNavigation.IdPersonaNavigation.Apellidos)
                    .ToArray(),
                NombreProyecto = report.IdProyectoNavigation.Descripcion,
                FechaActividad = report.FechaActividad,
                TipoActividad = catalogo != null ? catalogo.Descripcion : null, // Usar la descripción del catálogo si existe
                cliente = report.IdProyectoNavigation.IdClienteNavigation.NombreComercial,
                Nombre = report.Usuario.Nombre,
                FechaDesde = FechaInicio,
                FechaHasta = FechaFin
            }
        ).ToListAsync();

        return actividades;

    }


    public async Task<List<ActividadDiariaConsulta>> GetActProyAsync(int usuarioId)
    {
        var actividades = await (
         from report in _context.ActividadDiariaTimeReports
         join catalogo in _context.Catalogos on report.IdTipoActividad equals catalogo.IdCatalogo into catalogoGrouping
         from catalogo in catalogoGrouping.DefaultIfEmpty()
         select new ActividadDiariaConsulta
         {
             Descripcion = report.Descripcion,
             Hora = report.Hora,
             CodigoProyecto = report.IdProyectoNavigation.CodigoProyecto,
             NombreProyecto = report.IdProyectoNavigation.Descripcion,
             TipoActividad = catalogo != null ? catalogo.Nemonico : null, // Usar el Nemonico del catálogo si existe
             FechaActividad = report.FechaActividad
         }
     ).ToListAsync();

        return actividades;

    }

    public async Task<IEnumerable<ActividadDiariaConsulta>> GetActProyAsyncs()
    {
        var actividades = await (
            from report in _context.ActividadDiariaTimeReports
            join catalogo in _context.Catalogos on report.IdTipoActividad equals catalogo.IdCatalogo into catalogoGrouping
            from catalogo in catalogoGrouping.DefaultIfEmpty()
            where report.Estado == IPMConstants.ESTADO_ACTIVO
            select new ActividadDiariaConsulta
            {
                Descripcion = report.Descripcion,
                Hora = report.Hora,
                CodigoProyecto = report.IdProyectoNavigation.CodigoProyecto,
                NombreProyecto = report.IdProyectoNavigation.Descripcion,
                TipoActividad = catalogo != null ? catalogo.Nemonico : null,
                FechaActividad = report.FechaActividad,
                UsuarioId = report.UsuarioId
            }
        ).ToListAsync();

        return actividades;

    }

    public async Task<bool> ActualizarAsync(ActividadDiariaDto actividadProyectoDto)
    {
        var entidad = await _context.ActividadDiariaTimeReports
            .FirstOrDefaultAsync(a => a.IdActividadDiaria == actividadProyectoDto.IdActividadDiaria);

        if (entidad == null)
        {
            return false;
        }


        entidad.Descripcion = actividadProyectoDto.Descripcion;
        entidad.Hora = actividadProyectoDto.Hora;
        entidad.FechaActividad = actividadProyectoDto.FechaActividad;
        entidad.IdProyecto = actividadProyectoDto.IdProyecto;
        entidad.IdTipoActividad = actividadProyectoDto.IdCatalogo;

        int resp = await _context.SaveChangesAsync();
        return resp > 0;
    }



    public async Task<bool> DeleteActi(int id)
    {
        var actividadDiarium = await _context.ActividadDiariaTimeReports.FindAsync(id);
        if (actividadDiarium == null)
        {
            return false;
        }

        actividadDiarium.Estado = "I";
        int filasAfectadas = await _context.SaveChangesAsync();

        return filasAfectadas > 0;
    }
}