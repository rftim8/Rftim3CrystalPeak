using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.CodinGame.Data;
using Rftim3Convoy.Services.Static.CP.CodinGame.Data;

namespace Rftim3CodinGame.Refactor
{
    public class _TheBridge : I_TheBridge
    {
        #region Static
        private readonly List<string>? data;

        public _TheBridge()
        {
            data = RftCodinGameStaticData.Input_Test(testType: false, problemName: nameof(_TheBridge));
        }

        /// <summary>
        ///
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            return 0;
        }

        /// <summary>
        ///
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            return 0;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftCodinGameHostData? RftCodinGameHostData;

        public _TheBridge(IHost host)
        {
            RftCodinGameHostData = host.Services.GetRequiredService<IRftCodinGameHostData>();
            data = RftCodinGameHostData.Input_Test(problemName: nameof(_TheBridge));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}