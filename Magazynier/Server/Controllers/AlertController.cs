using System;
using System.Collections.Generic;
using System.Linq;
using Magazynier.Shared;
using MagazynierApp.Server;
using Microsoft.AspNetCore.Mvc;

namespace Magazynier.Server.Controllers
{
    [Route("alerts")]
    [ApiController]
    public class AlertController: Controller
    {
        private INotificationManager _notificationManager;
        public AlertController(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        [HttpGet]
        public List<MachineWarningNotification> GetAlerts()
        {
            var manager = _notificationManager as MachineNotificationManager;
            return manager.MachineNotifications;
        }

        [HttpPut]
        public void DeleteAlert(int index)
        {
            var manager = _notificationManager as MachineNotificationManager;
            manager.MachineNotifications.RemoveAt(index);
            Console.WriteLine($"Index: {index}");
        }
    }
}
