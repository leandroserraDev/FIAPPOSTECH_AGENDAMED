using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.Calender
{
    public class CalendarViewMode
    {

        public string DateCalendar{ get; set; }

        public CalendarViewMode(string dateCalendar)
        {
            DateCalendar = dateCalendar;
        }
    }
}
