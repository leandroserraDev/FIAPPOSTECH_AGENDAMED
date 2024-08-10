using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user.patient
{
    public class Patient : EntityID
    {

        public string UserID { get; set; }
    }
}
