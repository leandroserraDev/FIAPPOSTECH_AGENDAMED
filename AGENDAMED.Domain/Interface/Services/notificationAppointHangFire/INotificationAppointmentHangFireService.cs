using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.notificationAppointHangFire
{
    public interface INotificationAppointmentHangFireService
    {
        Task SendEmailDayBeforeAppointment();
    }
}
