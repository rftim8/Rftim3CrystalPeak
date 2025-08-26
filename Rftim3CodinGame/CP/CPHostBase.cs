using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Static.IO;
using Rftim3CodinGame.Refactor;

namespace Rftim3CodinGame.CP
{
    internal class CPHostBase : ICPHostBase
    {
        public void RunCPHostBase(IHost host) => RunCPHostBase0(host.Services);

        private static void RunCPHostBase0(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            //RftFileContentManager.GetCodinGameProblemNames();
            //RftFileContentManager.CreateCodinGameDataFiles(RftFileContentManager.GetCodinGameProblemNames());
            //RftFileContentManager.CreateCodinGameCodeInterfaceFiles(RftFileContentManager.GetCodinGameProblemNames());
            //RftFileContentManager.CreateCodinGameCodeFiles(RftFileContentManager.GetCodinGameProblemNames());
            //RftFileContentManager.CreateCodinGamexUnitTestFiles(RftFileContentManager.GetCodinGameProblemNames());

            #region CodinGame
            I_1000000000DWORLD i_1000000000DWORLD = serviceProvider.GetRequiredService<I_1000000000DWORLD>();
            i_1000000000DWORLD.PrintSolution();

            //I_Staircases i_Staircases = serviceProvider.GetRequiredService<I_Staircases>();
            //i_Staircases.PrintSolution();
            #endregion
        }
    }
}
