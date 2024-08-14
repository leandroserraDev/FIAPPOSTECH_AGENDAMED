using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.schedule
{
    public class ScheduleHourViewModel
    {
        public string Time { get; set; }

        public ScheduleHourViewModel(ScheduleTime scheduleTime)
        {
            Time = string.Concat(scheduleTime.Time.Hours,":",scheduleTime.Time.Minutes.ToString("00"));
        }
    }
}
