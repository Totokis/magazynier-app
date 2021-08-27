using System;
using System.Threading;
using System.Threading.Tasks;
using MagazynierApp.Server.Controllers;
using Magazynier.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Magazynier.Server
{
    public class MachineMonitorService: IHostedService, IDisposable
    {
        private int _executionCount = 0;
        private readonly ILogger<MachineMonitorService> _logger;
        private readonly INotificationManager _notificationManager;
        private Timer _timer;
        public MachineMonitorService(ILogger<MachineMonitorService> logger, INotificationManager notificationManager)
        {
            _logger = logger;
            _notificationManager = notificationManager;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
           _logger.LogInformation("Machine Monitor Service running");

           _timer = new Timer(CheckMachinesState,null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
           
           return Task.CompletedTask;
        }
        private void CheckMachinesState(object? state)
        {
            var machines = MachinesController.ListOfMachines;

            foreach (var machine in machines)
            {
                if(machine.IsAlmostEmpty)
                    _notificationManager.AddNotification(new MachineWarningNotification(machine));
            }
            _notificationManager.SendNotification();
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Machine Monitor Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
