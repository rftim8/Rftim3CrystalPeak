using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Static.IO;
using Rftim3LeetCode.Refactor;

namespace Rftim3LeetCode.CP
{
    internal class CPHostBase : ICPHostBase
    {
        public void RunCPHostBase(IHost host) => RunCPHostBase0(host.Services);

        private static void RunCPHostBase0(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            //RftFileContentManager.GetLeetCodeProblemNames();
            //RftFileContentManager.CreateLeetCodeDataFiles(RftFileContentManager.GetLeetCodeProblemNames());
            //RftFileContentManager.CreateLeetCodeCodeInterfaceFiles(RftFileContentManager.GetLeetCodeProblemNames());
            //RftFileContentManager.CreateLeetCodeCodeFiles(RftFileContentManager.GetLeetCodeProblemNames());
            //RftFileContentManager.CreateLeetCodexUnitTestFiles(RftFileContentManager.GetLeetCodeProblemNames());

            #region LeetCode
            I_00001_TwoSum i_00001_TwoSum = serviceProvider.GetRequiredService<I_00001_TwoSum>();

            i_00001_TwoSum.PrintSolution();
            #endregion

        }
    }
}
