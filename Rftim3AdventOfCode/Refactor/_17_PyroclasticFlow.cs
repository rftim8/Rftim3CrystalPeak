using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _17_PyroclasticFlow : I_17_PyroclasticFlow
    {
        #region Static
        private readonly List<string>? data;

        public _17_PyroclasticFlow()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_17_PyroclasticFlow));
        }

        /// <summary>
        /// Your handheld device has located an alternative exit from the cave for you and the elephants. 
        /// The ground is rumbling almost continuously now, but the strange valves bought you some time. It's definitely getting warmer in here, though.
        /// 
        /// The tunnels eventually open into a very tall, narrow chamber.
        /// Large, oddly-shaped rocks are falling into the chamber from above, presumably due to all the rumbling.
        /// If you can't work out where the rocks will fall next, you might be crushed!
        /// 
        /// The five types of rocks have the following peculiar shapes, where # is rock and . is empty space:
        /// 
        /// ####
        /// 
        /// .#.
        /// ###
        /// .#.
        /// 
        /// ..#
        /// ..#
        /// ###
        /// 
        /// #
        /// #
        /// #
        /// #
        /// 
        /// ##
        /// ##
        /// The rocks fall in the order shown above: first the - shape, then the + shape, and so on.
        /// Once the end of the list is reached, the same order repeats: the - shape falls first, sixth, 11th, 16th, etc.
        /// 
        /// The rocks don't spin, but they do get pushed around by jets of hot gas coming out of the walls themselves.
        /// A quick scan reveals the effect the jets of hot gas will have on the rocks as they fall (your puzzle input).
        ///
        /// For example, suppose this was the jet pattern in your cave:
        /// 
        /// >>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>
        /// In jet patterns, < means a push to the left, while > means a push to the right.
        /// The pattern above means that the jets will push a falling rock right, then right, then right, then left, then left, then right, and so on.
        /// If the end of the list is reached, it repeats.
        /// 
        /// The tall, vertical chamber is exactly seven units wide. 
        /// Each rock appears so that its left edge is two units away from the left wall and its bottom edge is three units 
        /// above the highest rock in the room (or the floor, if there isn't one).
        ///
        ///
        /// After a rock appears, it alternates between being pushed by a jet of hot gas one unit (in the direction indicated by the next symbol in the jet pattern)
        /// and then falling one unit down.If any movement would cause any part of the rock to move into the walls, floor, or a stopped rock, 
        /// the movement instead does not occur. If a downward movement would have caused a falling rock to move into the floor or an already-fallen rock,
        /// the falling rock stops where it is (having landed on something) and a new rock immediately begins falling.
        ///
        /// Drawing falling rocks with @ and stopped rocks with #, the jet pattern in the example above manifests as follows:
        /// 
        /// The first rock begins falling:
        /// |..@@@@.|
        /// |.......|
        /// |.......|
        /// |.......|
        /// +-------+
        /// 
        /// 
        /// Jet of gas pushes rock right:
        /// |...@@@@|
        /// |.......|
        /// |.......|
        /// |.......|
        /// +-------+
        /// 
        /// 
        /// Rock falls 1 unit:
        /// |...@@@@|
        /// |.......|
        /// |.......|
        /// +-------+
        /// 
        /// 
        /// Jet of gas pushes rock right, but nothing happens:
        /// |...@@@@|
        /// |.......|
        /// |.......|
        /// +-------+
        /// 
        /// 
        /// Rock falls 1 unit:
        /// |...@@@@|
        /// |.......|
        /// +-------+
        /// 
        /// 
        /// Jet of gas pushes rock right, but nothing happens:
        /// |...@@@@|
        /// |.......|
        /// +-------+
        /// 
        /// 
        /// Rock falls 1 unit:
        /// |...@@@@|
        /// +-------+
        /// 
        /// 
        /// Jet of gas pushes rock left:
        /// |..@@@@.|
        /// +-------+
        /// 
        /// 
        /// Rock falls 1 unit, causing it to come to rest:
        /// |..####.|
        /// +-------+
        /// 
        /// 
        /// A new rock begins falling:
        /// |...@...|
        /// |..@@@..|
        /// |...@...|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |..####.|
        /// +-------+
        /// 
        /// Jet of gas pushes rock left:
        /// |..@....|
        /// |.@@@...|
        /// |..@....|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |..####.|
        /// +-------+
        /// 
        /// Rock falls 1 unit:
        /// |..@....|
        /// |.@@@...|
        /// |..@....|
        /// |.......|
        /// |.......|
        /// |..####.|
        /// +-------+
        /// 
        /// Jet of gas pushes rock right:
        /// |...@...|
        /// |..@@@..|
        /// |...@...|
        /// |.......|
        /// |.......|
        /// |..####.|
        /// +-------+
        /// 
        /// Rock falls 1 unit:
        /// |...@...|
        /// |..@@@..|
        /// |...@...|
        /// |.......|
        /// |..####.|
        /// +-------+
        /// 
        /// Jet of gas pushes rock left:
        /// |..@....|
        /// |.@@@...|
        /// |..@....|
        /// |.......|
        /// |..####.|
        /// +-------+
        /// 
        /// Rock falls 1 unit:
        /// |..@....|
        /// |.@@@...|
        /// |..@....|
        /// |..####.|
        /// +-------+
        /// 
        /// Jet of gas pushes rock right:
        /// |...@...|
        /// |..@@@..|
        /// |...@...|
        /// |..####.|
        /// +-------+
        /// 
        /// Rock falls 1 unit, causing it to come to rest:
        /// |...#...|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// A new rock begins falling:
        /// |....@..|
        /// |....@..|
        /// |..@@@..|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |...#...|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// The moment each of the next few rocks begins falling, you would see this:
        /// 
        /// |..@....|
        /// |..@....|
        /// |..@....|
        /// |..@....|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |..#....|
        /// |..#....|
        /// |####...|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |..@@...|
        /// |..@@...|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |..@@@@.|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |....##.|
        /// |....##.|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |...@...|
        /// |..@@@..|
        /// |...@...|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |.####..|
        /// |....##.|
        /// |....##.|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |....@..|
        /// |....@..|
        /// |..@@@..|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |..#....|
        /// |.###...|
        /// |..#....|
        /// |.####..|
        /// |....##.|
        /// |....##.|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |..@....|
        /// |..@....|
        /// |..@....|
        /// |..@....|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |.....#.|
        /// |.....#.|
        /// |..####.|
        /// |.###...|
        /// |..#....|
        /// |.####..|
        /// |....##.|
        /// |....##.|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |..@@...|
        /// |..@@...|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |....#..|
        /// |....#..|
        /// |....##.|
        /// |....##.|
        /// |..####.|
        /// |.###...|
        /// |..#....|
        /// |.####..|
        /// |....##.|
        /// |....##.|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// 
        /// |..@@@@.|
        /// |.......|
        /// |.......|
        /// |.......|
        /// |....#..|
        /// |....#..|
        /// |....##.|
        /// |##..##.|
        /// |######.|
        /// |.###...|
        /// |..#....|
        /// |.####..|
        /// |....##.|
        /// |....##.|
        /// |....#..|
        /// |..#.#..|
        /// |..#.#..|
        /// |#####..|
        /// |..###..|
        /// |...#...|
        /// |..####.|
        /// +-------+
        /// To prove to the elephants your simulation is accurate, they want to know how tall the tower will get after 2022 rocks have 
        /// stopped(but before the 2023rd rock begins falling). In this example, the tower of rocks will be 3068 units tall.
        /// 
        /// How many units tall will the tower of rocks be after 2022 rocks have stopped falling?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            int repeatSize = input[0].Length;
            HashSet<(int x, long y)> map = [];

            for (int x = 0; x < 7; x++)
            {
                map.Add((x, 0));
            }

            long top = 0L;
            int i = 0;
            long turn = 0L;
            do
            {
                HashSet<(int x, long y)> piece = GetPiece(turn % 5, top + 4);
                while (true)
                {
                    if (input[0][i] == '<')
                    {
                        piece = MoveLeft(piece);
                        if (piece.Overlaps(map)) piece = MoveRight(piece);
                    }
                    else
                    {
                        piece = MoveRight(piece);
                        if (piece.Overlaps(map)) piece = MoveLeft(piece);
                    }
                    i = (i + 1) % repeatSize;
                    piece = MoveDown(piece);

                    if (piece.Overlaps(map))
                    {
                        piece = MoveUp(piece);
                        map.UnionWith(piece);
                        top = map.Max(y => y.y);
                        break;
                    }

                }
                turn++;
            } while (turn < 2022);

            return top;
        }

        /// <summary>
        /// The elephants are not impressed by your simulation. They demand to know how tall the tower will be after 1000000000000 rocks have stopped! 
        /// Only then will they feel confident enough to proceed through the cave.
        /// 
        /// In the example above, the tower would be 1514285714288 units tall!
        /// 
        /// How tall will the tower be after 1000000000000 rocks have stopped?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            int repeatSize = input[0].Length;
            HashSet<(int x, long y)> map = [];
            for (int x = 0; x < 7; x++)
            {
                map.Add((x, 0L));
            }

            long top = 0L;
            int i = 0;
            long rockCount = 0L;
            long max = 1000000000000;
            long added = 0L;
            Dictionary<(int i, long t), (long t, long y)> seen = [];
            while (rockCount < max)
            {
                HashSet<(int x, long y)> piece = GetPiece(rockCount % 5, top + 4);
                while (true)
                {
                    if (input[0][i] == '<')
                    {
                        piece = MoveLeft(piece);
                        if (piece.Overlaps(map)) piece = MoveRight(piece);
                    }
                    else
                    {
                        piece = MoveRight(piece);
                        if (piece.Overlaps(map)) piece = MoveLeft(piece);
                    }
                    i = (i + 1) % repeatSize;
                    piece = MoveDown(piece);

                    if (piece.Overlaps(map))
                    {
                        piece = MoveUp(piece);
                        map.UnionWith(piece);
                        top = map.Max(y => y.y);
                        (int i, long) temp = (i, rockCount % 5);

                        if (seen.TryGetValue(temp, out (long t, long y) value) && rockCount >= 2022)
                        {
                            (long oldt, long oldy) = value;
                            long dy = top - oldy;
                            long dt = rockCount - oldt;
                            long amount = (max - rockCount) / dt;
                            added += amount * dy;
                            rockCount += amount * dt;
                        }
                        seen[temp] = (rockCount, top);
                        break;
                    }

                }
                rockCount++;
            }

            return top + added;
        }

        private static HashSet<(int x, long y)> GetPiece(long i, long y)
        {
            return i switch
            {
                0 =>
                    [
                        (2, y),
                        (3, y),
                        (4, y),
                        (5, y)
                    ],
                1 =>
                    [
                        (3, y + 2),
                        (2, y + 1),
                        (3, y + 1),
                        (4, y + 1),
                        (3, y)
                    ],
                2 =>
                    [
                        (2, y),
                        (3, y),
                        (4, y),
                        (4, y + 1),
                        (4, y + 2)
                    ],
                3 =>
                    [
                        (2, y),
                        (2, y + 1),
                        (2, y + 2),
                        (2, y + 3)
                    ],
                4 =>
                    [
                        (2, y + 1),
                        (2, y),
                        (3, y + 1),
                        (3, y)
                    ],
                _ => []
            };
        }

        private static HashSet<(int x, long y)> MoveLeft(HashSet<(int x, long y)> piece)
        {
            if (piece.Any(x => x.x == 0)) return piece;

            HashSet<(int x, long y)> tempPiece = [];
            foreach ((int x, long y) in piece)
            {
                tempPiece.Add((x - 1, y));
            }

            return tempPiece;
        }

        private static HashSet<(int x, long y)> MoveRight(HashSet<(int x, long y)> piece)
        {
            if (piece.Any(x => x.x == 6)) return piece;

            HashSet<(int x, long y)> tempPiece = [];
            foreach ((int x, long y) in piece)
            {
                tempPiece.Add((x + 1, y));
            }

            return tempPiece;
        }

        private static HashSet<(int x, long y)> MoveDown(HashSet<(int x, long y)> piece)
        {
            HashSet<(int x, long y)> tempPiece = [];
            foreach ((int x, long y) in piece)
            {
                tempPiece.Add((x, y - 1));
            }

            return tempPiece;
        }

        private static HashSet<(int x, long y)> MoveUp(HashSet<(int x, long y)> piece)
        {
            HashSet<(int x, long y)> tempPiece = [];
            foreach ((int x, long y) in piece)
            {
                tempPiece.Add((x, y + 1));
            }

            return tempPiece;
        }
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _17_PyroclasticFlow(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_17_PyroclasticFlow));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}