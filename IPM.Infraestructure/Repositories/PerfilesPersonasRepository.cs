using IPM.Core.Constants;
using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Repositories
{
    public class PerfilesPersonasRepository : IPerfilesPersonasRepository
    {
        private readonly IntegrityProjectManagementContext _context;

        public PerfilesPersonasRepository(IntegrityProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<InformacionPersonal> ObtenerInformacionPersonalAsync(int id)
        {

            var asing = await _context.Personas
                .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .Where(a => a.IdPersona == id)
                .Join(_context.Catalogos,
                            persona => persona.Genero, 
                            catalogo => catalogo.IdCatalogo,
                            (persona, catalogo) => new { Persona = persona, Catalogo = catalogo })
                .Join(_context.Catalogos,
                              joined => joined.Persona.Cargo,
                              cargoCatalogo => cargoCatalogo.IdCatalogo,
                              (joined, cargoCatalogo) => new { joined.Persona, joined.Catalogo, CargoCatalogo = cargoCatalogo })
                    .Select(joined => new InformacionPersonal
                    {
                        Imagen = joined.Persona.Imagen,
                        Nombre = joined.Persona.Nombres,
                        Apellido = joined.Persona.Apellidos,
                        Identificacion = joined.Persona.NumeroIdentificacion,
                        Genero = joined.Catalogo.Descripcion,
                        cargo = joined.CargoCatalogo.Descripcion,
                        Correo1 = joined.Persona.EmailPersonal,
                        Correo2 = joined.Persona.EmailCorporativo,
                        Github = joined.Persona.Github,
                        Linkedin = joined.Persona.Linkedin
                    })
                .FirstOrDefaultAsync();
            return asing;
        }
        public async Task<List<StackTecnologicoPerfil>> ObtenerListadoStackTecnologicoAsync(int id)
        {
          

            var asign = await _context.StackTecnologicos
                .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .Where(a => a.IdPersona == id)
                .Join(_context.Catalogos,
                            stack => stack.IdCatalogoStack,
                            catalogo => catalogo.IdCatalogo,
                            (stack, catalogo) => new { Stack = stack, Catalogo = catalogo })
                .Join(_context.Catalogos,
                              joined => joined.Stack.IdNivelDominioTecnologico,
                              cargoCatalogo => cargoCatalogo.IdCatalogo,
                              (joined, cargoCatalogo) => new { joined.Stack, joined.Catalogo, CargoCatalogo = cargoCatalogo })
                .Select(a => new StackTecnologicoPerfil
                {
                    Tecnologias = a.Stack.Tecnologias,
                    IdCatalogoStack = a.Catalogo.Descripcion,
                    IdNivelDominioTecnologico = a.CargoCatalogo.Descripcion,
                })
                .ToListAsync();

            return asign;
        }

        public async Task<List<HistorialLaboralPerfil>> ObtenerListadoHistorialLaboralAsync(int id)
        {

            var asign = await _context.HistorialLaborals
                .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .Where(a => a.IdPersona == id)
                .Select(a => new HistorialLaboralPerfil
                {
                    Empresa = a.Empresa,
                    FechaDesde = a.FechaDesde,
                    FechaHasta = a.FechaHasta,
                    Cargo = a.Cargo,
                    DescripcionSalida = a.DescripcionSalida
                })
                .ToListAsync();

            return asign;
        }


        public async Task<List<CursosTomadosPerfil>> ObtenerListadoCursosTomadosAsync(int id)
        {
            var asign = await _context.CursosTomados
                .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                .Where(a => a.IdPersona == id)
                .Select(a => new CursosTomadosPerfil
                { 
                    NombreCurso = a.NombreCurso,
                    HorasCurso = a.HorasCurso,
                    FechaDesde = a.FechaDesde,
                    FechaHasta = a.FechaHasta,
                    ProgresoPorcentaje = a.ProgresoPorcentaje
                })
                .ToListAsync();

            return asign;
        }

        public async Task<List<FeedbackProgresoHistoricoPerfil>> ObtenerListadoFeedbackProgresoHistoricoAsync(int id)
        {

            var asign = await _context.FeedbackProgresoHistoricos
                    .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
                    .Where(a => a.IdPersona == id)
                    .GroupBy(a => a.IdPersona)  
                    .Select(group => new FeedbackProgresoHistoricoPerfil
                    {
                        Entrevistas = group.Select(a => a.Entrevistas).ToArray(),
                        Observaciones = group.Select(a => a.Observaciones).ToArray(),
                        Alertas = group.Select(a => a.Alertas).ToArray(),
                    })
                    .ToListAsync();

            return asign;
        }

        public async Task<List<BusquedaDePerfiles>> ObtenerListadoDeBusquedaPerfilAsync(string busqueda)
        {
            var resultadoBusqueda = await _context.Personas
           .Where(a => a.Estado == IPMConstants.ESTADO_ACTIVO)
           .Where(a => a.Nombres.Contains(busqueda) || a.Apellidos.Contains(busqueda) || 
           _context.Catalogos.Any(c => c.IdCatalogo == a.Cargo && c.Descripcion.Contains(busqueda)))
           .Select(a => new
           {
               Persona = a,
               Catalogo = _context.Catalogos
                   .Where(c => c.IdCatalogo == a.Cargo)
                   .FirstOrDefault()
           })
           .ToListAsync();

            // Construir la lista de BusquedaDePerfiles utilizando la información obtenida
            var busquedaDePerfiles = resultadoBusqueda.Select(a => new BusquedaDePerfiles
            
            {
                IdPersona = a.Persona.IdPersona,
                Imagen = a.Persona.Imagen,
                Nombre = a.Persona.Nombres,
                Apellido = a.Persona.Apellidos,
                IdCargo = a.Persona.Cargo,
                Cargo = a.Catalogo != null ? a.Catalogo.Descripcion : null
            }).ToList();

            return busquedaDePerfiles;
            
           
        }




    }

}
