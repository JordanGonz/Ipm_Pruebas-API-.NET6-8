using IPM.Core.Contracts.Services;
using IPM.Core.Contracts.Services.Reportes;
using IPM.Core.Contracts.Services.Reportes.Excel;
using IPM.Core.Contracts.Services.SMTP;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.Repositories;
using IPM.Infraestructure.Services;
using IPM.Infraestructure.Services.Reportes.Excel;
using IPM.Infraestructure.Services.SMTP;
using IPM.Infrastructure.Services;
using IPM.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IPM.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructureDependencies(this IServiceCollection services)
        {

          


            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermisoService, PermisoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IRolesPermisoService, RolePermisoService>();
            services.AddScoped<IProyectoService, ProyectoService>();
            
         
            services.AddScoped< IPersonaService, PersonaService>();
            
           
            services.AddScoped<IActividadDiariaRepository, ActividadDiariaRepository>();
            services.AddScoped<IActividadDiariaService, ActividadDiariaService>();
            services.AddScoped<IRolesUsuariosService, RolesUsuariosService>();

            services.AddScoped<ICatalogoService, CatalogoService>();
            services.AddScoped<ICatalogoRepository, CatalogoRepository>();
           
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ILiderRepository, LiderRepository>();
            services.AddScoped<ILiderService, LiderService>();


            services.AddScoped<IActividadDiariaRepository, ActividadDiariaRepository>();
            services.AddScoped<ICatalogoRepository, CatalogoRepository>();
            services.AddScoped<ICatalogoService, CatalogoService>();
            services.AddScoped<IBajaEquipoService, BajaEquiposService>();
            services.AddScoped<IBajaRepository, BajaEquipoRepository>();
            services.AddScoped<IMantenimientoService, MantenimientoService>();
            services.AddScoped<IMantenimientoRepository, MantenimientoRepository>();
            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IEquipoService, EquipoService>();
            services.AddScoped<IEquipoRepostirory, EquipoRepository>();

            services.AddTransient<IAuthenticationService, TokenAuthenticationService>();

            services.AddScoped<IEquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice, EquipoPersonaEquipoPersonaEquipoPersonaAsignacionservice>();
            services.AddScoped<IAsignacionRepository, AsignacionRepository>();
            services.AddScoped<IAsignacionArticuloService, AsignacionArticuloService>();
            services.AddScoped<IAsignacionArticuloRepository, AsignacionArticuloRepository>();

            services.AddScoped<IHistorialEquipoRepository, HistorialRepository>();
            services.AddScoped<IHistorialEquipoService, HistorialEquipoService>();
            services.AddScoped<IPaginaService, PaginaService>();
            services.AddScoped<IPaginaRepository, PaginaRespository>();
            services.AddScoped<ExcelService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPerfilesPersonasRepository, PerfilesPersonasRepository>();
            services.AddScoped<IPerfilesPersonasService, PerfilesPersonasService>();
            services.AddScoped<ICursosTomadosIscService, CursosTomadosIscService>();
            services.AddScoped<ICursosTomadosIscRepository, CursosTomadosIscRepository>();
            services.AddScoped<IFeedbackProgresoHistoricoRepository, FeedbackProgresoHistoricoRepository>();
            services.AddScoped<IFeedbackProgresoHistoricoService, FeedbackProgresoHistoricoService>();
            services.AddScoped<IHistorialLaboralRepository, HistorialLaboralRepository>();
            services.AddScoped<IHistorialLaboralService, HistorialLaboralService>();

            return services;
        }
    }
}
