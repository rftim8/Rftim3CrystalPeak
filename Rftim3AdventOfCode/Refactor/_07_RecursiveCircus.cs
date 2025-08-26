using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _07_RecursiveCircus : I_07_RecursiveCircus
    {
        #region Static
        private readonly List<string>? data;

        public _07_RecursiveCircus()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_RecursiveCircus));
        }

        /// <summary>
        /// Wandering further through the circuits of the computer, you come upon a tower of programs that have gotten themselves into a bit of trouble.
        /// A recursive algorithm has gotten out of hand, and now they're balanced precariously in a large tower.
        /// 
        /// One program at the bottom supports the entire tower.It's holding a large disc, and on the disc are balanced several more sub-towers. 
        /// At the bottom of these sub-towers, standing on the bottom disc, are other programs, each holding their own disc, and so on. At the very tops of these sub-sub-sub-...-towers, many programs stand simply keeping the disc below them balanced but with no disc of their own.
        /// 
        /// You offer to help, but first you need to understand the structure of these towers.
        /// You ask each program to yell out their name, their weight, and (if they're holding a disc) the names of the programs immediately above them balancing on that disc. 
        /// You write this information down (your puzzle input).
        /// Unfortunately, in their panic, they don't do this in an orderly fashion; by the time you're done, you're not sure which program gave which information.
        /// 
        /// For example, if your list is the following:
        /// 
        /// pbga (66)
        /// xhth(57)
        /// ebii(61)
        /// havc(66)
        /// ktlj(57)
        /// fwft(72) -> ktlj, cntj, xhth
        ///         qoyq(66)
        /// padx(45) -> pbga, havc, qoyq
        /// tknk(41) -> ugml, padx, fwft
        /// jptl(61)
        /// ugml(68) -> gyxo, ebii, jptl
        /// gyxo(61)
        /// cntj(57)
        /// ...then you would be able to recreate the structure of the towers that looks like this:
        /// 
        ///                 gyxo
        ///               /     
        ///          ugml - ebii
        ///        /      \     
        ///       |         jptl
        ///       |        
        ///       |         pbga
        ///      /        /
        /// tknk --- padx - havc
        ///      \        \
        ///       |         qoyq
        ///       |             
        ///       |         ktlj
        ///        \      /     
        ///          fwft - cntj
        ///               \     
        ///                 xhth
        /// In this example, tknk is at the bottom of the tower (the bottom program), and is holding up ugml, padx, and fwft. 
        /// Those programs are, in turn, holding up other programs; in this example, none of those programs are holding up any other programs, and are all the tops of their own towers.
        /// (The actual tower balancing in front of you is much larger.)
        /// 
        /// Before you're ready to help them, you need to make sure your information is correct. What is the name of the bottom program?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            List<Disc> discs = input.Select(x => new Disc(x)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs));

            return GetBaseDisc(discs).Name;
        }

        /// <summary>
        /// The programs explain the situation: they can't get down. Rather, they could get down, if they weren't expending all of their energy trying to keep the tower balanced. 
        /// Apparently, one program has the wrong weight, and until it's fixed, they're stuck here.
        /// 
        /// For any program holding a disc, each program standing on that disc forms a sub-tower.
        /// Each of those sub-towers are supposed to be the same weight, or the disc itself isn't balanced. 
        /// The weight of a tower is the sum of the weights of the programs in that tower.
        /// 
        /// In the example above, this means that for ugml's disc to be balanced, gyxo, ebii, and jptl must all have the same weight, and they do: 61.
        /// 
        /// However, for tknk to be balanced, each of the programs standing on its disc and all programs above it must each match.
        /// This means that the following sums must all be the same:
        /// 
        /// ugml + (gyxo + ebii + jptl) = 68 + (61 + 61 + 61) = 251
        /// padx + (pbga + havc + qoyq) = 45 + (66 + 66 + 66) = 243
        /// fwft + (ktlj + cntj + xhth) = 72 + (57 + 57 + 57) = 243
        /// As you can see, tknk's disc is unbalanced: ugml's stack is heavier than the other two.
        /// Even though the nodes above ugml are balanced, ugml itself is too heavy: it needs to be 8 units lighter for its stack to weigh 243 and keep the towers balanced.
        /// If this change were made, its weight would be 60.
        /// 
        /// Given that exactly one program is the wrong weight, what would its weight need to be to balance the entire tower?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<Disc> discs = input.Select(x => new Disc(x)).ToList();
            discs.ForEach(x => x.AddChildDiscs(discs));

            Disc disc = GetBaseDisc(discs);
            int targetWeight = 0;

            while (!disc.IsBalanced())
            {
                (disc, targetWeight) = disc.GetUnbalancedChild();
            }

            int weightDiff = targetWeight - disc.GetTotalWeight();

            return disc.Weight + weightDiff;
        }

        private static Disc GetBaseDisc(IEnumerable<Disc> discs)
        {
            Disc disc = discs.First();

            while (disc.Parent != null)
            {
                disc = disc.Parent;
            }

            return disc;
        }

        private class Disc
        {
            public int Weight { get; private set; }
            public string Name { get; private set; }
            public List<string> ChildNames { get; private set; }
            public List<Disc>? ChildDiscs { get; private set; }
            public Disc? Parent { get; private set; }

            public Disc(string input)
            {
                List<string> words = [.. input.Split(' ')];

                Name = words[0];
                Weight = int.Parse(words[1].Replace("(", "").Replace(")", ""));
                ChildNames = [];

                if (words.Count > 2)
                {
                    for (int i = 3; i < words.Count; i++)
                    {
                        ChildNames.Add(words[i].Replace(",", "").Trim());
                    }
                }
            }

            public void AddChildDiscs(IEnumerable<Disc> discs)
            {
                ChildDiscs = ChildNames.Select(x => discs.First(y => y.Name == x)).ToList();
                ChildDiscs.ForEach(x => x.Parent = this);
            }

            public int GetTotalWeight()
            {
                int childSum = ChildDiscs!.Sum(x => x.GetTotalWeight());

                return childSum + Weight;
            }

            public bool IsBalanced()
            {
                IEnumerable<IGrouping<int, Disc>> groups = ChildDiscs!.GroupBy(x => x.GetTotalWeight());

                return groups.Count() == 1;
            }

            public (Disc disc, int targetWeight) GetUnbalancedChild()
            {
                IEnumerable<IGrouping<int, Disc>> groups = ChildDiscs!.GroupBy(x => x.GetTotalWeight());
                int targetWeight = groups.First(x => x.Count() > 1).Key;
                Disc unbalancedChild = groups.First(x => x.Count() == 1).First();

                return (unbalancedChild, targetWeight);
            }
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _07_RecursiveCircus(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_RecursiveCircus));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}