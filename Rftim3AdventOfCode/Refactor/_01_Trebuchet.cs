using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _01_Trebuchet : I_01_Trebuchet
    {
        #region Static
        private readonly List<string>? data;

        public _01_Trebuchet()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_01_Trebuchet));
        }

        /// <summary>
        /// Something is wrong with global snow production, and you've been selected to take a look. 
        /// The Elves have even given you a map; on it, they've used stars to mark the top fifty locations that are likely to be having problems.
        /// 
        /// You've been doing this long enough to know that to restore snow operations, you need to check all fifty stars by December 25th.
        /// 
        /// Collect stars by solving puzzles.Two puzzles will be made available on each day in the Advent calendar; 
        /// the second puzzle is unlocked when you complete the first.Each puzzle grants one star. Good luck!
        /// 
        /// You try to ask why they can't just use a weather machine ("not powerful enough") and where they're even sending you ("the sky") and 
        /// why your map looks mostly blank("you sure ask a lot of questions") and hang on did you just say the sky("of course, 
        /// where do you think snow comes from") when you realize that the Elves are already loading you into a trebuchet("please hold still, we need to strap you in").
        /// 
        /// As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended 
        /// by a very young Elf who was apparently just excited to show off her art skills.
        /// Consequently, the Elves are having trouble reading the values on the document.
        /// 
        /// The newly-improved calibration document consists of lines of text; 
        /// each line originally contained a specific calibration value that the Elves now need to recover.
        /// On each line, the calibration value can be found by combining the first digit and the last digit(in that order) to form a single two-digit number.
        /// For example:
        /// 
        /// 1abc2
        /// pqr3stu8vwx
        /// a1b2c3d4e5f
        /// treb7uchet
        /// In this example, the calibration values of these four lines are 12, 38, 15, and 77. 
        /// Adding these together produces 142.
        /// 
        /// Consider your entire calibration document.What is the sum of all of the calibration values?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                List<int> x = [];
                string q = string.Empty;

                foreach (char item1 in item)
                {
                    if (char.IsNumber(item1))
                    {
                        x.Add(int.Parse(item1.ToString()));
                        q += item1;
                    }
                }

                string t = $"{x.First()}{x.Last()}";

                if (x.Count > 0) r += int.Parse(t);
            }

            return r;
        }

        /// <summary>
        /// Your calculation isn't quite right. It looks like some of the digits are actually spelled out with letters:
        /// one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".
        /// 
        /// Equipped with this new information, you now need to find the real first and last digit on each line.For example:
        ///
        /// two1nine
        /// eightwothree
        /// abcone2threexyz
        /// xtwone3four
        /// 4nineeightseven2
        /// zoneight234
        /// 7pqrstsixteen
        /// In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.
        /// 
        /// What is the sum of all of the calibration values?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                string x = "";

                string y = "";
                string z = "";

                for (int i = 0; i < item.Length; i++)
                {
                    x += item[i];
                    if (int.TryParse(item[i].ToString(), out int value))
                    {
                        y = item[i].ToString();
                        break;
                    }
                    else
                    {
                        string y0 = FindValue(x);
                        if (!string.IsNullOrEmpty(y0))
                        {
                            y = y0;
                            break;
                        }
                    }
                }

                x = "";
                for (int i = item.Length - 1; i > -1; i--)
                {
                    x = item[i] + x;
                    if (int.TryParse(item[i].ToString(), out int value))
                    {
                        z = item[i].ToString();
                        break;
                    }
                    else
                    {
                        string z0 = FindValue(x);
                        if (!string.IsNullOrEmpty(z0))
                        {
                            z = z0;
                            break;
                        }
                    }
                }

                string t = $"{y}{z}";

                r += int.Parse(t);
            }

            return r;
        }

        private static string FindValue(string s) => s switch
        {
            string when s.Contains("one") => "1",
            string when s.Contains("two") => "2",
            string when s.Contains("three") => "3",
            string when s.Contains("four") => "4",
            string when s.Contains("five") => "5",
            string when s.Contains("six") => "6",
            string when s.Contains("seven") => "7",
            string when s.Contains("eight") => "8",
            string when s.Contains("nine") => "9",
            _ => ""
        };
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _01_Trebuchet(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_01_Trebuchet));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}