
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaDto>> ObtenerTodosLosPersonaAsync();
        Task<PersonaDto> ObtenePersonaPorIdAsync(int personaId);
        Task<PersonaDto> CrearPersonaAsync(PersonaDto personaDto);
        Task<bool> ActualizaPersonaAsync(int personaId, PersonaDto personaDto);
        Task<bool> EliminarPersonaAsync(int personaId);
    }
}