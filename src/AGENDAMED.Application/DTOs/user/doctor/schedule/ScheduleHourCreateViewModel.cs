using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.schedule
{
    public class ScheduleHourCreateViewModel
    {
        public string Time { get; set; }

        public ScheduleTime ToDomain()
        {
            var newScheduleHour = new ScheduleTime() { Time = TimeSpan.Parse(Time)};

            return newScheduleHour;
        }

    }
}
