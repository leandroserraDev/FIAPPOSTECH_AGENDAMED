using AGENDAMED.Domain.Interface.Services.email.emailBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AGENDAMED.Services.Services.email.emailBase
{
    public abstract class EmailBase : IEmailBase
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;

        protected EmailBase( string sendTO, string message, string subject, IConfiguration configuration)
        {
            _configuration = configuration;
            var host = _configuration["ConfigurationMAILTrap:Host"];
            var port = _configuration["ConfigurationMAILTrap:Port"];
            var userName = _configuration["ConfigurationMAILTrap:UserName"];
            var password = _configuration["ConfigurationMAILTrap:Password"];





            _smtpClient = new SmtpClient(host, Convert.ToInt32(port))
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };

            SendTO = sendTO;
            Subject = subject;
            Body = message;

        }

        public string SendTO { get ; }
        public string Body { get ;  }
        public string Subject { get; }

        public void SendEmail()
        {

            _smtpClient.Send("from@example.com", SendTO, Subject, Body);

        }
    }
}
