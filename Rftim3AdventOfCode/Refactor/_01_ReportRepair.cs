using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _01_ReportRepair : I_01_ReportRepair
    {
        #region Static
        private readonly List<string>? data;

        public _01_ReportRepair()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_01_ReportRepair));
        }

        /// <summary>
        /// After saving Christmas five years in a row, you've decided to take a vacation at a nice resort on a tropical island. 
        /// Surely, Christmas will go on without you.
        /// 
        /// The tropical island has its own currency and is entirely cash-only.The gold coins used there have a little picture of a starfish; 
        /// the locals just call them stars.None of the currency exchanges seem to have heard of them, but somehow, you'll need to find fifty of 
        /// these coins by the time you arrive so you can pay the deposit on your room.
        /// 
        /// To save your vacation, you need to get all fifty stars by December 25th.
        /// 
        /// Collect stars by solving puzzles.Two puzzles will be made available on each day in the Advent calendar; 
        /// the second puzzle is unlocked when you complete the first.Each puzzle grants one star. Good luck!
        /// 
        /// Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.
        /// 
        /// Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.
        /// 
        /// For example, suppose your expense report contained the following:
        /// 
        /// 1721
        /// 979
        /// 366
        /// 299
        /// 675
        /// 1456
        /// 
        /// In this list, the two entries that sum to 2020 are 1721 and 299. 
        /// Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.
        /// 
        /// Of course, your expense report is much larger. Find the two entries that sum to 2020; what do you get if you multiply them together ?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (int.Parse(input[i]) + int.Parse(input[j]) == 2020) return int.Parse(input[i]) * int.Parse(input[j]);
                }
            }

            return r;
        }

        /// <summary>
        /// The Elves in accounting are thankful for your help; one of them even offers you a starfish coin they had left over from a past vacation. 
        /// They offer you a second one if you can find three numbers in your expense report that meet the same criteria.
        /// 
        /// Using the above example again, the three entries that sum to 2020 are 979, 366, and 675. 
        /// Multiplying them together produces the answer, 241861950.
        /// 
        /// In your expense report, what is the product of the three entries that sum to 2020?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    for (int k = j + 1; k < input.Count; k++)
                    {
                        int x = int.Parse(input[i]);
                        int y = int.Parse(input[j]);
                        int z = int.Parse(input[k]);

                        if (x + y + z == 2020) return x * y * z;
                    }
                }
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _01_ReportRepair(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_01_ReportRepair));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}