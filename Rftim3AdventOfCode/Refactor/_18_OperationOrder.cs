using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _18_OperationOrder : I_18_OperationOrder
    {
        #region Static
        private readonly List<string>? data;

        public _18_OperationOrder()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_18_OperationOrder));
        }

        /// <summary>
        /// As you look out the window and notice a heavily-forested continent slowly appear over the horizon, you are interrupted by the child sitting next to you. 
        /// They're curious if you could help them with their math homework.
        /// 
        /// Unfortunately, it seems like this "math" follows different rules than you remember.
        /// 
        /// 
        /// The homework (your puzzle input) consists of a series of expressions that consist of addition (+), multiplication(*), and parentheses((...)). 
        /// Just like normal math, parentheses indicate that the expression inside must be evaluated before it can be used by the surrounding expression.
        /// Addition still finds the sum of the numbers on both sides of the operator, and multiplication still finds the product.
        /// 
        /// 
        /// However, the rules of operator precedence have changed.Rather than evaluating multiplication before addition, the operators have the same precedence,
        /// and are evaluated left-to-right regardless of the order in which they appear.
        /// 
        /// For example, the steps to evaluate the expression 1 + 2 * 3 + 4 * 5 + 6 are as follows:
        /// 
        /// 1 + 2 * 3 + 4 * 5 + 6
        ///   3   * 3 + 4 * 5 + 6
        ///       9   + 4 * 5 + 6
        ///          13   * 5 + 6
        ///              65   + 6
        ///                  71
        /// Parentheses can override this order; for example, here is what happens if parentheses are added to form 1 + (2 * 3) + (4 * (5 + 6)):
        /// 
        /// 1 + (2 * 3) + (4 * (5 + 6))
        /// 1 +    6    + (4 * (5 + 6))
        ///      7      + (4 * (5 + 6))
        ///      7      + (4 *   11   )
        ///      7      +     44
        ///             51
        /// Here are a few more examples:
        /// 
        /// 2 * 3 + (4 * 5) becomes 26.
        /// 5 + (8 * 3 + 9 + 3 * 4 * 3) becomes 437.
        /// 5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) becomes 12240.
        /// ((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 becomes 13632.
        /// Before you can help with the homework, you need to understand it yourself.Evaluate the expression on each line of the homework; what is the sum of the resulting values?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            Regex bracketMatcher = MyRegex();

            long p1 = 0;
            foreach (string line in input)
            {
                string l = line;
                while (bracketMatcher.IsMatch(l))
                {
                    l = bracketMatcher.Replace(l, m => EvaluateP1(m.Groups[1].Value));
                }
                p1 += long.Parse(EvaluateP1(l));
            }

            return p1;
        }

        /// <summary>
        /// You manage to answer the child's questions and they finish part 1 of their homework, but get stuck when they reach the next section: advanced math.
        /// 
        /// Now, addition and multiplication have different precedence levels, but they're not the ones you're familiar with.
        /// Instead, addition is evaluated before multiplication.
        /// 
        /// For example, the steps to evaluate the expression 1 + 2 * 3 + 4 * 5 + 6 are now as follows:
        /// 
        /// 1 + 2 * 3 + 4 * 5 + 6
        ///   3   * 3 + 4 * 5 + 6
        ///   3   *   7   * 5 + 6
        ///   3   *   7   *  11
        ///      21       *  11
        ///          231
        /// Here are the other examples from above:
        /// 
        /// 1 + (2 * 3) + (4 * (5 + 6)) still becomes 51.
        /// 2 * 3 + (4 * 5) becomes 46.
        /// 5 + (8 * 3 + 9 + 3 * 4 * 3) becomes 1445.
        /// 5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) becomes 669060.
        /// ((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 becomes 23340.
        /// What do you get if you add up the results of evaluating the homework problems using these new rules?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            Regex bracketMatcher = MyRegex();

            long p2 = 0;
            foreach (string line in input)
            {
                string l = line;
                while (bracketMatcher.IsMatch(l))
                {
                    l = bracketMatcher.Replace(l, m => EvaluateP2(m.Groups[1].Value));
                }
                p2 += long.Parse(EvaluateP2(l));
            }

            return p2;
        }

        private static string EvaluateP1(string input)
        {
            Regex opper = MyRegex1();
            while (opper.IsMatch(input))
            {
                input = opper.Replace(
                    input,
                    m => m.Groups[2].Value == "+"
                        ? (long.Parse(m.Groups[1].Value) + long.Parse(m.Groups[3].Value)).ToString()
                        : (long.Parse(m.Groups[1].Value) * long.Parse(m.Groups[3].Value)).ToString(),
                    1);
            }

            return input;
        }

        private static string EvaluateP2(string input)
        {
            Regex plusser = MyRegex2();
            while (plusser.IsMatch(input))
            {
                input = plusser.Replace(input, m => (long.Parse(m.Groups[1].Value) + long.Parse(m.Groups[2].Value)).ToString(), 1);
            }

            Regex multer = MyRegex3();
            while (multer.IsMatch(input))
            {
                input = multer.Replace(input, m => (long.Parse(m.Groups[1].Value) * long.Parse(m.Groups[2].Value)).ToString(), 1);
            }

            return input;
        }

        [GeneratedRegex(@"\(([^()]+)\)")]
        private static partial Regex MyRegex();
        [GeneratedRegex(@"(\d+) (\+|\*) (\d+)")]
        private static partial Regex MyRegex1();
        [GeneratedRegex(@"(\d+) \+ (\d+)")]
        private static partial Regex MyRegex2();
        [GeneratedRegex(@"(\d+) \* (\d+)")]
        private static partial Regex MyRegex3();
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _18_OperationOrder(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_18_OperationOrder));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}