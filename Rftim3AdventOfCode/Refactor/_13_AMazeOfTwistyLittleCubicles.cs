using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Drawing;

namespace Rftim3AdventOfCode.Refactor
{
    public class _13_AMazeOfTwistyLittleCubicles : I_13_AMazeOfTwistyLittleCubicles
    {
        #region Static
        private readonly List<string>? data;

        public _13_AMazeOfTwistyLittleCubicles()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_13_AMazeOfTwistyLittleCubicles));
        }

        /// <summary>
        /// You arrive at the first floor of this new building to discover a much less welcoming environment than the shiny atrium of the last one.
        /// Instead, you are in a maze of twisty little cubicles, all alike.
        /// 
        /// Every location in this area is addressed by a pair of non-negative integers(x, y). Each such coordinate is either a wall or an open space.You can't move diagonally.
        /// The cube maze starts at 0,0 and seems to extend infinitely toward positive x and y; negative values are invalid, as they represent a location outside the building.
        /// You are in a small waiting area at 1,1.
        /// 
        /// While it seems chaotic, a nearby morale-boosting poster explains, the layout is actually quite logical.
        /// You can determine whether a given x,y coordinate will be a wall or an open space using a simple system:
        /// 
        /// Find x* x + 3* x + 2* x* y + y + y* y.
        /// Add the office designer's favorite number (your puzzle input).
        /// Find the binary representation of that sum; count the number of bits that are 1.
        /// If the number of bits that are 1 is even, it's an open space.
        /// If the number of bits that are 1 is odd, it's a wall.
        /// For example, if the office designer's favorite number were 10, drawing walls as # and open spaces as ., 
        /// the corner of the building containing 0,0 would look like this:
        /// 
        ///   0123456789
        /// 0 .#.####.##
        /// 1 ..#..#...#
        /// 2 #....##...
        /// 3 ###.#.###.
        /// 4 .##..#..#.
        /// 5 ..##....#.
        /// 6 #...##.###
        /// Now, suppose you wanted to reach 7,4. The shortest route you could take is marked as O:
        /// 
        ///   0123456789
        /// 0 .#.####.##
        /// 1 .O#..#...#
        /// 2 #OOO.##...
        /// 3 ###O#.###.
        /// 4 .##OO#OO#.
        /// 5 ..##OOO.#.
        /// 6 #...##.###
        /// Thus, reaching 7,4 would take a minimum of 11 steps(starting from your current location, 1,1).
        /// 
        /// What is the fewest number of steps required for you to reach 31,39?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            shortest = [];
            int width = 150, height = 150;
            char[,] map = new char[width, height];

            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    int e = x * x + 3 * x + 2 * x * y + y + y * y + int.Parse(input[0]);
                    bool open = (Convert.ToString(e, 2).ToArray().Count(c => c == '1') & 1) == 0;

                    map[y, x] = open ? '.' : '#';
                }
            }

            dirs = [new Size(-1, 0), new Size(1, 0), new Size(0, -1), new Size(0, 1)];

            Point target = new(31, 39);
            Point start = new(1, 1);

            int count = -1;
            Find(map, start, target, count, true);

            return shortest[target];
        }

        /// <summary>
        /// How many locations (distinct x,y coordinates, including your starting location) can you reach in at most 50 steps?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            shortest = [];
            int width = 150, height = 150;
            char[,] map = new char[width, height];

            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    int e = x * x + 3 * x + 2 * x * y + y + y * y + int.Parse(input[0]);
                    bool open = (Convert.ToString(e, 2).ToArray().Count(c => c == '1') & 1) == 0;

                    map[y, x] = open ? '.' : '#';
                }
            }

            dirs = [new Size(-1, 0), new Size(1, 0), new Size(0, -1), new Size(0, 1)];

            Point target = new(31, 39);
            Point start = new(1, 1);

            int count = -1;
            Find(map, start, target, count, false);

            return shortest.Count;
        }
        
        private static Size[]? dirs;
        private static Dictionary<Point, int>? shortest;

        private static void Find(char[,] map, Point current, Point target, int numSteps, bool part)
        {
            ++numSteps;

            if (part)
            {
                if (current == target)
                {
                    shortest[current] = numSteps;
                    return;
                }
            }
            else
            {
                if (numSteps >= 50)
                {
                    shortest[current] = numSteps;
                    return;
                }
            }

            if (shortest.TryGetValue(current, out int value))
            {
                if (value < numSteps)
                {
                    Console.WriteLine("dead end:" + value);
                    return;
                }
                shortest[current] = numSteps;
            }
            else shortest.Add(current, numSteps);

            if (current == new Point(1, 1)) numSteps = 0;

            for (int i = 0; i < 4; i++)
            {
                Point nm = Point.Add(current, dirs![i]);

                if (nm.X >= 0 && nm.Y >= 0 && map[nm.Y, nm.X] == '.') Find(map, nm, target, numSteps, part);
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _13_AMazeOfTwistyLittleCubicles(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_13_AMazeOfTwistyLittleCubicles));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}