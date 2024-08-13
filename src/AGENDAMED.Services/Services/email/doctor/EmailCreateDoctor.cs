using AGENDAMED.Domain.Interface.Services.email.emailBase;
using AGENDAMED.Services.Services.email.emailBase;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.email.doctor
{
    public class EmailCreateDoctor : EmailBase
    {
        public EmailCreateDoctor(string sendTO, string message, string subject, IConfiguration configuration) : 
            base(sendTO, message, subject, configuration)
        {
        }
    }
}
