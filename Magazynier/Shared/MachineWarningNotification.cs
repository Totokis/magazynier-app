using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace Magazynier.Shared
{
    public class MachineWarningNotification: INotification
    {
        public MachineWarningNotification(Machine machine)
        {
            MachineName = machine.Name;
            ProductsToRefill = machine.ProductsToRefill;
            DistributionPoint = machine.Localization;
            AlertTime = DateTime.Now;
        }

        public MachineWarningNotification()
        {
            
        }

        public int Id { get; set; }

        public string MachineName { get; set; }

        public List<Product> ProductsToRefill { get; set; }

        public string DistributionPoint { get; set; }

        public DateTime AlertTime { get; set; }

        public string Message
        {
            get
            {
                var message = "";
                foreach (var product in ProductsToRefill)
                {
                    message += $"- {product.Name}: {product.Quantity}/{product.MaxQuantity} musi zostać uzupełniony.\n";
                }
                return message;
            }
        }

        public string Title => $"{MachineName} in: {DistributionPoint}";

        public string IconUrl => "img/machines/default.jpg";

        public override bool Equals(object obj)
        {
            return (obj is MachineWarningNotification notification)
                   && notification.MachineName == MachineName
                   && notification.DistributionPoint == DistributionPoint
                   && notification.ProductsToRefill.All(ProductsToRefill.Contains)
                   && notification.AlertTime - AlertTime <= TimeSpan.FromHours(2);
        }
        
    }
}
