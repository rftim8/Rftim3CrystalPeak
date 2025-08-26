using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _07_HandyHaversacks : I_07_HandyHaversacks
    {
        #region Static
        private readonly List<string>? data;

        public _07_HandyHaversacks()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_HandyHaversacks));
        }

        /// <summary>
        /// You land at the regional airport in time for your next flight. In fact, it looks like you'll even have time to grab some food: 
        /// all flights are currently delayed due to issues in luggage processing.
        /// 
        /// Due to recent aviation regulations, many rules(your puzzle input) are being enforced about bags and their contents; 
        /// bags must be color-coded and must contain specific quantities of other color-coded bags.
        /// Apparently, nobody responsible for these regulations considered how long they would take to enforce!
        /// 
        /// For example, consider the following rules:
        /// 
        /// light red bags contain 1 bright white bag, 2 muted yellow bags.
        /// dark orange bags contain 3 bright white bags, 4 muted yellow bags.
        /// bright white bags contain 1 shiny gold bag.
        /// muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
        /// shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
        /// dark olive bags contain 3 faded blue bags, 4 dotted black bags.
        /// vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
        /// faded blue bags contain no other bags.
        /// dotted black bags contain no other bags.
        /// These rules specify the required contents for 9 bag types. In this example, every faded blue bag is empty,
        /// every vibrant plum bag contains 11 bags (5 faded blue and 6 dotted black), and so on.
        /// You have a shiny gold bag.If you wanted to carry it in at least one other bag, how many different bag colors would be valid for the outermost bag? 
        /// (In other words: how many colors can, eventually, contain at least one shiny gold bag?)
        /// 
        /// In the above rules, the following options would be available to you:
        /// 
        /// A bright white bag, which can hold your shiny gold bag directly.
        ///         A muted yellow bag, which can hold your shiny gold bag directly, plus some other bags.
        /// A dark orange bag, which can hold bright white and muted yellow bags, either of which could then hold your shiny gold bag.
        /// A light red bag, which can hold bright white and muted yellow bags, either of which could then hold your shiny gold bag.
        /// So, in this example, the number of bag colors that can eventually contain at least one shiny gold bag is 4.
        /// 
        /// How many bag colors can eventually contain at least one shiny gold bag? (The list of rules is quite long; make sure you get all of it.)
        /// </summary> 
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            const string MyBag = "shiny gold";

            Regex re = MyRegex();

            Dictionary<string, Dictionary<string, int>> contains = input
                .Select(l => re.Match(l))
                .ToDictionary(
                    m => m.Groups[1].Value,
                    m => m.Groups[2].Captures.OfType<Capture>()
                        .Select(c => c.Value.Split([' '], 2))
                        .ToDictionary(a => a[1], a => int.Parse(a[0])));

            bool CanContain(string colour) => contains[colour].ContainsKey(MyBag) || contains[colour].Keys.Any(CanContain);

            return contains.Keys.Count(CanContain);
        }

        /// <summary>
        /// It's getting pretty expensive to fly these days - not because of ticket prices, but because of the ridiculous number of bags you need to buy!
        /// 
        /// Consider again your shiny gold bag and the rules from the above example:
        /// 
        /// faded blue bags contain 0 other bags.
        /// dotted black bags contain 0 other bags.
        /// vibrant plum bags contain 11 other bags: 5 faded blue bags and 6 dotted black bags.
        /// dark olive bags contain 7 other bags: 3 faded blue bags and 4 dotted black bags.
        /// So, a single shiny gold bag must contain 1 dark olive bag (and the 7 bags within it) plus 2 vibrant plum 
        /// bags(and the 11 bags within each of those) : 1 + 1*7 + 2 + 2*11 = 32 bags!
        /// 
        /// Of course, the actual rules have a small chance of going several levels deeper than this example;
        /// be sure to count all of the bags, even if the nesting becomes topologically impractical!
        /// 
        /// Here's another example:
        /// 
        /// shiny gold bags contain 2 dark red bags.
        /// dark red bags contain 2 dark orange bags.
        /// dark orange bags contain 2 dark yellow bags.
        /// dark yellow bags contain 2 dark green bags.
        /// dark green bags contain 2 dark blue bags.
        /// dark blue bags contain 2 dark violet bags.
        /// dark violet bags contain no other bags.
        /// In this example, a single shiny gold bag must contain 126 other bags.
        /// 
        /// How many individual bags are required inside your single shiny gold bag?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            const string MyBag = "shiny gold";

            Regex re = MyRegex();

            Dictionary<string, Dictionary<string, int>> contains = input
                .Select(l => re.Match(l))
                .ToDictionary(
                    m => m.Groups[1].Value,
                    m => m.Groups[2].Captures.OfType<Capture>()
                        .Select(c => c.Value.Split([' '], 2))
                        .ToDictionary(a => a[1], a => int.Parse(a[0])));

            bool CanContain(string colour) => contains[colour].ContainsKey(MyBag) || contains[colour].Keys.Any(CanContain);

            int MustContain(string colour) => contains[colour].Sum(kvp => kvp.Value * (1 + MustContain(kvp.Key)));

            return MustContain(MyBag);
        }

        [GeneratedRegex(@"(.*?) bags contain(?: (\d+ .*?) bag(?:s)?[,.])*")]
        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _07_HandyHaversacks(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_HandyHaversacks));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}