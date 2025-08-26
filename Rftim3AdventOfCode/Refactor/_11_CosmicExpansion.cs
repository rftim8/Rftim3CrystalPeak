using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Drawing;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _11_CosmicExpansion : I_11_CosmicExpansion
    {
        #region Static
        private readonly List<string>? data;

        public _11_CosmicExpansion()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_11_CosmicExpansion));
        }

        /// <summary>
        /// You continue following signs for "Hot Springs" and eventually come across an observatory. 
        /// The Elf within turns out to be a researcher studying cosmic expansion using the giant telescope here.
        ///
        ///He doesn't know anything about the missing machine parts; he's only visiting for this research project.
        ///However, he confirms that the hot springs are the next-closest area likely to have people; 
        ///he'll even take you straight there once he's done with today's observation analysis.
        ///
        ///Maybe you can help him with the analysis to speed things up?
        ///
        ///The researcher has collected a bunch of data and compiled the data into a single giant image(your puzzle input). 
        ///The image includes empty space(.) and galaxies(#). For example:
        ///
        ///...#......
        ///.......#..
        ///#.........
        ///..........
        ///......#...
        ///.#........
        ///.........#
        ///..........
        ///.......#..
        ///#...#.....
        ///The researcher is trying to figure out the sum of the lengths of the shortest path between every pair of galaxies.
        ///However, there's a catch: the universe expanded in the time it took the light from those galaxies to reach the observatory.
        ///
        ///Due to something involving gravitational effects, only some space expands. 
        ///In fact, the result is that any rows or columns that contain no galaxies should all actually be twice as big.
        ///
        ///In the above example, three columns and two rows contain no galaxies:
        ///
        ///   v v  v
        /// ...#......
        /// .......#..
        /// #.........
        ///>..........<
        /// ......#...
        /// .#........
        /// .........#
        ///>..........<
        /// .......#..
        /// #...#.....
        ///   ^  ^  ^
        ///These rows and columns need to be twice as big; the result of cosmic expansion therefore looks like this:
        ///
        ///....#........
        ///.........#...
        ///#............
        ///.............
        ///.............
        ///........#....
        ///.#...........
        ///............#
        ///.............
        ///.............
        ///.........#...
        ///#....#.......
        ///Equipped with this expanded universe, the shortest path between every pair of galaxies can be found.
        ///It can help to assign every galaxy a unique number:
        ///
        ///....1........
        ///.........2...
        ///3............
        ///.............
        ///.............
        ///........4....
        ///.5...........
        ///............6
        ///.............
        ///.............
        ///.........7...
        ///8....9.......
        ///In these 9 galaxies, there are 36 pairs.Only count each pair once; order within the pair doesn't matter. 
        ///For each pair, find any shortest path between the two galaxies using only steps that move up, down, left, or 
        ///right exactly one . or # at a time. (The shortest path between two galaxies is allowed to pass through another galaxy.)
        ///
        ///For example, here is one of the shortest paths between galaxies 5 and 9:
        ///
        ///....1........
        ///.........2...
        ///3............
        ///.............
        ///.............
        ///........4....
        ///.5...........
        ///.##.........6
        ///..##.........
        ///...##........
        ///....##...7...
        ///8....9.......
        ///This path has length 9 because it takes a minimum of nine steps to get from galaxy 5 to galaxy 9 
        ///(the eight locations marked # plus the step onto galaxy 9 itself). Here are some other example shortest path lengths:
        ///
        ///Between galaxy 1 and galaxy 7: 15
        ///Between galaxy 3 and galaxy 6: 17
        ///Between galaxy 8 and galaxy 9: 5
        ///In this example, after expanding the universe, the sum of the shortest path between all 36 pairs of galaxies is 374.
        ///
        ///Expand the universe, then find the length of the shortest path between every pair of galaxies.
        ///What is the sum of these lengths?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            #region Initial Universe
            int n = input.Count;
            int m = input[0].Length;
            #endregion

            #region Expand Universe
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] == '.') c++;
                }
                if (c == m)
                {
                    input.Insert(i, string.Concat(Enumerable.Repeat('.', m)));
                    i++;
                    n++;
                }
            }

            List<int> cols = [];
            for (int i = 0; i < m; i++)
            {
                cols.Add(0);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] == '.') cols[j]++;
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (cols[i] == n)
                {
                    for (int j = 0; j < n; j++)
                    {
                        StringBuilder sb = new();
                        sb.Append(input[j]);
                        sb.Insert(i + 1, '.');
                        input[j] = sb.ToString();
                    }
                    cols.Insert(0, i + 1);

                    i++;
                    m++;
                }
            }
            #endregion

            #region Search Galaxies
            List<Point> galaxies = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] != '.') galaxies.Add(new(i, j));
                }
            }
            #endregion

            #region Calculate Distances
            Dictionary<(Point, Point), long> kvp = [];

            foreach (Point item in galaxies)
            {
                foreach (Point item1 in galaxies)
                {
                    if (item != item1)
                    {
                        long t = ManhattanDistance(item.X, item.Y, item1.X, item1.Y);

                        if (kvp.ContainsKey((item1, item))) kvp[(item1, item)] = Math.Min(kvp[(item1, item)], t);
                        else kvp.Add((item, item1), t);
                    }
                }
            }
            #endregion

            #region Print Result
            return kvp.Select(o => o.Value).Sum();
            #endregion
        }

        /// <summary>
        /// The galaxies are much older (and thus much farther apart) than the researcher initially estimated.
        /// 
        /// Now, instead of the expansion you did before, make each empty row or column one million times larger.
        /// That is, each empty row should be replaced with 1000000 empty rows, and each empty column should be replaced with 
        /// 1000000 empty columns.
        /// 
        /// (In the example above, if each empty row or column were merely 10 times larger,
        /// the sum of the shortest paths between every pair of galaxies would be 1030. 
        /// If each empty row or column were merely 100 times larger, the sum of the shortest paths between every pair 
        /// of galaxies would be 8410. However, your universe will need to expand far beyond these values.)
        /// 
        /// Starting with the same initial image, expand the universe according to these new rules, 
        /// then find the length of the shortest path between every pair of galaxies.What is the sum of these lengths?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            #region Initial Universe
            int n = input.Count;
            int m = input[0].Length;
            #endregion

            #region Expand Universe
            int f = 999999;
            int e = f;

            List<int> cols = [];
            for (int i = 0; i < m; i++)
            {
                cols.Add(0);
            }

            List<(int, int)> heights = [];
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] == '.')
                    {
                        cols[j]++;
                        c++;
                    }
                }
                if (c == m)
                {
                    heights.Add((i, e));
                    e += f;
                }
            }

            e = f;
            List<(int, int)> widths = [];
            for (int i = 0; i < m; i++)
            {
                if (cols[i] == n)
                {
                    widths.Add((i, e));
                    e += f;
                }
            }
            #endregion

            #region Search Galaxies
            List<Point> galaxies = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] != '.')
                    {
                        int x0 = 0, y0 = 0;
                        for (int k = 0; k < heights.Count; k++)
                        {
                            if (i > heights[k].Item1) x0 = heights[k].Item2;
                        }
                        for (int k = 0; k < widths.Count; k++)
                        {
                            if (j > widths[k].Item1) y0 = widths[k].Item2;
                        }
                        galaxies.Add(new(i + x0, j + y0));
                    }
                }
            }
            #endregion

            #region Calculate Distances
            Dictionary<(Point, Point), long> kvp = [];

            foreach (Point item in galaxies)
            {
                foreach (Point item1 in galaxies)
                {
                    if (item != item1)
                    {
                        long t = ManhattanDistance(item.X, item.Y, item1.X, item1.Y);

                        if (kvp.ContainsKey((item1, item))) kvp[(item1, item)] = Math.Min(kvp[(item1, item)], t);
                        else kvp.Add((item, item1), t);
                    }
                }
            }
            #endregion

            #region Print Result
            return kvp.Select(o => o.Value).Sum();
            #endregion
        }

        private static int ManhattanDistance(int x0, int y0, int x1, int y1)
        {
            return Math.Abs(x0 - x1) + Math.Abs(y0 - y1);
        }
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _11_CosmicExpansion(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_11_CosmicExpansion));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}