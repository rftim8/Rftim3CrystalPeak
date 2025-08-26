using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Coords = System.Tuple<int, int>;
using INT = System.Int64;

namespace Rftim3AdventOfCode.Refactor
{
    public class _11_SpacePolice : I_11_SpacePolice
    {
        #region Static
        private readonly List<string>? data;

        public _11_SpacePolice()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_11_SpacePolice));
        }

        /// <summary>
        /// On the way to Jupiter, you're pulled over by the Space Police.
        /// 
        /// "Attention, unmarked spacecraft! You are in violation of Space Law! All spacecraft must have a clearly visible registration identifier! 
        /// You have 24 hours to comply or be sent to Space Jail!"
        /// 
        /// Not wanting to be sent to Space Jail, you radio back to the Elves on Earth for help.
        /// Although it takes almost three hours for their reply signal to reach you, they send instructions for how to power 
        /// up the emergency hull painting robot and even provide a small Intcode program(your puzzle input) that will cause it to paint your ship appropriately.
        ///         There's just one problem: you don't have an emergency hull painting robot.
        /// 
        /// You'll need to build a new emergency hull painting robot. The robot needs to be able to move around on the grid of square panels on the side of your ship,
        /// detect the color of its current panel, and paint its current panel black or white. (All of the panels are currently black.)
        /// 
        /// The Intcode program will serve as the brain of the robot.The program uses input instructions to access the robot's camera:
        /// provide 0 if the robot is over a black panel or 1 if the robot is over a white panel. Then, the program will output two values:
        /// 
        /// First, it will output a value indicating the color to paint the panel the robot is over: 0 means to paint the panel black, and 1 means to paint the panel white.
        ///         Second, it will output a value indicating the direction the robot should turn: 0 means it should turn left 90 degrees, and 1 means it should turn right 90 degrees.
        /// After the robot turns, it should always move forward exactly one panel. The robot starts facing up.
        ///         The robot will continue running for a while like this and halt when it is finished drawing. 
        ///         Do not restart the Intcode computer inside the robot during this process.
        /// 
        /// For example, suppose the robot is about to start running. Drawing black panels as ., white panels as #, 
        /// and the robot pointing the direction it is facing (< ^ > v), the initial state and region near the robot looks like this:
        /// 
        /// .....
        /// .....
        /// ..^..
        /// .....
        /// .....
        /// The panel under the robot (not visible here because a ^ is shown instead) is also black, and so any input instructions at this point should be provided 0.
        /// Suppose the robot eventually outputs 1 (paint white) and then 0 (turn left). After taking these actions and moving forward one panel, the region now looks like this:
        /// 
        /// .....
        /// .....
        /// .<#..
        /// .....
        /// .....
        /// Input instructions should still be provided 0. Next, the robot might output 0 (paint black) and then 0 (turn left):
        /// 
        /// .....
        /// .....
        /// ..#..
        /// .v...
        /// .....
        ///         After more outputs (1,0, 1,0):
        /// 
        /// .....
        /// .....
        /// ..^..
        /// .##..
        /// .....
        /// The robot is now back where it started, but because it is now on a white panel, input instructions should be provided 1. 
        /// After several more outputs (0,1, 1,0, 1,0), the area looks like this:
        /// 
        /// .....
        /// ..<#.
        /// ...#.
        /// .##..
        /// .....
        /// Before you deploy the robot, you should probably have an estimate of the area it will cover: specifically, 
        /// you need to know the number of panels it paints at least once, regardless of color.In the example above, the robot painted 6 panels at least once. 
        /// (It painted its starting panel twice, but that panel is still only counted once; it also never painted the panel it ended on.)
        /// 
        /// Build a new emergency hull painting robot and run the Intcode program on it.How many panels does it paint at least once?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            List<long> input = input0[0].Split(',').Select(INT.Parse).ToList();

            Paintbot p = new(input);
            p.Run();

            return p.CountPaintedPanels();
        }

        /// <summary>
        /// You're not sure what it's trying to paint, but it's definitely not a registration identifier. The Space Police are getting impatient.
        /// 
        /// Checking your external ship cameras again, you notice a white panel marked "emergency hull painting robot starting panel".
        /// The rest of the panels are still black, but it looks like the robot was expecting to start on a white panel, not a black one.
        /// Based on the Space Law Space Brochure that the Space Police attached to one of your windows, a valid registration identifier is always eight capital letters. 
        /// After starting the robot on a single white panel instead, what registration identifier does it paint on your hull?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input0)
        {
            List<long> input = input0[0].Split(',').Select(INT.Parse).ToList();

            Paintbot p = new(input);
            p.SetColor(1);
            p.Run();
            p.Display();

            return "BLULZJLZ";
        }

        private class Intcode
        {
            private readonly List<INT> inputQueue = [];

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

            public void SendInput(INT input)
            {
                inputQueue.Add(input);
                waiting = false;
            }

            private void Output(INT i)
            {
                output = i;
                if (outputDest != null) outputDest.SendInput(i);
                else { } // Console.WriteLine(i);

                sentOutput = true;
            }

            private INT Memget(INT address) => memory.TryGetValue(address, out long value) ? value : 0;

            private void Memset(INT address, INT value) => memory[address] = value;

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
                            SetParam(1, inputQueue[0]);
                            inputQueue.RemoveAt(0);
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

                if (waiting) { }
            }
        }

        private class Paintbot(List<INT> input)
        {
            private readonly Dictionary<Coords, int> grid = [];
            private readonly Intcode brain = new(input);
            private Coords cursor = new(0, 0);
            private int facing;

            public int GetColor(Coords coords) => grid.TryGetValue(coords, out int value) ? value : 0;

            public int GetColor() => GetColor(cursor);

            public void SetColor(int color) => grid[cursor] = color;

            public void TurnLeft() => facing = (facing + 3) % 4;

            public void TurnRight() => facing = (facing + 1) % 4;

            public void StepForward()
            {
                switch (facing)
                {
                    case 0:
                        cursor = new Coords(cursor.Item1, cursor.Item2 + 1);
                        break;
                    case 1:
                        cursor = new Coords(cursor.Item1 + 1, cursor.Item2);
                        break;
                    case 2:
                        cursor = new Coords(cursor.Item1, cursor.Item2 - 1);
                        break;
                    case 3:
                        cursor = new Coords(cursor.Item1 - 1, cursor.Item2);
                        break;
                }
            }

            public void Run()
            {
                brain.RunToOutput();
                while (!brain.halted)
                {
                    if (brain.waiting) brain.SendInput(GetColor());
                    else
                    {
                        SetColor((int)brain.output);
                        brain.RunToOutput();

                        if (brain.output == 0) TurnLeft();
                        else TurnRight();

                        StepForward();
                    }
                    brain.RunToOutput();
                }
            }

            public int CountPaintedPanels() => grid.Count;

            public void Display()
            {
                int minx = 0;
                int maxx = 0;
                int miny = 0;
                int maxy = 0;
                foreach (Coords coords in grid.Keys)
                {
                    if (coords.Item1 < minx) minx = coords.Item1;
                    if (coords.Item1 > maxx) maxx = coords.Item1;
                    if (coords.Item2 < miny) miny = coords.Item2;
                    if (coords.Item2 > maxy) maxy = coords.Item2;
                }

                for (int y = maxy; y >= miny; y--)
                {
                    for (int x = minx; x <= maxx; x++)
                    {
                        Console.Write(GetColor(new Coords(x, y)) > 0 ? '#' : ' ');
                    }
                    Console.WriteLine();
                }
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _11_SpacePolice(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_11_SpacePolice));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}