using AGENDAMED.Domain.Interface.Services.email.emailBase;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.email.appointment
{
    public class EmailAppointment : EmailBase, IEmailAppointment
    {
        public EmailAppointment(string sendTO, string message, string subject, IConfiguration configuration) 
            : base(sendTO, message, subject, configuration)
        {
        }
    }
}
