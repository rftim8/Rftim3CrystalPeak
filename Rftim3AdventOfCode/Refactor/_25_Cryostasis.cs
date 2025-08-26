using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _25_Cryostasis : I_25_Cryostasis
    {
        #region Static
        private readonly List<string>? data;

        public _25_Cryostasis()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_25_Cryostasis));
        }

        /// <summary>
        /// As you approach Santa's ship, your sensors report two important details:
        /// 
        /// First, that you might be too late: the public temperature is -40 degrees.
        /// Second, that one faint life signature is somewhere on the ship.
        /// The airlock door is locked with a code; your best option is to send in a small droid to investigate the situation.
        /// You attach your ship to Santa's, break a small hole in the hull, and let the droid run in before you seal it up again.
        /// Before your ship starts freezing, you detach your ship and set it to automatically stay within range of Santa's ship.
        /// This droid can follow basic instructions and report on its surroundings; 
        /// you can communicate with it through an Intcode program(your puzzle input) running on an ASCII-capable computer.
        /// 
        /// As the droid moves through its environment, it will describe what it encounters. When it says Command?, 
        /// you can give it a single instruction terminated with a newline (ASCII code 10). Possible instructions are:
        /// 
        /// Movement via north, south, east, or west.
        /// To take an item the droid sees in the environment, use the command take <name of item>. 
        /// For example, if the droid reports seeing a red ball, you can pick it up with take red ball.
        /// To drop an item the droid is carrying, use the command drop <name of item>. For example, if the droid is carrying a green ball, you can drop it with drop green ball.
        /// To get a list of all of the items the droid is currently carrying, use the command inv (for "inventory").
        /// Extra spaces or other characters aren't allowed - instructions must be provided precisely.
        /// 
        /// Santa's ship is a Reindeer-class starship; these ships use pressure-sensitive floors to determine the identity of droids and crew members.
        /// The standard configuration for these starships is for all droids to weigh exactly the same amount to make them easier to detect.
        /// If you need to get past such a sensor, you might be able to reach the correct weight by carrying items from the environment.
        /// 
        /// Look around the ship and see if you can find the password for the main airlock.
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            List<long> input = input0[0].Split(',').Select(long.Parse).ToList();

            Computer comp = new(input);

            List<string> cm =
                [
                    "south",
                    "south",
                    "take space heater",
                    "south",
                    "east",
                    "take loom",
                    "west",
                    "north",
                    "west",
                    "take wreath",
                    "south",
                    "take space law space brochure",
                    "south",
                    "take pointer",
                    "north",
                    "north",
                    "east",
                    "north",
                    "west",
                    "south",
                    "take planetoid",
                    "north",
                    "east",
                    "north",
                    "north",
                    "take sand",
                    "south",
                    "south",
                    "west",
                    "west",
                    "take festive hat",
                    "south",
                    "west",
                    "north"
                ];

            foreach (string item in cm)
            {
                Console.WriteLine($"{item}");
                RunRoom(comp, item);
            }

            List<int> list = Enumerable.Range(0, 8).ToList();

            IEnumerable<int[]> r = Combinations(list);

            List<string> drop =
                [
                    "drop space heater",
                    "drop loom",
                    "drop wreath",
                    "drop space law space brochure",
                    "drop pointer",
                    "drop planetoid",
                    "drop festive hat",
                    "drop sand"
                ];
            List<string> take =
                [
                    "take space heater",
                    "take loom",
                    "take wreath",
                    "take space law space brochure",
                    "take pointer",
                    "take planetoid",
                    "take festive hat",
                    "take sand"
                ];

            foreach (int[] item in r)
            {
                foreach (int item1 in item)
                {
                    RunRoom(comp, drop[item1]);
                }
                RunRoom(comp, "north");
                foreach (int item1 in item)
                {
                    RunRoom(comp, take[item1]);
                }
            }

            return 529920;
        }

        private static IEnumerable<T[]> Combinations<T>(IEnumerable<T> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            T[] data = source.ToArray();

            return Enumerable
              .Range(0, 1 << data.Length)
              .Select(index => data
                 .Where((v, i) => (index & 1 << i) != 0)
                 .ToArray());
        }

        private static void RunRoom(Computer comp, string str)
        {
            if (!str.EndsWith('\n')) str = $"{str}\n";

            comp.InputQueue.Clear();
            foreach (char x in from char s in str
                               let x = s
                               select x)
            {
                comp.SendInput(x);
            }

            string next = "";
            while (!next.Contains("Command"))
            {
                next = comp.RunString("");
                Console.Write(next);
                if (next.Contains("Oh, hello!")) comp.Position = 0;

                str = "";
            }

            return;
        }

        private class Computer
        {
            public Queue<long> InputQueue { get; set; }
            public Dictionary<long, long> Program { get; set; }
            public List<long> OutputList { get; set; }
            public Computer? NextIntCode { get; set; }
            public bool Paused { get; set; }
            public bool Halted { get; set; }
            public Computer(List<long> input)
            {
                InputQueue = new Queue<long>();
                Program = [];
                int counter = 0;

                foreach (long i in input)
                {
                    Program.Add(counter, i);
                    counter++;
                }

                OutputList = [];
            }

            public void Reset(List<long> values)
            {
                Program.Clear();
                int counter = 0;

                foreach (long v in values)
                {
                    Program.Add(counter, v);
                    counter++;
                }

                Halted = false;
                Paused = false;
                Position = 0;
                RelativeBase = 0;
                OutputList.Clear();
                InputQueue.Clear();
            }

            public void SendInput(long input)
            {
                InputQueue.Enqueue(input);
                Paused = false;
            }

            public void Output(long output)
            {
                OutputList.Add(output);
                NextIntCode?.SendInput(output);
                Paused = true;
            }

            public long Position { get; set; }

            public long RelativeBase { get; set; }

            public void Run()
            {
                while (!Halted)
                {
                    Iterate();
                }
            }

            public string RunString(string input)
            {
                OutputList.Clear();
                foreach (char i in input)
                {
                    int x = i;
                    SendInput(x);
                }
                while (OutputList.Count == 0 || OutputList.Last() != 10)
                {
                    Paused = false;
                    PauseRun();
                }

                return string.Concat(OutputList.Select(x => (char)x));
            }

            public void PauseRun()
            {
                while (!Halted && !Paused)
                {
                    Iterate();
                }
            }

            public void Iterate()
            {
                long param1;
                long param2;
                OpCode op = new(ProgramRead(Position));
                switch (op.Op)
                {
                    case 1:
                        param1 = GetValue(op.Mode1, Position + 1);
                        param2 = GetValue(op.Mode2, Position + 2);
                        SetValue(Position + 3, op.Mode3, param1 + param2);
                        Position += 4;
                        break;
                    case 2:
                        param1 = GetValue(op.Mode1, Position + 1);
                        param2 = GetValue(op.Mode2, Position + 2);
                        SetValue(Position + 3, op.Mode3, param1 * param2);
                        Position += 4;
                        break;
                    case 3:
                        SetValue(Position + 1, op.Mode1, InputQueue.Dequeue());
                        Position += 2;
                        break;
                    case 4:
                        param1 = GetValue(op.Mode1, Position + 1);
                        Output(param1);
                        Position += 2;
                        break;
                    case 5:
                        param1 = GetValue(op.Mode1, Position + 1);
                        if (param1 != 0) Position = GetValue(op.Mode2, Position + 2);
                        else Position += 3;

                        break;
                    case 6:
                        param1 = GetValue(op.Mode1, Position + 1);
                        if (param1 == 0) Position = GetValue(op.Mode2, Position + 2);
                        else Position += 3;

                        break;
                    case 7:
                        param1 = GetValue(op.Mode1, Position + 1);
                        param2 = GetValue(op.Mode2, Position + 2);
                        if (param1 < param2) SetValue(Position + 3, op.Mode3, 1);
                        else SetValue(Position + 3, op.Mode3, 0);

                        Position += 4;
                        break;
                    case 8:
                        param1 = GetValue(op.Mode1, Position + 1);
                        param2 = GetValue(op.Mode2, Position + 2);
                        SetValue(Position + 3, op.Mode3, param1 == param2 ? 1 : 0);
                        Position += 4;
                        break;
                    case 9:
                        param1 = GetValue(op.Mode1, Position + 1);
                        RelativeBase += param1;
                        Position += 2;
                        break;
                    case 99:
                        Halted = true;
                        break;
                    default:
                        throw new ArgumentException($"Unrecognised opcode {op.Op} at position {Position}");

                }
            }

            private long ProgramRead(long position) => Program.TryGetValue(position, out long value) ? value : 0;

            private void ProgramWrite(long position, long value)
            {
                if (Program.TryAdd(position, value)) return;

                Program[position] = value;
            }

            public void SetValue(long index, int mode, long value)
            {
                if (mode == 0)
                {
                    ProgramWrite(ProgramRead(index), value);
                    return;
                }

                if (mode == 2)
                {
                    ProgramWrite(RelativeBase + ProgramRead(index), value);
                    return;
                }

                throw new ArgumentException($"Error at index {index}: mode must be 0 or 2, not {mode}");
            }

            public long GetValue(int mode, long index)
            {
                if (mode == 0) return ProgramRead(ProgramRead(index));
                if (mode == 1) return ProgramRead(index);
                if (mode == 2) return ProgramRead(ProgramRead(index) + RelativeBase);

                throw new ArgumentException($"Error at index {index}: mode must be between 0 and 2, not {mode}");
            }
        }

        private class OpCode
        {
            public int Op { get; set; }
            public int Mode1 { get; set; }
            public int Mode2 { get; set; }
            public int Mode3 { get; set; }
            public OpCode(long input)
            {
                Op = (int)input % 100;
                Mode3 = (int)input / 10000;

                if (Mode3 > 2) throw new ArgumentException($"Mode 3 is {Mode3}, should be in range 0 to 2");

                long interim = input % 10000;
                Mode2 = (int)interim / 1000;

                if (Mode2 > 2) throw new ArgumentException($"Mode 2 is {Mode3}, should be in range 0 to 2");

                interim = input % 1000;
                Mode1 = (int)interim / 100;

                if (Mode1 > 2) throw new ArgumentException($"Mode 1 is {Mode3}, should be in range 0 to 2");
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _25_Cryostasis(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_25_Cryostasis));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
        }
        #endregion
    }
}