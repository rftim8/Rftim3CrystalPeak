using Rftim3Convoy.Data;
using Rftim3Convoy.Dotnet;
using Rftim3Convoy.Services.Static.IO;
using Rftim3LeetCode.Benchmarking;
using Rftim3LeetCode.CP;

namespace Rftim3LeetCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            #region Benchmarking
            //await RftBenchmark.InitBenchmark();
            #endregion

            #region Hosting
            await CPHostMain.InitHost(args);
            //await DataHostMain.InitHost(args);
            //await DotnetHostMain.InitHost(args);
            #endregion

            //RftFileContentManager.CleanCodeForcesProblemNames();
        }
    }
}
