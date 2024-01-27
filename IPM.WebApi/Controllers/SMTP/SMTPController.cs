using IPM.Core.Constants;
using IPM.Core.Contracts.Services.SMTP;
using IPM.Core.Models.SMTP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Controllers.SMTP;
[Route("api/Emails")]
[ApiController]
[Authorize]

public class SMTPController : Controller
{
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    public SMTPController(IEmailService emailService, IConfiguration configuration)
    {
        _emailService = emailService;
        _configuration = configuration;
    }


    [HttpPost("enviar-correo-bienvenida")]
    public IActionResult EnviarCorreoBienvenida([FromBody] List<string> destinatarios)
    {
        string message;
        string ruta = "Template/Bienvenidos.html";
        string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);
      
        string htmlContent = System.IO.File.ReadAllText(rutaCompleta);

        // Utiliza el servicio para enviar el correo a múltiples destinatarios
        _emailService.Send(destinatarios, new EmailParams
        {
            EmailOrigen = _configuration["Email:EmailOrg"],
            Contraseña = _configuration["Email:Contra"],
            asunto = EmailConstants.AsuntoBienvenida,
            Body = htmlContent
        }, out message);


        // Devuelve el resultado de la operación
        return Ok(new { Success = true, Message = message });
    }

    [HttpPost("enviar-correo-restablecer")]
    public IActionResult EnviarCorreoRestablecer([FromBody] List<string> destinatarios)
    {
        string message;

        string ruta = "Template/Restablecer.html";
        string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

        string htmlContent = System.IO.File.ReadAllText(rutaCompleta);

        // Utiliza el servicio para enviar el correo a múltiples destinatarios
        _emailService.Send(destinatarios, new EmailParams
        {
            EmailOrigen = _configuration["Email:EmailOrg"],
            Contraseña = _configuration["Email:Contra"],
            asunto = EmailConstants.RestablecimientoContrasena,
            Body = htmlContent
        }, out message);

        // Devuelve el resultado de la operación
        return Ok(new { Success = true, Message = message });
    }


}
