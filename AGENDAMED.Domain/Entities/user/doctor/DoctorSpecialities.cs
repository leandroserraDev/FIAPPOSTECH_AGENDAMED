using AGENDAMED.Domain.Entities.speciality;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user.doctor
{
    public class DoctorSpecialities:EntityID
    {

        public long SpecialtyID{ get; set; }
        public Speciality Speciality { get; set; }
        public string DoctorID{ get; set; }

        public virtual IList<ScheduleSpecialityDoctor> SchedulesSpecialityDoctor { get; set; }


    }
}
