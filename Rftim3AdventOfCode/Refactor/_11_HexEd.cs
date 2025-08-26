using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _11_HexEd : I_11_HexEd
    {
        #region Static
        private readonly List<string>? data;

        public _11_HexEd()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_11_HexEd));
        }

        /// <summary>
        /// Crossing the bridge, you've barely reached the other side of the stream when a program comes up to you, clearly in distress. 
        /// "It's my child process," she says, "he's gotten lost in an infinite grid!"
        /// 
        /// Fortunately for her, you have plenty of experience with infinite grids.
        /// 
        /// Unfortunately for you, it's a hex grid.
        /// 
        /// The hexagons ("hexes") in this grid are aligned such that adjacent hexes can be found to the north, northeast, southeast, south, southwest, and northwest:
        /// 
        ///   \ n  /
        /// nw +--+ ne
        ///   /    \
        /// -+      +-
        ///   \    /
        /// sw +--+ se
        ///   / s  \
        /// You have the path the child process took.Starting where he started, you need to determine the fewest number of steps required to reach him. 
        /// (A "step" means to move from the hex you are in to any adjacent hex.)
        /// 
        /// For example:
        /// 
        /// ne,ne,ne is 3 steps away.
        /// ne, ne, sw, sw is 0 steps away (back where you started).
        /// ne,ne,s,s is 2 steps away(se, se).
        /// se,sw,se,sw,sw is 3 steps away(s, s, sw).
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            return input[0].Split(',').ToDistances().Last();
        }

        /// <summary>
        /// How many steps away is the furthest he ever got from his starting position?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            return input[0].Split(',').ToDistances().Max();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _11_HexEd(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_11_HexEd));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }

    static class Extensions0
    {
        public static IEnumerable<int> ToDistances(this IEnumerable<string> steps)
        {
            (int n, int ne, int se, int s, int sw, int nw) = (0, 0, 0, 0, 0, 0);
            foreach (string step in steps)
            {
                switch (step)
                {
                    case "n": ReduceN(); break;
                    case "ne": ReduceNE(); break;
                    case "se": ReduceSE(); break;
                    case "s": ReduceS(); break;
                    case "sw": ReduceSW(); break;
                    case "nw": ReduceNW(); break;
                }
                yield return n + ne + se + s + sw + nw;
            }

            void ReduceN() { if (se > 0) { se--; ReduceNE(); } else if (sw > 0) { sw--; ReduceNW(); } else if (s > 0) { s--; } else { n++; } }
            void ReduceNE() { if (nw > 0) { nw--; ReduceN(); } else if (s > 0) { s--; ReduceSE(); } else if (sw > 0) { sw--; } else { ne++; } }
            void ReduceSE() { if (sw > 0) { sw--; ReduceS(); } else if (n > 0) { n--; ReduceNE(); } else if (nw > 0) { nw--; } else { se++; } }
            void ReduceS() { if (ne > 0) { ne--; ReduceSE(); } else if (nw > 0) { nw--; ReduceSW(); } else if (n > 0) { n--; } else { s++; } }
            void ReduceSW() { if (se > 0) { se--; ReduceS(); } else if (n > 0) { n--; ReduceNW(); } else if (ne > 0) { ne--; } else { sw++; } }
            void ReduceNW() { if (ne > 0) { ne--; ReduceN(); } else if (s > 0) { s--; ReduceSW(); } else if (se > 0) { se--; } else { nw++; } }
        }
    }
}