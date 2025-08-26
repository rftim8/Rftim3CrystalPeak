using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _14_ExtendedPolymerization : I_14_ExtendedPolymerization
    {
        #region Static
        private readonly List<string>? data;

        public _14_ExtendedPolymerization()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_14_ExtendedPolymerization));
        }

        /// <summary>
        /// The incredible pressures at this depth are starting to put a strain on your submarine. 
        /// The submarine has polymerization equipment that would produce suitable materials to reinforce the submarine, 
        /// and the nearby volcanically-active caves should even have the necessary input elements in sufficient quantities.
        /// 
        /// The submarine manual contains instructions for finding the optimal polymer formula; specifically, 
        /// it offers a polymer template and a list of pair insertion rules(your puzzle input). 
        /// You just need to work out what polymer would result after repeating the pair insertion process a few times.
        /// For example:
        /// 
        /// NNCB
        /// 
        /// CH -> B
        /// HH -> N
        /// CB -> H
        /// NH -> C
        /// HB -> C
        /// HC -> B
        /// HN -> C
        /// NN -> C
        /// BH -> H
        /// NC -> B
        /// NB -> B
        /// BN -> B
        /// BB -> N
        /// BC -> B
        /// CC -> N
        /// CN -> C
        /// The first line is the polymer template - this is the starting point of the process.
        /// The following section defines the pair insertion rules.A rule like AB -> C means that when elements A and B are immediately adjacent,
        /// element C should be inserted between them.These insertions all happen simultaneously.
        /// 
        /// So, starting with the polymer template NNCB, the first step simultaneously considers all three pairs:
        /// 
        /// The first pair (NN) matches the rule NN -> C, so element C is inserted between the first N and the second N.
        /// The second pair (NC) matches the rule NC -> B, so element B is inserted between the N and the C.
        /// The third pair (CB) matches the rule CB -> H, so element H is inserted between the C and the B.
        /// Note that these pairs overlap: the second element of one pair is the first element of the next pair.
        /// Also, because all pairs are considered simultaneously, inserted elements are not considered to be part of a pair until the next step.
        /// After the first step of this process, the polymer becomes NCNBCHB.
        /// 
        /// Here are the results of a few steps using the above rules:
        /// 
        /// Template:     NNCB
        /// After step 1: NCNBCHB
        /// After step 2: NBCCNBBBCBHCB
        /// After step 3: NBBBCNCCNBBNBNBBCHBHHBCHB
        /// After step 4: NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB
        /// This polymer grows quickly.After step 5, it has length 97; After step 10, it has length 3073. 
        /// After step 10, B occurs 1749 times, C occurs 298 times, H occurs 161 times, and N occurs 865 times; 
        /// taking the quantity of the most common element(B, 1749) and subtracting the quantity of the least common element(H, 161) produces 1749 - 161 = 1588.
        /// 
        /// Apply 10 steps of pair insertion to the polymer template and find the most and least common elements in the result.
        /// What do you get if you take the quantity of the most common element and subtract the quantity of the least common element?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            string polymer = input[0];

            Dictionary<string, string[]> generatedMolecules = (
                from line in input[1].Split("\r\n")
                let parts = line.Split(" -> ")
                select (molecule: parts[0], element: parts[1])
            ).ToDictionary(
                p => p.molecule,
                p => new string[] { p.molecule[0] + p.element, p.element + p.molecule[1] }
            );

            Dictionary<string, long> moleculeCount = (
                from i in Enumerable.Range(0, polymer.Length - 1)
                let molecule = polymer.Substring(i, 2)
                group molecule by molecule into g
                select (molecule: g.Key, count: (long)g.Count())
            ).ToDictionary(p => p.molecule, p => p.count);

            for (var i = 0; i < 10; i++)
            {
                moleculeCount = (
                    from kvp in moleculeCount
                    let molecule = kvp.Key
                    let count = kvp.Value
                    from generatedMolecule in generatedMolecules[molecule]
                    group count by generatedMolecule into g
                    select (newMolecule: g.Key, count: g.Sum())
                ).ToDictionary(g => g.newMolecule, g => g.count);
            }

            Dictionary<char, long> elementCounts = (
                from kvp in moleculeCount
                let molecule = kvp.Key
                let count = kvp.Value
                let element = molecule[0]
                group count by element into g
                select (element: g.Key, count: g.Sum())
            ).ToDictionary(kvp => kvp.element, kvp => kvp.count);

            elementCounts[polymer.Last()]++;

            return elementCounts.Values.Max() - elementCounts.Values.Min();
        }

        /// <summary>
        /// The resulting polymer isn't nearly strong enough to reinforce the submarine.
        /// You'll need to run more steps of the pair insertion process; a total of 40 steps should do it.
        /// 
        /// In the above example, the most common element is B(occurring 2192039569602 times) and the least common element is H(occurring 3849876073 times); 
        /// subtracting these produces 2188189693529.
        /// 
        /// Apply 40 steps of pair insertion to the polymer template and find the most and least common elements in the result.
        /// What do you get if you take the quantity of the most common element and subtract the quantity of the least common element?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            string polymer = input[0];
            Dictionary<string, string[]> generatedMolecules = (
            from line in input[1].Split("\r\n")
            let parts = line.Split(" -> ")
            select (molecule: parts[0], element: parts[1])
            ).ToDictionary(
            p => p.molecule,
            p => new string[] { p.molecule[0] + p.element, p.element + p.molecule[1] }
            );
            Dictionary<string, long> moleculeCount = (
            from i in Enumerable.Range(0, polymer.Length - 1)
            let molecule = polymer.Substring(i, 2)
            group molecule by molecule into g
            select (molecule: g.Key, count: (long)g.Count())
            ).ToDictionary(p => p.molecule, p => p.count);
            for (var i = 0; i < 40; i++)
            {
                moleculeCount = (
                from kvp in moleculeCount
                let molecule = kvp.Key
                let count = kvp.Value
                from generatedMolecule in generatedMolecules[molecule]
                group count by generatedMolecule into g
                select (newMolecule: g.Key, count: g.Sum())
                ).ToDictionary(g => g.newMolecule, g => g.count);
            }

            Dictionary<char, long> elementCounts = (
                from kvp in moleculeCount
                let molecule = kvp.Key
                let count = kvp.Value
                let element = molecule[0]
                group count by element into g
                select (element: g.Key, count: g.Sum())
            ).ToDictionary(kvp => kvp.element, kvp => kvp.count);

            elementCounts[polymer.Last()]++;

            return elementCounts.Values.Max() - elementCounts.Values.Min();
        }
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _14_ExtendedPolymerization(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_14_ExtendedPolymerization));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}