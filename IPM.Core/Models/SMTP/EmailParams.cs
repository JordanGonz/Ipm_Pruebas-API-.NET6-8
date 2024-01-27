using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Core.Models.SMTP
{
    public class EmailParams
    {
        public string EmailOrigen { get; set; }
        public string EmailDestino { get; set; }
        public string Contraseña { get; set; }
        public string Body { get; set; }
        public string asunto { get; set; }

    }
}

//public string SenderEmail { get; set; }
//public string SenderName { get; set; }
//public string Subject { get; set; }
//public string EmailTo { get; set; }
//public string Body { get; set; }