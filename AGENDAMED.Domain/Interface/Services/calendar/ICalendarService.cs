using AGENDAMED.Domain.Entities.calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.calendar
{
    public interface ICalendarService
    {
        Task<IList<Calendar>> CalendarDoctor(string doctorID, DateTime startPeriod, DateTime? endPeriod = null);
    }
}
