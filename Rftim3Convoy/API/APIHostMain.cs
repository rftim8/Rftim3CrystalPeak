using Microsoft.Extensions.Hosting;

namespace Rftim3Convoy.API
{
    internal class APIHostMain
    {
        public static async Task InitHost(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            IHost host = builder.Build();
            await host.StartAsync();

            await ShutdownHost(host);
        }

        public static async Task ShutdownHost(IHost host)
        {
            host.Dispose();
            await host.StopAsync();
        }
    }
}
