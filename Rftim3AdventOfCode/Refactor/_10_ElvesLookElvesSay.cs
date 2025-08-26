using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _10_ElvesLookElvesSay : I_10_ElvesLookElvesSay
    {
        #region Static
        private readonly List<string>? data;

        public _10_ElvesLookElvesSay()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_10_ElvesLookElvesSay));
        }

        /// <summary>
        /// Today, the Elves are playing a game called look-and-say.
        /// They take turns making sequences by reading aloud the previous sequence and using that reading as the next sequence.
        /// For example, 211 is read as "one two, two ones", which becomes 1221 (1 2, 2 1s).
        /// Look-and-say sequences are generated iteratively, using the previous value as input for the next step.
        /// For each step, take the previous value, and replace each run of digits(like 111) with the number of digits(3) followed by the digit itself(1).
        /// 
        /// For example:
        /// 
        /// 1 becomes 11 (1 copy of digit 1).
        /// 11 becomes 21 (2 copies of digit 1).
        /// 21 becomes 1211 (one 2 followed by one 1).
        /// 1211 becomes 111221 (one 1, one 2, and two 1s).
        /// 111221 becomes 312211 (three 1s, two 2s, and one 1).
        /// 
        /// Starting with the digits in your puzzle input, apply this process 40 times.What is the length of the result?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string data = input[0];
            int r = 0;

            string s = string.Empty;
            int c = 1;

            for (int j = 0; j < 40; j++)
            {
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i - 1].ToString() == data[i].ToString()) c++;
                    else
                    {
                        s += $"{c}{data[i - 1]}";
                        data = data[i..];
                        i = 0;
                        c = 1;
                    }

                    if (i == data.Length - 1)
                    {
                        s += $"{c}{data[i]}";
                        c = 1;
                    }
                }

                Console.WriteLine($"{j} {s.Length}");

                data = s;
                s = string.Empty;
            }

            return r;
        }

        /// <summary>
        /// Neat, right? You might also enjoy hearing John Conway talking about this sequence (that's Conway of Conway's Game of Life fame).
        /// Now, starting again with the digits in your puzzle input, apply this process 50 times.
        /// 
        /// What is the length of the new result?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string data = input[0];
            int r = 0;

            string s = string.Empty;
            int c = 1;

            for (int j = 0; j < 40; j++)
            {
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i - 1].ToString() == data[i].ToString()) c++;
                    else
                    {
                        s += $"{c}{data[i - 1]}";
                        data = data[i..];
                        i = 0;
                        c = 1;
                    }

                    if (i == data.Length - 1)
                    {
                        s += $"{c}{data[i]}";
                        c = 1;
                    }
                }

                Console.WriteLine($"{j} {s.Length}");

                data = s;
                s = string.Empty;
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

        public _10_ElvesLookElvesSay(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_10_ElvesLookElvesSay));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}