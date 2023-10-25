using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using IPM.Core.Dtos;
using MailKit.Security;

namespace IPM.Infraestructure.Services
{
    public static class CorreoService
    {
        private static string _Host = "smtp.gmail.com";
        private static int _Puerto = 587;

        private static string _NombreEnvia = "TuNombre";
        private static string _Correo = "TuCorreo@gmail.com";
        private static string _Clave = "TuClaveDeCorreo";

        public static bool Enviar(CorreoDto correodto)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress(_NombreEnvia, _Correo));
                email.To.Add(MailboxAddress.Parse(correodto.Para));
                email.Subject = correodto.Asunto;
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = correodto.Contenido
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(_Host, _Puerto, SecureSocketOptions.StartTls);

                    smtp.Authenticate(_Correo, _Clave);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
