using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.email.emailBase
{
    public interface IEmailBase 
    {

        void SendEmail();
        public string SendTO{ get; }
        public string Body { get; }
        public string Subject { get;}
    }
}
