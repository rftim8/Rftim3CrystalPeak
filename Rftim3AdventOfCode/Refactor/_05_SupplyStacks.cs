using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _05_SupplyStacks : I_05_SupplyStacks
    {
        #region Static
        private readonly List<string>? data;

        public _05_SupplyStacks()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_05_SupplyStacks));
        }

        /// <summary>
        /// T he expedition can depart as soon as the final supplies have been unloaded from the ships.Supplies are stored in stacks of marked crates, but because the needed supplies are buried under many other crates, the crates need to be rearranged.
        /// The ship has a giant cargo crane capable of moving crates between stacks.To ensure none of the crates get crushed or fall over, the crane operator will rearrange them in a series of carefully-planned steps. After the crates are rearranged, the desired crates will be at the top of each stack.
        /// The Elves don't want to interrupt the crane operator during this delicate procedure, but they forgot to ask her which crate will end up where, and they want to be ready to unload them as soon as possible so they can embark.
        /// They do, however, have a drawing of the starting stacks of crates and the rearrangement procedure (your puzzle input). For example:
        /// 
        ///     [D]
        /// [N][C]
        /// [Z][M][P]
        ///  1   2   3 
        /// 
        /// move 1 from 2 to 1
        /// move 3 from 1 to 3
        /// move 2 from 2 to 1
        /// move 1 from 1 to 2
        /// In this example, there are three stacks of crates. Stack 1 contains two crates: crate Z is on the bottom, and crate N is on top. Stack 2 contains three crates; from bottom to top, they are crates M, C, and D. Finally, stack 3 contains a single crate, P.
        /// 
        /// Then, the rearrangement procedure is given. In each step of the procedure, a quantity of crates is moved from one stack to a different stack. In the first step of the above rearrangement procedure, one crate is moved from stack 2 to stack 1, resulting in this configuration:
        /// 
        /// [D]
        /// [N]
        /// [C]
        ///  * [Z]
        /// [M]
        /// [P]
        ///   1   2   3 
        ///  In the second step, three crates are moved from stack 1 to stack 3. Crates are moved one at a time, so the first crate to be moved (D) ends up below the second and third crates:
        ///  
        ///          [Z]
        /// [N]
        /// [C][D]
        /// [M][P]
        ///   1   2   3
        ///  Then, both crates are moved from stack 2 to stack 1. Again, because crates are moved one at a time, crate C ends up below crate M:
        ///  
        ///          [Z]
        /// [N]
        /// [M][D]
        /// [C][P]
        ///   1   2   3
        ///  Finally, one crate is moved from stack 1 to stack 2:
        ///  
        ///          [Z]
        /// [N]
        /// [D]
        /// [C][M][P]
        ///   1   2   3
        ///  The Elves just need to know which crate will end up on top of each stack; in this example, the top crates are C in stack 1, M in stack 2, and Z in stack 3, so you should combine these together and give the Elves the message CMZ.
        /// 
        ///  After the rearrangement procedure completes, what crate ends up on top of each stack?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            string a = string.Empty;

            List<StackAoC> stacks =
            [
                new StackAoC("1", []),
                new StackAoC("2", []),
                new StackAoC("3", []),
                new StackAoC("4", []),
                new StackAoC("5", []),
                new StackAoC("6", []),
                new StackAoC("7", []),
                new StackAoC("8", []),
                new StackAoC("9", [])
            ];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (j == 0)
                    {
                        if (input[i][j + 1] != ' ') stacks[0].x.Add(input[i][j + 1].ToString());
                    }
                    else
                    {
                        if (j % 4 == 0)
                        {
                            foreach (StackAoC item in stacks)
                            {
                                if (item.name == (j / 4 + 1).ToString())
                                {
                                    if (input[i][j + 1] != ' ') item.x.Add(input[i][j + 1].ToString());
                                }
                            }
                        }
                    }
                }
            }

            foreach (StackAoC item in stacks)
            {
                item.x.Reverse();
            }

            for (int i = 10; i < input.Count; i++)
            {
                int q = int.Parse(input[i].Split(' ')[1]);
                string s = input[i].Split(' ')[3];
                string r = input[i].Split(' ')[5];

                foreach (StackAoC item in stacks)
                {
                    if (item.name == s)
                    {
                        foreach (StackAoC item1 in stacks)
                        {
                            if (item1.name == r)
                            {
                                for (int j = 0; j < q; j++)
                                {
                                    item1.x.Add(item.x.Last());
                                    item.x.RemoveAt(item.x.Count - 1);
                                }
                            }
                        }
                    }
                }


                foreach (StackAoC item in stacks)
                {
                    Console.WriteLine(item.name);
                    foreach (string item1 in item.x)
                    {
                        Console.Write($"{item1} ");
                    }
                    Console.WriteLine();
                }

            }

            foreach (StackAoC item in stacks)
            {
                a += item.x[^1];
            }

            return a;
        }

        /// <summary>
        /// As you watch the crane operator expertly rearrange the crates, you notice the process isn't following your prediction.
        ///  
        ///  Some mud was covering the writing on the side of the crane, and you quickly wipe it away. The crane isn't a CrateMover 9000 - it's a CrateMover 9001.
        ///  
        ///  The CrateMover 9001 is notable for many new and exciting features: air conditioning, leather seats, an extra cup holder, and the ability to pick up and move multiple crates at once.
        /// 
        ///  Again considering the example above, the crates begin in the same configuration:
        ///  
        ///      [D]
        /// [N][C]
        /// [Z][M][P]
        ///   1   2   3 
        ///  Moving a single crate from stack 2 to stack 1 behaves the same as before:
        ///  
        ///  [D]
        /// [N][C]
        /// [Z][M][P]
        ///   1   2   3 
        ///  However, the action of moving three crates from stack 1 to stack 3 means that those three moved crates stay in the same order, resulting in this new configuration:
        /// 
        ///          [D]
        /// [N]
        /// [C][Z]
        /// [M][P]
        ///   1   2   3
        ///  Next, as both crates are moved from stack 2 to stack 1, they retain their order as well:
        ///  
        ///        [D]
        /// [N]
        /// [C][Z]
        /// [M][P]
        ///   1   2   3
        ///  Finally, a single crate is still moved from stack 1 to stack 2, but now it's crate C that gets moved:
        ///  
        ///          [D]
        /// [N]
        /// [Z]
        /// [M][C][P]
        ///  1   2   3
        ///  In this example, the CrateMover 9001 has put the crates in a totally different order: MCD.
        /// 
        /// Before the rearrangement process finishes, update your simulation so that the Elves know where they should stand to be ready to unload the final supplies. After the rearrangement procedure completes, what crate ends up on top of each stack?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string a = string.Empty;

            List<StackAoC> stacks =
            [
                new StackAoC("1", []),
                new StackAoC("2", []),
                new StackAoC("3", []),
                new StackAoC("4", []),
                new StackAoC("5", []),
                new StackAoC("6", []),
                new StackAoC("7", []),
                new StackAoC("8", []),
                new StackAoC("9", [])
            ];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (j == 0)
                    {
                        if (input[i][j + 1] != ' ') stacks[0].x.Add(input[i][j + 1].ToString());
                    }
                    else
                    {
                        if (j % 4 == 0)
                        {
                            foreach (StackAoC item in stacks)
                            {
                                if (item.name == (j / 4 + 1).ToString())
                                {
                                    if (input[i][j + 1] != ' ') item.x.Add(input[i][j + 1].ToString());
                                }
                            }
                        }
                    }
                }
            }

            foreach (StackAoC item in stacks)
            {
                item.x.Reverse();
            }

            for (int i = 10; i < input.Count; i++)
            {
                int q = int.Parse(input[i].Split(' ')[1]);
                string s = input[i].Split(' ')[3];
                string r = input[i].Split(' ')[5];

                foreach (StackAoC item in stacks)
                {
                    if (item.name == s)
                    {
                        foreach (StackAoC item1 in stacks)
                        {
                            if (item1.name == r)
                            {
                                for (int j = q - 1; j >= 0; j--)
                                {
                                    item1.x.Add(item.x[item.x.Count - 1 - j]);
                                    item.x.RemoveAt(item.x.Count - 1 - j);
                                }
                            }
                        }
                    }
                }


                foreach (StackAoC item in stacks)
                {
                    Console.WriteLine(item.name);
                    foreach (string item1 in item.x)
                    {
                        Console.Write($"{item1} ");
                    }
                    Console.WriteLine();
                }

            }

            foreach (StackAoC item in stacks)
            {
                a += item.x[^1];
            }

            return a;
        }
        
        private class StackAoC(string name, List<string> x)
        {
            public string name = name;
            public List<string> x = x;
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _05_SupplyStacks(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_05_SupplyStacks));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}