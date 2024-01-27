using IPM.Core.Dtos;

namespace IPM.Core.Contracts.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaDto>> ObtenerTodosLosPersonaAsync();
        Task<PersonaDto> ObtenerPersonaPorIdAsync(int personaId);
        Task<InformacionPersonaDto> ObtenerInformacionUsuario(int usuario);
        Task<bool> CrearPersonaAsync(PersonaCreacionDTO personaDto);
        Task<bool> ActualizaPersonaAsync(int personaId, PersonaDto personaDto);
        Task<bool> ActualizarInformacionPerfil(int idpersona, InformacionActualizarPersonaDto infoActPerfil);
        Task<bool> EliminarPersonaAsync(int personaId);
    }
}       
