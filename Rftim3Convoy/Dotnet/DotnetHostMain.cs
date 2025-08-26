using Microsoft.Extensions.Hosting;

namespace Rftim3Convoy.Dotnet
{
    public class DotnetHostMain
    {
        public static async Task InitHost(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            IHost host = builder.Build();

            await host.StartAsync();
            _ = new DotnetHostBase(host);

            await ShutdownHost(host);
        }

        public static async Task ShutdownHost(IHost host)
        {
            host.Dispose();
            await host.StopAsync();
        }
    }
}
