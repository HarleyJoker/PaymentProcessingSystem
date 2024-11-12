using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using System.Collections.Generic;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {

        private static List<Notification> notifications = new List<Notification>();

        //sends a notification (simulated as adding to the list 
        [HttpPost]
        public ActionResult<Notification> SendNotification(Notification notification)
        {
            notification.NotificationId = notifications.Count + 1;
            notification.SentAt = DateTime.UtcNow;
            notifications.Add(notification);
            return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
        }


        //retrieves a specific notification by Id 
        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotification(int id)
        {
            var notification = notifications.Find(n => n.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }
    }
}
