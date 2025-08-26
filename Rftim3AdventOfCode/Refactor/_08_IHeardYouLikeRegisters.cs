using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _08_IHeardYouLikeRegisters : I_08_IHeardYouLikeRegisters
    {
        #region Static
        private readonly List<string>? data;

        public _08_IHeardYouLikeRegisters()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_08_IHeardYouLikeRegisters));
        }

        /// <summary>
        /// You receive a signal directly from the CPU. Because of your recent assistance with jump instructions,
        /// it would like you to compute the result of a series of unusual register instructions.
        /// 
        /// Each instruction consists of several parts: the register to modify, whether to increase or decrease that register's value, 
        /// the amount by which to increase or decrease it, and a condition. 
        /// If the condition fails, skip the instruction without modifying the register. The registers all start at 0. The instructions look like this:
        /// 
        /// b inc 5 if a > 1
        /// a inc 1 if b< 5
        /// c dec -10 if a >= 1
        /// c inc -20 if c == 10
        /// These instructions would be processed as follows:
        /// 
        /// Because a starts at 0, it is not greater than 1, and so b is not modified.
        /// a is increased by 1 (to 1) because b is less than 5 (it is 0).
        /// c is decreased by -10 (to 10) because a is now greater than or equal to 1 (it is 1).
        /// c is increased by -20 (to -10) because c is equal to 10.
        /// After this process, the largest value in any register is 1.
        /// 
        /// You might also encounter <= (less than or equal to) or != (not equal to). 
        /// However, the CPU doesn't have the bandwidth to tell you what all the registers are named, and leaves that to you to determine.
        /// 
        /// What is the largest value in any register after completing the instructions in your puzzle input?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Dictionary<string, int> registers = [];

            int max = 0;

            foreach (string line in input)
            {
                string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = values[0];
                if (!registers.TryGetValue(name, out int amount)) registers.Add(name, 0);

                bool increase = values[1] == "inc";
                int delta = Convert.ToInt32(values[2]);

                string otherName = values[4];
                if (!registers.TryGetValue(otherName, out int otherAmount)) registers.Add(otherName, 0);

                string comparisonOp = values[5];
                int compareAmount = Convert.ToInt32(values[6]);

                if (Compare(otherAmount, compareAmount, comparisonOp))
                {
                    if (increase)
                    {
                        registers[name] += delta;
                        max = Math.Max(registers[name], max);
                    }
                    else
                    {
                        registers[name] -= delta;
                        max = Math.Max(registers[name], max);
                    }
                }
            }
            max = registers.Values.Max();

            return max;
        }

        /// <summary>
        /// To be safe, the CPU also needs to know the highest value held in any register during this process so that it can decide how much memory to allocate to these operations.
        /// For example, in the above instructions, the highest value ever held was 10 (in register c after the third instruction was evaluated).
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            Dictionary<string, int> registers = [];

            int max = 0;

            foreach (string line in input)
            {
                string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = values[0];
                if (!registers.TryGetValue(name, out int amount)) registers.Add(name, 0);

                bool increase = values[1] == "inc";
                int delta = Convert.ToInt32(values[2]);

                string otherName = values[4];
                if (!registers.TryGetValue(otherName, out int otherAmount)) registers.Add(otherName, 0);

                string comparisonOp = values[5];
                int compareAmount = Convert.ToInt32(values[6]);

                if (Compare(otherAmount, compareAmount, comparisonOp))
                {
                    if (increase)
                    {
                        registers[name] += delta;
                        max = Math.Max(registers[name], max);
                    }
                    else
                    {
                        registers[name] -= delta;
                        max = Math.Max(registers[name], max);
                    }
                }
            }

            return max;
        }

        private static bool Compare(int first, int second, string op)
        {
            return op switch
            {
                ">" => first > second,
                ">=" => first >= second,
                "<" => first < second,
                "<=" => first <= second,
                "==" => first == second,
                "!=" => first != second,
                _ => false,
            };
        }

        private static List<string> ParseInput(string line, string stringSeperator)
        {
            return [.. line.Split([stringSeperator], StringSplitOptions.RemoveEmptyEntries)];
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _08_IHeardYouLikeRegisters(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_08_IHeardYouLikeRegisters));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}