using AGENDAMED.Domain.Entities.notification;
using AGENDAMED.Domain.Interface.Services.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.notification
{
    public class NotificationErrorService : INotificationErrorService
    {
        private List<Notification> _notifications;

        public NotificationErrorService()
        {
            _notifications =  new List<Notification>();
        }

        public async Task<List<Notification>> AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
            return await Task.FromResult(_notifications);
        }

        public async Task<bool> HasNotifications()
        {
            return await Task.FromResult(_notifications.Count() > 0);
        }

        public List<Notification> Notifications()
        {
            return _notifications;
        }
    }
}
