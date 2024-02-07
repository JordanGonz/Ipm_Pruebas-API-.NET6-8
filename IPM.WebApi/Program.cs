using IPM.Core.Common;
using IPM.Core.Contracts.Middleware;
using IPM.Core.Models.Seguridad;
using IPM.Infraestructure;
using IPM.Infraestructure.MainContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using IPM.Infraestructure.Mappers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile(o => o.RootPath = o.RootPath = @"C:\IPM_Logs");

builder.Services.AddCors(options =>
{
    options.AddPolicy("ISCPolicy", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddInfraestructureDependencies();

builder.Services.AddAutoMapper(
    typeof(CatalogoProfile),
    typeof(ActividadDiariaProfile),
    typeof(BajaEquiposProfile),
    typeof(MantenimientoProfile),
    typeof(ArticuloProfile),
    typeof(EquipoProfile),
    typeof(HistorialEquipo),
    typeof(PaginaProfile),
    typeof(PerfilesPersonasProfile),
    typeof(FeedbackProgresoHistoricoProfile),
    typeof(ClienteProfile),
    typeof(LiderProfile),
    typeof(HistorialLabolarProfile)

);

builder.Services.AddDbContext<IntegrityProjectManagementContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("registroOficina")));

builder.Services.Configure<TokenManagement>(builder.Configuration.GetSection("TokenManagement"));
var tokenManagement = builder.Configuration.GetSection("TokenManagement").Get<TokenManagement>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenManagement.Secret)),
        ValidIssuer = tokenManagement.Issuer,
        ValidAudience = tokenManagement.Audience,
        ValidateIssuer = true,
        ValidateAudience = false
    };


});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Inserte su token JWT aqu�",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionHandler, GenericExceptionHandler>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{

}
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Path}");
    await next();
});
app.UseCors("ISCPolicy");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Integrity Project Management v1.0");

});


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "ImagenesPersonas")),
    RequestPath = "/ImagenesPersonas"
});

app.UseExceptionMiddleware();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();