using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.schedule
{
    public class ScheduleViewModel
    {
        public long DayOfWeek { get; set; }

        public ScheduleViewModel(Schedule schedule)
        {
            DayOfWeek = schedule.DayOfWeek;
            NameDayOfWeek = ((DayOfWeek)schedule.DayOfWeek).ToString();

            ScheduleTime = new List<ScheduleHourViewModel>();

            foreach(var scheduleTime in schedule.ScheduleTime)
            {
                ScheduleTime.Add(new ScheduleHourViewModel(scheduleTime)); 
            }

        }

        public string NameDayOfWeek { get; set; }
        public List<ScheduleHourViewModel> ScheduleTime{ get; set; }

   


    }
}
