using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Numerics;

namespace Rftim3AdventOfCode.Refactor
{
    public class _09_SensorBoost : I_09_SensorBoost
    {
        #region Static
        private readonly List<string>? data;

        public _09_SensorBoost()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_09_SensorBoost));
        }

        /// <summary>
        /// You've just said goodbye to the rebooted rover and left Mars when you receive a faint distress signal coming from the asteroid belt. 
        /// It must be the Ceres monitoring station!
        /// 
        /// In order to lock on to the signal, you'll need to boost your sensors. The Elves send up the latest BOOST program - Basic Operation Of System Test.
        /// 
        /// While BOOST(your puzzle input) is capable of boosting your sensors, for tenuous safety reasons, 
        /// it refuses to do so until the computer it runs on passes some checks to demonstrate it is a complete Intcode computer.
        /// 
        /// Your existing Intcode computer is missing one key feature: it needs support for parameters in relative mode.
        /// 
        /// Parameters in mode 2, relative mode, behave very similarly to parameters in position mode: the parameter is interpreted as a position.
        /// Like position mode, parameters in relative mode can be read from or written to.
        /// 
        /// The important difference is that relative mode parameters don't count from address 0. Instead, they count from a value called the relative base.
        /// The relative base starts at 0.
        /// 
        /// The address a relative mode parameter refers to is itself plus the current relative base. When the relative base is 0, 
        /// relative mode parameters and position mode parameters with the same value refer to the same address.
        /// 
        /// For example, given a relative base of 50, a relative mode parameter of -7 refers to memory address 50 + -7 = 43.
        /// 
        /// The relative base is modified with the relative base offset instruction:
        /// 
        /// Opcode 9 adjusts the relative base by the value of its only parameter.The relative base increases (or decreases, if the value is negative) by the value of the parameter.
        /// For example, if the relative base is 2000, then after the instruction 109,19, the relative base would be 2019. 
        /// If the next instruction were 204,-34, then the value at address 1985 would be output.
        /// 
        /// Your Intcode computer will also need a few other capabilities:
        /// 
        /// The computer's available memory should be much larger than the initial program.
        /// Memory beyond the initial program starts with the value 0 and can be read or written like any other memory.
        /// (It is invalid to try to access memory at a negative address, though.)
        /// The computer should have support for large numbers. Some instructions near the beginning of the BOOST program will verify this capability.
        /// Here are some example programs that use these features:
        /// 
        /// 109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99 takes no input and produces a copy of itself as output.
        /// 1102,34915192,34915192,7,4,7,99,0 should output a 16-digit number.
        /// 104,1125899906842624,99 should output the large number in the middle.
        /// The BOOST program will ask for a single input; run it in test mode by providing it the value 1. It will perform a series of checks on each opcode, 
        /// output any opcodes(and the associated parameter modes) that seem to be functioning incorrectly, and finally output a BOOST keycode.
        /// Once your Intcode computer is fully functional, the BOOST program should report no malfunctioning opcodes when run in test mode; 
        /// it should only output a single value, the BOOST keycode.What BOOST keycode does it produce?
        /// </summary>
        [Benchmark]
        public BigInteger PartOne() => PartOne0(data!);

        private static BigInteger PartOne0(List<string> input0)
        {
            List<BigInteger> input = input0[0].Split(',').Select(BigInteger.Parse).ToList();

            Intcode m = new(input);
            m.SendInput(1);
            m.Run();

            return m.r;
        }

        /// <summary>
        /// You now have a complete Intcode computer.
        /// 
        /// Finally, you can lock on to the Ceres distress signal! You just need to boost your sensors using the BOOST program.
        /// 
        /// The program runs in sensor boost mode by providing the input instruction the value 2. 
        /// Once run, it will boost the sensors automatically, but it might take a few seconds to complete the operation on slower hardware.
        /// In sensor boost mode, the program will output a single value: the coordinates of the distress signal.
        /// 
        /// 
        /// Run the BOOST program in sensor boost mode.What are the coordinates of the distress signal?
        /// </summary>        
        [Benchmark]
        public BigInteger PartTwo() => PartTwo0(data!);

        private static BigInteger PartTwo0(List<string> input0)
        {
            List<BigInteger> input = input0[0].Split(',').Select(BigInteger.Parse).ToList();

            Intcode m = new(input);
            m.SendInput(2);
            m.Run();

            return m.r;
        }

        private class Intcode
        {
            public BigInteger r = 0;
            public List<BigInteger> inputQueue = [];
            public BigInteger output = 0;

            public Intcode? outputDest;

            public List<BigInteger> memory;
            public int ip = 0;
            public int rb = 0;

            public bool waiting = false;
            public bool halted = false;
            public bool sentOutput = false;

            public int id = 0;
            public static int nextID = 0;

            public Intcode(List<BigInteger> initialMemory)
            {
                id = nextID;
                nextID++;
                memory = new List<BigInteger>(initialMemory);
            }

            public void SendInput(BigInteger input)
            {
                inputQueue.Add(input);
                waiting = false;
            }

            public void Output(BigInteger i)
            {
                output = i;
                if (outputDest != null) outputDest.SendInput(i);
                else r = i;

                sentOutput = true;
            }

            private BigInteger Memget(int address)
            {
                if (address < memory.Count) return memory[address];
                else return 0;
            }

            private BigInteger Memget(BigInteger address) => Memget((int)address);

            private void Memset(BigInteger address, BigInteger value)
            {
                while (address >= memory.Count)
                {
                    memory.Add(0);
                }

                memory[(int)address] = value;

            }

            private int AccessMode(int idx)
            {
                int mode = (int)Memget(ip) / 100;
                for (int i = 1; i < idx; i++)
                {
                    mode /= 10;
                }

                return mode % 10;
            }

            public void SetValue(int idx, BigInteger value)
            {
                BigInteger param = Memget(ip + idx);
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

            public BigInteger GetValue(int idx)
            {
                BigInteger param = Memget(ip + idx);
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
                        SetValue(3, GetValue(1) + GetValue(2));
                        ip += 4;
                        break;
                    case 2:
                        SetValue(3, GetValue(1) * GetValue(2));
                        ip += 4;
                        break;
                    case 3:
                        if (inputQueue.Count > 0)
                        {
                            SetValue(1, inputQueue[0]);
                            inputQueue.RemoveAt(0);
                            ip += 2;
                        }
                        else waiting = true;
                        break;
                    case 4:
                        Output(GetValue(1));
                        ip += 2;
                        break;
                    case 5:
                        if (GetValue(1) == 0) ip += 3;
                        else ip = (int)GetValue(2);
                        break;
                    case 6:
                        if (GetValue(1) == 0) ip = (int)GetValue(2);
                        else ip += 3;
                        break;
                    case 7:
                        if (GetValue(1) < GetValue(2)) SetValue(3, 1);
                        else SetValue(3, 0);
                        ip += 4;
                        break;
                    case 8:
                        if (GetValue(1) == GetValue(2)) SetValue(3, 1);
                        else SetValue(3, 0);
                        ip += 4;
                        break;
                    case 9:
                        rb += (int)GetValue(1);
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

                if (waiting) { }
            }
        }
        #endregion

        #region UnitTest
        public static BigInteger PartOne_Test(List<string> data) => PartOne0(data);

        public static BigInteger PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _09_SensorBoost(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_09_SensorBoost));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}