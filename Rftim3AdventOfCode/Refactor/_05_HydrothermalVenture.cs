using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _05_HydrothermalVenture : I_05_HydrothermalVenture
    {
        #region Static
        private readonly List<string>? data;

        public _05_HydrothermalVenture()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_05_HydrothermalVenture));
        }

        /// <summary>
        /// You come across a field of hydrothermal vents on the ocean floor! These vents constantly produce large, opaque clouds, so it would be best to avoid them if possible.
        /// 
        /// They tend to form in lines; the submarine helpfully produces a list of nearby lines of vents(your puzzle input) for you to review.For example:
        /// 
        /// 0,9 -> 5,9
        /// 8,0 -> 0,8
        /// 9,4 -> 3,4
        /// 2,2 -> 2,1
        /// 7,0 -> 7,4
        /// 6,4 -> 2,0
        /// 0,9 -> 2,9
        /// 3,4 -> 1,4
        /// 0,0 -> 8,8
        /// 5,5 -> 8,2
        /// Each line of vents is given as a line segment in the format x1,y1 -> x2,y2 where x1,y1 are the coordinates of one end the line segment 
        /// and x2, y2 are the coordinates of the other end.These line segments include the points at both ends.In other words:
        /// 
        /// An entry like 1,1 -> 1,3 covers points 1,1, 1,2, and 1,3.
        /// An entry like 9,7 -> 7,7 covers points 9,7, 8,7, and 7,7.
        /// For now, only consider horizontal and vertical lines: lines where either x1 = x2 or y1 = y2.
        /// 
        /// So, the horizontal and vertical lines from the above list would produce the following diagram:
        /// 
        /// .......1..
        /// ..1....1..
        /// ..1....1..
        /// .......1..
        /// .112111211
        /// ..........
        /// ..........
        /// ..........
        /// ..........
        /// 222111....
        /// In this diagram, the top left corner is 0,0 and the bottom right corner is 9,9.
        /// Each position is shown as the number of lines which cover that point or. if no line covers that point.
        /// The top-left pair of 1s, for example, comes from 2,2 -> 2,1; the very bottom row is formed by the overlapping lines 0,9 -> 5,9 and 0,9 -> 2,9.
        /// 
        /// To avoid the most dangerous areas, you need to determine the number of points where at least two lines overlap. 
        /// In the above example, this is anywhere in the diagram with a 2 or larger - a total of 5 points.
        /// 
        /// Consider only horizontal and vertical lines. At how many points do at least two lines overlap?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            int[,] x = new int[1000, 1000];
            foreach (string item in input)
            {
                int x0 = int.Parse(item.Split("->")[0].Split(',')[0]);
                int y0 = int.Parse(item.Split("->")[0].Split(',')[1].Trim());
                int x1 = int.Parse(item.Split("->")[1].Split(',')[0].Trim());
                int y1 = int.Parse(item.Split("->")[1].Split(',')[1]);

                if (Math.Abs(x0 - x1) != Math.Abs(y0 - y1))
                {
                    if (x0 > x1)
                    {
                        for (int i = x1; i <= x0; i++)
                        {
                            x[y0, i]++;
                        }
                    }
                    if (x0 < x1)
                    {
                        for (int i = x0; i <= x1; i++)
                        {
                            x[y0, i]++;
                        }
                    }
                    if (y0 > y1)
                    {
                        for (int i = y1; i <= y0; i++)
                        {
                            x[i, x0]++;
                        }
                    }
                    if (y0 < y1)
                    {
                        for (int i = y0; i <= y1; i++)
                        {
                            x[i, x0]++;
                        }
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (x[i, j] >= 2) r++;
                }
            }

            return r;
        }

        /// <summary>
        /// Unfortunately, considering only horizontal and vertical lines doesn't give you the full picture; you need to also consider diagonal lines.
        /// 
        /// Because of the limits of the hydrothermal vent mapping system, the lines in your list will only ever be horizontal, vertical, 
        /// or a diagonal line at exactly 45 degrees.In other words:
        /// 
        /// An entry like 1,1 -> 3,3 covers points 1,1, 2,2, and 3,3.
        /// An entry like 9,7 -> 7,9 covers points 9,7, 8,8, and 7,9.
        /// Considering all lines from the above example would now produce the following diagram:
        /// 
        /// 1.1....11.
        /// .111...2..
        /// ..2.1.111.
        /// ...1.2.2..
        /// .112313211
        /// ...1.2....
        /// ..1...1...
        /// .1.....1..
        /// 1.......1.
        /// 222111....
        /// You still need to determine the number of points where at least two lines overlap.In the above example,
        /// this is still anywhere in the diagram with a 2 or larger - now a total of 12 points.
        /// 
        /// Consider all of the lines.At how many points do at least two lines overlap?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            int[,] x = new int[1000, 1000];
            foreach (string item in input)
            {
                int x0 = int.Parse(item.Split("->")[0].Split(',')[0]);
                int y0 = int.Parse(item.Split("->")[0].Split(',')[1].Trim());
                int x1 = int.Parse(item.Split("->")[1].Split(',')[0].Trim());
                int y1 = int.Parse(item.Split("->")[1].Split(',')[1]);

                if (Math.Abs(x0 - x1) != Math.Abs(y0 - y1))
                {
                    if (x0 > x1)
                    {
                        for (int i = x1; i <= x0; i++)
                        {
                            x[y0, i]++;
                        }
                    }
                    if (x0 < x1)
                    {
                        for (int i = x0; i <= x1; i++)
                        {
                            x[y0, i]++;
                        }
                    }
                    if (y0 > y1)
                    {
                        for (int i = y1; i <= y0; i++)
                        {
                            x[i, x0]++;
                        }
                    }
                    if (y0 < y1)
                    {
                        for (int i = y0; i <= y1; i++)
                        {
                            x[i, x0]++;
                        }
                    }
                }
                else
                {
                    int x00 = x0;
                    int y00 = y0;
                    int x10 = x1;
                    int y10 = y1;
                    int t = Math.Abs(x0 - x1);
                    for (int i = 0; i <= t; i++)
                    {
                        x[y00, x00]++;

                        if (x00 < x10) x00++;
                        if (x00 > x10) x00--;
                        if (y00 < y10) y00++;
                        if (y00 > y10) y00--;
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (x[i, j] >= 2) r++;
                    //Console.Write($"{x[i, j]} ");
                }
                //Console.WriteLine();
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

        public _05_HydrothermalVenture(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_05_HydrothermalVenture));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}