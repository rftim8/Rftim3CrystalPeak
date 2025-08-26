using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _04_SecureContainer : I_04_SecureContainer
    {
        #region Static
        private readonly List<string>? data;

        public _04_SecureContainer()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_04_SecureContainer));
        }

        /// <summary>
        /// You arrive at the Venus fuel depot only to discover it's protected by a password. 
        /// The Elves had written the password on a sticky note, but someone threw it out.
        /// 
        /// However, they do remember a few key facts about the password:
        /// 
        /// It is a six-digit number.
        /// The value is within the range given in your puzzle input.
        /// Two adjacent digits are the same (like 22 in 122345).
        /// Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
        /// Other than the range rule, the following are true:
        /// 
        /// 111111 meets these criteria(double 11, never decreases).
        /// 223450 does not meet these criteria(decreasing pair of digits 50).
        /// 123789 does not meet these criteria(no double).
        /// How many different passwords within the range given in your puzzle input meet these criteria?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int a = int.Parse(input[0].Split('-')[0]);
            int b = int.Parse(input[0].Split('-')[1]);

            int r = 0;

            for (int i = a; i < b; i++)
            {
                string t = i.ToString();
                bool d = false;
                bool dec = true;
                for (int j = 0; j < t.Length - 1; j++)
                {
                    if (t[j] == t[j + 1]) d = true;
                    if (t[j] > t[j + 1]) dec = false;
                }

                if (d && dec) r++;
            }

            return r;
        }

        /// <summary>
        /// An Elf just remembered one more important detail: the two adjacent matching digits are not part of a larger group of matching digits.
        /// 
        /// Given this additional criterion, but still ignoring the range rule, the following are now true:
        /// 
        /// 112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
        /// 123444 no longer meets the criteria (the repeated 44 is part of a larger group of 444).
        /// 111122 meets the criteria (even though 1 is repeated more than twice, it still contains a double 22).
        /// How many different passwords within the range given in your puzzle input meet all of the criteria?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int a = int.Parse(input[0].Split('-')[0]);
            int b = int.Parse(input[0].Split('-')[1]);

            int r = 0;

            for (int i = a; i < b; i++)
            {
                string t = i.ToString();
                bool d = false;
                bool dec = true;
                int c = 1;
                for (int j = 1; j < t.Length; j++)
                {
                    if (t[j] == t[j - 1]) c++;
                    else if (t[j] < t[j - 1])
                    {
                        dec = false;
                        break;
                    }
                    else
                    {
                        if (c == 2) d = true;
                        c = 1;
                    }

                    if (j == t.Length - 1 && c == 2) d = true;
                }

                if (dec && d) r++;
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

        public _04_SecureContainer(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_04_SecureContainer));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}