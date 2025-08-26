using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _23_OpeningTheTuringLock : I_23_OpeningTheTuringLock
    {
        #region Static
        private readonly List<string>? data;

        public _23_OpeningTheTuringLock()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_23_OpeningTheTuringLock));
        }

        /// <summary>
        /// Little Jane Marie just got her very first computer for Christmas from some unknown benefactor. 
        /// It comes with instructions and an example program, but the computer itself seems to be malfunctioning. 
        /// She's curious what the program does, and would like you to help her run it.
        /// 
        /// The manual explains that the computer supports two registers and six instructions(truly, it goes on to remind the reader, a state-of-the-art technology). 
        /// The registers are named a and b, can hold any non-negative integer, and begin with a value of 0. The instructions are as follows:
        /// 
        /// hlf r sets register r to half its current value, then continues with the next instruction.
        /// tpl r sets register r to triple its current value, then continues with the next instruction.
        /// inc r increments register r, adding 1 to it, then continues with the next instruction.
        /// jmp offset is a jump; it continues with the instruction offset away relative to itself.
        /// jie r, offset is like jmp, but only jumps if register r is even ("jump if even").
        /// jio r, offset is like jmp, but only jumps if register r is 1 ("jump if one", not odd).
        /// All three jump instructions work with an offset relative to that instruction.
        /// The offset is always written with a prefix + or - to indicate the direction of the jump (forward or backward, respectively).
        /// For example, jmp +1 would simply continue with the next instruction, while jmp +0 would continuously jump back to itself forever.
        /// 
        /// The program exits when it tries to run an instruction beyond the ones defined.
        /// 
        /// For example, this program sets a to 2, because the jio instruction causes it to skip the tpl instruction:
        /// 
        /// inc a
        /// jio a, +2
        /// tpl a
        /// inc a
        /// 
        /// What is the value in register b when the program in your puzzle input is finished executing?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Dictionary<string, int> kvp = [];
            kvp.Add("a", 0);
            kvp.Add("b", 0);

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(i);
                int n = input[i].Split(' ').Length;
                string command = input[i].Split(' ')[0];
                int c = 0;
                string location = string.Empty;
                if (n == 2)
                {
                    string t = input[i].Split(' ')[1];
                    if (t.Length == 1) location = t;
                    else c = int.Parse(t.Replace("+", ""));
                }
                else
                {
                    location = input[i].Split(' ')[1].Replace(",", "");
                    string t = input[i].Split(' ')[2];
                    c = int.Parse(t.Replace("+", ""));
                }
                Console.WriteLine($"{command}: {location} {c}");

                switch (command)
                {
                    case "inc":
                        kvp[location]++;
                        break;
                    case "hlf":
                        kvp[location] /= 2;
                        break;
                    case "tpl":
                        kvp[location] *= 3;
                        break;
                    case "jmp":
                        i += c - 1;
                        break;
                    case "jie":
                        if (kvp[location] % 2 == 0)
                        {
                            i += c;
                            i--;
                        }
                        break;
                    case "jio":
                        if (kvp[location] == 1)
                        {
                            i += c;
                            i--;
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"{kvp["a"]} {kvp["b"]}");
                Console.WriteLine();
            }

            return kvp["b"];
        }

        /// <summary>
        /// The unknown benefactor is very thankful for releasi-- er, helping little Jane Marie with her computer. 
        /// Definitely not to distract you, what is the value in register b after the program is finished executing if register a starts as 1 instead?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            Dictionary<string, int> kvp = [];
            kvp.Add("a", 1);
            kvp.Add("b", 0);

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(i);
                int n = input[i].Split(' ').Length;
                string command = input[i].Split(' ')[0];
                int c = 0;
                string location = string.Empty;
                if (n == 2)
                {
                    string t = input[i].Split(' ')[1];
                    if (t.Length == 1) location = t;
                    else c = int.Parse(t.Replace("+", ""));
                }
                else
                {
                    location = input[i].Split(' ')[1].Replace(",", "");
                    string t = input[i].Split(' ')[2];
                    c = int.Parse(t.Replace("+", ""));
                }
                Console.WriteLine($"{command}: {location} {c}");

                switch (command)
                {
                    case "inc":
                        kvp[location]++;
                        break;
                    case "hlf":
                        kvp[location] /= 2;
                        break;
                    case "tpl":
                        kvp[location] *= 3;
                        break;
                    case "jmp":
                        i += c - 1;
                        break;
                    case "jie":
                        if (kvp[location] % 2 == 0)
                        {
                            i += c;
                            i--;
                        }
                        break;
                    case "jio":
                        if (kvp[location] == 1)
                        {
                            i += c;
                            i--;
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"{kvp["a"]} {kvp["b"]}");
                Console.WriteLine();
            }

            return kvp["b"];
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _23_OpeningTheTuringLock(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_23_OpeningTheTuringLock));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}