using System.Threading.Tasks;
using Magazynier.Shared;
using Magazynier.Shared;

namespace Magazynier.Server
{
    public interface INotificationManager
    {
        void AddNotification(INotification notification);
        Task SendNotification();
    }
}
