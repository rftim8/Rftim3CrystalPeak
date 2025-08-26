using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using INT = System.Int64;

namespace Rftim3AdventOfCode.Refactor
{
    public class _13_CarePackage : I_13_CarePackage
    {
        #region Static
        private readonly List<string>? data;

        public _13_CarePackage()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_13_CarePackage));
        }

        /// <summary>
        /// As you ponder the solitude of space and the ever-increasing three-hour roundtrip for messages between you and Earth,
        /// you notice that the Space Mail Indicator Light is blinking. To help keep you sane, the Elves have sent you a care package.
        /// 
        /// It's a new game for the ship's arcade cabinet! Unfortunately, the arcade is all the way on the other end of the ship.
        /// Surely, it won't be hard to build your own - the care package even comes with schematics.
        /// 
        /// The arcade cabinet runs Intcode software like the game the Elves sent (your puzzle input). It has a primitive screen capable of drawing square tiles on a grid.
        /// The software draws tiles to the screen with output instructions: every three output instructions specify the x position(distance from the left),
        /// y position(distance from the top), and tile id.The tile id is interpreted as follows:
        /// 
        /// 0 is an empty tile.No game object appears in this tile.
        /// 1 is a wall tile.Walls are indestructible barriers.
        /// 2 is a block tile.Blocks can be broken by the ball.
        /// 3 is a horizontal paddle tile. The paddle is indestructible.
        /// 4 is a ball tile.The ball moves diagonally and bounces off objects.
        /// For example, a sequence of output values like 1,2,3,6,5,4 would draw a horizontal paddle tile (1 tile from the left and 2 tiles from the top) 
        /// and a ball tile(6 tiles from the left and 5 tiles from the top).
        /// 
        /// Start the game.How many block tiles are on the screen when the game exits?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            List<INT> input = input0[0].Split(',').Select(INT.Parse).ToList();

            Screen screen = Run(input);

            return screen.CountBlocks();
        }

        /// <summary>
        /// The game didn't run because you didn't put in any quarters. Unfortunately, you did not bring any quarters. 
        /// Memory address 0 represents the number of quarters that have been inserted; set it to 2 to play for free.
        /// 
        /// The arcade cabinet has a joystick that can move left and right.The software reads the position of the joystick with input instructions:
        /// 
        /// 
        /// If the joystick is in the neutral position, provide 0.
        /// If the joystick is tilted to the left, provide -1.
        /// If the joystick is tilted to the right, provide 1.
        /// The arcade cabinet also has a segment display capable of showing a single number that represents the player's current score.
        /// When three output instructions specify X=-1, Y=0, the third output instruction is not a tile; 
        /// the value instead specifies the new score to show in the segment display. For example, a sequence of output values like -1,0,12345 would show 12345 as 
        /// the player's current score.
        /// Beat the game by breaking all the blocks. What is your score after the last block is broken?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input0)
        {
            List<INT> input = input0[0].Split(',').Select(INT.Parse).ToList();

            Screen screen = Play(input);

            return screen.score;
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

            public Intcode(Intcode m)
            {
                id = nextID;
                nextID++;
                inputQueue = new List<INT>(m.inputQueue);
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
            }

        }

        private class Screen
        {
            private readonly Dictionary<Tuple<INT, INT>, INT> tiles;
            public INT score;
            public INT ballpos;
            public INT paddlepos;


            public void Set(INT x, INT y, INT tile)
            {
                tiles[new Tuple<INT, INT>(x, y)] = tile;
                if (tile == 4) ballpos = x;
                else if (tile == 3) paddlepos = x;
            }

            public INT Get(INT x, INT y)
            {
                Tuple<INT, INT> key = new(x, y);

                return tiles.TryGetValue(key, out long value) ? value : 0;
            }

            public int CountBlocks()
            {
                int blocks = 0;
                foreach (Tuple<long, long> key in tiles.Keys)
                {
                    if (tiles[key] == 2) blocks++;
                }

                return blocks;
            }

            public bool AllBlocksGone()
            {
                foreach (Tuple<long, long> key in tiles.Keys)
                {
                    if (tiles[key] == 2) return false;
                }

                return true;
            }

            public Screen()
            {
                tiles = [];
                score = 0;
            }

            public Screen(Screen s)
            {
                tiles = new Dictionary<Tuple<INT, INT>, INT>(s.tiles);
                score = s.score;
            }

            public void Display()
            {
                Console.WriteLine();
                Console.WriteLine(score);
                INT maxX = 0;
                INT maxY = 0;
                foreach (Tuple<INT, INT> key in tiles.Keys)
                {
                    if (key.Item1 > maxX) maxX = key.Item1;
                    if (key.Item2 > maxY) maxY = key.Item2;
                }

                string tileset = " #=_O";
                for (INT y = maxY; y >= 0; y--)
                {
                    for (int x = 0; x <= maxX; x++)
                    {
                        Console.Write(tileset[(int)Get(x, y)]);
                    }

                    Console.WriteLine();
                }
            }
        }

        private class ArcadeMachine
        {
            public Intcode brain;
            public Screen screen;

            public ArcadeMachine(List<INT> input, bool quarters)
            {
                brain = new Intcode(input);
                if (quarters) brain.Memset(0, 2);
                screen = new Screen();
            }

            public ArcadeMachine(ArcadeMachine a)
            {
                brain = new Intcode(a.brain);
                screen = new Screen(a.screen);
            }

            public void Run()
            {
                while (!brain.waiting && !brain.halted)
                {
                    brain.RunToOutput();
                    if (brain.waiting || brain.halted) return;
                    if (brain.sentOutput)
                    {
                        INT x = brain.output;
                        brain.RunToOutput();
                        INT y = brain.output;
                        brain.RunToOutput();
                        INT value = brain.output;
                        if (x == -1 && y == 0) screen.score = value;
                        else screen.Set(x, y, value);
                    }
                }
            }
        }

        private static Screen Run(List<INT> input)
        {
            ArcadeMachine m = new(input, false);

            while (!m.brain.halted)
            {
                m.Run();
            }

            return m.screen;
        }

        private static Screen Play(List<INT> input)
        {
            ArcadeMachine m = new(input, true);
            while (true)
            {
                m.Run();
                if (m.brain.halted || m.screen.AllBlocksGone()) return m.screen;
                else if (m.brain.waiting)
                {
                    if (m.screen.paddlepos < m.screen.ballpos) m.brain.SendInput(1);
                    else if (m.screen.paddlepos > m.screen.ballpos) m.brain.SendInput(-1);
                    else m.brain.SendInput(0);
                }
            }
        }

        private static Screen? AutoPlay(List<INT> input)
        {
            List<ArcadeMachine> multiverse = [new ArcadeMachine(input, true)];
            while (multiverse.Count > 0)
            {
                Console.WriteLine(multiverse.Count);
                List<ArcadeMachine> next = [];
                foreach (ArcadeMachine m in multiverse)
                {
                    m.Run();
                    if (m.screen.AllBlocksGone()) return m.screen;
                    else if (m.brain.waiting)
                    {
                        ArcadeMachine mLeft = new(m);
                        ArcadeMachine mRight = new(m);
                        m.brain.SendInput(0);
                        mLeft.brain.SendInput(-1);
                        mRight.brain.SendInput(1);
                        next.Add(m);
                        next.Add(mLeft);
                        next.Add(mRight);
                    }
                    else if (!m.brain.halted) next.Add(m);
                }
                multiverse = next;
            }

            return null;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _13_CarePackage(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_13_CarePackage));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}