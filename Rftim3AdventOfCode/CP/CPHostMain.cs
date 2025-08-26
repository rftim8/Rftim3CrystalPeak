using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3AdventOfCode.CP
{
    internal class CPHostMain
    {
        public static async Task InitHost(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddSingleton<ICPHostBase, CPHostBase>();

            builder.Services.AddSingleton<IRftAdventOfCodeHostData, RftAdventOfCodeHostData>();

            #region AdventOfCode
            builder.Services.AddSingleton<I_01_CalorieCounting, _01_CalorieCounting>();
            builder.Services.AddSingleton<I_01_ChronalCalibration, _01_ChronalCalibration>();
            builder.Services.AddSingleton<I_01_HistorianHysteria, _01_HistorianHysteria>();
            builder.Services.AddSingleton<I_01_InverseCaptcha, _01_InverseCaptcha>();
            builder.Services.AddSingleton<I_02_RedNosedReports, _02_RedNosedReports>();
            builder.Services.AddSingleton<I_03_MullItOver, _03_MullItOver>();
            builder.Services.AddSingleton<I_04_CeresSearch, _04_CeresSearch>();
            builder.Services.AddSingleton<I_05_PrintQueue, _05_PrintQueue>();
            builder.Services.AddSingleton<I_06_GuardGallivant, _06_GuardGallivant>();
            builder.Services.AddSingleton<I_07_BridgeRepair, _07_BridgeRepair>();
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
