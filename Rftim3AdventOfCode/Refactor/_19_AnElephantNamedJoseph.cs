using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _19_AnElephantNamedJoseph : I_19_AnElephantNamedJoseph
    {
        #region Static
        private readonly List<string>? data;

        public _19_AnElephantNamedJoseph()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_19_AnElephantNamedJoseph));
        }

        /// <summary>
        /// The Elves contact you over a highly secure emergency channel. Back at the North Pole, the Elves are busy misunderstanding White Elephant parties.
        /// 
        /// Each Elf brings a present.They all sit in a circle, numbered starting with position 1. 
        /// Then, starting with the first Elf, they take turns stealing all the presents from the Elf to their left.
        /// An Elf with no presents is removed from the circle and does not take turns.
        /// 
        /// For example, with five Elves(numbered 1 to 5):
        /// 
        ///   1
        /// 5   2
        ///  4 3
        /// Elf 1 takes Elf 2's present.
        /// Elf 2 has no presents and is skipped.
        /// Elf 3 takes Elf 4's present.
        /// Elf 4 has no presents and is also skipped.
        /// Elf 5 takes Elf 1's two presents.
        /// Neither Elf 1 nor Elf 2 have any presents, so both are skipped.
        /// Elf 3 takes Elf 5's three presents.
        /// So, with five Elves, the Elf that sits starting in position 3 gets all the presents.
        /// 
        /// With the number of Elves given in your puzzle input, which Elf gets all the presents?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int n = int.Parse(input[0]);
            int f = 1;

            while (Math.Pow(2, f) <= n)
            {
                f++;
            }
            int current = (int)Math.Pow(2, f - 1);

            return 2 * (n - current) + 1;
        }

        /// <summary>
        /// Realizing the folly of their present-exchange rules, the Elves agree to instead steal presents from the Elf directly across the circle.
        /// If two Elves are across the circle, the one on the left (from the perspective of the stealer) is stolen from. 
        /// The other rules remain unchanged: Elves with no presents are removed from the circle entirely, and the other elves move in slightly to keep the circle evenly spaced.
        /// 
        /// For example, with five Elves(again numbered 1 to 5):
        /// 
        /// The Elves sit in a circle; Elf 1 goes first:
        ///   1
        /// 5   2
        ///  4 3
        /// Elves 3 and 4 are across the circle; Elf 3's present is stolen, being the one to the left. Elf 3 leaves the circle, and the rest of the Elves move in:
        ///   1           1
        /// 5   2  -->  5   2
        ///  4 -          4
        /// Elf 2 steals from the Elf directly across the circle, Elf 5:
        ///   1         1 
        /// -   2  -->     2
        ///   4         4 
        /// Next is Elf 4 who, choosing between Elves 1 and 2, steals from Elf 1:
        ///  -          2  
        ///     2  -->
        ///  4          4
        /// Finally, Elf 2 steals from Elf 4:
        ///  2
        ///     -->  2  
        ///  -
        /// So, with five Elves, the Elf that sits starting in position 2 gets all the presents.
        /// 
        /// With the number of Elves given in your puzzle input, which Elf now gets all the presents?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int n = int.Parse(input[0]);
            int f = 1;

            while (Math.Pow(3, f) <= n)
            {
                f++;
            }

            int current = (int)(Math.Pow(3, f - 1) + 1);
            int inc2 = (int)(Math.Pow(3, f) * 2);

            return Math.Max(2 * (n - inc2), 0) + (Math.Min(n, inc2) - current) + 1;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _19_AnElephantNamedJoseph(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_19_AnElephantNamedJoseph));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}