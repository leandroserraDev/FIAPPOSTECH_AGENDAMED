using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.notification
{
    public class Notification
    {
        public Notification( string message)
        {
            ID = Guid.NewGuid();
            Message = message;
        }

        public Guid ID { get; private set; }

        public string Message { get; private set; }

    }

}
