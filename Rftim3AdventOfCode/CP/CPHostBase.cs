using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Static.IO;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3AdventOfCode.CP
{
    internal class CPHostBase : ICPHostBase
    {
        public void RunCPHostBase(IHost host) => RunCPHostBase0(host.Services);

        private static void RunCPHostBase0(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            //RftFileContentManager.GetAdventOfCodeProblemNames();
            //RftFileContentManager.CreateAdventOfCodeDataFiles(RftFileContentManager.GetAdventOfCodeProblemNames());
            //RftFileContentManager.CreateAdventOfCodeCodeInterfaceFiles(RftFileContentManager.GetAdventOfCodeProblemNames());
            //RftFileContentManager.CreateAdventOfCodeCodeFiles(RftFileContentManager.GetAdventOfCodeProblemNames());
            //RftFileContentManager.CreateAdventOfCodexUnitTestFiles(RftFileContentManager.GetAdventOfCodeProblemNames());

            #region AdventOfCode
            I_01_CalorieCounting i_01_CalorieCounting = serviceProvider.GetRequiredService<I_01_CalorieCounting>();
            i_01_CalorieCounting.PrintSolution();

            //I_01_ChronalCalibration i_01_ChronalCalibration = serviceProvider.GetRequiredService<I_01_ChronalCalibration>();

            //I_01_HistorianHysteria i_01_HistorianHysteria = serviceProvider.GetRequiredService<I_01_HistorianHysteria>();
            //i_01_HistorianHysteria.PrintSolution();

            //I_01_InverseCaptcha i_01_InverseCaptcha = serviceProvider.GetRequiredService<I_01_InverseCaptcha>();
            //i_01_InverseCaptcha.PrintSolution();

            //I_02_RedNosedReports i_02_RedNosedReports = serviceProvider.GetRequiredService<I_02_RedNosedReports>();
            //i_02_RedNosedReports.PrintSolution();

            //I_03_MullItOver i_03_MullItOver = serviceProvider.GetRequiredService<I_03_MullItOver>();
            //i_03_MullItOver.PrintSolution();

            //I_04_CeresSearch i_04_CeresSearch = serviceProvider.GetRequiredService<I_04_CeresSearch>();
            //i_04_CeresSearch.PrintSolution();

            //I_05_PrintQueue i_05_PrintQueue = serviceProvider.GetRequiredService<I_05_PrintQueue>();
            //i_05_PrintQueue.PrintSolution();

            //I_06_GuardGallivant i_06_GuardGallivant = serviceProvider.GetRequiredService<I_06_GuardGallivant>();
            //i_06_GuardGallivant.PrintSolution();

            //I_07_BridgeRepair i_07_BridgeRepair = serviceProvider.GetRequiredService<I_07_BridgeRepair>();
            //i_07_BridgeRepair.PrintSolution();
            #endregion
        }
    }
}
