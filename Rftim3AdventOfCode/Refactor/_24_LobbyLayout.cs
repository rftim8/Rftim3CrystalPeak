using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _24_LobbyLayout : I_24_LobbyLayout
    {
        #region Static
        private readonly List<string>? data;

        public _24_LobbyLayout()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_24_LobbyLayout));
        }

        /// <summary>
        /// Your raft makes it to the tropical island; it turns out that the small crab was an excellent navigator. You make your way to the resort.
        /// 
        /// As you enter the lobby, you discover a small problem: the floor is being renovated.You can't even reach the check-in desk 
        /// until they've finished installing the new tile floor.
        /// The tiles are all hexagonal; they need to be arranged in a hex grid with a very specific color pattern.Not in the mood to wait,
        /// you offer to help figure out the pattern.
        /// The tiles are all white on one side and black on the other. They start with the white side facing up. 
        /// The lobby is large enough to fit whatever pattern might need to appear there.
        /// A member of the renovation crew gives you a list of the tiles that need to be flipped over (your puzzle input). 
        /// Each line in the list identifies a single tile that needs to be flipped by giving a series of steps starting from a reference tile in the very center of the room.
        /// (Every line starts from the same reference tile.)
        /// 
        /// Because the tiles are hexagonal, every tile has six neighbors: east, southeast, southwest, west, northwest, and northeast.
        /// These directions are given in your list, respectively, as e, se, sw, w, nw, and ne. A tile is identified by a series of these directions with no delimiters; 
        /// for example, esenee identifies the tile you land on if you start at the reference tile and then move one tile east, one tile southeast, one tile northeast, 
        /// and one tile east.
        /// Each time a tile is identified, it flips from white to black or from black to white.Tiles might be flipped more than once.
        /// For example, a line like esew flips a tile immediately adjacent to the reference tile, and a line like nwwswee flips the reference tile itself.
        /// Here is a larger example:
        /// 
        /// sesenwnenenewseeswwswswwnenewsewsw
        /// neeenesenwnwwswnenewnwwsewnenwseswesw
        /// seswneswswsenwwnwse
        /// nwnwneseeswswnenewneswwnewseswneseene
        /// swweswneswnenwsewnwneneseenw
        /// eesenwseswswnenwswnwnwsewwnwsene
        /// sewnenenenesenwsewnenwwwse
        /// wenwwweseeeweswwwnwwe
        /// wsweesenenewnwwnwsenewsenwwsesesenwne
        /// neeswseenwwswnwswswnw
        /// nenwswwsewswnenenewsenwsenwnesesenew
        /// enewnwewneswsewnwswenweswnenwsenwsw
        /// sweneswneswneneenwnewenewwneswswnese
        /// swwesenesewenwneswnwwneseswwne
        /// enesenwswwswneneswsenwnewswseenwsese
        /// wnwnesenesenenwwnenwsewesewsesesew
        /// nenewswnwewswnenesenwnesewesw
        /// eneswnwswnwsenenwnwnwwseeswneewsenese
        /// neswnwewnwnwseenwseesewsenwsweewe
        /// wseweeenwnesenwwwswnew
        /// In the above example, 10 tiles are flipped once(to black), and 5 more are flipped twice(to black, then back to white).
        /// After all of these instructions have been followed, a total of 10 tiles are black.
        /// 
        /// Go through the renovation crew's list and determine which tiles they need to flip. 
        /// After all of the instructions have been followed, how many tiles are left with the black side up?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Dictionary<(int x, int y), int> floor = [];
            (int minX, int minY, int maxX, int maxY) = (0, 0, 0, 0);

            foreach (string path in input)
            {
                (int x, int y) pos = (0, 0);
                pos = (0, 0);
                for (int p = 0; p < path.Length; p++)
                {
                    Dictionary<string, (int, int)> directions = new() { { "nw", (-1, 1) }, { "ne", (1, 1) }, { "w", (-2, 0) }, { "e", (2, 0) }, { "sw", (-1, -1) }, { "se", (1, -1) } };
                    (int dx, int dy) = "ns".Contains(path[p]) ? directions[path[p..(p++ + 2)]] : directions[path[p].ToString()];
                    pos = (pos.x + dx, pos.y + dy);
                }
                floor[pos] = floor.TryGetValue(pos, out int curValue) ? Math.Abs(curValue - 1) : 1;
            }

            return floor.Values.Sum();
        }

        /// <summary>
        /// The tile floor in the lobby is meant to be a living art exhibit. Every day, the tiles are all flipped according to the following rules:
        /// 
        /// Any black tile with zero or more than 2 black tiles immediately adjacent to it is flipped to white.
        /// Any white tile with exactly 2 black tiles immediately adjacent to it is flipped to black.
        /// Here, tiles immediately adjacent means the six tiles directly touching the tile in question.
        /// 
        /// The rules are applied simultaneously to every tile; put another way, it is first determined which tiles need to be flipped, then they are all flipped at the same time.
        /// 
        /// In the above example, the number of black tiles that are facing up after the given number of days has passed is as follows:
        /// 
        /// Day 1: 15
        /// Day 2: 12
        /// Day 3: 25
        /// Day 4: 14
        /// Day 5: 23
        /// Day 6: 28
        /// Day 7: 41
        /// Day 8: 37
        /// Day 9: 49
        /// Day 10: 37
        /// 
        /// Day 20: 132
        /// Day 30: 259
        /// Day 40: 406
        /// Day 50: 566
        /// Day 60: 788
        /// Day 70: 1106
        /// Day 80: 1373
        /// Day 90: 1844
        /// Day 100: 2208
        /// After executing this process a total of 100 times, there would be 2208 black tiles facing up.
        /// 
        /// How many tiles will be black after 100 days?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            (int x, int y) pos = (0, 0);
            Dictionary<(int x, int y), int> floor = [];
            (int minX, int minY, int maxX, int maxY) = (0, 0, 0, 0);
            Dictionary<string, (int, int)> directions = new() { { "nw", (-1, 1) }, { "ne", (1, 1) }, { "w", (-2, 0) }, { "e", (2, 0) }, { "sw", (-1, -1) }, { "se", (1, -1) } };

            foreach (string path in input)
            {
                pos = (0, 0);
                for (int p = 0; p < path.Length; p++)
                {
                    (int dx, int dy) = "ns".Contains(path[p]) ? directions[path[p..(p++ + 2)]] : directions[path[p].ToString()];
                    pos = (pos.x + dx, pos.y + dy);
                }
                floor[pos] = floor.TryGetValue(pos, out int curValue) ? Math.Abs(curValue - 1) : 1;
            }

            for (int day = 1; day <= 100; day++)
            {
                minX = floor.Keys.Select(k => k.x).Min(); maxX = floor.Keys.Select(k => k.x).Max();
                minY = floor.Keys.Select(k => k.y).Min(); maxY = floor.Keys.Select(k => k.y).Max();
                Dictionary<(int, int), int> newFloor = new(floor);
                for (int x = minX - 1; x <= maxX + 1; x++)
                {
                    for (int y = minY - 1; y <= maxY + 1; y++)
                    {
                        int neighbours = 0;
                        if ((x + y) % 2 != 0) continue;
                        if (!floor.ContainsKey((x, y))) floor[(x, y)] = 0;
                        foreach ((int dx, int dy) in directions.Values)
                        {
                            if (floor.ContainsKey((x + dx, y + dy))) neighbours += floor[(x + dx, y + dy)];
                        }

                        if (floor[(x, y)] == 1 && (neighbours == 0 || neighbours > 2)) newFloor[(x, y)] = 0;
                        if (floor[(x, y)] == 0 && neighbours == 2) newFloor[(x, y)] = 1;
                    }
                }

                floor = new Dictionary<(int, int), int>(newFloor);
            }

            return floor.Values.Sum();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _24_LobbyLayout(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_24_LobbyLayout));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}