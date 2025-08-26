using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _16_PermutationPromenade : I_16_PermutationPromenade
    {
        #region Static
        private readonly List<string>? data;

        public _16_PermutationPromenade()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_16_PermutationPromenade));
        }

        /// <summary>
        /// You come upon a very unusual sight; a group of programs here appear to be dancing.
        /// 
        /// There are sixteen programs in total, named a through p.They start by standing in a line: 
        /// a stands in position 0, b stands in position 1, and so on until p, which stands in position 15.
        /// 
        /// The programs' dance consists of a sequence of dance moves:
        /// 
        /// Spin, written sX, makes X programs move from the end to the front, but maintain their order otherwise. (For example, s3 on abcde produces cdeab).
        /// Exchange, written xA/B, makes the programs at positions A and B swap places.
        /// Partner, written pA/B, makes the programs named A and B swap places.
        /// For example, with only five programs standing in a line (abcde), they could do the following dance:
        /// 
        /// s1, a spin of size 1: eabcd.
        /// x3/4, swapping the last two programs: eabdc.
        /// pe/b, swapping programs e and b: baedc.
        /// After finishing their dance, the programs end up in order baedc.
        /// 
        /// You watch the dance for a while and record their dance moves (your puzzle input). In what order are the programs standing after their dance?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> data)
        {
            return 0;
        }

        /// <summary>
        /// Now that you're starting to get a feel for the dance moves, you turn your attention to the dance as a whole.
        /// Keeping the positions they ended up in from their previous dance, the programs perform it again and again: including the first dance, a total of one billion(1000000000) times.
        /// In the example above, their second dance would begin with the order baedc, and use the same dance moves:
        /// 
        /// s1, a spin of size 1: cbaed.
        /// x3/4, swapping the last two programs: cbade.
        /// pe/b, swapping programs e and b: ceadb.
        /// In what order are the programs standing after their billion dances?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> data)
        {
            return 0;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _16_PermutationPromenade(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_16_PermutationPromenade));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}