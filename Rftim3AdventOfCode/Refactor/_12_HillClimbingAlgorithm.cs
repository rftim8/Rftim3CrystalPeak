using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _12_HillClimbingAlgorithm : I_12_HillClimbingAlgorithm
    {
        #region Static
        private readonly List<string>? data;

        public _12_HillClimbingAlgorithm()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_12_HillClimbingAlgorithm));
        }

        /// <summary>
        /// You try contacting the Elves using your handheld device, but the river you're following must be too low to get a decent signal.
        /// 
        /// You ask the device for a heightmap of the surrounding area(your puzzle input). 
        /// The heightmap shows the local area from above broken into a grid; the elevation of each square of the grid is given by a single lowercase letter,
        /// where a is the lowest elevation, b is the next-lowest, and so on up to the highest elevation, z.
        /// 
        /// Also included on the heightmap are marks for your current position(S) and the location that should get the best signal(E). 
        /// Your current position(S) has elevation a, and the location that should get the best signal(E) has elevation z.
        /// 
        /// You'd like to reach E, but to save energy, you should do it in as few steps as possible.
        /// During each step, you can move exactly one square up, down, left, or right. 
        /// To avoid needing to get out your climbing gear, the elevation of the destination square can be at most one higher than the elevation of your current square;
        /// that is, if your current elevation is m, you could step to elevation n, but not to elevation o.
        /// (This also means that the elevation of the destination square can be much lower than the elevation of your current square.)
        /// 
        /// For example:
        /// 
        /// Sabqponm
        ///         abcryxxl
        /// accszExk
        ///         acctuvwj
        /// abdefghi
        /// Here, you start in the top-left corner; your goal is near the middle.
        /// You could start by moving down or right, but eventually you'll need to head toward the e at the bottom. 
        /// From there, you can spiral around to the goal:
        /// 
        /// v..v<<<<
        /// >v.vv<<^
        /// .>vv>E^^
        /// ..v>>>^^
        /// ..>>>>>^
        /// In the above diagram, the symbols indicate whether the path exits each square moving up(^), down(v), left(<), or right(>). 
        /// The location that should get the best signal is still E, and . marks unvisited squares.
        ///         This path reaches the goal in 31 steps, the fewest possible.
        /// 
        /// What is the fewest steps required to move from your current position to the location that should get the best signal?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int height = input.Count;
            int width = input[0].Length;

            return BFS([.. input], height, width);
        }

        /// <summary>
        /// As you walk up the hill, you suspect that the Elves will want to turn this into a hiking trail. 
        /// The beginning isn't very scenic, though; perhaps you can find a better starting point.
        /// 
        /// To maximize exercise while hiking, the trail should start as low as possible: elevation a.The goal is still the square marked E.
        /// However, the trail should still be direct, taking the fewest steps to reach its goal.
        /// So, you'll need to find the shortest path from any square at elevation a to the square marked E.
        /// 
        /// Again consider the example from above:
        /// 
        /// Sabqponm
        /// abcryxxl
        /// accszExk
        /// acctuvwj
        /// abdefghi
        /// Now, there are six choices for starting position (five marked a, plus the square marked S that counts as being at elevation a). 
        /// If you start at the bottom-left square, you can reach the goal most quickly:
        /// 
        /// ...v<<<<
        /// ...vv<<^
        /// ...v>E^^
        /// .>v>>>^^
        /// >^>>>>>^
        /// This path reaches the goal in only 29 steps, the fewest possible.
        /// 
        /// What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int height = input.Count;
            int width = input[0].Length;
            int[,] costs = new int[height, width];
            foreach (int x in Enumerable.Range(0, height))
            {
                foreach (int y in Enumerable.Range(0, width))
                {
                    if (input[x][y] == 'S') costs[x, y] = 1;
                    else if (input[x][y] == 'E') costs[x, y] = 26;
                    else costs[x, y] = input[x][y] - 'a' + 1;
                }
            }

            return BFS([.. input], height, width, costs);
        }

        private static readonly List<(int x, int y)> neighbors = [(-1, 0), (1, 0), (0, -1), (0, 1)];

        private static int BFS(string[] grid, int height, int width, int[,]? costs = null)
        {
            Queue<((int x, int y), int cost)> locQueue = new();
            foreach ((int x, int y) in from int x in Enumerable.Range(0, height)
                                       from int y in Enumerable.Range(0, width)
                                       where costs == null && grid[x][y] == 'S' || costs != null && costs[x, y] == 1
                                       select (x, y))
            {
                locQueue.Enqueue(((x, y), 0));
            }

            HashSet<(int x, int y)> seen = [];

            while (locQueue.Count != 0)
            {
                ((int x, int y), int cost) = locQueue.Dequeue();
                if (!seen.Add((x, y))) continue;
                if (grid[x][y] == 'E') return cost;

                foreach ((int dx, int dy) in neighbors)
                {
                    int dxP = x + dx;
                    int dyP = y + dy;
                    if (dxP >= 0 && dxP < height && dyP >= 0 && dyP < width)
                    {
                        if (costs == null)
                        {
                            if (grid[x][y] == 'S' ? grid[dxP][dyP] - 'a' <= 1 : grid[dxP][dyP] - grid[x][y] <= 1) locQueue.Enqueue(((dxP, dyP), cost + 1));
                        }
                        else
                        {
                            if (costs[dxP, dyP] <= 1 + costs[x, y]) locQueue.Enqueue(((dxP, dyP), cost + 1));
                        }

                    }
                }
            }

            return 0;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _12_HillClimbingAlgorithm(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_12_HillClimbingAlgorithm));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}