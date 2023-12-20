using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<Notification>> GetUnreadNotifications(string username)
        {
            return await _notificationRepository.GetUnreadNotifications(username);
        }

        public async Task<List<Notification>> GetAllNotification()
        {
            return await _notificationRepository.GetAllNotification();
        }

        public async Task<Notification> MarkNotificationAsRead(int id)
        {
            return await _notificationRepository.MarkNotificationAsRead(id);
        }
    }
}
