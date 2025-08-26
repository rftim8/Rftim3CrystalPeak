using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Drawing;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _14_ParabolicReflectorDish : I_14_ParabolicReflectorDish
    {
        #region Static
        private readonly List<string>? data;

        public _14_ParabolicReflectorDish()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_14_ParabolicReflectorDish));
        }

        /// <summary>
        /// You reach the place where all of the mirrors were pointing: a massive parabolic reflector dish attached to the side 
        /// of another large mountain.
        /// 
        /// The dish is made up of many small mirrors, but while the mirrors themselves are roughly in the shape of a parabolic 
        /// reflector dish, each individual mirror seems to be pointing in slightly the wrong direction.
        /// If the dish is meant to focus light, all it's doing right now is sending it in a vague direction.
        /// 
        /// This system must be what provides the energy for the lava! If you focus the reflector dish,
        /// maybe you can go where it's pointing and use the light to fix the lava production.
        /// 
        /// Upon closer inspection, the individual mirrors each appear to be connected via an elaborate system of ropes 
        /// and pulleys to a large metal platform below the dish. The platform is covered in large rocks of various shapes.
        /// Depending on their position, the weight of the rocks deforms the platform, and the shape of the platform controls 
        /// which ropes move and ultimately the focus of the dish.
        /// 
        /// In short: if you move the rocks, you can focus the dish.
        /// The platform even has a control panel on the side that lets you tilt it in one of four directions! 
        /// The rounded rocks (O) will roll when the platform is tilted, while the cube-shaped rocks (#) will stay in place. 
        /// You note the positions of all of the empty spaces (.) and rocks (your puzzle input). 
        /// For example:
        /// 
        /// O....#....
        /// O.OO#....#
        /// .....##...
        /// OO.#O....O
        /// .O.....O#.
        /// O.#..O.#.#
        /// ..O..#O..O
        /// .......O..
        /// #....###..
        /// # OO..#....
        /// Start by tilting the lever so all of the rocks will slide north as far as they will go:
        /// 
        /// 
        /// OOOO.#.O..
        /// OO..#....#
        /// OO..O##..O
        /// O..#.OO...
        /// ........#.
        /// ..#....#.#
        /// ..O..#.O.O
        /// ..O.......
        /// #....###..
        /// #....#....
        /// You notice that the support beams along the north side of the platform are damaged; 
        /// to ensure the platform doesn't collapse, you should calculate the total load on the north support beams.
        /// 
        /// The amount of load caused by a single rounded rock(O) is equal to the number of rows from the rock to the south edge of the platform, 
        /// including the row the rock is on. (Cube-shaped rocks(#) don't contribute to load.) 
        /// So, the amount of load caused by each rock in each row is as follows:
        /// 
        /// OOOO.#.O.. 10
        /// OO..#....#  9
        /// OO..O##..O  8
        /// O..#.OO...  7
        /// ........#.  6
        /// ..#....#.#  5
        /// ..O..#.O.O  4
        /// ..O.......  3
        /// #....###..  2
        /// #....#....  1
        /// The total load is the sum of the load caused by all of the rounded rocks.
        /// In this example, the total load is 136.
        /// 
        /// Tilt the platform so that the rounded rocks all roll north.
        /// Afterward, what is the total load on the north support beams?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int n = input.Count;
            int m = input[0].Length;
            int r = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (input[j][i] == 'O')
                    {
                        int t = j;
                        while (t > 0 && input[t - 1][i] == '.')
                        {
                            StringBuilder sb = new(input[t - 1]);
                            sb[i] = 'O';
                            input[t - 1] = sb.ToString();

                            sb = new(input[t]);
                            sb[i] = '.';
                            input[t] = sb.ToString();

                            t--;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                int x = 0;
                foreach (char item in input[i])
                {
                    if (item == 'O') x++;
                }

                r += x * (n - i);
            }

            return r;
        }

        /// <summary>
        /// The parabolic reflector dish deforms, but not in a way that focuses the beam. 
        /// To do that, you'll need to move the rocks to the edges of the platform.
        /// Fortunately, a button on the side of the control panel labeled "spin cycle" attempts to do just that!
        /// 
        /// Each cycle tilts the platform four times so that the rounded rocks roll north, then west, then south, then east.
        /// After each tilt, the rounded rocks roll as far as they can before the platform tilts in the next direction.
        /// After one cycle, the platform will have finished rolling the rounded rocks in those four directions in that order.
        /// 
        /// Here's what happens in the example above after each of the first few cycles:
        /// 
        /// After 1 cycle:
        /// .....#....
        /// ....#...O#
        /// ...OO##...
        /// .OO#......
        /// .....OOO#.
        /// .O#...O#.#
        /// ....O#....
        /// ......OOOO
        /// #...O###..
        /// #..OO#....
        /// 
        /// After 2 cycles:
        /// .....#....
        /// ....#...O#
        /// .....##...
        /// ..O#......
        /// .....OOO#.
        /// .O#...O#.#
        /// ....O#...O
        /// .......OOO
        /// #..OO###..
        /// #.OOO#...O
        /// 
        /// After 3 cycles:
        /// .....#....
        /// ....#...O#
        /// .....##...
        /// ..O#......
        /// .....OOO#.
        /// .O#...O#.#
        /// ....O#...O
        /// .......OOO
        /// #...O###.O
        /// #.OOO#...O
        /// This process should work if you leave it running long enough, but you're still worried about the north support beams.
        /// To make sure they'll survive for a while, you need to calculate the total load on the north support beams after 1000000000 cycles.
        /// 
        /// In the above example, after 1000000000 cycles, the total load on the north support beams is 64.
        /// 
        /// Run the spin cycle for 1000000000 cycles.Afterward, what is the total load on the north support beams?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            List<Point> x = [];
            int i = 0, j = 1000000000;
            bool f = false;
            while (i < j)
            {
                input = RollNorth(input);
                int north = PrintResult(input);

                input = RollWest(input);
                int west = PrintResult(input);

                input = RollSouth(input);
                int south = PrintResult(input);

                input = RollEast(input);
                int east = PrintResult(input);

                if (i == j - 1)
                {
                    r = east;
                    break;
                }

                Point y = new(north, south);

                if (!f)
                {
                    if (!x.Contains(y)) x.Add(y);
                    else
                    {
                        int t = (1000000000 - x.IndexOf(y)) % (x.Count - x.IndexOf(y));
                        j = t;
                        i = 0;
                        f = true;
                    }
                }
                i++;
            }

            return r;
        }

        private static int PrintResult(List<string> input)
        {
            int n = input.Count;
            int r = 0;

            for (int i = 0; i < n; i++)
            {
                int x = 0;
                foreach (char item in input[i])
                {
                    if (item == 'O') x++;
                }

                r += x * (n - i);
            }

            return r;
        }

        private static List<string> RollNorth(List<string> input)
        {
            int n = input.Count;
            int m = input[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (input[j][i] == 'O')
                    {
                        int t = j;
                        while (t > 0 && input[t - 1][i] == '.')
                        {
                            StringBuilder sb = new(input[t - 1]);
                            sb[i] = 'O';
                            input[t - 1] = sb.ToString();

                            sb = new(input[t]);
                            sb[i] = '.';
                            input[t] = sb.ToString();

                            t--;
                        }
                    }
                }
            }

            return input;
        }

        private static List<string> RollWest(List<string> input)
        {
            int n = input.Count;
            int m = input[0].Length;

            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new(input[i]);
                for (int j = 0; j < m; j++)
                {
                    if (sb[j] == 'O')
                    {
                        int t = j;
                        while (t > 0 && sb[t - 1] == '.')
                        {
                            sb[t - 1] = 'O';
                            sb[t] = '.';

                            t--;
                        }
                    }
                }
                input[i] = sb.ToString();
            }

            return input;
        }

        private static List<string> RollSouth(List<string> input)
        {
            int n = input.Count;
            int m = input[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = n - 1; j > -1; j--)
                {
                    if (input[j][i] == 'O')
                    {
                        int t = j;
                        while (t < n - 1 && input[t + 1][i] == '.')
                        {
                            StringBuilder sb = new(input[t + 1]);
                            sb[i] = 'O';
                            input[t + 1] = sb.ToString();

                            sb = new(input[t]);
                            sb[i] = '.';
                            input[t] = sb.ToString();

                            t++;
                        }
                    }
                }
            }

            return input;
        }

        private static List<string> RollEast(List<string> input)
        {
            int n = input.Count;
            int m = input[0].Length;

            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new(input[i]);
                for (int j = m - 1; j > -1; j--)
                {
                    if (sb[j] == 'O')
                    {
                        int t = j;
                        while (t < m - 1 && sb[t + 1] == '.')
                        {
                            sb[t + 1] = 'O';
                            sb[t] = '.';

                            t++;
                        }
                    }
                }
                input[i] = sb.ToString();
            }

            return input;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _14_ParabolicReflectorDish(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_14_ParabolicReflectorDish));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}