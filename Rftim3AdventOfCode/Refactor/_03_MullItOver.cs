using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_MullItOver : I_03_MullItOver
    {
        #region Static
        private readonly List<string>? data;

        public _03_MullItOver()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_MullItOver));
        }

        /// <summary>
        /// "Our computers are having issues, so I have no idea if we have any Chief Historians in stock! 
        /// You're welcome to check the warehouse, though," says the mildly flustered shopkeeper at the North Pole Toboggan Rental Shop. 
        /// The Historians head out to take a look.
        /// The shopkeeper turns to you. "Any chance you can see why our computers are having issues again?"
        /// The computer appears to be trying to run a program, but its memory(your puzzle input) is corrupted.All of the instructions have been jumbled up!
        /// It seems like the goal of the program is just to multiply some numbers.It does that with instructions like mul(X, Y), where X and Y are each 1-3 digit numbers.
        /// For instance, mul(44,46) multiplies 44 by 46 to get a result of 2024. Similarly, mul(123,4) would multiply 123 by 4.
        /// However, because the program's memory has been corrupted, there are also many invalid characters that should be ignored, even if they look like part of a mul instruction. 
        /// Sequences like mul(4*, mul(6,9!, ?(12,34), or mul ( 2 , 4 ) do nothing.
        /// 
        /// For example, consider the following section of corrupted memory:
        /// 
        /// xmul(2,4)%&mul[3, 7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
        /// Only the four highlighted sections are real mul instructions.
        /// Adding up the result of each instruction produces 161 (2*4 + 5*5 + 11*8 + 8*5).
        /// 
        /// Scan the corrupted memory for uncorrupted mul instructions.
        /// What do you get if you add up all of the results of the multiplications?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int res = 0;

            foreach (string item in input)
            {
                string pattern = @"mul\(\d+,\d+\)";
                MatchCollection matchCollection = Regex.Matches(item, pattern);

                foreach (Match item1 in matchCollection)
                {
                    string t = item1.Value!.Replace("mul(", "").Replace(")", "");
                    res += int.Parse(t.Split(",")[0]) * int.Parse(t.Split(",")[1]);
                }
            }

            return res;
        }

        /// <summary>
        /// As you scan through the corrupted memory, you notice that some of the conditional statements are also still intact. 
        /// If you handle some of the uncorrupted conditional statements in the program, you might be able to get an even more accurate result.
        /// 
        /// There are two new instructions you'll need to handle:
        /// The do() instruction enables future mul instructions.
        /// The don't() instruction disables future mul instructions.
        /// Only the most recent do() or don't() instruction applies. 
        /// At the beginning of the program, mul instructions are enabled.
        /// 
        /// For example:
        /// 
        /// xmul(2,4)&mul[3, 7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
        /// This corrupted memory is similar to the example from before, but this time the mul(5,5) and mul(11,8) instructions are disabled because there is a don't() instruction before them. 
        /// The other mul instructions function normally, including the one at the end that gets re-enabled by a do() instruction.
        /// 
        /// This time, the sum of the results is 48 (2*4 + 8*5).
        /// 
        /// Handle the new instructions; what do you get if you add up all of the results of just the enabled multiplications?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int res = 0;
            string q = string.Join("", input);
            List<(int, int)> l0 = [];

            MatchCollection x = Regex.Matches(q, @"mul\(\d+,\d+\)");
            List<int> y = [];
            foreach (Match item in x)
            {
                y.Add(item.Index);
            }

            MatchCollection dos = Regex.Matches(q, @"do\(\)");
            foreach (Match item in dos)
            {
                l0.Add((item.Index, 1));
            }

            MatchCollection donts = Regex.Matches(q, @"don't\(\)");
            foreach (Match item in donts)
            {
                l0.Add((item.Index, 0));
            }

            l0.Sort();

            int j0 = 0;
            bool a = true;

            foreach (Match item in x)
            {
                if (y[j0] > l0[0].Item1)
                {
                    for (int i = 0; i < l0.Count - 1; i++)
                    {
                        if (l0[i].Item1 < y[j0] && l0[i + 1].Item1 > y[j0] && l0[i].Item2 == 1)
                        {
                            a = true;
                            break;

                        }
                        else
                            a = false;
                    }
                }

                if (a)
                {
                    string t = item.Value.Replace("mul(", "").Replace(")", "");
                    res += int.Parse(t.Split(",")[0]) * int.Parse(t.Split(",")[1]);
                }

                j0 += 1;
            }

            return res;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _03_MullItOver(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_MullItOver));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}