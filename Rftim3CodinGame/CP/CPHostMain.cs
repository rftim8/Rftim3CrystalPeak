using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3CodinGame.Refactor;
using Rftim3Convoy.Services.Host.CP.CodinGame.Data;

namespace Rftim3CodinGame.CP
{
    internal class CPHostMain
    {
        public static async Task InitHost(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddSingleton<ICPHostBase, CPHostBase>();

            builder.Services.AddSingleton<IRftCodinGameHostData, RftCodinGameHostData>();

            #region CodinGame
            builder.Services.AddSingleton<I_1000000000DWORLD, _1000000000DWORLD>();
            builder.Services.AddSingleton<I_Staircases, _Staircases>();
            #endregion

            IHost host = builder.Build();

            await host.StartAsync();

            ICPHostBase cPHostBase = host.Services.GetRequiredService<ICPHostBase>();
            cPHostBase.RunCPHostBase(host);

            await ShutdownHost(host);
        }

        public static async Task ShutdownHost(IHost host)
        {
            host.Dispose();
            await host.StopAsync();
        }
    }
}
