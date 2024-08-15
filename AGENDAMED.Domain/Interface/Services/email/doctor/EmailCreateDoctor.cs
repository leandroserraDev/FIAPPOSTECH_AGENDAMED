using AGENDAMED.Domain.Interface.Services.email.emailBase;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.email.doctor.email

{ 
    public class EmailCreateDoctor : EmailBase
    {
        public EmailCreateDoctor(string sendTO, string message, string subject, IConfiguration configuration) : 
            base(sendTO, message, subject, configuration)
        {
        }
    }
}
