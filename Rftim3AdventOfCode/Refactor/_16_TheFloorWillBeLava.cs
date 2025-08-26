using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _16_TheFloorWillBeLava : I_16_TheFloorWillBeLava
    {
        #region Static
        private readonly List<string>? data;

        public _16_TheFloorWillBeLava()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_16_TheFloorWillBeLava));
        }

        /// <summary>
        /// With the beam of light completely focused somewhere, the reindeer leads you deeper still into the Lava Production Facility.
        /// At some point, you realize that the steel facility walls have been replaced with cave, and the doorways are just cave,
        /// and the floor is cave, and you're pretty sure this is actually just a giant cave.
        /// 
        /// Finally, as you approach what must be the heart of the mountain, you see a bright light in a cavern up ahead.
        /// There, you discover that the beam of light you so carefully focused is emerging from the cavern wall closest to the facility
        /// and pouring all of its energy into a contraption on the opposite side.
        /// 
        /// 
        /// Upon closer inspection, the contraption appears to be a flat, two-dimensional square grid containing empty space (.),
        /// mirrors(/ and \), and splitters(| and -).
        /// 
        /// The contraption is aligned so that most of the beam bounces around the grid, but each tile on the grid converts some of the 
        /// beam's light into heat to melt the rock in the cavern.
        /// 
        /// You note the layout of the contraption(your puzzle input). For example:
        /// 
        /// .|...\....
        /// |.-.\.....
        /// .....|-...
        /// ........|.
        /// ..........
        /// .........\
        /// ..../.\\..
        /// .-.-/..|..
        /// .|....-|.\
        /// ..//.|....
        /// The beam enters in the top-left corner from the left and heading to the right.
        /// Then, its behavior depends on what it encounters as it moves:
        /// 
        /// If the beam encounters empty space (.), it continues in the same direction.
        /// If the beam encounters a mirror(/ or \), the beam is reflected 90 degrees depending on the angle of the mirror.
        /// For instance, a rightward-moving beam that encounters a / mirror would continue upward in the mirror's column,
        /// while a rightward-moving beam that encounters a \ mirror would continue downward from the mirror's column.
        /// If the beam encounters the pointy end of a splitter (| or -), the beam passes through the splitter as if the splitter
        /// were empty space.For instance, a rightward-moving beam that encounters a - splitter would continue in the same direction.
        /// If the beam encounters the flat side of a splitter(| or -), the beam is split into two beams going in each of the two 
        /// directions the splitter's pointy ends are pointing. For instance, a rightward-moving beam that encounters a | splitter 
        /// would split into two beams: one that continues upward from the splitter's column and one that continues downward from
        /// the splitter's column.
        /// Beams do not interact with other beams; a tile can have many beams passing through it at the same time.
        /// A tile is energized if that tile has at least one beam pass through it, reflect in it, or split in it.
        /// In the above example, here is how the beam of light bounces around the contraption:
        /// 
        /// >|<<<\....
        /// |v-.\^....
        /// .v...|->>>
        /// .v...v^.|.
        /// .v...v^...
        /// .v...v^..\
        /// .v../2\\..
        /// <->-/vv|..
        /// .|<<<2-|.\
        /// .v//.|.v..
        /// Beams are only shown on empty tiles; arrows indicate the direction of the beams.
        /// If a tile contains beams moving in multiple directions, the number of distinct directions is shown instead.
        /// Here is the same diagram but instead only showing whether a tile is energized (#) or not (.):
        /// 
        /// ######....
        /// .#...#....
        /// .#...#####
        /// .#...##...
        /// .#...##...
        /// .#...##...
        /// .#..####..
        /// ########..
        /// .#######..
        /// .#...#.#..
        /// Ultimately, in this example, 46 tiles become energized.
        /// 
        /// The light isn't energizing enough tiles to produce lava; to debug the contraption, 
        /// you need to start by analyzing the current situation. With the beam starting in the top-left heading right, 
        /// how many tiles end up being energized?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            PopulateMapFromInputWithBorders(input, 'X', out _, out _);
            int maxEnergised = ProcessBeam((-1, 0), (1, 0));

            return maxEnergised;
        }

        /// <summary>
        /// As you try to work out what might be wrong, the reindeer tugs on your shirt and leads you to a nearby control panel.
        /// There, a collection of buttons lets you align the contraption so that the beam enters from any edge tile and heading away
        /// from that edge. (You can choose either of two directions for the beam if it starts on a corner; 
        /// for instance, if the beam starts in the bottom-right corner, it can start heading either left or upward.)
        /// 
        /// So, the beam could start on any tile in the top row(heading downward), any tile in the bottom row(heading upward), 
        /// any tile in the leftmost column(heading right), or any tile in the rightmost column(heading left). 
        /// To produce lava, you need to find the configuration that energizes as many tiles as possible.
        /// In the above example, this can be achieved by starting the beam in the fourth tile from the left in the top row:
        /// 
        /// .|<2<\....
        /// |v-v\^....
        /// .v.v.|->>>
        /// .v.v.v^.|.
        /// .v.v.v^...
        /// .v.v.v^..\
        /// .v.v/2\\..
        /// <-2-/vv|..
        /// .|<<<2-|.\
        /// .v//.|.v..
        /// Using this configuration, 51 tiles are energized:
        /// 
        /// .#####....
        /// .#.#.#....
        /// .#.#.#####
        /// .#.#.##...
        /// .#.#.##...
        /// .#.#.##...
        /// .#.#####..
        /// ########..
        /// .#######..
        /// .#...#.#..
        /// Find the initial beam configuration that energizes the largest number of tiles;
        /// how many tiles are energized in that configuration?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            PopulateMapFromInputWithBorders(input, 'X', out int width, out int height);

            int maxEnergised = ProcessBeam((-1, 0), (1, 0));

            for (int x = 0; x < width; x++)
            {
                maxEnergised = Math.Max(ProcessBeam((x, -1), (0, 1)), maxEnergised);
                maxEnergised = Math.Max(ProcessBeam((x, height), (0, -1)), maxEnergised);
            }

            for (int y = 0; y < height; y++)
            {
                maxEnergised = Math.Max(ProcessBeam((-1, y), (1, 0)), maxEnergised);
                maxEnergised = Math.Max(ProcessBeam((width, y), (-1, 0)), maxEnergised);
            }

            return maxEnergised;
        }

        private static readonly Dictionary<(int x, int y), char> map = [];

        private static void PopulateMapFromInputWithBorders(List<string> input, char borderChar, out int width, out int height)
        {
            width = input[0].Length; height = input.Count;

            for (int y = -1; y <= height; y++)
            {
                for (int x = -1; x <= width; x++)
                {
                    if (x == -1 || y == -1 || x == width || y == height) map[(x, y)] = borderChar;
                    else map[(x, y)] = input[y][x];
                }
            }
        }

        private static int ProcessBeam((int, int) start, (int, int) direction)
        {
            HashSet<(int, int)> energizedCells = [];
            HashSet<((int, int), (int, int))> knownStates = [];
            List<Beam> beams = [new(start, direction)];

            do
            {
                for (int i = beams.Count - 1; i >= 0; i--)
                {
                    if (beams[i].Move(map, beams))
                    {
                        energizedCells.Add(beams[i].Location);

                        if (!knownStates.Add((beams[i].Location, beams[i].Direction))) beams.Remove(beams[i]);
                    }
                }
            } while (beams.Count > 0);

            return energizedCells.Count;
        }

        private class Beam((int, int) location, (int, int) direction)
        {
            public (int x, int y) Location { get; private set; } = location;

            public (int x, int y) Direction { get; private set; } = direction;

            public bool Move(Dictionary<(int x, int y), char> map, List<Beam> beams)
            {
                Location = (Location.x + Direction.x, Location.y + Direction.y);

                switch (map[Location])
                {
                    case '.': return true;
                    case '/':
                        Direction = (-Direction.y, -Direction.x);
                        return true;
                    case '\\':
                        Direction = (Direction.y == 0 ? 0 : Direction.y, Direction.x == 0 ? 0 : Direction.x);
                        return true;
                    case '-':
                        if (Direction.y == 0) return true;
                        Direction = (-Direction.y, -Direction.x);
                        beams.Add(new(Location, (-Direction.x, 0)));
                        return true;
                    case '|':
                        if (Direction.x == 0) return true;
                        Direction = (Direction.y == 0 ? Direction.y : 0, Direction.x == 0 ? 0 : Direction.x);
                        beams.Add(new(Location, (0, -Direction.y)));
                        return true;
                    default:
                        beams.Remove(this);
                        return false;
                }
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _16_TheFloorWillBeLava(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_16_TheFloorWillBeLava));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}