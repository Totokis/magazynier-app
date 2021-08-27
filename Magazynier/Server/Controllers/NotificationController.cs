using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Magazynier.Shared;
using Magazynier.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebPush;

namespace Magazynier.Server.Controllers
{
    [Route("notifications")]
    [ApiController]
    public class NotificationController : Controller
    {
        public static List<NotificationSubscription> SubscriptionsStorage = new List<NotificationSubscription>();


        [HttpPut("subscribe")]
        public void Subscribe(NotificationSubscription subscription)
        {
            var userId = GetUserId();
            foreach (var notificationSubscription in SubscriptionsStorage.ToArray())//TODO add database
            {
                if (notificationSubscription.UserId == userId)
                    SubscriptionsStorage.Remove(notificationSubscription);
            }
            subscription.UserId = userId;
            SubscriptionsStorage.Add(subscription);
            Console.WriteLine("Subscription Added !");
        }
        
        
        private string GetUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
