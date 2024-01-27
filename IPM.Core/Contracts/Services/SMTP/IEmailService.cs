using IPM.Core.Models.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Contracts.Services.SMTP
{
    public interface  IEmailService
    {
        void Send(List<string> destinatarios, EmailParams emailParams, out string message);
    }
}
