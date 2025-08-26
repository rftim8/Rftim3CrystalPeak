using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _01_NoTimeForATaxicab : I_01_NoTimeForATaxicab
    {
        #region Static
        private readonly List<string>? data;

        public _01_NoTimeForATaxicab()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_01_NoTimeForATaxicab));
        }

        /// <summary>
        /// Santa's sleigh uses a very high-precision clock to guide its movements, and the clock's oscillator is regulated by stars. 
        /// Unfortunately, the stars have been stolen... by the Easter Bunny. 
        /// To save Christmas, Santa needs you to retrieve all fifty stars by December 25th.
        /// 
        /// Collect stars by solving puzzles.Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first.
        /// Each puzzle grants one star. Good luck!
        /// 
        /// You're airdropped near Easter Bunny Headquarters in a city somewhere. 
        /// "Near", unfortunately, is as close as you can get - the instructions on the Easter Bunny Recruiting Document the Elves intercepted start here, 
        /// and nobody had time to work them out further.
        /// 
        /// The Document indicates that you should start at the given coordinates (where you just landed) and face North.
        /// Then, follow the provided sequence: either turn left(L) or right(R) 90 degrees, then walk forward the given number of blocks, ending at a new intersection.
        /// 
        /// There's no time to follow such ridiculous instructions on foot, though, so you take a moment and work out the destination. 
        /// Given that you can only walk on the street grid of the city, how far is the shortest path to the destination?
        /// 
        /// For example:
        /// 
        /// Following R2, L3 leaves you 2 blocks East and 3 blocks North, or 5 blocks away.
        /// R2, R2, R2 leaves you 2 blocks due South of your starting position, which is 2 blocks away.
        /// R5, L5, R5, R3 leaves you 12 blocks away.
        /// How many blocks away is Easter Bunny HQ?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<string> dir = input[0].Split(',').Select(o => o.Trim()).ToList();

            int x = 0, y = 0;
            bool north = true;
            bool south = false;
            bool east = false;
            bool west = false;
            foreach (string item in dir)
            {
                if (north)
                {
                    if (item[0] == 'R')
                    {
                        x += int.Parse(item[1..]);
                        east = true;
                    }
                    else
                    {
                        x -= int.Parse(item[1..]);
                        west = true;
                    }
                    north = false;
                }
                else if (east)
                {
                    if (item[0] == 'R')
                    {
                        y -= int.Parse(item[1..]);
                        south = true;
                    }
                    else
                    {
                        y += int.Parse(item[1..]);
                        north = true;
                    }
                    east = false;
                }
                else if (south)
                {
                    if (item[0] == 'R')
                    {
                        x -= int.Parse(item[1..]);
                        west = true;
                    }
                    else
                    {
                        x += int.Parse(item[1..]);
                        east = true;
                    }
                    south = false;
                }
                else if (west)
                {
                    if (item[0] == 'R')
                    {
                        y += int.Parse(item[1..]);
                        north = true;
                    }
                    else
                    {
                        y -= int.Parse(item[1..]);
                        south = true;
                    }
                    west = false;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        /// <summary>
        /// Then, you notice the instructions continue on the back of the Recruiting Document. 
        /// Easter Bunny HQ is actually at the first location you visit twice.
        /// 
        /// For example, if your instructions are R8, R4, R4, R8, the first location you visit twice is 4 blocks away, due East.
        /// 
        /// How many blocks away is the first location you visit twice?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<string> dir = input[0].Split(',').Select(o => o.Trim()).ToList();

            List<(int, int)> vis = [(0, 0)];

            int x = 0, y = 0;
            bool north = true;
            bool south = false;
            bool east = false;
            bool west = false;
            foreach (string item in dir)
            {
                if (north)
                {
                    if (item[0] == 'R')
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x + i, y))) return Math.Abs(x + i) + Math.Abs(y);

                            vis.Add((x + i, y));
                        }
                        x += t;
                        east = true;
                    }
                    else
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x - i, y))) return Math.Abs(x - i) + Math.Abs(y);

                            vis.Add((x - i, y));
                        }
                        x -= t;
                        west = true;
                    }
                    north = false;
                }
                else if (east)
                {
                    if (item[0] == 'R')
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x, y + i))) return Math.Abs(x) + Math.Abs(y + i);

                            vis.Add((x, y + i));
                        }
                        y += t;
                        south = true;
                    }
                    else
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x, y - i))) return Math.Abs(x) + Math.Abs(y - i);

                            vis.Add((x, y - i));
                        }
                        y -= t;
                        north = true;
                    }
                    east = false;
                }
                else if (south)
                {
                    if (item[0] == 'R')
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x - i, y))) return Math.Abs(x - i) + Math.Abs(y);

                            vis.Add((x - i, y));
                        }
                        x -= t;
                        west = true;
                    }
                    else
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x + i, y))) return Math.Abs(x + i) + Math.Abs(y);

                            vis.Add((x + i, y));
                        }
                        x += t;
                        east = true;
                    }
                    south = false;
                }
                else if (west)
                {
                    if (item[0] == 'R')
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x, y - i))) return Math.Abs(x) + Math.Abs(y - i);

                            vis.Add((x, y - i));
                        }
                        y -= t;
                        north = true;
                    }
                    else
                    {
                        int t = int.Parse(item[1..]);
                        for (int i = 1; i <= t; i++)
                        {
                            if (vis.Contains((x, y + i))) return Math.Abs(x) + Math.Abs(y + i);

                            vis.Add((x, y + i));
                        }
                        y += t;
                        south = true;
                    }
                    west = false;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _01_NoTimeForATaxicab(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_01_NoTimeForATaxicab));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}