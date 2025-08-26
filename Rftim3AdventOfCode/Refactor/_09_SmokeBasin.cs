using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Drawing;

namespace Rftim3AdventOfCode.Refactor
{
    public class _09_SmokeBasin : I_09_SmokeBasin
    {
        #region Static
        private readonly List<string>? data;

        public _09_SmokeBasin()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_09_SmokeBasin));
        }

        /// <summary>
        /// These caves seem to be lava tubes. Parts are even still volcanically active; small hydrothermal vents release smoke into the caves that slowly settles like rain.
        /// 
        /// If you can model how the smoke flows through the caves, you might be able to avoid it and be that much safer.
        /// The submarine generates a heightmap of the floor of the nearby caves for you (your puzzle input).
        /// 
        /// Smoke flows to the lowest point of the area it's in. For example, consider the following heightmap:
        /// 
        /// 2199943210
        /// 3987894921
        /// 9856789892
        /// 8767896789
        /// 9899965678
        /// Each number corresponds to the height of a particular location, where 9 is the highest and 0 is the lowest a location can be.
        /// Your first goal is to find the low points - the locations that are lower than any of its adjacent locations.
        /// Most locations have four adjacent locations (up, down, left, and right); locations on the edge or corner of the map 
        /// have three or two adjacent locations, respectively. (Diagonal locations do not count as adjacent.)
        /// 
        /// In the above example, there are four low points, all highlighted: two are in the first row(a 1 and a 0), one is in the third row(a 5), 
        /// and one is in the bottom row(also a 5). All other locations on the heightmap have some lower adjacent location, and so are not low points.
        /// The risk level of a low point is 1 plus its height.In the above example, the risk levels of the low points are 2, 1, 6, and 6. 
        /// The sum of the risk levels of all low points in the heightmap is therefore 15.
        /// 
        /// Find all of the low points on your heightmap.What is the sum of the risk levels of all low points on your heightmap?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int[][] map = input.Select(x => x.Select(y => int.Parse(y.ToString())).ToArray()).ToArray();
            List<int> mins = [];

            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[0].Length; y++)
                {
                    int current = map[x][y];
                    if (x != 0 && current >= map[x - 1][y]) continue;
                    if (x != map.Length - 1 && current >= map[x + 1][y]) continue;
                    if (y != 0 && current >= map[x][y - 1]) continue;
                    if (y != map[0].Length - 1 && current >= map[x][y + 1]) continue;
                    mins.Add(current);
                }
            }

            return mins.Sum() + mins.Count;
        }

        /// <summary>
        /// Next, you need to find the largest basins so you know what areas are most important to avoid.
        /// 
        /// A basin is all locations that eventually flow downward to a single low point.
        /// Therefore, every low point has a basin, although some basins are very small.
        /// Locations of height 9 do not count as being in any basin, and all other locations will always be part of exactly one basin.
        /// The size of a basin is the number of locations within the basin, including the low point.The example above has four basins.
        /// The top-left basin, size 3:
        /// 
        /// 2199943210
        /// 3987894921
        /// 9856789892
        /// 8767896789
        /// 9899965678
        /// The top-right basin, size 9:
        /// 
        /// 2199943210
        /// 3987894921
        /// 9856789892
        /// 8767896789
        /// 9899965678
        /// The middle basin, size 14:
        /// 
        /// 2199943210
        /// 3987894921
        /// 9856789892
        /// 8767896789
        /// 9899965678
        /// The bottom-right basin, size 9:
        /// 
        /// 2199943210
        /// 3987894921
        /// 9856789892
        /// 8767896789
        /// 9899965678
        /// Find the three largest basins and multiply their sizes together. In the above example, this is 9 * 14 * 9 = 1134.
        /// 
        /// What do you get if you multiply together the sizes of the three largest basins?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int[][] map = input.Select(x => x.Select(y => int.Parse(y.ToString())).ToArray()).ToArray();
            List<int> mins = [];

            mins = [];
            List<Point> basinOrgins = [];
            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[0].Length; y++)
                {
                    int current = map[x][y];
                    if (x != 0 && current >= map[x - 1][y]) continue;
                    if (x != map.Length - 1 && current >= map[x + 1][y]) continue;
                    if (y != 0 && current >= map[x][y - 1]) continue;
                    if (y != map[0].Length - 1 && current >= map[x][y + 1]) continue;

                    mins.Add(current);
                    basinOrgins.Add(new Point() { X = x, Y = y });
                }
            }

            List<HashSet<Point>> basins = [];
            foreach (Point basin in basinOrgins)
            {
                HashSet<Point> visited = [];
                Queue<Point> active = new();
                active.Enqueue(basin);

                while (active.Count != 0)
                {
                    Point currentTile = active.Dequeue();
                    visited.Add(currentTile);
                    int x = currentTile.X;
                    int y = currentTile.Y;

                    if (x != 0 && 9 != map[x - 1][y])
                    {
                        Point p = new(x - 1, y);
                        if (!visited.Contains(p)) active.Enqueue(p);
                    }

                    if (x != map.Length - 1 && 9 != map[x + 1][y])
                    {
                        Point p = new(x + 1, y);
                        if (!visited.Contains(p)) active.Enqueue(p);
                    }

                    if (y != 0 && 9 != map[x][y - 1])
                    {
                        Point p = new(x, y - 1);
                        if (!visited.Contains(p)) active.Enqueue(p);
                    }

                    if (y != map[0].Length - 1 && 9 != map[x][y + 1])
                    {
                        Point p = new(x, y + 1);
                        if (!visited.Contains(p)) active.Enqueue(p);
                    }
                }
                basins.Add(visited);
            }

            int product = basins.OrderByDescending(x => x.Count).Take(3).Aggregate(1, (accum, x) => accum * x.Count);

            return product;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _09_SmokeBasin(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_09_SmokeBasin));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}