using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Magazynier.Server.Controllers;
using MagazynierApp.Server.Controllers;
using Magazynier.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebPush;

namespace Magazynier.Server
{
    public class MachineNotificationManager: INotificationManager
    {
        public List<MachineWarningNotification> MachineNotifications = new List<MachineWarningNotification>();
        private readonly VapidConfiguration _vapidConfiguration;
        public MachineNotificationManager(IOptions<VapidConfiguration> vapidConfiguration)
        {
            _vapidConfiguration = vapidConfiguration.Value;
        }
        

        public void AddNotification(INotification notification)
        {
            var tempMachineNotification = notification as MachineWarningNotification;
            if (!MachineNotifications.Contains(tempMachineNotification))
            {
                MachineNotifications.Add(tempMachineNotification);
                Console.WriteLine("Notification added");
            }
        }
        
        public async Task SendNotification()
        {
            if (MachineNotifications.Count != 0)
            {
                foreach (var subscription in NotificationController.SubscriptionsStorage)
                {
                    await SendNotificationAsync(subscription);
                }
            }
            
        }
        
        private async Task SendNotificationAsync(NotificationSubscription subscription)
        {
            
            var publicKey = _vapidConfiguration.PublicKey;
            var privateKey = _vapidConfiguration.PrivateKey;

            var pushSubscription = new PushSubscription(subscription.Url, subscription.P256dh, subscription.Auth);
            var vapidDetails = new VapidDetails(_vapidConfiguration.Subject, publicKey, privateKey);
            var webPushClient = new WebPushClient();
            foreach (var notification in MachineNotifications)//TODO poprawić
            {
                try
                {
                        var payload = JsonConvert.SerializeObject(new
                        {
                            title = notification.Title,
                            message = notification.Message,
                            iconUrl = notification.IconUrl,
                            url = "mymachines/"
                        });
                        await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                        Console.WriteLine($"Notification send to {subscription.Url}");
                        
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Error sending push notification: "+ e.Message);
                }
            }
           
        }
    }
}
