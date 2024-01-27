using IPM.Core.Dtos;
using IPM.Infraestructure.Contracts.Repositories;
using IPM.Infraestructure.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Repositories
{
    public class PaginaRespository : IPaginaRepository
    {
        private readonly IntegrityProjectManagementContext _context;


        public PaginaRespository(IntegrityProjectManagementContext context )
        {
            _context = context;
        
        }

        public async Task<List<PaginaDto>> ListaDePaginaPorRol(int rol)
        {
            var asignaciones = await _context.PaginaRols
                .Include(a => a.IdPaginaNavigation)
                .Include(a => a.IdRolNavigation)
                 //.Where(a => a.IdRolNavigation.RolId == rol)
                 .Where(pr => pr.IdRolNavigation.RolUsuarios.Any(ur => ur.UsuariosUsuarioId == rol))
                 .GroupBy(a =>  a.IdPaginaNavigation)
                .Select(b => new PaginaDto
                {
                    IdRol = b.Select(a => a.IdRolNavigation.RolId).Distinct().ToList(),
                    Ruta = b.Key.Ruta,
                    Nombre = b.Key.Nombre,
                    Codigo = b.Key.Codigo,
                    RutaPadre = b.Key.RutaPadre,
                    RutaUrl = b.Key.RutaUrl,

                })
                .ToListAsync();
                 
            return asignaciones;
        }
    }
}
