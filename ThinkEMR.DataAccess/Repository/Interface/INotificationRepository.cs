using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetUnreadNotifications(string username);
        Task<List<Notification>> GetAllNotification();

        Task<Notification> MarkNotificationAsRead(int id);

    }
}
