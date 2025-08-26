using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _06_ProbablyAFireHazard : I_06_ProbablyAFireHazard
    {
        #region Static
        private readonly List<string>? data;

        public _06_ProbablyAFireHazard()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_06_ProbablyAFireHazard));
        }

        /// <summary>
        /// Because your neighbors keep defeating you in the holiday house decorating contest year after year, you've decided to deploy one million lights in a 1000x1000 grid.
        /// Furthermore, because you've been especially nice this year, Santa has mailed you instructions on how to display the ideal lighting configuration.
        /// Lights in your grid are numbered from 0 to 999 in each direction; the lights at each corner are at 0,0, 0,999, 999,999, and 999,0. 
        /// The instructions include whether to turn on, turn off, or toggle various inclusive ranges given as coordinate pairs.
        /// Each coordinate pair represents opposite corners of a rectangle, inclusive; a coordinate pair like 0,0 through 2,2 therefore refers to 9 lights in a 3x3 square.
        /// The lights all start turned off.
        /// To defeat your neighbors this year, all you have to do is set up your lights by doing the instructions Santa sent you in order.
        /// 
        /// For example:
        /// 
        /// turn on 0,0 through 999,999 would turn on (or leave on) every light.
        /// toggle 0,0 through 999,0 would toggle the first line of 1000 lights, turning off the ones that were on, and turning on the ones that were off.
        /// turn off 499,499 through 500,500 would turn off (or leave off) the middle four lights.
        /// 
        /// After following the instructions, how many lights are lit?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;
            int[,] h = new int[1000, 1000];

            for (int i = 0; i < input.Count; i++)
            {
                int x = input[i].Split(' ').Length;

                if (x == 5)
                {
                    int x1 = int.Parse(input[i].Split(' ')[2].Split(',')[0]);
                    int y1 = int.Parse(input[i].Split(' ')[2].Split(',')[1]);
                    int x2 = int.Parse(input[i].Split(' ')[4].Split(',')[0]);
                    int y2 = int.Parse(input[i].Split(' ')[4].Split(',')[1]);

                    if (input[i].Split(' ')[1] == "on")
                    {
                        for (int j = x1; j <= x2; j++)
                        {
                            for (int k = y1; k <= y2; k++)
                            {
                                h[j, k] = 1;
                            }
                        }
                    }
                    else
                    {
                        for (int j = x1; j <= x2; j++)
                        {
                            for (int k = y1; k <= y2; k++)
                            {
                                if (h[j, k] > 0) h[j, k] = 0;
                            }
                        }
                    }
                }
                else
                {
                    int x1 = int.Parse(input[i].Split(' ')[1].Split(',')[0]);
                    int y1 = int.Parse(input[i].Split(' ')[1].Split(',')[1]);
                    int x2 = int.Parse(input[i].Split(' ')[3].Split(',')[0]);
                    int y2 = int.Parse(input[i].Split(' ')[3].Split(',')[1]);

                    for (int j = x1; j <= x2; j++)
                    {
                        for (int k = y1; k <= y2; k++)
                        {
                            if (h[j, k] == 0) h[j, k] = 1;
                            else h[j, k] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    r += h[i, j];
                }
            }

            return r;
        }

        /// <summary>
        /// You just finish implementing your winning light pattern when you realize you mistranslated Santa's message from Ancient Nordic Elvish.
        /// The light grid you bought actually has individual brightness controls; each light can have a brightness of zero or more.The lights all start at zero.
        /// The phrase turn on actually means that you should increase the brightness of those lights by 1.
        /// The phrase turn off actually means that you should decrease the brightness of those lights by 1, to a minimum of zero.
        /// The phrase toggle actually means that you should increase the brightness of those lights by 2.
        /// 
        /// What is the total brightness of all lights combined after following Santa's instructions?
        /// 
        /// For example:
        /// 
        /// turn on 0,0 through 0,0 would increase the total brightness by 1.
        /// toggle 0,0 through 999,999 would increase the total brightness by 2000000.
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;
            int[,] h = new int[1000, 1000];

            for (int i = 0; i < input.Count; i++)
            {
                int x = input[i].Split(' ').Length;

                if (x == 5)
                {
                    int x1 = int.Parse(input[i].Split(' ')[2].Split(',')[0]);
                    int y1 = int.Parse(input[i].Split(' ')[2].Split(',')[1]);
                    int x2 = int.Parse(input[i].Split(' ')[4].Split(',')[0]);
                    int y2 = int.Parse(input[i].Split(' ')[4].Split(',')[1]);

                    if (input[i].Split(' ')[1] == "on")
                    {
                        for (int j = x1; j <= x2; j++)
                        {
                            for (int k = y1; k <= y2; k++)
                            {
                                h[j, k] += 1;
                            }
                        }
                    }
                    else
                    {
                        for (int j = x1; j <= x2; j++)
                        {
                            for (int k = y1; k <= y2; k++)
                            {
                                if (h[j, k] > 0) h[j, k] -= 1;
                            }
                        }
                    }
                }
                else
                {
                    int x1 = int.Parse(input[i].Split(' ')[1].Split(',')[0]);
                    int y1 = int.Parse(input[i].Split(' ')[1].Split(',')[1]);
                    int x2 = int.Parse(input[i].Split(' ')[3].Split(',')[0]);
                    int y2 = int.Parse(input[i].Split(' ')[3].Split(',')[1]);

                    for (int j = x1; j <= x2; j++)
                    {
                        for (int k = y1; k <= y2; k++)
                        {
                            h[j, k] += 2;
                        }
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    r += h[i, j];
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

        public _06_ProbablyAFireHazard(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_06_ProbablyAFireHazard));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}