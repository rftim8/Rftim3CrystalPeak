using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _13_TransparentOrigami : I_13_TransparentOrigami
    {
        #region Static
        private readonly List<string>? data;

        public _13_TransparentOrigami()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_13_TransparentOrigami));
        }

        /// <summary>
        /// You reach another volcanically active part of the cave. It would be nice if you could do some kind of thermal imaging
        /// so you could tell ahead of time which caves are too hot to safely enter.
        /// 
        /// Fortunately, the submarine seems to be equipped with a thermal camera! When you activate it, you are greeted with:
        /// 
        /// Congratulations on your purchase! To activate this infrared thermal imaging
        /// camera system, please enter the code found on page 1 of the manual.
        /// Apparently, the Elves have never used this feature.To your surprise, you manage to find the manual; 
        /// as you go to open it, page 1 falls out. It's a large sheet of transparent paper! 
        /// The transparent paper is marked with random dots and includes instructions on how to fold it up (your puzzle input). For example:
        /// 
        /// 6,10
        /// 0,14
        /// 9,10
        /// 0,3
        /// 10,4
        /// 4,11
        /// 6,0
        /// 6,12
        /// 4,1
        /// 0,13
        /// 10,12
        /// 3,4
        /// 3,0
        /// 8,4
        /// 1,10
        /// 2,14
        /// 8,10
        /// 9,0
        /// 
        /// fold along y=7
        /// fold along x=5
        /// The first section is a list of dots on the transparent paper. 0,0 represents the top-left coordinate. 
        /// The first value, x, increases to the right. The second value, y, increases downward.
        /// So, the coordinate 3,0 is to the right of 0,0, and the coordinate 0,7 is below 0,0. 
        /// The coordinates in this example form the following pattern, where # is a dot on the paper and . is an empty, unmarked position:
        /// 
        /// ...#..#..#.
        /// ....#......
        /// ...........
        /// #..........
        /// ...#....#.#
        /// ...........
        /// ...........
        /// ...........
        /// ...........
        /// ...........
        /// .#....#.##.
        /// ....#......
        /// ......#...#
        /// #..........
        /// #.#........
        /// Then, there is a list of fold instructions. Each instruction indicates a line on the transparent paper and wants you 
        /// to fold the paper up (for horizontal y = ... lines) or left(for vertical x = ... lines). 
        /// In this example, the first fold instruction is fold along y= 7, which designates the line formed by all of the positions where y is 7 (marked here with -):
        /// 
        /// ...#..#..#.
        /// ....#......
        /// ...........
        /// #..........
        /// ...#....#.#
        /// ...........
        /// ...........
        /// -----------
        /// ...........
        /// ...........
        /// .#....#.##.
        /// ....#......
        /// ......#...#
        /// #..........
        /// #.#........
        /// Because this is a horizontal line, fold the bottom half up. Some of the dots might end up overlapping after the fold is complete, 
        /// but dots will never appear exactly on a fold line. The result of doing this fold looks like this:
        /// 
        /// #.##..#..#.
        /// #...#......
        /// ......#...#
        /// #...#......
        /// .#.#..#.###
        /// ...........
        /// ...........
        /// Now, only 17 dots are visible.
        /// 
        /// Notice, for example, the two dots in the bottom left corner before the transparent paper is folded; after the fold is complete,
        /// those dots appear in the top left corner (at 0,0 and 0,1). 
        /// Because the paper is transparent, the dot just below them in the result(at 0,3) remains visible, as it can be seen through the transparent paper.
        /// 
        /// Also notice that some dots can end up overlapping; in this case, the dots merge together and become a single dot.
        /// 
        /// The second fold instruction is fold along x=5, which indicates this line:
        /// 
        /// #.##.|#..#.
        /// #...#|.....
        /// .....|#...#
        /// #...#|.....
        /// .#.#.|#.###
        /// .....|.....
        /// .....|.....
        /// Because this is a vertical line, fold left:
        /// 
        /// #####
        /// #...#
        /// #...#
        /// #...#
        /// #####
        /// .....
        /// .....
        /// The instructions made a square!
        /// 
        /// The transparent paper is pretty big, so for now, focus on just completing the first fold.After the first fold in the example above,
        /// 17 dots are visible - dots that end up overlapping after the fold is completed count as a single dot.
        /// 
        /// How many dots are visible after completing just the first fold instruction on your transparent paper?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            HashSet<(int, int)> dots = input
                .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(','))
                .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])))
                .Aggregate(new HashSet<(int, int)>(), (set, dot) =>
                {
                    set.Add(dot);
                    return set;
                });

            IEnumerable<(Direction, int)> folds = input
                .Skip(dots.Count + 1)
                .Select(line => line.Split(' ').Last())
                .Select(line => (line[0] == 'x' ? Direction.X : Direction.Y, int.Parse(line[2..])));

            int part1 = ExecuteFold(dots, folds.First()).Count;

            return part1;
        }

        /// <summary>
        /// Finish folding the transparent paper according to the instructions. The manual says the code is always eight capital letters.
        /// 
        /// What code do you use to activate the infrared thermal imaging camera system?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            HashSet<(int, int)> dots = input
                 .TakeWhile(line => !string.IsNullOrWhiteSpace(line))
                 .Select(line => line.Split(','))
                 .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])))
                 .Aggregate(new HashSet<(int, int)>(), (set, dot) =>
                 {
                     set.Add(dot);
                     return set;
                 });

            IEnumerable<(Direction, int)> folds = input
                .Skip(dots.Count + 1)
                .Select(line => line.Split(' ').Last())
                .Select(line => (line[0] == 'x' ? Direction.X : Direction.Y, int.Parse(line[2..])));

            HashSet<(int, int)> finalCode = folds.Aggregate(dots, ExecuteFold);
            int maxX = finalCode.Select(pt => pt.Item1).Max();
            int maxY = finalCode.Select(pt => pt.Item2).Max();

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    Console.Write(finalCode.Contains((x, y)) ? '#' : ' ');
                }
                Console.WriteLine();
            }

            return "FAGURZHE";
        }

        enum Direction { X, Y }

        private static HashSet<(int, int)> ExecuteFold(HashSet<(int, int)> dots, (Direction, int) fold)
        {
            (Direction direction, int position) = fold;
            HashSet<(int, int)> newDots = [];
            foreach ((int x, int y) in dots)
            {
                int newX = direction == Direction.X && x > position ? position - (x - position) : x;
                int newY = direction == Direction.Y && y > position ? position - (y - position) : y;
                newDots.Add((newX, newY));
            }

            return newDots;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _13_TransparentOrigami(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_13_TransparentOrigami));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}