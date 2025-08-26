using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _10_TheStarsAlign : I_10_TheStarsAlign
    {
        #region Static
        private readonly List<string>? data;

        public _10_TheStarsAlign()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_10_TheStarsAlign));
        }

        /// <summary>
        /// It's no use; your navigation system simply isn't capable of providing walking directions in the arctic circle, and certainly not in 1018.
        /// 
        /// The Elves suggest an alternative.In times like these, North Pole rescue operations will arrange points of light in the sky to guide missing Elves back to base.
        /// Unfortunately, the message is easy to miss: the points move slowly enough that it takes hours to align them,
        /// but have so much momentum that they only stay aligned for a second.If you blink at the wrong time, it might be hours before another message appears.
        /// 
        /// You can see these points of light floating in the distance, and record their position in the sky and their velocity, 
        /// the relative change in position per second (your puzzle input). The coordinates are all given from your perspective; 
        /// given enough time, those positions and velocities will move the points into a cohesive message!
        /// 
        /// Rather than wait, you decide to fast-forward the process and calculate what the points will eventually spell.
        /// 
        /// For example, suppose you note the following points:
        /// 
        /// position=< 9,  1> velocity=< 0,  2>
        /// position=< 7,  0> velocity=<-1,  0>
        /// position=< 3, -2> velocity=<-1,  1>
        /// position=< 6, 10> velocity=<-2, -1>
        /// position=< 2, -4> velocity=< 2,  2>
        /// position=<-6, 10> velocity=< 2, -2>
        /// position=< 1,  8> velocity=< 1, -1>
        /// position=< 1,  7> velocity=< 1,  0>
        /// position=<-3, 11> velocity=< 1, -2>
        /// position=< 7,  6> velocity=<-1, -1>
        /// position=<-2,  3> velocity=< 1,  0>
        /// position=<-4,  3> velocity=< 2,  0>
        /// position=<10, -3> velocity=<-1,  1>
        /// position=< 5, 11> velocity=< 1, -2>
        /// position=< 4,  7> velocity=< 0, -1>
        /// position=< 8, -2> velocity=< 0,  1>
        /// position=<15,  0> velocity=<-2,  0>
        /// position=< 1,  6> velocity=< 1,  0>
        /// position=< 8,  9> velocity=< 0, -1>
        /// position=< 3,  3> velocity=<-1,  1>
        /// position=< 0,  5> velocity=< 0, -1>
        /// position=<-2,  2> velocity=< 2,  0>
        /// position=< 5, -2> velocity=< 1,  2>
        /// position=< 1,  4> velocity=< 2,  1>
        /// position=<-2,  7> velocity=< 2, -2>
        /// position=< 3,  6> velocity=<-1, -1>
        /// position=< 5,  0> velocity=< 1,  0>
        /// position=<-6,  0> velocity=< 2,  0>
        /// position=< 5,  9> velocity=< 1, -2>
        /// position=<14,  7> velocity=<-2,  0>
        /// position=<-3,  6> velocity=< 2, -1>
        /// Each line represents one point.Positions are given as <X, Y> pairs: X represents how far left(negative) or right(positive) the point appears,
        /// while Y represents how far up(negative) or down(positive) the point appears.
        /// 
        /// At 0 seconds, each point has the position given.Each second, each point's velocity is added to its position. 
        /// So, a point with velocity <1, -2> is moving to the right, but is moving upward twice as quickly. 
        /// If this point's initial position were <3, 9>, after 3 seconds, its position would become <6, 3>.
        /// 
        /// Over time, the points listed above would move like this:
        /// 
        /// Initially:
        /// ........#.............
        /// ................#.....
        /// .........#.#..#.......
        /// ......................
        /// #..........#.#.......#
        /// ...............#......
        /// ....#.................
        /// ..#.#....#............
        /// .......#..............
        /// ......#...............
        /// ...#...#.#...#........
        /// ....#..#..#.........#.
        /// .......#..............
        /// ...........#..#.......
        /// #...........#.........
        /// ...#.......#..........
        /// 
        /// After 1 second:
        /// ......................
        /// ......................
        /// ..........#....#......
        /// ........#.....#.......
        /// ..#.........#......#..
        /// ......................
        /// ......#...............
        /// ....##.........#......
        /// ......#.#.............
        /// .....##.##..#.........
        /// ........#.#...........
        /// ........#...#.....#...
        /// ..#...........#.......
        /// ....#.....#.#.........
        /// ......................
        /// ......................
        /// 
        /// After 2 seconds:
        /// ......................
        /// ......................
        /// ......................
        /// ..............#.......
        /// ....#..#...####..#....
        /// ......................
        /// ........#....#........
        /// ......#.#.............
        /// .......#...#..........
        /// .......#..#..#.#......
        /// ....#....#.#..........
        /// .....#...#...##.#.....
        /// ........#.............
        /// ......................
        /// ......................
        /// ......................
        /// 
        /// After 3 seconds:
        /// ......................
        /// ......................
        /// ......................
        /// ......................
        /// ......#...#..###......
        /// ......#...#...#.......
        /// ......#...#...#.......
        /// ......#####...#.......
        /// ......#...#...#.......
        /// ......#...#...#.......
        /// ......#...#...#.......
        /// ......#...#..###......
        /// ......................
        /// ......................
        /// ......................
        /// ......................
        /// 
        /// After 4 seconds:
        /// ......................
        /// ......................
        /// ......................
        /// ............#.........
        /// ........##...#.#......
        /// ......#.....#..#......
        /// .....#..##.##.#.......
        /// .......##.#....#......
        /// ...........#....#.....
        /// ..............#.......
        /// ....#......#...#......
        /// .....#.....##.........
        /// ...............#......
        /// ...............#......
        /// ......................
        /// ......................
        /// After 3 seconds, the message appeared briefly: HI.Of course, your message will be much longer and will take many more seconds to appear.
        /// 
        /// What message will eventually appear in the sky?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            (int x, int y, int dx, int dy)[] data = input
                .Select(l => (
                    x: int.Parse(l.Substring(10, 6)),
                    y: int.Parse(l.Substring(18, 6)),
                    dx: int.Parse(l.Substring(36, 2)),
                    dy: int.Parse(l.Substring(40, 2))
                ))
                .ToArray();

            (int x, int y) box = (x: 100, y: 30);
            IEnumerable<(int seconds, IEnumerable<(int x, int y)> points)> candidates = from seconds in Enumerable.Range(0, 11000)
                                                                                        let points = from datum in data
                                                                                                     let x = datum.x + seconds * datum.dx
                                                                                                     let y = datum.y + seconds * datum.dy
                                                                                                     select (x, y)
                                                                                        let minX = points.Min(x => x.x)
                                                                                        let maxX = points.Max(x => x.x)
                                                                                        let minY = points.Min(x => x.y)
                                                                                        let maxY = points.Max(x => x.y)
                                                                                        where maxX - minX <= box.x
                                                                                        where maxY - minY <= box.y
                                                                                        let normalized = from cc in points
                                                                                                         let x = cc.x - minX
                                                                                                         let y = cc.y - minY
                                                                                                         select (x, y)
                                                                                        select (seconds, points: normalized);

            //foreach ((int seconds, IEnumerable<(int x, int y)> points) in candidates)
            //{
            //    Console.WriteLine($"Elapsed: {seconds} seconds");

            //    for (int y = 0; y < box.y; y++)
            //    {
            //        for (int x = 0; x < box.x; x++)
            //        {
            //            Console.Write(points.Contains((x, y)) ? "#" : ".");
            //        }
            //        Console.WriteLine();
            //    }
            //}

            return "BLGNHPJC";
        }

        /// <summary>
        /// Good thing you didn't have to wait, because that would have taken a long time - much longer than the 3 seconds in the example above.
        /// Impressed by your sub-hour communication capabilities, the Elves are curious: exactly how many seconds would they have needed to wait for that message to appear?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            (int x, int y, int dx, int dy)[] data = input
                 .Select(l => (
                     x: int.Parse(l.Substring(10, 6)),
                     y: int.Parse(l.Substring(18, 6)),
                     dx: int.Parse(l.Substring(36, 2)),
                     dy: int.Parse(l.Substring(40, 2))
                 ))
                 .ToArray();

            (int x, int y) box = (x: 100, y: 30);
            IEnumerable<(int seconds, IEnumerable<(int x, int y)> points)> candidates = from seconds in Enumerable.Range(0, 11000)
                                                                                        let points = from datum in data
                                                                                                     let x = datum.x + seconds * datum.dx
                                                                                                     let y = datum.y + seconds * datum.dy
                                                                                                     select (x, y)
                                                                                        let minX = points.Min(x => x.x)
                                                                                        let maxX = points.Max(x => x.x)
                                                                                        let minY = points.Min(x => x.y)
                                                                                        let maxY = points.Max(x => x.y)
                                                                                        where maxX - minX <= box.x
                                                                                        where maxY - minY <= box.y
                                                                                        let normalized = from cc in points
                                                                                                         let x = cc.x - minX
                                                                                                         let y = cc.y - minY
                                                                                                         select (x, y)
                                                                                        select (seconds, points: normalized);

            //foreach ((int seconds, IEnumerable<(int x, int y)> points) in candidates)
            //{
            //    Console.WriteLine($"Elapsed: {seconds} seconds");

            //    for (int y = 0; y < box.y; y++)
            //    {
            //        for (int x = 0; x < box.x; x++)
            //        {
            //            Console.Write(points.Contains((x, y)) ? "#" : ".");
            //        }
            //        Console.WriteLine();
            //    }
            //}

            return 10476;
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _10_TheStarsAlign(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_10_TheStarsAlign));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}