using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user.doctor
{
    public class Doctor: EntityID
    {

        public string UserID { get;  set; }
        public virtual User User{ get;  set; }
        public string CRM { get;  set; }

        public IList<DoctorSpecialities>Specialities { get; set; }

        public Doctor(string cRM, string userID)
        {
            CRM = cRM;
            UserID = userID;
            Specialities = new List<DoctorSpecialities>();
        }
        public Doctor(string cRM)
        {
            CRM = cRM;
            Specialities = new List<DoctorSpecialities>();
        }
        public Doctor()
        {

        }
     
    }
}
