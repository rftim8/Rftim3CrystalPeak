using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using INT = System.Int64;
using Point = System.Tuple<int, int>;

namespace Rftim3AdventOfCode.Refactor
{
    public class _17_SetAndForget : I_17_SetAndForget
    {
        #region Static
        private readonly List<string>? data;

        public _17_SetAndForget()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_17_SetAndForget));
        }

        /// <summary>
        /// An early warning system detects an incoming solar flare and automatically activates the ship's electromagnetic shield. 
        /// Unfortunately, this has cut off the Wi-Fi for many small robots that, unaware of the impending danger,
        /// are now trapped on exterior scaffolding on the unsafe side of the shield. To rescue them, you'll have to act quickly!
        /// 
        /// The only tools at your disposal are some wired cameras and a small vacuum robot currently asleep at its charging station.
        /// The video quality is poor, but the vacuum robot has a needlessly bright LED that makes it easy to spot no matter where it is.
        /// 
        /// An Intcode program, the Aft Scaffolding Control and Information Interface(ASCII, your puzzle input), provides access to the cameras and the vacuum robot.
        /// Currently, because the vacuum robot is asleep, you can only access the cameras.
        /// 
        /// Running the ASCII program on your Intcode computer will provide the current view of the scaffolds.
        /// This is output, purely coincidentally, as ASCII code: 35 means #, 46 means ., 10 starts a new line of output below the current one, and so on. 
        /// (Within a line, characters are drawn left-to-right.)
        /// 
        /// In the camera output, # represents a scaffold and . represents open space. 
        /// The vacuum robot is visible as ^, v, <, or > depending on whether it is facing up, down, left, or right respectively.
        /// When drawn like this, the vacuum robot is always on a scaffold; if the vacuum robot ever walks off of a scaffold and begins tumbling through space uncontrollably, 
        /// it will instead be visible as X.
        /// 
        /// In general, the scaffold forms a path, but it sometimes loops back onto itself.For example, suppose you can see the following view from the cameras:
        /// 
        /// ..#..........
        /// ..#..........
        /// #######...###
        /// #.#...#...#.#
        /// #############
        /// ..#...#...#..
        /// ..#####...^..
        /// Here, the vacuum robot, ^ is facing up and sitting at one end of the scaffold near the bottom-right of the image.
        /// The scaffold continues up, loops across itself several times, and ends at the top-left of the image.
        /// 
        /// The first step is to calibrate the cameras by getting the alignment parameters of some well-defined points. 
        /// Locate all scaffold intersections; for each, its alignment parameter is the distance between its left edge and the left edge of the view 
        /// multiplied by the distance between its top edge and the top edge of the view.Here, the intersections from the above image are marked O:
        /// 
        /// ..#..........
        /// ..#..........
        /// ##O####...###
        /// #.#...#...#.#
        /// ##O###O###O##
        /// ..#...#...#..
        /// ..#####...^..
        /// For these intersections:
        /// 
        /// The top-left intersection is 2 units from the left of the image and 2 units from the top of the image, so its alignment parameter is 2 * 2 = 4.
        /// The bottom-left intersection is 2 units from the left and 4 units from the top, so its alignment parameter is 2 * 4 = 8.
        /// The bottom-middle intersection is 6 from the left and 4 from the top, so its alignment parameter is 24.
        /// The bottom-right intersection's alignment parameter is 40.
        /// To calibrate the cameras, you need the sum of the alignment parameters. In the above example, this is 76.
        /// 
        /// Run your ASCII program. What is the sum of the alignment parameters for the scaffold intersections?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            List<INT> input = [];
            foreach (string line in input0)
            {
                foreach (string token in line.Split(','))
                {
                    input.Add(INT.Parse(token));
                }
            }

            Droid d = new()
            {
                brain = new Intcode(input)
            };
            d.BuildMap();

            return d.AlignmentSum();
        }

        /// <summary>
        /// Now for the tricky part: notifying all the other robots about the solar flare. 
        /// The vacuum robot can do this automatically if it gets into range of a robot.
        /// However, you can't see the other robots on the camera, so you need to be thorough instead: you need to make the vacuum robot visit 
        /// every part of the scaffold at least once.
        /// 
        /// The vacuum robot normally wanders randomly, but there isn't time for that today.
        /// Instead, you can override its movement logic with new rules.
        /// 
        /// Force the vacuum robot to wake up by changing the value in your ASCII program at address 0 from 1 to 2. 
        /// When you do this, you will be automatically prompted for the new movement rules that the vacuum robot should use.
        /// The ASCII program will use input instructions to receive them, but they need to be provided as ASCII code; end each line of logic with a single newline, ASCII code 10.
        /// 
        /// First, you will be prompted for the main movement routine.The main routine may only call the movement functions: A, B, or C.
        /// Supply the movement functions to use as ASCII text, separating them with commas (,, ASCII code 44), and ending the list with a newline(ASCII code 10). 
        /// For example, to call A twice, then alternate between B and C three times, provide the string A, A, B, C, B, C, B, C and then a newline.
        /// Then, you will be prompted for each movement function.Movement functions may use L to turn left, R to turn right, or a number to move forward that many units.
        /// Movement functions may not call other movement functions. Again, separate the actions with commas and end the list with a newline. 
        /// For example, to move forward 10 units, turn left, move forward 8 units, turn right, and finally move forward 6 units, provide the string 10, L,8, R,6 and then a newline.
        /// 
        /// Finally, you will be asked whether you want to see a continuous video feed; provide either y or n and a newline.
        /// Enabling the continuous video feed can help you see what's going on, but it also requires a significant amount of processing power, 
        /// and may even cause your Intcode computer to overheat.
        /// 
        /// Due to the limited amount of memory in the vacuum robot, the ASCII definitions of the main routine and the movement functions may each contain at most 20 characters, 
        /// not counting the newline.
        /// 
        /// For example, consider the following camera feed:
        /// 
        /// #######...#####
        /// #.....#...#...#
        /// #.....#...#...#
        /// ......#...#...#
        /// ......#...###.#
        /// ......#.....#.#
        /// ^########...#.#
        /// ......#.#...#.#
        /// ......#########
        /// ........#...#..
        /// ....#########..
        /// ....#...#......
        /// ....#...#......
        /// ....#...#......
        /// ....#####......
        /// In order for the vacuum robot to visit every part of the scaffold at least once, one path it could take is:
        /// 
        /// R,8, R,8, R,4, R,4, R,8, L,6, L,2, R,4, R,4, R,8, R,8, R,8, L,6, L,2
        /// Without the memory limit, you could just supply this whole string to function A and have the main routine call A once.
        /// However, you'll need to split it into smaller parts.
        /// 
        /// One approach is:
        /// 
        /// Main routine: A, B, C, B, A, C
        /// (ASCII input: 65, 44, 66, 44, 67, 44, 66, 44, 65, 44, 67, 10)
        /// Function A:   R,8,R,8
        /// (ASCII input: 82, 44, 56, 44, 82, 44, 56, 10)
        /// Function B:   R,4,R,4,R,8
        /// (ASCII input: 82, 44, 52, 44, 82, 44, 52, 44, 82, 44, 56, 10)
        /// Function C:   L,6,L,2
        /// (ASCII input: 76, 44, 54, 44, 76, 44, 50, 10)
        /// Visually, this would break the desired path into the following parts:
        /// 
        /// A,        B,            C,        B,            A,        C
        ///         R,8, R,8, R,4, R,4, R,8, L,6, L,2, R,4, R,4, R,8, R,8, R,8, L,6, L,2
        /// 
        /// CCCCCCA...BBBBB
        ///         C.....A...B...B
        /// C.....A...B...B
        ///         ......A...B...B
        ///         ......A...CCC.B
        /// ......A.....C.B
        /// ^AAAAAAAA...C.B
        /// ......A.A...C.B
        /// ......AAAAAA#AB
        /// ........A...C..
        /// ....BBBB#BBBB..
        /// ....B...A......
        /// ....B...A......
        /// ....B...A......
        /// ....BBBBA......
        ///         Of course, the scaffolding outside your ship is much more complex.
        /// 
        /// As the vacuum robot finds other robots and notifies them of the impending solar flare, it also can't help but leave them squeaky clean, 
        /// collecting any space dust it finds. Once it finishes the programmed set of movements, assuming it hasn't drifted off into space,
        /// the cleaning robot will return to its docking station and report the amount of space dust it collected as a large, non-ASCII value in a single output instruction.
        /// 
        /// After visiting every part of the scaffold at least once, how much dust does the vacuum robot report it has collected?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input0)
        {
            List<INT> input = [];
            foreach (string line in input0)
            {
                foreach (string token in line.Split(','))
                {
                    input.Add(INT.Parse(token));
                }
            }

            Droid d = new()
            {
                brain = new Intcode(input)
            };
            d.BuildMap();

            d.brain = new Intcode(input);
            d.brain.Memset(0, 2);

            string path = d.FindPath();

            List<string>? pathParts = Compress(path);
            foreach (string part in pathParts!)
            {
                d.SendPath(part);
            }

            d.SendInput("n");
            d.brain.Run();

            return d.brain.output;
        }

        private static int Abs(int x) => x >= 0 ? x : -x;

        private static IEnumerable<string> Subroutines(string main)
        {
            int start = 0;
            while ("ABC,".IndexOf(main[start]) > -1)
            {
                start++;
            }

            for (int len = 1; len <= 20; len++)
            {
                int end = start + len;
                if (end <= main.Length && (end == main.Length || main[end] == ','))
                {
                    if ("ABC".IndexOf(main[end - 1]) > -1) break;
                    yield return main.Substring(start, len);
                }
            }
            yield break;
        }

        private static bool AcceptableMain(string main)
        {
            foreach (var _ in from char c in "RL01234546789"
                              where main.IndexOf(c) > -1
                              select new { }) return false;

            return true;
        }

        private static List<string>? Compress(string path)
        {
            foreach (string a in Subroutines(path))
            {
                string mainA = path.Replace(a, "A");
                foreach (string b in Subroutines(mainA))
                {
                    string mainB = mainA.Replace(b, "B");
                    foreach (string c in Subroutines(mainB))
                    {
                        string mainC = mainB.Replace(c, "C");
                        if (AcceptableMain(mainC))
                        {
                            return [mainC, a, b, c];
                        }
                    }
                }
            }

            return null;
        }

        private class Droid
        {
            private List<string>? map;
            private List<Point>? intersections;
            public Intcode? brain;
            public int initialFacing;
            public Point? pos;

            public void BuildMap()
            {
                map = [];
                string s = "";
                while (!brain!.halted)
                {
                    brain.RunToOutput();
                    if (brain.output == 10)
                    {
                        if (s.Length > 0) map.Add(s);
                        s = "";
                    }
                    else s += (char)brain.output;
                }

                intersections = [];
                for (int y = 1; y < map.Count - 1; y++)
                {
                    for (int x = 1; x < map[y].Length - 1; x++)
                    {
                        if (map[y][x] == '#' &&
                            map[y - 1][x] == '#' &&
                            map[y + 1][x] == '#' &&
                            map[y][x - 1] == '#' &&
                            map[y][x + 1] == '#')
                        {
                            intersections.Add(new Point(x, y));
                        }

                        char c = map[y][x];
                        switch (c)
                        {
                            case '^':
                                initialFacing = 0;
                                pos = new Point(x, y);
                                break;
                            case '>':
                                initialFacing = 1;
                                pos = new Point(x, y);
                                break;
                            case 'v':
                                initialFacing = 2;
                                pos = new Point(x, y);
                                break;
                            case '<':
                                initialFacing = 3;
                                pos = new Point(x, y);
                                break;
                        }
                    }
                }
            }

            public void DisplayMap()
            {
                foreach (string s in map!)
                {
                    Console.WriteLine(s);
                }
            }

            public int AlignmentSum()
            {
                int result = 0;
                foreach (Point p in intersections!)
                {
                    result += p.Item1 * p.Item2;
                }

                return result;
            }

            public bool OnPath(int x, int y) => y >= 0 && y < map!.Count && x >= 0 && x < map[y].Length && map[y][x] == '#';

            public string FindPath()
            {
                string path = "";
                int x = pos!.Item1;
                int y = pos.Item2;
                int facing = initialFacing;

                int[] xinc = [0, 1, 0, -1];
                int[] yinc = [-1, 0, 1, 0];

                while (true)
                {
                    int previousFacing = facing;
                    facing = -1;
                    for (int i = 0; i < 4; i++)
                    {
                        if (i != (previousFacing + 2) % 4)
                        {
                            if (OnPath(x + xinc[i], y + yinc[i]))
                            {
                                facing = i;
                                break;
                            }
                        }
                    }
                    if (facing == -1) return path;

                    if (facing == (previousFacing + 1) % 4) path += "R,";
                    else path += "L,";

                    int d = 0;
                    x += xinc[facing];
                    y += yinc[facing];
                    while (OnPath(x, y))
                    {
                        d++;
                        x += xinc[facing];
                        y += yinc[facing];
                    }
                    x -= xinc[facing];
                    y -= yinc[facing];
                    path += d + ",";

                }


            }

            public void SendInput(string s)
            {
                brain!.SendInput(s);
                brain.SendInput(10);
            }

            public void SendPath(string s)
            {
                if (s[^1] == ',') s = s[..^1];

                SendInput(s);
            }
        }

        private class Intcode
        {
            private readonly Queue<INT> inputQueue = new();

            public INT output;
            public Intcode? outputDest;

            private readonly Dictionary<INT, INT> memory;
            private INT ip;
            private INT rb;

            public bool waiting;
            public bool halted;
            public bool sentOutput;

            public int id;
            private static int nextID;

            public Intcode(List<INT> initialMemory)
            {
                id = nextID;
                nextID++;
                memory = [];
                INT address = 0;
                foreach (INT n in initialMemory)
                {
                    memory[address] = n;
                    address++;
                }
            }

            public Intcode(Intcode m)
            {
                id = nextID;
                nextID++;
                inputQueue = new Queue<INT>(m.inputQueue);
                output = m.output;
                memory = new Dictionary<INT, INT>(m.memory);
                ip = m.ip;
                rb = m.rb;
                waiting = m.waiting;
                halted = m.halted;
                sentOutput = m.sentOutput;
            }

            public void SendInput(INT input)
            {
                inputQueue.Enqueue(input);
                waiting = false;
            }

            public void SendInput(string s)
            {
                foreach (char c in s)
                {
                    SendInput(c);
                }
            }

            private void Output(INT i)
            {
                output = i;
                if (outputDest != null) outputDest.SendInput(i);
                else { } // Console.WriteLine(i);

                sentOutput = true;
            }

            public INT Memget(INT address) => memory.TryGetValue(address, out long value) ? value : 0;

            public void Memset(INT address, INT value) => memory[address] = value;

            private int AccessMode(int idx)
            {
                int mode = (int)Memget(ip) / 100;
                for (int i = 1; i < idx; i++)
                {
                    mode /= 10;
                }

                return mode % 10;
            }

            private void SetParam(int idx, INT value)
            {
                INT param = Memget(ip + idx);
                switch (AccessMode(idx))
                {
                    case 0:
                        Memset(param, value);
                        break;
                    case 1:
                        throw new Exception("Intcode immediate mode not allowed in setting memory");
                    case 2:
                        Memset(rb + param, value);
                        break;
                    default:
                        throw new Exception("Invalid Intcode parameter mode");
                }
            }

            private INT GetParam(int idx)
            {
                INT param = Memget(ip + idx);
                return AccessMode(idx) switch
                {
                    0 => Memget(param),
                    1 => param,
                    2 => Memget(rb + param),
                    _ => throw new Exception("Invalid Intcode parameter mode"),
                };
            }

            public void Step()
            {
                int opcode = (int)(Memget(ip) % 100);
                switch (opcode)
                {
                    case 1:
                        SetParam(3, GetParam(1) + GetParam(2));
                        ip += 4;
                        break;
                    case 2:
                        SetParam(3, GetParam(1) * GetParam(2));
                        ip += 4;
                        break;
                    case 3:
                        if (inputQueue.Count > 0)
                        {
                            SetParam(1, inputQueue.Dequeue());
                            ip += 2;
                        }
                        else waiting = true;

                        break;
                    case 4:
                        Output(GetParam(1));
                        ip += 2;
                        break;
                    case 5:
                        if (GetParam(1) == 0) ip += 3;
                        else ip = GetParam(2);

                        break;
                    case 6:
                        if (GetParam(1) == 0) ip = GetParam(2);
                        else ip += 3;

                        break;
                    case 7:
                        if (GetParam(1) < GetParam(2)) SetParam(3, 1);
                        else SetParam(3, 0);

                        ip += 4;
                        break;
                    case 8:
                        if (GetParam(1) == GetParam(2)) SetParam(3, 1);
                        else SetParam(3, 0);

                        ip += 4;
                        break;
                    case 9:
                        rb += GetParam(1);
                        ip += 2;
                        break;
                    case 99:
                        halted = true;
                        break;
                    default:
                        throw new Exception("Unknown Intcode opcode " + opcode + " at position " + ip);
                }
            }

            public void RunToOutput()
            {
                sentOutput = false;
                while (!halted && !waiting && !sentOutput)
                {
                    Step();
                }
            }

            public void Run()
            {
                while (!halted && !waiting)
                {
                    Step();
                }
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _17_SetAndForget(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_17_SetAndForget));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}