using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Diagnostics;

namespace Rftim3AdventOfCode.Refactor
{
    public class _17_ClumsyCrucible : I_17_ClumsyCrucible
    {
        #region Static
        private readonly List<string>? data;

        public _17_ClumsyCrucible()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_17_ClumsyCrucible));
        }

        /// <summary>
        /// The lava starts flowing rapidly once the Lava Production Facility is operational. 
        /// As you leave, the reindeer offers you a parachute, allowing you to quickly reach Gear Island.
        /// 
        /// As you descend, your bird's-eye view of Gear Island reveals why you had trouble finding anyone on your way up: 
        /// half of Gear Island is empty, but the half below you is a giant factory city!
        /// 
        /// You land near the gradually-filling pool of lava at the base of your new lavafall.
        /// Lavaducts will eventually carry the lava throughout the city, but to make use of it immediately, 
        /// Elves are loading it into large crucibles on wheels.
        /// 
        /// The crucibles are top-heavy and pushed by hand.Unfortunately, the crucibles become very difficult to steer at high speeds,
        /// and so it can be hard to go in a straight line for very long.
        /// 
        /// To get Desert Island the machine parts it needs as soon as possible, you'll need to find the best way to get the crucible
        /// from the lava pool to the machine parts factory. To do this, you need to minimize heat loss while choosing a route 
        /// that doesn't require the crucible to go in a straight line for too long.
        /// 
        /// Fortunately, the Elves here have a map(your puzzle input) that uses traffic patterns, ambient temperature,
        /// and hundreds of other parameters to calculate exactly how much heat loss can be expected for a crucible entering any 
        /// particular city block.
        /// 
        /// For example:
        /// 
        /// 2413432311323
        /// 3215453535623
        /// 3255245654254
        /// 3446585845452
        /// 4546657867536
        /// 1438598798454
        /// 4457876987766
        /// 3637877979653
        /// 4654967986887
        /// 4564679986453
        /// 1224686865563
        /// 2546548887735
        /// 4322674655533
        /// Each city block is marked by a single digit that represents the amount of heat loss if the crucible enters that block.
        /// The starting point, the lava pool, is the top-left city block; the destination, the machine parts factory, 
        /// is the bottom-right city block. (Because you already start in the top-left block, you don't incur that block's heat loss 
        /// unless you leave that block and then return to it.)
        /// 
        /// Because it is difficult to keep the top-heavy crucible going in a straight line for very long, 
        /// it can move at most three blocks in a single direction before it must turn 90 degrees left or right.
        /// The crucible also can't reverse direction; after entering each city block, it may only turn left, continue straight, or turn right.
        /// 
        /// One way to minimize heat loss is this path:
        /// 
        /// 2>>34^>>>1323
        /// 32v>>>35v5623
        /// 32552456v>>54
        /// 3446585845v52
        /// 4546657867v>6
        /// 14385987984v4
        /// 44578769877v6
        /// 36378779796v>
        /// 465496798688v
        /// 456467998645v
        /// 12246868655<v
        /// 25465488877v5
        /// 43226746555v>
        /// This path never moves more than three consecutive blocks in the same direction and incurs a heat loss of only 102.
        /// 
        /// Directing the crucible from the lava pool to the machine parts factory, but not moving more than three consecutive blocks
        /// in the same direction, what is the least heat loss it can incur?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            return Traverse(ParseMap(input), 1, 3);
        }

        /// <summary>
        /// The crucibles of lava simply aren't large enough to provide an adequate supply of lava to the machine parts factory. 
        /// Instead, the Elves are going to upgrade to ultra crucibles.
        /// 
        /// Ultra crucibles are even more difficult to steer than normal crucibles.
        /// Not only do they have trouble going in a straight line, but they also have trouble turning!
        /// 
        /// Once an ultra crucible starts moving in a direction, it needs to move a minimum of four blocks in that direction 
        /// before it can turn(or even before it can stop at the end).
        /// However, it will eventually start to get wobbly: an ultra crucible can move a maximum of ten consecutive blocks without turning.
        /// 
        /// In the above example, an ultra crucible could follow this path to minimize heat loss:
        /// 
        /// 2>>>>>>>>1323
        /// 32154535v5623
        /// 32552456v4254
        /// 34465858v5452
        /// 45466578v>>>>
        /// 143859879845v
        /// 445787698776v
        /// 363787797965v
        /// 465496798688v
        /// 456467998645v
        /// 122468686556v
        /// 254654888773v
        /// 432267465553v
        /// In the above example, an ultra crucible would incur the minimum possible heat loss of 94.
        /// 
        /// Here's another example:
        /// 
        /// 111111111111
        /// 999999999991
        /// 999999999991
        /// 999999999991
        /// 999999999991
        /// Sadly, an ultra crucible would need to take an unfortunate path like this one:
        /// 
        /// 1>>>>>>>1111
        /// 9999999v9991
        /// 9999999v9991
        /// 9999999v9991
        /// 9999999v>>>>
        /// This route causes the ultra crucible to incur the minimum possible heat loss of 71.
        /// 
        /// Directing the ultra crucible from the lava pool to the machine parts factory, what is the least heat loss it can incur?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            return Traverse(ParseMap(input), 4, 10);
        }

        private static int[][] ParseMap(List<string> input)
        {
            return input.Select(o => o.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        }

        private enum Direction
        {
            N,
            E,
            S,
            W
        }

        private static int Traverse(int[][] map, int minSteps, int maxSteps)
        {
            PriorityQueue<(int y, int x, Direction direction, int directionMoves), int> queue = new();
            Dictionary<(Direction, int), int>[][] visited = new Dictionary<(Direction, int), int>[map.Length][];
            for (int y = 0; y < map.Length; y++)
            {
                visited[y] = new Dictionary<(Direction, int), int>[map[0].Length];

                for (int x = 0; x < map[0].Length; x++)
                {
                    visited[y][x] = [];
                }
            }

            queue.Enqueue((0, 0, Direction.E, 0), 0);
            queue.Enqueue((0, 0, Direction.S, 0), 0);

            while (queue.Count > 0)
            {
                (int y, int x, Direction direction, int directionMoves) = queue.Dequeue();

                int heat = visited[y][x].GetValueOrDefault((direction, directionMoves));

                if (directionMoves < maxSteps) Move(y, x, direction, heat, directionMoves);

                if (directionMoves >= minSteps)
                {
                    Move(y, x, L90(direction), heat, 0);
                    Move(y, x, R90(direction), heat, 0);
                }
            }

            int maxY = map.Length - 1;
            int maxX = map[0].Length - 1;

            return visited[maxY][maxX].Min(x => x.Value);

            void Move(int y, int x, Direction direction, int heat, int directionMoves)
            {
                int dy = direction switch
                {
                    Direction.N => -1,
                    Direction.S => 1,
                    _ => 0
                };

                int dx = direction switch
                {
                    Direction.E => 1,
                    Direction.W => -1,
                    _ => 0
                };

                for (int i = 1; i <= maxSteps; i++)
                {
                    int newY = y + i * dy;
                    int newX = x + i * dx;
                    int newDirectionMoves = directionMoves + i;

                    if (newY < 0 || newY >= map.Length || newX < 0 || newX >= map[0].Length || newDirectionMoves > maxSteps) return;

                    heat += map[newY][newX];

                    if (i < minSteps) continue;

                    Dictionary<(Direction, int), int> vlist = visited[newY][newX];

                    if (vlist.TryGetValue((direction, newDirectionMoves), out int visitedHeat))
                    {
                        if (visitedHeat <= heat) return;
                    }

                    queue.Enqueue((newY, newX, direction, newDirectionMoves), heat);
                    vlist[(direction, newDirectionMoves)] = heat;
                }
            }

            static Direction L90(Direction direction) => direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => throw new UnreachableException()
            };

            static Direction R90(Direction direction) => direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new UnreachableException()
            };
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _17_ClumsyCrucible(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_17_ClumsyCrucible));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}