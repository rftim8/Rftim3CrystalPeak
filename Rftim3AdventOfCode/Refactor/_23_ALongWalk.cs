using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Numerics;
using Map = System.Collections.Generic.Dictionary<System.Numerics.Complex, char>;
using Node = long;

namespace Rftim3AdventOfCode.Refactor
{
    public class _23_ALongWalk : I_23_ALongWalk
    {
        #region Static
        private readonly List<string>? data;

        public _23_ALongWalk()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_23_ALongWalk));
        }

        /// <summary>
        /// The Elves resume water filtering operations! Clean water starts flowing over the edge of Island Island.
        /// 
        /// They offer to help you go over the edge of Island Island, too! Just hold on tight to one end of this impossibly long rope 
        /// and they'll lower you down a safe distance from the massive waterfall you just created.
        /// 
        /// As you finally reach Snow Island, you see that the water isn't really reaching the ground: it's being absorbed by the air itself.
        /// It looks like you'll finally have a little downtime while the moisture builds up to snow-producing levels. 
        /// Snow Island is pretty scenic, even without any snow; why not take a walk?
        /// 
        /// There's a map of nearby hiking trails (your puzzle input) that indicates paths (.), forest (#), and steep slopes (^, >, v, and <).
        /// 
        /// For example:
        /// 
        /// #.#####################
        /// #.......#########...###
        /// #######.#########.#.###
        /// ###.....#.>.>.###.#.###
        /// ###v#####.#v#.###.#.###
        /// ###.>...#.#.#.....#...#
        /// ###v###.#.#.#########.#
        /// ###...#.#.#.......#...#
        /// #####.#.#.#######.#.###
        /// #.....#.#.#.......#...#
        /// #.#####.#.#.#########v#
        /// #.#...#...#...###...>.#
        /// #.#.#v#######v###.###v#
        /// #...#.>.#...>.>.#.###.#
        /// #####v#.#.###v#.#.###.#
        /// #.....#...#...#.#.#...#
        /// #.#########.###.#.#.###
        /// #...###...#...#...#.###
        /// ###.###.#.###v#####v###
        /// #...#...#.#.>.>.#.>.###
        /// #.###.###.#.###.#.#v###
        /// #.....###...###...#...#
        /// #####################.#
        /// You're currently on the single path tile in the top row; your goal is to reach the single path tile in the bottom row.
        /// Because of all the mist from the waterfall, the slopes are probably quite icy; 
        /// if you step onto a slope tile, your next step must be downhill (in the direction the arrow is pointing).
        /// To make sure you have the most scenic hike possible, never step onto the same tile twice. What is the longest hike you can take?
        /// 
        /// In the example above, the longest hike you can take is marked with O, and your starting position is marked S:
        /// 
        /// #S#####################
        /// #OOOOOOO#########...###
        /// #######O#########.#.###
        /// ###OOOOO#OOO>.###.#.###
        /// ###O#####O#O#.###.#.###
        /// ###OOOOO#O#O#.....#...#
        /// ###v###O#O#O#########.#
        /// ###...#O#O#OOOOOOO#...#
        /// #####.#O#O#######O#.###
        /// #.....#O#O#OOOOOOO#...#
        /// #.#####O#O#O#########v#
        /// #.#...#OOO#OOO###OOOOO#
        /// #.#.#v#######O###O###O#
        /// #...#.>.#...>OOO#O###O#
        /// #####v#.#.###v#O#O###O#
        /// #.....#...#...#O#O#OOO#
        /// #.#########.###O#O#O###
        /// #...###...#...#OOO#O###
        /// ###.###.#.###v#####O###
        /// #...#...#.#.>.>.#.>O###
        /// #.###.###.#.###.#.#O###
        /// #.....###...###...#OOO#
        /// #####################O#
        /// This hike contains 94 steps. (The other possible hikes you could have taken were 90, 86, 82, 82, and 74 steps long.)
        /// 
        /// Find the longest hike you can take through the hiking trails listed on your map.How many steps long is the longest hike?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            string input = string.Join("\n", input0);

            (long[] nodes, Edge[] edges) = MakeGraph(input);
            (long start, long goal) = (nodes.First(), nodes.Last());

            Dictionary<(long, long), int> cache = [];
            int LongestPath(Node node, long visited)
            {
                if (node == goal) return 0;
                else if ((visited & node) != 0) return int.MinValue;

                (long node, long visited) key = (node, visited);

                if (!cache.TryGetValue(key, out int value))
                {
                    value = edges
                        .Where(e => e.Start == node)
                        .Select(e => e.Distance + LongestPath(e.End, visited | node))
                        .Max();
                    cache[key] = value;
                }

                return value;
            }

            return LongestPath(start, 0);
        }

        /// <summary>
        /// As you reach the trailhead, you realize that the ground isn't as slippery as you expected;
        /// you'll have no problem climbing up the steep slopes.
        /// 
        /// Now, treat all slopes as if they were normal paths(.).
        /// You still want to make sure you have the most scenic hike possible, so continue to ensure that you never step onto the same tile twice.
        /// What is the longest hike you can take?
        /// 
        /// In the example above, this increases the longest hike to 154 steps:
        /// 
        /// #S#####################
        /// #OOOOOOO#########OOO###
        /// #######O#########O#O###
        /// ###OOOOO#.>OOO###O#O###
        /// ###O#####.#O#O###O#O###
        /// ###O>...#.#O#OOOOO#OOO#
        /// ###O###.#.#O#########O#
        /// ###OOO#.#.#OOOOOOO#OOO#
        /// #####O#.#.#######O#O###
        /// #OOOOO#.#.#OOOOOOO#OOO#
        /// #O#####.#.#O#########O#
        /// #O#OOO#...#OOO###...>O#
        /// #O#O#O#######O###.###O#
        /// #OOO#O>.#...>O>.#.###O#
        /// #####O#.#.###O#.#.###O#
        /// #OOOOO#...#OOO#.#.#OOO#
        /// #O#########O###.#.#O###
        /// #OOO###OOO#OOO#...#O###
        /// ###O###O#O###O#####O###
        /// #OOO#OOO#O#OOO>.#.>O###
        /// #O###O###O#O###.#.#O###
        /// #OOOOO###OOO###...#OOO#
        /// #####################O#
        /// Find the longest hike you can take through the surprisingly dry hiking trails listed on your map.
        /// How many steps long is the longest hike?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input0)
        {
            string input = string.Join("\n", input0);
            input = RemoveSlopes(input);

            (long[] nodes, Edge[] edges) = MakeGraph(input);
            (long start, long goal) = (nodes.First(), nodes.Last());

            Dictionary<(long, long), int> cache = [];
            int LongestPath(Node node, long visited)
            {
                if (node == goal) return 0;
                else if ((visited & node) != 0) return int.MinValue;

                (long node, long visited) key = (node, visited);

                if (!cache.TryGetValue(key, out int value))
                {
                    value = edges
                        .Where(e => e.Start == node)
                        .Select(e => e.Distance + LongestPath(e.End, visited | node))
                        .Max();
                    cache[key] = value;
                }

                return value;
            }

            return LongestPath(start, 0);
        }

        private record Edge(Node Start, Node End, int Distance);

        private static readonly Complex Up = -Complex.ImaginaryOne;
        private static readonly Complex Down = Complex.ImaginaryOne;
        private static readonly Complex Left = -1;
        private static readonly Complex Right = 1;
        private static readonly Complex[] Dirs = [Up, Down, Left, Right];
        private static readonly Dictionary<char, Complex[]> exits = new()
        {
            ['<'] = [Left],
            ['>'] = [Right],
            ['^'] = [Up],
            ['v'] = [Down],
            ['.'] = [Up, Down, Left, Right],
            ['#'] = []
        };

        private static string RemoveSlopes(string st) => string.Join("", st.Select(ch => ">v<^".Contains(ch) ? '.' : ch));

        private static (Node[], Edge[]) MakeGraph(string input)
        {
            Map map = ParseMap(input);

            Complex[] crossroads = (
                from pos in map.Keys
                orderby pos.Imaginary, pos.Real
                where IsFree(map, pos) && !IsRoad(map, pos)
                select pos
            ).ToArray();

            long[] nodes = (
                from i in Enumerable.Range(0, crossroads.Length)
                select 1L << i
            ).ToArray();

            Edge[] edges = (
                from i in Enumerable.Range(0, crossroads.Length)
                from j in Enumerable.Range(0, crossroads.Length)
                where i != j
                let distance = Distance(map, crossroads[i], crossroads[j])
                where distance > 0
                select new Edge(nodes[i], nodes[j], distance)
            ).ToArray();

            return (nodes, edges);
        }

        private static int Distance(Map map, Complex crossroadA, Complex crossroadB)
        {
            Queue<(Complex, int)> q = new();
            q.Enqueue((crossroadA, 0));

            HashSet<Complex> visited = [crossroadA];
            while (q.Count != 0)
            {
                (Complex pos, int dist) = q.Dequeue();
                foreach (Complex dir in exits[map[pos]])
                {
                    Complex posT = pos + dir;

                    if (posT == crossroadB) return dist + 1;
                    else if (IsRoad(map, posT) && !visited.Contains(posT))
                    {
                        visited.Add(posT);
                        q.Enqueue((posT, dist + 1));
                    }
                }
            }

            return -1;
        }

        private static bool IsFree(Map map, Complex p) => map.ContainsKey(p) && map[p] != '#';

        private static bool IsRoad(Map map, Complex p) => Dirs.Count(d => IsFree(map, p + d)) == 2;

        private static Map ParseMap(string input)
        {
            string[] lines = input.Split('\n');
            return (
                from irow in Enumerable.Range(0, lines.Length)
                from icol in Enumerable.Range(0, lines[0].Length)
                let pos = new Complex(icol, irow)
                select new KeyValuePair<Complex, char>(pos, lines[irow][icol])
            ).ToDictionary();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _23_ALongWalk(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_23_ALongWalk));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}