using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_GearRatios : I_03_GearRatios
    {
        #region Static
        private readonly List<string>? data;

        public _03_GearRatios()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_GearRatios));
        }

        /// <summary>
        /// You and the Elf eventually reach a gondola lift station; he says the gondola lift will take you up to the water source, but this is as far as he can bring you. 
        /// You go inside.
        /// 
        /// It doesn't take long to find the gondolas, but there seems to be a problem: they're not moving.
        /// 
        /// "Aaah!"
        /// 
        /// You turn around to see a slightly-greasy Elf with a wrench and a look of surprise.
        /// "Sorry, I wasn't expecting anyone! The gondola lift isn't working right now; it'll still be a while before I can fix it." You offer to help.
        /// 
        /// The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one. 
        /// If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.
        /// 
        /// The engine schematic (your puzzle input) consists of a visual representation of the engine.
        /// There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, 
        /// is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)
        /// 
        /// Here is an example engine schematic:
        /// 
        /// 467..114..
        /// ...*......
        /// ..35..633.
        /// ......#...
        /// 617*......
        /// .....+.58.
        /// ..592.....
        /// ......755.
        /// ...$.*....
        /// .664.598..
        /// In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right). 
        /// Every other number is adjacent to a symbol and so is a part number; their sum is 4361.
        /// 
        /// Of course, the actual engine schematic is much larger.What is the sum of all of the part numbers in the engine schematic?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int n = input.Count + 2, m = input[0].Length + 2;
            int r = 0;
            string q = string.Concat(Enumerable.Repeat('.', n));
            input.Insert(0, q);
            input.Add(q);

            for (int i = 1; i < n - 1; i++)
            {
                input[i] = $".{input[i]}.";
            }

            for (int i = 1; i < n - 1; i++)
            {
                string t = string.Empty;
                bool f = false;

                for (int j = 1; j < m - 1; j++)
                {
                    if (char.IsNumber(input[i][j]))
                    {
                        t += input[i][j];
                        if (!char.IsNumber(input[i][j + 1]) && input[i][j + 1] != '.') f = true;
                        if (!char.IsNumber(input[i + 1][j + 1]) && input[i + 1][j + 1] != '.') f = true;
                        if (!char.IsNumber(input[i + 1][j]) && input[i + 1][j] != '.') f = true;
                        if (!char.IsNumber(input[i + 1][j - 1]) && input[i + 1][j - 1] != '.') f = true;
                        if (!char.IsNumber(input[i][j - 1]) && input[i][j - 1] != '.') f = true;
                        if (!char.IsNumber(input[i - 1][j - 1]) && input[i - 1][j - 1] != '.') f = true;
                        if (!char.IsNumber(input[i - 1][j]) && input[i - 1][j] != '.') f = true;
                        if (!char.IsNumber(input[i - 1][j + 1]) && input[i - 1][j + 1] != '.') f = true;
                    }
                    else
                    {
                        if (f && t != "")
                        {
                            r += int.Parse(t);
                            Console.WriteLine(t);
                        }

                        t = string.Empty;
                        f = false;
                    }
                    if (j == m - 2 && f && t != "") r += int.Parse(t);
                }
            }

            return r;
        }

        /// <summary>
        /// The engineer finds the missing part and installs it in the engine! As the engine springs to life, you jump in the closest gondola,
        /// finally ready to ascend to the water source.
        /// 
        /// You don't seem to be going very fast, though. Maybe something is still wrong? 
        /// Fortunately, the gondola has a phone labeled "help", so you pick it up and the engineer answers.
        /// 
        /// Before you can explain the situation, she suggests that you look out the window.
        /// There stands the engineer, holding a phone in one hand and waving with the other.
        /// You're going so slowly that you haven't even left the station.You exit the gondola.
        /// 
        /// The missing part wasn't the only issue - one of the gears in the engine is wrong. A gear is any * symbol that is adjacent to exactly two part numbers. 
        /// Its gear ratio is the result of multiplying those two numbers together.
        /// 
        /// This time, you need to find the gear ratio of every gear and add them all up so that the engineer can figure out which gear needs to be replaced.
        /// 
        /// Consider the same engine schematic again:
        /// 
        /// 467..114..
        /// ...*......
        /// ..35..633.
        /// ......#...
        /// 617*......
        /// .....+.58.
        /// ..592.....
        /// ......755.
        /// ...$.*....
        /// .664.598..
        /// In this schematic, there are two gears. The first is in the top left; it has part numbers 467 and 35, so its gear ratio is 16345. 
        /// The second gear is in the lower right; its gear ratio is 451490.
        /// (The* adjacent to 617 is not a gear because it is only adjacent to one part number.) Adding up all of the gear ratios produces 467835.
        /// 
        /// What is the sum of all of the gear ratios in your engine schematic?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int n = input.Count + 2, m = input[0].Length + 2;
            int r = 0;
            Dictionary<(int, int), List<int>> kvp = [];

            string q = string.Concat(Enumerable.Repeat('.', n));

            input.Insert(0, q);
            input.Add(q);

            for (int i = 1; i < n - 1; i++)
            {
                input[i] = $".{input[i]}.";
            }

            for (int i = 1; i < n - 1; i++)
            {
                string t = string.Empty;
                bool f = false;
                (int, int) c = (0, 0);

                for (int j = 1; j < m - 1; j++)
                {
                    if (char.IsNumber(input[i][j]))
                    {
                        t += input[i][j];
                        if (input[i][j + 1] == '*')
                        {
                            f = true;
                            c = (i, j + 1);
                        }
                        if (input[i + 1][j + 1] == '*')
                        {
                            f = true;
                            c = (i + 1, j + 1);
                        }
                        if (input[i + 1][j] == '*')
                        {
                            f = true;
                            c = (i + 1, j);
                        }
                        if (input[i + 1][j - 1] == '*')
                        {
                            f = true;
                            c = (i + 1, j - 1);
                        }
                        if (input[i][j - 1] == '*')
                        {
                            f = true;
                            c = (i, j - 1);
                        }
                        if (input[i - 1][j - 1] == '*')
                        {
                            f = true;
                            c = (i - 1, j - 1);
                        }
                        if (input[i - 1][j] == '*')
                        {
                            f = true;
                            c = (i - 1, j);
                        }
                        if (input[i - 1][j + 1] == '*')
                        {
                            f = true;
                            c = (i - 1, j + 1);
                        }
                    }
                    else
                    {
                        if (f)
                        {
                            if (t != "")
                            {
                                if (!kvp.TryGetValue(c, out List<int>? value)) kvp.Add(c, [int.Parse(t)]);
                                else value.Add(int.Parse(t));
                            }
                        }
                        t = string.Empty;
                        f = false;
                    }
                    if (j == m - 2 && t != "" && f)
                    {
                        if (!kvp.TryGetValue(c, out List<int>? value)) kvp.Add(c, [int.Parse(t)]);
                        else value.Add(int.Parse(t));
                    }
                }
            }

            foreach (KeyValuePair<(int, int), List<int>> item in kvp)
            {
                Console.WriteLine(item.Key);
                foreach (int item1 in item.Value)
                {
                    Console.Write($"{item1} ");
                }
                Console.WriteLine();
                if (item.Value.Count == 2)
                {
                    r += item.Value[0] * item.Value[1];
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

        public _03_GearRatios(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_GearRatios));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}