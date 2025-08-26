using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _22_ModeMaze : I_22_ModeMaze
    {
        #region Static
        private readonly List<string>? data;

        public _22_ModeMaze()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_22_ModeMaze));
        }

        /// <summary>
        /// This is it, your final stop: the year -483. It's snowing and dark outside; the only light you can see is coming from a small cottage in the distance.
        /// You make your way there and knock on the door.
        /// 
        /// A portly man with a large, white beard answers the door and invites you inside.
        /// For someone living near the North Pole in -483, he must not get many visitors, but he doesn't act surprised to see you.
        /// Instead, he offers you some milk and cookies.
        /// 
        /// After talking for a while, he asks a favor of you. His friend hasn't come back in a few hours, and he's not sure where he is. 
        /// Scanning the region briefly, you discover one life signal in a cave system nearby; his friend must have taken shelter there.
        /// The man asks if you can go there to retrieve his friend.
        /// 
        /// The cave is divided into square regions which are either dominantly rocky, narrow, or wet (called its type). 
        /// Each region occupies exactly one coordinate in X,Y format where X and Y are integers and zero or greater. (Adjacent regions can be the same type.)
        /// 
        /// The scan(your puzzle input) is not very detailed: it only reveals the depth of the cave system and the coordinates of the target.
        /// However, it does not reveal the type of each region.The mouth of the cave is at 0,0.
        /// 
        /// The man explains that due to the unusual geology in the area, there is a method to determine any region's type based on its erosion level.
        /// The erosion level of a region can be determined from its geologic index. The geologic index can be determined using the first rule that applies from the list below:
        /// 
        /// The region at 0,0 (the mouth of the cave) has a geologic index of 0.
        /// The region at the coordinates of the target has a geologic index of 0.
        /// If the region's Y coordinate is 0, the geologic index is its X coordinate times 16807.
        /// If the region's X coordinate is 0, the geologic index is its Y coordinate times 48271.
        /// Otherwise, the region's geologic index is the result of multiplying the erosion levels of the regions at X-1,Y and X,Y-1.
        /// A region's erosion level is its geologic index plus the cave system's depth, all modulo 20183. Then:
        /// 
        /// If the erosion level modulo 3 is 0, the region's type is rocky.
        /// If the erosion level modulo 3 is 1, the region's type is wet.
        /// If the erosion level modulo 3 is 2, the region's type is narrow.
        /// For example, suppose the cave system's depth is 510 and the target's coordinates are 10,10. Using % to represent the modulo operator, the cavern would look as follows:
        /// 
        /// At 0,0, the geologic index is 0. The erosion level is (0 + 510) % 20183 = 510. The type is 510 % 3 = 0, rocky.
        /// At 1,0, because the Y coordinate is 0, the geologic index is 1 * 16807 = 16807. The erosion level is (16807 + 510) % 20183 = 17317. The type is 17317 % 3 = 1, wet.
        /// At 0,1, because the X coordinate is 0, the geologic index is 1 * 48271 = 48271. The erosion level is (48271 + 510) % 20183 = 8415. The type is 8415 % 3 = 0, rocky.
        /// At 1,1, neither coordinate is 0 and it is not the coordinate of the target, so the geologic index is the erosion level of 0,1 (8415) 
        /// times the erosion level of 1,0 (17317), 8415 * 17317 = 145722555. The erosion level is (145722555 + 510) % 20183 = 1805. The type is 1805 % 3 = 2, narrow.
        /// At 10,10, because they are the target's coordinates, the geologic index is 0. The erosion level is (0 + 510) % 20183 = 510. The type is 510 % 3 = 0, rocky.
        /// Drawing this same cave system with rocky as ., wet as =, narrow as |, the mouth as M, the target as T, with 0,0 in the top-left corner, 
        /// X increasing to the right, and Y increasing downward, the top-left corner of the map looks like this:
        /// 
        /// M=.|=.|.|=.|=|=.
        /// .|=|=||| .. |.= ...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// Before you go in, you should determine the risk level of the area.For the rectangle that has a top-left corner of region 0,0 
        /// and a bottom-right corner of the region containing the target, add up the risk level of each individual region: 0 for rocky regions,
        /// 1 for wet regions, and 2 for narrow regions.
        /// 
        /// In the cave system above, because the mouth is at 0,0 and the target is at 10,10, adding up the risk level of all regions with an 
        /// X coordinate from 0 to 10 and a Y coordinate from 0 to 10, this total is 114.
        /// 
        /// What is the total risk level for the smallest rectangle that includes 0,0 and the target's coordinates?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int risk = 0;
            for (int y = 0; y <= s_target.y; y++)
            {
                for (int x = 0; x <= s_target.x; x++)
                {
                    switch (GetRegionType(x, y))
                    {
                        case 'W': risk++; break;
                        case 'N': risk += 2; break;
                    }
                }
            }

            return risk;
        }

        /// <summary>
        /// Okay, it's time to go rescue the man's friend.
        /// 
        /// As you leave, he hands you some tools: a torch and some climbing gear.You can't equip both tools at once, but you can choose to use neither.
        /// 
        /// Tools can only be used in certain regions:
        /// 
        /// In rocky regions, you can use the climbing gear or the torch.You cannot use neither (you'll likely slip and fall).
        /// In wet regions, you can use the climbing gear or neither tool.You cannot use the torch (if it gets wet, you won't have a light source).
        /// In narrow regions, you can use the torch or neither tool. You cannot use the climbing gear (it's too bulky to fit).
        /// You start at 0,0 (the mouth of the cave) with the torch equipped and must reach the target coordinates as quickly as possible.
        /// The regions with negative X or Y are solid rock and cannot be traversed.The fastest route might involve entering regions beyond the X or Y coordinate of the target.
        /// 
        /// You can move to an adjacent region (up, down, left, or right; never diagonally) if your currently equipped tool allows you to enter that region.
        /// Moving to an adjacent region takes one minute. 
        /// (For example, if you have the torch equipped, you can move between rocky and narrow regions, but cannot enter wet regions.)
        /// 
        /// You can change your currently equipped tool or put both away if your new equipment would be valid for your current region.
        /// Switching to using the climbing gear, torch, or neither always takes seven minutes, regardless of which tools you start with. 
        /// (For example, if you are in a rocky region, you can switch from the torch to the climbing gear, but you cannot switch to neither.)
        /// 
        /// Finally, once you reach the target, you need the torch equipped before you can find him in the dark.
        /// The target is always in a rocky region, so if you arrive there with climbing gear equipped, you will need to spend seven minutes switching to your torch.
        /// 
        /// For example, using the same cave system as above, starting in the top left corner(0,0) and moving to the bottom right corner(the target, 10,10) as quickly as possible,
        /// one possible route is as follows, with your current position marked X:
        /// 
        /// Initially:
        /// X=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Down:
        /// M=.|=.|.|=.|=|=.
        /// X|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Right:
        /// M=.|=.|.|=.|=|=.
        /// .X=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Switch from using the torch to neither tool:
        /// M=.|=.|.|=.|=|=.
        /// .X=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Right 3:
        /// M=.|=.|.|=.|=|=.
        /// .|=|X|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Switch from using neither tool to the climbing gear:
        /// M=.|=.|.|=.|=|=.
        /// .|=|X|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Down 7:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..X==..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Right:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..=X=..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Down 3:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||.X.|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Right:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||..X|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Down:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.X..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Right 4:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===T===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=X||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Up 2:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===X===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// 
        /// Switch from using the climbing gear to the torch:
        /// M=.|=.|.|=.|=|=.
        /// .|=|=|||..|.=...
        /// .==|....||=..|==
        /// =.|....|.==.|==.
        /// =|..==...=.|==..
        /// =||.=.=||=|=..|=
        /// |.=.===|||..=..|
        /// |..==||=.|==|===
        /// .=..===..=|.|||.
        /// .======|||=|=.|=
        /// .===|=|===X===||
        /// =|||...|==..|=.|
        /// =.=|=.=..=.||==|
        /// ||=|=...|==.=|==
        /// |=.=||===.|||===
        /// ||.|==.|.|.||=||
        /// This is tied with other routes as the fastest way to reach the target: 45 minutes.
        /// In it, 21 minutes are spent switching tools(three times, seven minutes each) and the remaining 24 minutes are spent moving.
        /// What is the fewest number of minutes you can take to reach the target?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            return BfsSolve();
        }

        private static readonly int s_depth = 5913;
        private static readonly (int x, int y) s_target = (8, 701);

        private static int BfsSolve()
        {
            int r = 0;
            (int x, int y)[] neis = [(-1, 0), (0, 1), (1, 0), (0, -1)];

            Queue<(int x, int y, char tool, int switching, int minutes)> queue = new();
            HashSet<(int x, int y, char tool)> seen = [];
            queue.Enqueue((0, 0, 'T', 0, 0));
            seen.Add((0, 0, 'T'));
            while (queue.Count > 0)
            {
                (int x, int y, char tool, int switching, int minutes) = queue.Dequeue();
                if (switching > 0)
                {
                    if (switching != 1 || seen.Add((x, y, tool))) queue.Enqueue((x, y, tool, switching - 1, minutes + 1));
                    continue;
                }

                if ((x, y) == s_target && tool == 'T')
                {
                    r = minutes;
                    break;
                }

                foreach ((int xo, int yo) in neis)
                {
                    (int nx, int ny) = (x + xo, y + yo);
                    if (nx < 0 || ny < 0) continue;

                    if (GetAllowedTools(GetRegionType(nx, ny)).Contains(tool) && seen.Add((nx, ny, tool))) queue.Enqueue((nx, ny, tool, 0, minutes + 1));
                }

                foreach (char otherTool in GetAllowedTools(GetRegionType(x, y)))
                {
                    queue.Enqueue((x, y, otherTool, 6, minutes + 1));
                }
            }

            return r;
        }

        private static readonly Dictionary<(int x, int y), int> s_erosionLevels = [];

        private static int ErosionLevel(int x, int y)
        {
            if (s_erosionLevels.TryGetValue((x, y), out int val)) return val;

            if ((x, y) == (0, 0)) val = 0;
            else if ((x, y) == s_target) val = 0;
            else if (y == 0) val = x * 16807;
            else if (x == 0) val = y * 48271;
            else val = ErosionLevel(x - 1, y) * ErosionLevel(x, y - 1);

            val += s_depth;
            val %= 20183;
            s_erosionLevels.Add((x, y), val);

            return val;
        }

        private static char GetRegionType(int x, int y)
        {
            int erosionLevel = ErosionLevel(x, y);

            return "RWN"[erosionLevel % 3];
        }

        private static string GetAllowedTools(char region)
        {
            return region switch
            {
                'R' => "CT",
                'W' => "CN",
                'N' => "TN",
                _ => throw new Exception("Unreachable"),
            };
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _22_ModeMaze(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_22_ModeMaze));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}