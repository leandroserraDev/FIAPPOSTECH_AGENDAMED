using AGENDAMED.Domain.Entities.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.notification
{
    public interface INotificationErrorService
    {
        List<Notification> Notifications();
        Task<List<Notification>> AddNotification(string message);
        Task<bool> HasNotifications();
    }
}
