using IPM.Core.Contracts.Services.SMTP;
using System.Net.Mail;
using System.Net;
using System.Text;
using IPM.Core.Models.SMTP;
using IPM.Core.Constants;
using Microsoft.Extensions.Configuration;

namespace IPM.Infraestructure.Services.SMTP
{
    
    public class EmailService : IEmailService
    {
       
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Send(List<string> destinatarios, EmailParams emailParams, out string message)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(emailParams.EmailOrigen);
            msg.Subject = emailParams.asunto;
            msg.Body = emailParams.Body;
            msg.IsBodyHtml = true;

            foreach (var destinatario in destinatarios)
            {
                msg.To.Add(destinatario);
            }

            SmtpClient smtp = new SmtpClient
            {
                Host = _configuration["Email:Host"],
                Port = int.Parse(_configuration["Email:Port"]),
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailParams.EmailOrigen, emailParams.Contraseña)
            };

            try
            {
                smtp.Send(msg);
                smtp.Dispose();
                message = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                message = "Error enviando correo electrónico: " + ex.Message;
                //T0D0: escribir login de error             
            }
        }

    }
}


