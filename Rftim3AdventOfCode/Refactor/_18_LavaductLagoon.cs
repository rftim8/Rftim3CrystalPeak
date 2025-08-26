using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _18_LavaductLagoon : I_18_LavaductLagoon
    {
        #region Static
        private readonly List<string>? data;

        public _18_LavaductLagoon()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_18_LavaductLagoon));
        }

        /// <summary>
        /// Thanks to your efforts, the machine parts factory is one of the first factories up and running since the lavafall came back. 
        /// However, to catch up with the large backlog of parts requests, the factory will also need a large supply of lava for a while;
        /// the Elves have already started creating a large lagoon nearby for this purpose.
        /// 
        /// However, they aren't sure the lagoon will be big enough; they've asked you to take a look at the dig plan(your puzzle input).
        /// For example:
        /// 
        /// R 6 (#70c710)
        /// D 5 (#0dc571)
        /// L 2 (#5713f0)
        /// D 2 (#d2c081)
        /// R 2 (#59c680)
        /// D 2 (#411b91)
        /// L 5 (#8ceee2)
        /// U 2 (#caa173)
        /// L 1 (#1b58a2)
        /// U 2 (#caa171)
        /// R 2 (#7807d2)
        /// U 3 (#a77fa3)
        /// L 2 (#015232)
        /// U 2 (#7a21e3)
        /// The digger starts in a 1 meter cube hole in the ground.They then dig the specified number of meters up (U), down (D),
        /// left (L), or right (R), clearing full 1 meter cubes as they go. The directions are given as seen from above, so if "up" were north,
        /// then "right" would be east, and so on.Each trench is also listed with the color that the edge of the trench should be painted 
        /// as an RGB hexadecimal color code.
        /// When viewed from above, the above example dig plan would result in the following loop of trench (#) having been dug out
        /// from otherwise ground-level terrain (.):
        /// 
        /// #######
        /// #.....#
        /// ###...#
        /// ..#...#
        /// ..#...#
        /// ###.###
        /// #...#..
        /// ##..###
        /// .#....#
        /// .######
        /// At this point, the trench could contain 38 cubic meters of lava. However, this is just the edge of the lagoon; 
        /// the next step is to dig out the interior so that it is one meter deep as well:
        /// 
        /// #######
        /// #######
        /// #######
        /// ..#####
        /// ..#####
        /// #######
        /// #####..
        /// #######
        /// .######
        /// .######
        /// Now, the lagoon can contain a much more respectable 62 cubic meters of lava.While the interior is dug out, 
        /// the edges are also painted according to the color codes in the dig plan.
        /// The Elves are concerned the lagoon won't be large enough; if they follow their dig plan, 
        /// how many cubic meters of lava could it hold?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            (List<(long, long)> points, long totalEdgeLength) = GetPoints(input.Select(i =>
            {
                string instruction = i.Split(' ')[2][2..^1];

                return (i[0], long.Parse(i.Split(' ')[1]));
            }));

            return CalculateArea(points, totalEdgeLength);
        }

        /// <summary>
        /// The Elves were right to be concerned; the planned lagoon would be much too small.
        /// 
        /// After a few minutes, someone realizes what happened; someone swapped the color and instruction parameters when producing the dig plan.
        /// They don't have time to fix the bug; one of them asks if you can extract the correct instructions from the hexadecimal codes.
        /// 
        /// Each hexadecimal code is six hexadecimal digits long. The first five hexadecimal digits encode the distance in meters as a 
        /// five-digit hexadecimal number.The last hexadecimal digit encodes the direction to dig: 0 means R, 1 means D, 2 means L, and 3 means U.
        /// 
        /// So, in the above example, the hexadecimal codes can be converted into the true instructions:
        /// 
        /// #70c710 = R 461937
        /// #0dc571 = D 56407
        /// #5713f0 = R 356671
        /// # d2c081 = D 863240
        /// #59c680 = R 367720
        /// #411b91 = D 266681
        /// #8ceee2 = L 577262
        /// # caa173 = U 829975
        /// #1b58a2 = L 112010
        /// # caa171 = D 829975
        /// #7807d2 = L 491645
        /// # a77fa3 = U 686074
        /// #015232 = L 5411
        /// #7a21e3 = U 500254
        /// Digging out this loop and its interior produces a lagoon that can hold an impressive 952408144115 cubic meters of lava.
        /// 
        /// Convert the hexadecimal color codes into the correct instructions; if the Elves follow this new dig plan, 
        /// how many cubic meters of lava could the lagoon hold?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            (List<(long, long)> points, long totalEdgeLength) = GetPoints(input.Select(i =>
            {
                string instruction = i.Split(' ')[2][2..^1];

                return (instruction[^1], Convert.ToInt64(instruction[..^1], 16));
            }));

            return CalculateArea(points, totalEdgeLength);
        }

        private static (List<(long, long)> Points, long TotalEdgeLength) GetPoints(IEnumerable<(char, long)> instructions)
        {
            List<(long, long)> points = [];
            long currentX = 0;
            long currentY = 0;
            long totalEdgeLength = 0;

            foreach ((char direction, long distance) in instructions)
            {
                totalEdgeLength += distance;
                switch (direction)
                {
                    case 'R':
                    case '0':
                        currentX += distance;
                        break;
                    case 'D':
                    case '1':
                        currentY += distance;
                        break;
                    case 'L':
                    case '2':
                        currentX -= distance;
                        break;
                    case 'U':
                    case '3':
                        currentY -= distance;
                        break;
                    default:
                        throw new Exception($"Unexpected direction found in instruction: {direction} - {distance}");
                }
                points.Add((currentX, currentY));
            }

            return (points, totalEdgeLength);
        }

        private static long CalculateArea(List<(long, long)> points, long totalEdgeLength)
        {
            long area = 0;
            for (int i = 0; i < points.Count - 1; ++i)
            {
                area += (points[i].Item2 + points[i + 1].Item2) * (points[i].Item1 - points[i + 1].Item1);
            }
            area += (points[^1].Item2 + points[0].Item2) * (points[^1].Item1 - points[0].Item1);
            area += totalEdgeLength;
            area >>= 1;

            return ++area;
        }
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _18_LavaductLagoon(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_18_LavaductLagoon));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}