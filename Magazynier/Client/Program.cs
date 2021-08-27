using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;

namespace Magazynier.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<User>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddMudServices(configuration => {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
            } );
            await builder.Build().RunAsync();
        }
    }
}
