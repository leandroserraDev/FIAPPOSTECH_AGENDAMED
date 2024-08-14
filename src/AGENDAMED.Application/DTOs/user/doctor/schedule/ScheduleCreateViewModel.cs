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
        public long DayOfWeek { get; set; }
        public List<ScheduleHourCreateViewModel> ScheduleTime{ get; set; }

        public Schedule ToDomain()
        {
            var newSchedule = new Schedule() { DayOfWeek = DayOfWeek};

            ScheduleTime.ForEach(obj =>
            {
     
                newSchedule.ScheduleTime.Add(obj.ToDomain());
            });

            return newSchedule;
        }


    }
}
