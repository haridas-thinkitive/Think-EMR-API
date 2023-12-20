using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Authentication.CustomData;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public NotificationRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<List<Notification>> GetUnreadNotifications(string username)
        {
            var userExist = await _userManager.FindByNameAsync(username);
            if (userExist != null)
            {
                var unreadNotifications = await _context.notifications.Where(notification => notification.UserId == userExist.Id).ToListAsync();
                if(unreadNotifications != null)
                {
                    return unreadNotifications;
                }
            }
            return null;
        }

        public async Task<List<Notification>> GetAllNotification()
        {
           return await _context.notifications.ToListAsync();
        }

        public async Task<Notification> MarkNotificationAsRead(int id)
        {
            var notification = await _context.notifications.FindAsync(id);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
                return notification;
            }
            return null;
        }
    }
}
