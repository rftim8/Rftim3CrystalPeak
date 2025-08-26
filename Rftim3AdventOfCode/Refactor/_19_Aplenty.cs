using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rules = System.Collections.Generic.Dictionary<string, string>;
using Cube = System.Collections.Immutable.ImmutableArray<Range>;
using System.Collections.Immutable;
using System.Numerics;
using System.Text.RegularExpressions;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

record Range(int Begin, int End);

record Cond(int Dim, int Num, string Jmp);

namespace Rftim3AdventOfCode
{
    public partial class _19_Aplenty : I_19_Aplenty
    {
        #region Static
        private readonly List<string>? data;

        public _19_Aplenty()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_19_Aplenty));
        }

        /// <summary>
        /// The Elves of Gear Island are thankful for your help and send you on your way. They even have a hang glider that someone 
        /// stole from Desert Island; since you're already going that direction, it would help them a lot if you would use it to get down
        /// there and return it to them.
        /// 
        /// As you reach the bottom of the relentless avalanche of machine parts, you discover that they're already forming a formidable heap. 
        /// Don't worry, though - a group of Elves is already here organizing the parts, and they have a system.
        /// 
        /// To start, each part is rated in each of four categories:
        /// 
        /// x: Extremely cool looking
        /// m: Musical(it makes a noise when you hit it)
        /// a: Aerodynamic
        /// s: Shiny
        /// Then, each part is sent through a series of workflows that will ultimately accept or reject the part.
        /// Each workflow has a name and contains a list of rules; each rule specifies a condition and where to send the part if the condition 
        /// is true. The first rule that matches the part being considered is applied immediately, and the part moves on to the
        /// destination described by the rule. (The last rule in each workflow has no condition and always applies if reached.)
        /// 
        /// Consider the workflow ex { x>10:one,m<20:two,a>30:R,A }. This workflow is named ex and contains four rules.
        /// If workflow ex were considering a specific part, it would perform the following steps in order:
        /// 
        /// Rule "x>10:one": If the part's x is more than 10, send the part to the workflow named one.
        /// Rule "m<20:two": Otherwise, if the part's m is less than 20, send the part to the workflow named two.
        /// Rule "a>30:R": Otherwise, if the part's a is more than 30, the part is immediately rejected (R).
        /// Rule "A": Otherwise, because no other rules matched the part, the part is immediately accepted (A).
        /// If a part is sent to another workflow, it immediately switches to the start of that workflow instead and never returns.
        /// If a part is accepted (sent to A) or rejected(sent to R), the part immediately stops any further processing.
        /// 
        /// The system works, but it's not keeping up with the torrent of weird metal shapes. 
        /// The Elves ask if you can help sort a few parts and give you the list of workflows and some part ratings (your puzzle input). 
        /// For example:
        /// 
        /// px{a<2006:qkq, m>2090:A,rfg}
        /// pv{a>1716:R,A}
        /// lnx{m>1548:A, A}
        /// rfg{s<537:gd, x>2440:R, A}
        /// qs{s>3448:A, lnx}
        /// qkq{x<1416:A, crn}
        /// crn{x>2662:A, R}
        /// in{s<1351:px,qqz}
        /// qqz{s>2770:qs, m<1801:hdj, R}
        /// gd{a>3333:R, R}
        /// hdj{m>838:A, pv}
        /// 
        /// { x = 787,m = 2655,a = 1222,s = 2876}
        /// { x = 1679,m = 44,a = 2067,s = 496}
        /// { x = 2036,m = 264,a = 79,s = 2244}
        /// { x = 2461,m = 1339,a = 466,s = 291}
        /// { x = 2127,m = 1623,a = 2188,s = 1013}
        /// The workflows are listed first, followed by a blank line, then the ratings of the parts the Elves would like you to sort.
        /// All parts begin in the workflow named in. In this example, the five listed parts go through the following workflows:
        /// 
        /// { x = 787,m = 2655,a = 1222,s = 2876}: in -> qqz->qs->lnx->A
        /// { x = 1679,m = 44,a = 2067,s = 496}: in -> px->rfg->gd->R
        /// { x = 2036,m = 264,a = 79,s = 2244}: in -> qqz->hdj->pv->A
        /// { x = 2461,m = 1339,a = 466,s = 291}: in -> px->qkq->crn->R
        /// { x = 2127,m = 1623,a = 2188,s = 1013}: in -> px->rfg->A
        /// Ultimately, three parts are accepted. Adding up the x, m, a, and s rating for each of the accepted parts gives 7540 for the part
        /// with x=787, 4623 for the part with x=2036, and 6951 for the part with x=2127. Adding all of the ratings for all of the accepted
        /// parts gives the sum total of 19114.
        /// 
        /// Sort through all of the parts you've been given; what do you get if you add together all of the rating numbers for all 
        /// of the parts that ultimately get accepted?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            //Rules rules = [];
            //foreach (string item in input)
            //{
            //    if (string.IsNullOrEmpty(item)) break;
            //    else rules.Add(item.Split('{', '}')[0], item.Split('{', '}')[1]);
            //}

            //List<string> t0 = [];
            //bool reg = false;
            //foreach (string item in input)
            //{
            //    if (reg) t0.Add(item);
            //    if (string.IsNullOrEmpty(item)) reg = true;
            //}

            //return (
            //    from cube in ParseUnitCube([.. t0])
            //    where Accepted(rules, cube, "in") == 1
            //    select cube.Select(dim => dim.Begin).Sum()
            //).Sum();

            long r = 0;

            Dictionary<string, List<string>> kvp = [];
            List<Dictionary<char, int>> kvp0 = [];

            foreach (string item in input)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item[0] != '{') kvp.Add(item.Split('{')[0], [.. item.Split('{')[1].Replace("}", "").Split(',')]);
                    if (item[0] == '{')
                    {
                        string t = item[1..^1];
                        List<string> t0 = [.. t.Split(',')];
                        Dictionary<char, int> kvp1 = [];
                        foreach (string item1 in t0)
                        {
                            kvp1.Add(item1.Split('=')[0][0], int.Parse(item1.Split('=')[1]));
                        }
                        kvp0.Add(kvp1);
                    }
                }
            }

            foreach (Dictionary<char, int> item in kvp0)
            {
                string c = "in";
                while (c != "A" && c != "R")
                {
                    foreach (string item1 in kvp[c])
                    {
                        if (item1.Contains('<'))
                        {
                            if (item[item1.Split("<")[0][0]] < int.Parse(item1.Split("<")[1].Split(":")[0]))
                            {
                                c = item1.Split("<")[1].Split(":")[1];
                                break;
                            }
                        }
                        else if (item1.Contains('>'))
                        {
                            if (item[item1.Split(">")[0][0]] > int.Parse(item1.Split(">")[1].Split(":")[0]))
                            {
                                c = item1.Split(">")[1].Split(":")[1];
                                break;
                            }
                        }
                        else
                        {
                            c = item1;
                            break;
                        }
                    }
                }

                if (c == "A") r += item.Values.Sum();
            }

            return r;
        }

        /// <summary>
        /// Even with your help, the sorting process still isn't fast enough.
        /// 
        /// One of the Elves comes up with a new plan: rather than sort parts individually through all of these workflows, 
        /// maybe you can figure out in advance which combinations of ratings will be accepted or rejected.
        /// Each of the four ratings (x, m, a, s) can have an integer value ranging from a minimum of 1 to a maximum of 4000. 
        /// Of all possible distinct combinations of ratings, your job is to figure out which ones will be accepted.
        /// 
        /// In the above example, there are 167409079868000 distinct combinations of ratings that will be accepted.
        /// 
        /// Consider only your list of workflows; the list of part ratings that the Elves wanted you to sort is no longer relevant.
        /// How many distinct combinations of ratings will be accepted by the Elves' workflows?
        /// </summary>        
        [Benchmark]
        public BigInteger PartTwo() => PartTwo0(data!);

        private static BigInteger PartTwo0(List<string> input)
        {
            Rules rules = [];
            foreach (string item in input)
            {
                if (string.IsNullOrEmpty(item)) break;
                else rules.Add(item.Split('{', '}')[0], item.Split('{', '}')[1]);
            }

            Cube cube = Enumerable.Repeat(new Range(1, 4000), 4).ToImmutableArray();

            return Accepted(rules, cube, "in");
        }

        private static BigInteger Volume(Cube cube) => cube.Aggregate(BigInteger.One, (m, dim) => m * (dim.End - dim.Begin + 1));

        private static BigInteger Accepted(Rules rules, Cube cube, string state)
        {
            if (cube.Any(coord => coord.End < coord.Begin)) return 0;
            else if (state == "A") return Volume(cube);
            else if (state == "R") return 0;
            else
            {
                BigInteger res = BigInteger.Zero;
                foreach (string stm in rules[state].Split(","))
                {
                    if (TryParseCond(stm, '<', out Cond? cond))
                    {
                        (Range lo, Range hi) = SplitRange(cube[cond!.Dim], cond.Num);
                        res += Accepted(rules, cube.SetItem(cond.Dim, lo), cond.Jmp);
                        cube = cube.SetItem(cond.Dim, hi);
                    }
                    else if (TryParseCond(stm, '>', out cond))
                    {
                        (Range lo, Range hi) = SplitRange(cube[cond!.Dim], cond.Num + 1);
                        res += Accepted(rules, cube.SetItem(cond.Dim, hi), cond.Jmp);
                        cube = cube.SetItem(cond.Dim, lo);
                    }
                    else res += Accepted(rules, cube, stm);
                }

                return res;
            }
        }

        private static bool TryParseCond(string st, char ch, out Cond? cond)
        {
            if (!st.Contains(ch))
            {
                cond = null;
                return false;
            }
            else
            {
                string[] parts = st.Split(ch, ':');
                cond = new Cond(
                    Dim: parts[0] switch { "x" => 0, "m" => 1, "a" => 2, _ => 3 },
                    Num: int.Parse(parts[1]),
                    Jmp: parts[2]
                );

                return true;
            }
        }

        private static (Range lo, Range hi) SplitRange(Range r, int num) => (
            r with { Begin = r.Begin, End = Math.Min(num - 1, r.End) },
            r with { Begin = Math.Max(r.Begin, num), End = r.End }
        );

        private static Rules ParseRules(string input) => (
            from line in input.Split('\n')
            let parts = line.Split('{', '}')
            select new KeyValuePair<string, string>(parts[0], parts[1])
        ).ToDictionary();

        private static IEnumerable<Cube> ParseUnitCube(string[] input) =>
            from line in input
            let nums = MyRegex().Matches(line).Select(m => int.Parse(m.Value))
            select nums.Select(n => new Range(n, n)).ToImmutableArray();

        [GeneratedRegex(@"\d+")]
        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static BigInteger PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _19_Aplenty(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_19_Aplenty));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}