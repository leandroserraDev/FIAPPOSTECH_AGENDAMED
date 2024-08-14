using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.user.doctor.schedule
{
    public class ScheduleTime 
    {
        public ScheduleTime(string doctorID, long speciality, long dayOfWeek, TimeSpan time)
        {
            DoctorID = doctorID;
            Speciality = speciality;
            DayOfWeek = dayOfWeek;
            Time = time;
        }

        
        //contructor to view
        public ScheduleTime(TimeSpan time)
        {
            Time = time;
        }
        protected ScheduleTime() { }
        public string DoctorID { get; private set; }
        public long Speciality { get; private set; }
        public long DayOfWeek { get; private set; }
        public TimeSpan Time { get; private set; }

    }
}
