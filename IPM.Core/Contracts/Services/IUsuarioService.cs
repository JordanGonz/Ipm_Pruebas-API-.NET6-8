using IPM.Core.Dtos;
﻿using IPM.Core.Models.Seguridad;

namespace IPM.Core.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> ObtenerTodosLosUsuariosAsync();
        Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int usuarioId);
        Task<bool> RegistrarUsuarioCompletoAsync(RegistroCompletoDto registroCompletoDto);
        Task<List<RegistroCompletoDto>> ObtenerTodosLosRegistrosCompletosAsync();
        Task<UsuarioLoginDto> LoginAsync(string email, string contraseña);
        //Task<UsuarioLoginDto> LoginAsyc(string username, string contraseña);
        Task<bool> CrearUsuarioAsync(UsuarioCreacionDto usuarioDto);
        Task<bool> ActualizarUsuarioAsync(int usuarioId, UsuarioDto usuarioDto);
        Task<bool> EliminarUsuarioAsync(int usuarioId);
        CurrentUser GetByAuth(UserLogin req);

        bool Existe(string email);
        bool RegisterVerificationCode(string email, string code);
        VerifyCodeResponse VerifyCode(string email, string code);
        ChangePasswordResponse ChangePassword(string email, string code);
    }
}