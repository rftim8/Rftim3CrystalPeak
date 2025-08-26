using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using INT = System.Int64;
using Point = System.Tuple<int, int>;

namespace Rftim3AdventOfCode.Refactor
{
    public class _15_OxygenSystem : I_15_OxygenSystem
    {
        #region Static
        private readonly List<string>? data;

        public _15_OxygenSystem()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_15_OxygenSystem));
        }

        /// <summary>
        /// Out here in deep space, many things can go wrong. Fortunately, many of those things have indicator lights. 
        /// Unfortunately, one of those lights is lit: the oxygen system for part of the ship has failed!
        /// 
        /// According to the readouts, the oxygen system must have failed days ago after a rupture in oxygen tank two; 
        /// that section of the ship was automatically sealed once oxygen levels went dangerously low.
        /// A single remotely-operated repair droid is your only option for fixing the oxygen system.
        /// 
        /// The Elves' care package included an Intcode program (your puzzle input) that you can use to remotely control the repair droid. 
        /// By running that program, you can direct the repair droid to the oxygen system and fix the problem.
        /// 
        /// The remote control program executes the following steps in a loop forever:
        /// 
        /// Accept a movement command via an input instruction.
        /// Send the movement command to the repair droid.
        /// Wait for the repair droid to finish the movement operation.
        /// Report on the status of the repair droid via an output instruction.
        /// Only four movement commands are understood: north (1), south(2), west(3), and east(4). Any other command is invalid.
        /// The movements differ in direction, but not in distance: in a long enough east-west hallway, 
        /// a series of commands like 4,4,4,4,3,3,3,3 would leave the repair droid back where it started.
        /// 
        /// The repair droid can reply with any of the following status codes:
        /// 
        /// 0: The repair droid hit a wall.Its position has not changed.
        /// 1: The repair droid has moved one step in the requested direction.
        /// 2: The repair droid has moved one step in the requested direction; its new position is the location of the oxygen system.
        /// You don't know anything about the area around the repair droid, but you can figure it out by watching the status codes.
        /// 
        /// For example, we can draw the area using D for the droid, # for walls, . for locations the droid can traverse, and empty space for unexplored locations.
        /// Then, the initial state looks like this:
        ///       
        ///    D
        /// 
        /// To make the droid go north, send it 1. If it replies with 0, you know that location is a wall and that the droid didn't move:
        /// 
        ///       
        ///    #  
        ///    D
        /// 
        /// 
        /// To move east, send 4; a reply of 1 means the movement was successful:
        /// 
        ///       
        ///    #  
        ///    .D
        /// 
        /// 
        /// Then, perhaps attempts to move north(1), south(2), and east(4) are all met with replies of 0:
        /// 
        ///       
        ///    ## 
        ///    .D#
        ///     # 
        ///       
        /// Now, you know the repair droid is in a dead end.Backtrack with 3 (which you already know will get a reply of 1 because you already know that location is open):
        /// 
        ///       
        ///    ## 
        ///    D.#
        ///     # 
        ///       
        /// Then, perhaps west(3) gets a reply of 0, south(2) gets a reply of 1, south again(2) gets a reply of 0, and then west(3) gets a reply of 2:
        /// 
        ///       
        ///    ## 
        ///   #..#
        ///   D.# 
        ///    #  
        /// Now, because of the reply of 2, you know you've found the oxygen system! In this example, it was only 2 moves away from the repair droid's starting position.
        /// 
        /// What is the fewest number of movement commands required to move the repair droid from its starting position to the location of the oxygen system?
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

            Droid d = new(input);
            d.ExploreFully();

            return d.map.PathLength(d.leak);
        }

        /// <summary>
        /// You quickly repair the oxygen system; oxygen gradually fills the area.
        /// 
        /// Oxygen starts in the location containing the repaired oxygen system.
        /// It takes one minute for oxygen to spread to all open locations that are adjacent to a location that already contains oxygen.Diagonal locations are not adjacent.
        /// 
        /// In the example above, suppose you've used the droid to explore the area fully and have the following map (where locations that currently contain oxygen are marked O):
        /// 
        ///  ##   
        /// #..## 
        /// #.#..#
        /// #.O.# 
        ///  ###  
        /// Initially, the only location which contains oxygen is the location of the repaired oxygen system.However, after one minute,
        /// the oxygen spreads to all open(.) locations that are adjacent to a location containing oxygen:
        /// 
        ///  ##   
        /// #..## 
        /// #.#..#
        /// #OOO# 
        ///  ###  
        /// After a total of two minutes, the map looks like this:
        /// 
        ///  ##   
        /// #..## 
        /// #O#O.#
        /// #OOO# 
        ///  ###  
        /// After a total of three minutes:
        /// 
        ///  ##   
        /// # O.## 
        /// # O#OO#
        /// # OOO# 
        /// ###  
        /// And finally, the whole region is full of oxygen after a total of four minutes:
        /// 
        ///  ##   
        /// # OO## 
        /// # O#OO#
        /// # OOO# 
        /// ###  
        /// So, in this example, all locations contain oxygen after 4 minutes.
        /// Use the repair droid to get a complete map of the area. How many minutes will it take to fill with oxygen?
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

            Droid d = new(input);
            d.ExploreFully();

            return d.map.GetMaxDistance(d.leak);
        }

        private static int Abs(int x) => x >= 0 ? x : -x;

        private class Droid
        {
            private readonly Intcode brain;
            public Point pos;
            public Map map;
            public Point? leak;

            public Droid(List<INT> code)
            {
                brain = new Intcode(code);
                pos = new Point(0, 0);
                map = new Map();
                map.AddClear(pos);
                leak = null;
            }

            public bool Step(int direction)
            {
                brain.SendInput(direction);
                Point dest = direction == 1 ? Map.NorthOf(pos) : direction == 2 ? Map.SouthOf(pos) : direction == 3 ? Map.WestOf(pos) : Map.EastOf(pos);
                brain.RunToOutput();

                if (brain.output == 0)
                {
                    map.AddWall(dest);

                    return false;
                }

                map.AddClear(dest);
                pos = dest;

                if (brain.output == 2) leak = dest;

                return true;
            }

            public void GoTo(Point p)
            {
                foreach (int dir in map.FindPath(pos, p))
                {
                    Step(dir);
                }
            }

            public void ExploreFully()
            {
                while (map.Frontier.Count > 0)
                {
                    Point p = map.Frontier[0];
                    map.Frontier.RemoveAt(0);
                    GoTo(p);
                }
            }
        }

        private class Map
        {
            private readonly Dictionary<Point, bool> Walls;
            private Dictionary<Point, int>? Course;
            public List<Point> Frontier;

            public static Point origin = new(0, 0);

            public Map()
            {
                Walls = [];
                Frontier = [];
            }

            public static Point NorthOf(Point p) => new(p.Item1, p.Item2 + 1);

            public static Point SouthOf(Point p) => new(p.Item1, p.Item2 - 1);

            public static Point EastOf(Point p) => new(p.Item1 + 1, p.Item2);

            public static Point WestOf(Point p) => new(p.Item1 - 1, p.Item2);

            private void AddFrontierMaybe(Point pos)
            {
                if (!Walls.ContainsKey(pos) && !Frontier.Contains(pos)) Frontier.Add(pos);
            }

            public void AddWall(Point pos)
            {
                Frontier.Remove(pos);

                if (Walls.ContainsKey(pos)) return;

                Walls.Add(pos, true);
            }
            public void AddClear(Point pos)
            {
                Frontier.Remove(pos);

                if (Walls.ContainsKey(pos)) return;

                Walls.Add(pos, false);
                AddFrontierMaybe(NorthOf(pos));
                AddFrontierMaybe(SouthOf(pos));
                AddFrontierMaybe(EastOf(pos));
                AddFrontierMaybe(WestOf(pos));
            }

            private void AddMaybe(List<Point> stuff, Point p)
            {
                if (Walls.ContainsKey(p) && !Walls[p] && !Course!.ContainsKey(p) && !stuff.Contains(p)) stuff.Add(p);
            }

            public void ChartCourse(Point? start, Point end)
            {
                Course = [];

                List<Point> generation = [end];
                int distance = 0;

                while (generation.Count > 0)
                {
                    List<Point> next = [];
                    foreach (Point p in generation)
                    {
                        Course[p] = distance;
                        Course[p] = distance;

                        if (start != null && p.Item1 == start.Item1 && p.Item2 == start.Item2) return;

                        AddMaybe(next, NorthOf(p));
                        AddMaybe(next, SouthOf(p));
                        AddMaybe(next, EastOf(p));
                        AddMaybe(next, WestOf(p));
                    }
                    generation = next;
                    distance++;
                }
            }

            public int GetMaxDistance(Point? p)
            {
                ChartCourse(null, p!);
                int max = 0;
                foreach (int d in from int d in Course!.Values
                                  where d > max
                                  select d)
                {
                    max = d;
                }

                return max;
            }

            public IEnumerable<int> FindPath(Point start, Point end)
            {
                ChartCourse(start, end);
                Point p = start;
                while (Course![p] != 0)
                {
                    int dist = Course[p] - 1;
                    Point q = NorthOf(p);
                    if (Course.TryGetValue(q, out int value) && value == dist) yield return 1;
                    else
                    {
                        q = SouthOf(p);
                        if (Course.TryGetValue(q, out int value1) && value1 == dist) yield return 2;
                        else
                        {
                            q = WestOf(p);
                            if (Course.TryGetValue(q, out int value2) && value2 == dist) yield return 3;
                            else
                            {
                                q = EastOf(p);
                                if (Course.TryGetValue(q, out int value3) && value3 == dist) yield return 4;
                            }
                        }
                    }
                    p = q;
                }

                yield break;
            }

            public int PathLength(Point? end)
            {
                ChartCourse(origin, end!);

                return Course![origin];
            }
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

        public _15_OxygenSystem(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_15_OxygenSystem));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}