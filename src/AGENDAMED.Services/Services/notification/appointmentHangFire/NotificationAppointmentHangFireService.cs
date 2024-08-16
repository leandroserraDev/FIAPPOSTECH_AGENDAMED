using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.email.appointment;
using AGENDAMED.Domain.Interface.Services.notificationAppointHangFire;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.notification.appointmentHangFire
{
    public class NotificationAppointmentHangFireService : INotificationAppointmentHangFireService
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IConfiguration _configuration;

        public NotificationAppointmentHangFireService(IAppointmentService appointmentService, IConfiguration configuration)
        {
            _appointmentService = appointmentService;
            _configuration = configuration;
        }

        public async Task SendEmailDayBeforeAppointment()
        {
            var result = await _appointmentService.GetAppointmentsOneHour();
            var emailTO = "";
            result.ForEach(obj =>
            {
                emailTO.Concat($",{obj.Patient.Email}");

            });

            if (!string.IsNullOrEmpty(emailTO)) 
            {
                var email = new EmailAppointment(emailTO, "Consulta em 2 horas", "Você tem uma consulta em duas horas", _configuration);
                email.SendEmail();
            }


          

        }
    }
}
