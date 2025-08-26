using Rftim3AdventOfCode.Benchmarking;
using Rftim3AdventOfCode.CP;

namespace Rftim3AdventOfCode
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
            #endregion
        }
    }
}
