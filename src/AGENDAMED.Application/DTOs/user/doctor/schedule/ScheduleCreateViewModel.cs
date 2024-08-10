using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.schedule
{
    public class ScheduleCreateViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<ScheduleHourCreateViewModel> ScheduleHour{ get; set; }

        public Schedule ToDomain()
        {
            var newSchedule = new Schedule() { DayOfWeek = DayOfWeek};

            ScheduleHour.ForEach(obj =>
            {
     
                newSchedule.ScheduleTime.Add(obj.ToDomain());
            });

            return newSchedule;
        }


    }
}
