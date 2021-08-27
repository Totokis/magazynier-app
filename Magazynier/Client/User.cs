using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Magazynier.Shared;

namespace Magazynier.Client
{
    public class User
    {
        private readonly HttpClient _httpClient;

        public User(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await _httpClient.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}
