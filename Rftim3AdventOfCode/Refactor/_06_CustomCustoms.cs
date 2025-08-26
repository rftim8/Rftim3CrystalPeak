using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _06_CustomCustoms : I_06_CustomCustoms
    {
        #region Static
        private readonly List<string>? data;

        public _06_CustomCustoms()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_06_CustomCustoms));
        }

        /// <summary>
        /// As your flight approaches the regional airport where you'll switch to a much larger plane, customs declaration forms are distributed to the passengers.
        /// 
        /// The form asks a series of 26 yes-or-no questions marked a through z.All you need to do is identify the questions for which anyone in your group answers "yes". 
        /// Since your group is just you, this doesn't take very long.
        /// 
        /// However, the person sitting next to you seems to be experiencing a language barrier and asks if you can help.
        /// For each of the people in their group, you write down the questions for which they answer "yes", one per line.For example:
        /// 
        /// abcx
        /// abcy
        /// abcz
        /// In this group, there are 6 questions to which anyone answered "yes": a, b, c, x, y, and z.
        /// (Duplicate answers to the same question don't count extra; each question counts at most once.)
        /// 
        /// 
        /// Another group asks for your help, then another, and eventually you've collected answers from every group on the plane (your puzzle input).
        /// Each group's answers are separated by a blank line, and within each group, each person's answers are on a single line. For example:
        /// 
        /// 
        /// abc
        /// 
        /// a
        /// b
        /// c
        /// 
        /// 
        /// ab
        /// ac
        /// 
        /// 
        /// 
        /// a
        /// a
        /// a
        /// a
        /// 
        /// 
        /// b
        /// This list represents answers from five groups:
        /// 
        /// 
        /// The first group contains one person who answered "yes" to 3 questions: a, b, and c.
        /// The second group contains three people; combined, they answered "yes" to 3 questions: a, b, and c.
        /// The third group contains two people; combined, they answered "yes" to 3 questions: a, b, and c.
        /// The fourth group contains four people; combined, they answered "yes" to only 1 question, a.
        /// The last group contains one person who answered "yes" to only 1 question, b.
        /// In this example, the sum of these counts is 3 + 3 + 3 + 1 + 1 = 11.
        /// 
        /// For each group, count the number of questions to which anyone answered "yes". What is the sum of those counts?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            return string.Join("\n", input)
                .Split("\n\n")
                .Select(x => x.Replace("\n", "").ToCharArray().Distinct().Count())
                .Sum();
        }

        /// <summary>
        /// As you finish the last group's customs declaration, you notice that you misread one word in the instructions:
        /// 
        /// You don't need to identify the questions to which anyone answered "yes"; you need to identify the questions to which everyone answered "yes"!
        /// 
        /// Using the same example as above:
        /// 
        /// abc
        /// a
        /// b
        /// c
        /// 
        /// ab
        /// ac
        /// 
        /// a
        /// a
        /// a
        /// a
        /// 
        /// b
        /// This list represents answers from five groups:
        /// 
        /// In the first group, everyone (all 1 person) answered "yes" to 3 questions: a, b, and c.
        /// In the second group, there is no question to which everyone answered "yes".
        /// In the third group, everyone answered yes to only 1 question, a.Since some people did not answer "yes" to b or c, they don't count.
        /// In the fourth group, everyone answered yes to only 1 question, a.
        /// In the fifth group, everyone (all 1 person) answered "yes" to 1 question, b.
        /// In this example, the sum of these counts is 3 + 0 + 1 + 1 + 1 = 6.
        /// 
        /// For each group, count the number of questions to which everyone answered "yes". What is the sum of those counts?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            return string.Join("\n", input)
                .Split("\n\n")
                .Select(x => x.Split("\n").Select(l => l.ToCharArray().Distinct()))
                .Select(g => g.Aggregate((prev, next) => prev.Intersect(next).ToList()).Count())
                .Sum();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _06_CustomCustoms(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_06_CustomCustoms));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}