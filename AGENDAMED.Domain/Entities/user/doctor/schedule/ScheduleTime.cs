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
        public string DoctorID { get; set; }
        public long Speciality { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }

    }
}
