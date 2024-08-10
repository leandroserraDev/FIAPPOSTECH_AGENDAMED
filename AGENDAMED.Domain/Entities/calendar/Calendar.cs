using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.calendar
{
    public class Calendar
    {
        public DateTime Date { get; set; }

        public Calendar(DateTime date)
        {
            Date = date;
        }
    }
}
