using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using INT = System.Int64;

namespace Rftim3AdventOfCode.Refactor
{
    public class _19_TractorBeam : I_19_TractorBeam
    {
        #region Static
        private readonly List<string>? data;

        public _19_TractorBeam()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_19_TractorBeam));
        }

        /// <summary>
        /// Unsure of the state of Santa's ship, you borrowed the tractor beam technology from Triton. Time to test it out.
        /// 
        /// When you're safely away from anything else, you activate the tractor beam, but nothing happens. 
        /// It's hard to tell whether it's working if there's nothing to use it on.Fortunately, your ship's drone system can be configured to deploy
        /// a drone to specific coordinates and then check whether it's being pulled.There's even an Intcode program (your puzzle input) that gives you access to the drone system.
        /// 
        /// The program uses two input instructions to request the X and Y position to which the drone should be deployed. 
        /// Negative numbers are invalid and will confuse the drone; all numbers should be zero or positive.
        /// Then, the program will output whether the drone is stationary(0) or being pulled by something(1).
        /// For example, the coordinate X = 0, Y = 0 is directly in front of the tractor beam emitter, so the drone control program will always report 1 at that location.
        /// 
        /// To better understand the tractor beam, it is important to get a good picture of the beam itself.
        /// For example, suppose you scan the 10x10 grid of points closest to the emitter:
        /// 
        ///        X
        ///   0->      9
        ///  0#.........
        ///  |.#........
        ///  v..##......
        ///   ...###....
        ///   ....###...
        /// Y.....####.
        ///   ......####
        ///   ......####
        ///   .......###
        ///  9........##
        /// In this example, the number of points affected by the tractor beam in the 10x10 area closest to the emitter is 27.
        /// 
        /// However, you'll need to scan a larger area to understand the shape of the beam. 
        /// How many points are affected by the tractor beam in the 50x50 area closest to the emitter? (For each of X and Y, this will be 0 through 49.)
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

            probe = new Intcode(input);
            Diagonal.probe = probe;
            int count = 0;
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    count += Probe(x, y);
                }
            }

            return count;
        }

        /// <summary>
        /// You aren't sure how large Santa's ship is. You aren't even sure if you'll need to use this thing on Santa's ship, but it doesn't hurt to be prepared.
        /// You figure Santa's ship might fit in a 100x100 square.
        /// 
        /// The beam gets wider as it travels away from the emitter; you'll need to be a minimum distance away to fit a square of that size into the beam fully. 
        /// (Don't rotate the square; it should be aligned to the same axes as the drone grid.)
        /// 
        /// For example, suppose you have the following tractor beam readings:
        /// 
        /// #.......................................
        /// .#......................................
        /// ..##....................................
        /// ...###..................................
        /// ....###.................................
        /// .....####...............................
        /// ......#####.............................
        /// ......######............................
        /// .......#######..........................
        /// ........########........................
        /// .........#########......................
        /// ..........#########.....................
        /// ...........##########...................
        /// ...........############.................
        /// ............############................
        /// .............#############..............
        /// ..............##############............
        /// ...............###############..........
        /// ................###############.........
        /// ................#################.......
        /// .................########OOOOOOOOOO.....
        /// ..................#######OOOOOOOOOO#....
        /// ...................######OOOOOOOOOO###..
        /// ....................#####OOOOOOOOOO#####
        /// .....................####OOOOOOOOOO#####
        /// .....................####OOOOOOOOOO#####
        /// ......................###OOOOOOOOOO#####
        /// .......................##OOOOOOOOOO#####
        /// ........................#OOOOOOOOOO#####
        /// .........................OOOOOOOOOO#####
        /// ..........................##############
        /// ..........................##############
        /// ...........................#############
        /// ............................############
        /// .............................###########
        /// In this example, the 10x10 square closest to the emitter that fits entirely within the tractor beam has been marked O.
        /// Within it, the point closest to the emitter (the only highlighted O) is at X=25, Y=20.
        /// 
        /// Find the 100x100 square closest to the emitter that fits entirely within the tractor beam; within that square, find the point closest to the emitter.
        /// What value do you get if you take that point's X coordinate, multiply it by 10000, then add the point's Y coordinate ? (In the example above, this would be 250020.)
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input0)
        {
            List<INT> input = [];
            foreach (string line in input0)
            {
                foreach (string token in line.Split(','))
                {
                    input.Add(INT.Parse(token));
                }
            }

            probe = new Intcode(input);
            Diagonal.probe = probe;
            int count = 0;
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    count += Probe(x, y);
                }
            }

            int size = 100;
            Diagonal d = DiagonalForWidth(size);
            return d.left * 10000 + d.GetY(d.left + size - 1);
        }

        private static Intcode? probe;

        private static int Probe(int x, int y)
        {
            probe!.Reset();
            probe.SendInput(x);
            probe.SendInput(y);
            probe.RunToOutput();
            return (int)probe.output;
        }

        private static Diagonal DiagonalForWidth(int width)
        {
            Diagonal min = new(width);
            Diagonal margin = min;
            Diagonal max = min;
            while (max.BeamWidth() < width)
            {
                max = new Diagonal(max.rank * 2);
            }

            while (min.rank < max.rank - 1)
            {
                Diagonal d = new((min.rank + max.rank) / 2);
                int w = d.BeamWidth();
                if (w <= width - 2) margin = d;
                if (w < width) min = d;
                else max = d;
            }

            for (int i = margin.rank + 1; i < max.rank; i++)
            {
                Diagonal d = new(i);
                if (d.BeamWidth() == width) return d;
            }

            return max;
        }

        private class Diagonal(int rank)
        {
            public int rank = rank;

            public int left = -1;
            public int right = -1;

            public static Intcode? probe;

            public int GetY(int x) => rank - x;

            public bool Probe(int idx)
            {
                int x = idx;
                int y = GetY(x);
                probe!.Reset();
                probe.SendInput(x);
                probe.SendInput(y);
                probe.RunToOutput();
                return probe.output == 1;
            }

            private static IEnumerable<int> SearchOrder(int min, int max)
            {
                if (min > max) yield break;
                if (min == max)
                {
                    yield return min;
                    yield break;
                }

                int split = (min + max) / 2;
                yield return split;
                IEnumerator<int>? left = SearchOrder(min, split - 1).GetEnumerator();
                IEnumerator<int>? right = SearchOrder(split + 1, max).GetEnumerator();
                while (true)
                {
                    if (left == null && right == null) yield break;
                    if (left != null)
                    {
                        if (left.MoveNext()) yield return left.Current;
                        else left = null;
                    }
                    if (right != null)
                    {
                        if (right.MoveNext()) yield return right.Current;
                        else right = null;
                    }
                }
            }

            public int FindBeam()
            {
                foreach (int i in from int i in SearchOrder(0, rank)
                                  where Probe(i)
                                  select i)
                {
                    return i;
                }

                return -1;
            }

            public void FindExtents()
            {
                int maxLeft = FindBeam();
                int minRight = maxLeft;

                left = 0;
                while (left != maxLeft)
                {
                    int i = (left + maxLeft) / 2;
                    if (Probe(i)) maxLeft = i;
                    else left = i + 1;
                }

                right = rank;
                while (right != minRight)
                {
                    int i = (right + minRight + 1) / 2;
                    if (Probe(i)) minRight = i;
                    else right = i - 1;
                }
            }

            public int BeamWidth()
            {
                if (left == -1) FindExtents();
                return right - left + 1;
            }
        }

        private class Intcode
        {
            public Queue<INT> inputQueue = new();

            public INT output;
            public Intcode? outputDest;

            private readonly List<INT> initialMemory;
            private Dictionary<INT, INT> memory;
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
                this.initialMemory = initialMemory;
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
                initialMemory = m.initialMemory;
                inputQueue = new Queue<INT>(m.inputQueue);
                output = m.output;
                memory = new Dictionary<INT, INT>(m.memory);
                ip = m.ip;
                rb = m.rb;
                waiting = m.waiting;
                halted = m.halted;
                sentOutput = m.sentOutput;
            }

            public void Reset()
            {
                ip = 0;
                rb = 0;
                output = 0;
                waiting = false;
                halted = false;
                sentOutput = false;
                inputQueue = new Queue<INT>();
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
                        throw new Exception($"Unknown Intcode opcode {opcode} at position {ip}");
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

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _19_TractorBeam(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_19_TractorBeam));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}