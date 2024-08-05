using IPM.Core.Common.Security;
using IPM.Core.Contracts.Services;
using IPM.Core.Dtos;
using IPM.Core.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using IPM.Core.Constants;
using IPM.Core.Models.SMTP;
using IPM.Core.Contracts.Services.SMTP;
using Microsoft.AspNetCore.Mvc;
using IPM.Core.Models.Seguridad;

namespace IPM.WebApi.Controllers;

[ApiController]
[Route("api/autenticacion")]
[AllowAnonymous]
public class AuthController : BaseApiController <AuthController>
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthenticationService   _authenticationService;
    private readonly ILogger<AuthController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;


    public AuthController(IUsuarioService usuarioService, IEmailService emailService, IConfiguration configuration, IAuthenticationService authenticationService, ILogger<AuthController> logger)
    {
        _usuarioService = usuarioService;
        _authenticationService = authenticationService;
        _emailService = emailService;
        _configuration = configuration;
        _logger = logger;

    }



    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var response = new Response<object>(true, "OK");

        if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Contraseña))
        {
            response.Update(false, "Credenciales inválidas", "");
            return BadRequest(response);
        }

        request.Contraseña = Security.GetSHA256(request.Contraseña);

        try
        {
            var datosUsuario = await _authenticationService.IsAuthenticated(request);
            if (datosUsuario == null)
                return BadRequest(response.Update(false, "Usuario o contraseña incorrectas.", null));

            response.Data = datosUsuario;
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, "Lo sentimos, ocurrió un error en la autenticación.", null));
        }
    }

    [AllowAnonymous]
    [HttpPost, Route("forgot-password")]
    public ActionResult ForgotPassword([FromBody] ForgotPassword request)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(response.Update(false, "El correo electrónico es obligatorio", null));

            if (!_usuarioService.Existe(request.Email))
                return BadRequest(response.Update(false, "El correo electrónico no se encuentra vinculado a una cuenta.", null));

            string code = VerificationCode.Generate(5);
            _usuarioService.RegisterVerificationCode(request.Email, code.ToUpper());

          
            string message;

            string ruta = "Template/Restablecer.html";
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);
            string htmlContent = System.IO.File.ReadAllText(rutaCompleta);

            htmlContent = htmlContent.Replace("@code", code);

            var destinatarios = new List<string>();
            destinatarios.Add(request.Email);

            // Utiliza el servicio para enviar el correo a múltiples destinatarios
            _emailService.Send(destinatarios, new EmailParams
            {
                EmailOrigen = _configuration["Email:EmailOrg"],
                Contraseña = _configuration["Email:Contra"],
                asunto = EmailConstants.RestablecimientoContrasena,
                Body = htmlContent
            }, out message);

            Logger.LogError($"Respuesta email con código de verificación: ${code} | " + message);

            response.Message = message;
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, ex.Message, null));
        }
    }

    [AllowAnonymous]
    [HttpPost, Route("verify-code")]
    public ActionResult VerifyCode([FromBody] CodeForgotPassword request)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(response.Update(false, "El correo electrónico es obligatorio", null));

            if (!_usuarioService.Existe(request.Email))
                return BadRequest(response.Update(false, "El correo electrónico no se encuentra vinculado a una cuenta.", null));

            var verifyResponse = _usuarioService.VerifyCode(request.Email, request.Code.ToUpper());
            response.Message = verifyResponse.Message;
            response.Success = verifyResponse.IsSuccess;

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, ex.Message, null));
        }
    }


    [AllowAnonymous]
    [HttpPost, Route("change-password")]
    public ActionResult ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var response = new Response<string>(true, "OK");
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(response.Update(false, "El correo electrónico es obligatorio", null));

            request.NewPassword = Security.GetSHA256(request.NewPassword);

            var verifyResponse = _usuarioService.ChangePassword(request.Email, request.NewPassword);
            response.Message = verifyResponse.Message;
            response.Success = verifyResponse.IsSuccess;

            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return Conflict(response.Update(false, ex.Message, null));
        }
    }



}
