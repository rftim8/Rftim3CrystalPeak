using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _08_HauntedWasteland : I_08_HauntedWasteland
    {
        #region Static
        private readonly List<string>? data;

        public _08_HauntedWasteland()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_08_HauntedWasteland));
        }

        /// <summary>
        /// You're still riding a camel across Desert Island when you spot a sandstorm quickly approaching. 
        /// When you turn to warn the Elf, she disappears before your eyes! To be fair, she had just finished warning you about ghosts a few minutes ago.
        /// 
        /// One of the camel's pouches is labeled "maps" - sure enough, it's full of documents(your puzzle input) about how to navigate the desert.
        /// At least, you're pretty sure that's what they are; one of the documents contains a list of left/right instructions,
        /// and the rest of the documents seem to describe some kind of network of labeled nodes.
        /// 
        /// It seems like you're meant to use the left/right instructions to navigate the network.
        /// Perhaps if you have the camel follow the same instructions, you can escape the haunted wasteland!
        /// 
        /// After examining the maps for a bit, two nodes stick out: AAA and ZZZ.
        /// You feel like AAA is where you are now, and you have to follow the left/right instructions until you reach ZZZ.
        /// 
        /// This format defines each node of the network individually. For example:
        /// 
        /// RL
        /// 
        /// AAA = (BBB, CCC)
        /// BBB = (DDD, EEE)
        /// CCC = (ZZZ, GGG)
        /// DDD = (DDD, DDD)
        /// EEE = (EEE, EEE)
        /// GGG = (GGG, GGG)
        /// ZZZ = (ZZZ, ZZZ)
        /// Starting with AAA, you need to look up the next element based on the next left/right instruction in your input. 
        /// In this example, start with AAA and go right (R) by choosing the right element of AAA, CCC.
        /// Then, L means to choose the left element of CCC, ZZZ.By following the left/right instructions, you reach ZZZ in 2 steps.
        /// 
        /// Of course, you might not find ZZZ right away.
        /// If you run out of left/right instructions, repeat the whole sequence of instructions as necessary: RL really means RLRLRLRLRLRLRLRL... and so on.
        /// For example, here is a situation that takes 6 steps to reach ZZZ:
        /// 
        /// LLR
        /// 
        /// AAA = (BBB, BBB)
        /// BBB = (AAA, ZZZ)
        /// ZZZ = (ZZZ, ZZZ)
        /// Starting at AAA, follow the left/right instructions. How many steps are required to reach ZZZ?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int n = input.Count;
            int m = input[0].Length;
            string t = "";

            int start = 0;
            for (int i = 2; i < n; i++)
            {
                if (input[i].Split(" ")[0] == "AAA") start = i;
            }

            (string c0, string c1) = (input[start].Split(" ")[2].Replace("(", "").Replace(",", ""), input[start].Split(" ")[3].Replace(")", "").Replace(",", ""));

            int r = 0, r0 = 0;
            for (int i = start + 1; i < n; i++)
            {
                if (t == "ZZZ") return r;
                string a = input[i].Split(" ")[0];

                (string x, string y) = (input[i].Split(" ")[2].Replace("(", "").Replace(",", ""), input[i].Split(" ")[3].Replace(")", "").Replace(",", ""));

                if (input[0][r0] == 'R' && a == c1)
                {
                    r0++;
                    r++;
                    t = a;
                    (c0, c1) = (x, y);
                }
                else if (input[0][r0] == 'L' && a == c0)
                {
                    r0++;
                    r++;
                    t = a;
                    (c0, c1) = (x, y);
                }

                if (r0 > m - 1) r0 = 0;
                if (i == n - 1) i = 1;
            }

            return r;
        }

        /// <summary>
        /// The sandstorm is upon you and you aren't any closer to escaping the wasteland. 
        /// You had the camel follow the instructions, but you've barely left your starting position. It's going to take significantly more steps to escape!
        /// 
        /// What if the map isn't for people - what if the map is for ghosts? Are ghosts even bound by the laws of spacetime? Only one way to find out.
        /// 
        /// After examining the maps a bit longer, your attention is drawn to a curious fact: the number of nodes with names ending in A is equal to the number ending in Z! 
        /// If you were a ghost, you'd probably just start at every node that ends with A and follow all of the paths at the same time until they all simultaneously end up
        /// at nodes that end with Z.
        /// 
        /// For example:
        /// 
        /// LR
        /// 
        /// 11A = (11B, XXX)
        /// 11B = (XXX, 11Z)
        /// 11Z = (11B, XXX)
        /// 22A = (22B, XXX)
        /// 22B = (22C, 22C)
        /// 22C = (22Z, 22Z)
        /// 22Z = (22B, 22B)
        /// XXX = (XXX, XXX)
        /// Here, there are two starting nodes, 11A and 22A(because they both end with A). 
        /// As you follow each left/right instruction, use that instruction to simultaneously navigate away from both nodes you're currently on.
        /// Repeat this process until all of the nodes you're currently on end with Z. 
        /// (If only some of the nodes you're on end with Z, they act like any other node and you continue as normal.) In this example, you would proceed as follows:
        /// 
        /// Step 0: You are at 11A and 22A.
        /// Step 1: You choose all of the left paths, leading you to 11B and 22B.
        /// Step 2: You choose all of the right paths, leading you to 11Z and 22C.
        /// Step 3: You choose all of the left paths, leading you to 11B and 22Z.
        /// Step 4: You choose all of the right paths, leading you to 11Z and 22B.
        ///         Step 5: You choose all of the left paths, leading you to 11B and 22C.
        ///         Step 6: You choose all of the right paths, leading you to 11Z and 22Z.
        /// So, in this example, you end up entirely on nodes that end in Z after 6 steps.
        /// 
        /// Simultaneously start on every node that ends with A.How many steps does it take before you're only on nodes that end with Z?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            string[] instructions = input[0].ToCharArray().Select(char.ToString).ToArray();

            Dictionary<string, Node> nodes = [];

            Regex regex = MyRegex();

            List<string> currentNodeKeys = [];

            for (int i = 2; i < input.Count; i++)
            {
                string nodeStr = regex.Replace(input[i], string.Empty);
                string[] split = nodeStr.Split("=");
                string nodeKey = split[0];

                if (nodeKey.EndsWith('A')) currentNodeKeys.Add(nodeKey);

                string[] branchSplit = split[1].Split(",");
                Node branch = new(branchSplit[0], branchSplit[1]);
                nodes[nodeKey] = branch;
            }

            long[] outputs = new long[currentNodeKeys.Count];

            for (int i = 0; i < currentNodeKeys.Count; i++)
            {
                int currentInstruction = 0;
                while (true)
                {
                    if (currentNodeKeys[i].EndsWith('Z')) break;

                    string instruction = instructions[currentInstruction];

                    Node node = nodes[currentNodeKeys[i]];
                    currentNodeKeys[i] = instruction == "L" ? node.Left : node.Right;

                    currentInstruction = (currentInstruction + 1) % instructions.Length;
                    outputs[i]++;
                }
            }

            return LCMM(outputs);
        }

        private static long LCMM(long[] inputs)
        {
            if (inputs.Length == 2) return LCM(inputs[0], inputs[1]);
            else return LCM(inputs[0], LCMM(inputs.Skip(1).ToArray()));
        }

        private static long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private readonly struct Node(string left, string right)
        {
            public readonly string Left = left;
            public readonly string Right = right;
        }

        [GeneratedRegex("[)( ]")]
        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _08_HauntedWasteland(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_08_HauntedWasteland));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}