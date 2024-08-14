using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user.doctor.schedule
{
    public class ScheduleSpecialityDoctor :EntityID
    {
        public ScheduleSpecialityDoctor(string doctorID, ESpecialty speciality)
        {
            DoctorID = doctorID;
            SpecialityID = (long)speciality;
            Schedule = new List<Schedule>();
        }
        public ScheduleSpecialityDoctor(string doctorID, long specialityID)
        {
            DoctorID = doctorID;
            SpecialityID = specialityID;
            Schedule = new List<Schedule>();
        }
        protected ScheduleSpecialityDoctor()
        {
            
        }

        public string DoctorID { get; private set; }
        public long SpecialityID { get; private set; }
        public virtual List<Schedule> Schedule { get;  set; }
    }
}
