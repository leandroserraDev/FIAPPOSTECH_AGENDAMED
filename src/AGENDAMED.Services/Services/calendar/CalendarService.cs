using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Entities.calendar;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.calendar;
using AGENDAMED.Domain.Interface.Services.notification;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.calendar
{
    public class CalendarService : ICalendarService
    {
        private readonly IAppointmentService _appointmentService;
        private readonly INotificationErrorService _notificationErrorService;

        public CalendarService(IAppointmentService appointmentService, INotificationErrorService notificationErrorService)
        {
            _appointmentService = appointmentService;
            _notificationErrorService = notificationErrorService;
        }

        public async  Task<IList<Calendar>> CalendarDoctor(string doctorID, DateTime startPeriod, DateTime? endPeriod = null)
        {

            if(startPeriod.DayOfWeek.Equals(DayOfWeek.Saturday)
                ||
                startPeriod.DayOfWeek.Equals(DayOfWeek.Sunday)

                )
            {
                await _notificationErrorService.AddNotification("Não há atendimentos aos finais de semana");
                return null;
            }

            var dateTimeCalendar = new DateTime(startPeriod.Year, startPeriod.Month, startPeriod.Day, 10, 00, 00);
            var dateTimeInitPeriod = dateTimeCalendar;

            var predicateUser = PredicateBuilder.New<Appointment>();

            if (!string.IsNullOrEmpty(doctorID))
            {
                predicateUser = predicateUser.And(obj => obj.DoctorID.Equals(doctorID));
            }

            predicateUser = predicateUser.And(obj => obj.Date >= dateTimeCalendar);

            if (endPeriod is not null)
            {
                predicateUser = predicateUser.And(obj => obj.Date <= Convert.ToDateTime(endPeriod));
            }


            var appointmentDoctor = await _appointmentService.GetDoctorAppointments(predicateUser);

            var listCalender = new List<Calendar>();
            do
            {
                var newCalendar = new Calendar(dateTimeCalendar);

                if (!appointmentDoctor.Any(obj => obj.Date.Equals(newCalendar.Date))
                    &&
                   (newCalendar.Date.Hour < 12
                   ||
                    newCalendar.Date.Hour >= 13
                    )
                   )
                {
                    listCalender.Add(newCalendar);

                }

                dateTimeCalendar = dateTimeCalendar.AddMinutes(20.00);

            } while (dateTimeCalendar.Hour <  17);
            return await Task.FromResult(listCalender);
        }
    }
}
