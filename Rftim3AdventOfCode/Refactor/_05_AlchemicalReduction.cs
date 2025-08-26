using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _05_AlchemicalReduction : I_05_AlchemicalReduction
    {
        #region Static
        private readonly List<string>? data;

        public _05_AlchemicalReduction()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_05_AlchemicalReduction));
        }

        /// <summary>
        /// You've managed to sneak in to the prototype suit manufacturing lab. The Elves are making decent progress, 
        /// but are still struggling with the suit's size reduction capabilities.
        /// 
        /// While the very latest in 1518 alchemical technology might have solved their problem eventually, you can do better.
        /// You scan the chemical composition of the suit's material and discover that it is formed by extremely long polymers (one of which is available as your puzzle input).
        /// 
        /// The polymer is formed by smaller units which, when triggered, react with each other such that two adjacent units of the same type and opposite polarity are destroyed.
        /// Units' types are represented by letters; units' polarity is represented by capitalization.For instance, r and R are units with the same type but opposite polarity,
        /// whereas r and s are entirely different types and do not react.
        /// 
        /// For example:
        /// 
        /// In aA, a and A react, leaving nothing behind.
        /// In abBA, bB destroys itself, leaving aA. As above, this then destroys itself, leaving nothing.
        /// In abAB, no two adjacent units are of the same type, and so nothing happens.
        /// In aabAAB, even though aa and AA are of the same type, their polarities match, and so nothing happens.
        /// Now, consider a larger example, dabAcCaCBAcCcaDA:
        /// 
        /// dabAcCaCBAcCcaDA The first 'cC' is removed.
        /// dabAaCBAcCcaDA This creates 'Aa', which is removed.
        /// dabCBAcCcaDA Either 'cC' or 'Cc' are removed (the result is the same).
        /// dabCBAcaDA No further actions can be taken.
        /// After all possible reactions, the resulting polymer contains 10 units.
        /// 
        /// How many units remain after fully reacting the polymer you scanned? (Note: in this puzzle and others, the input is large; if you copy/paste your input,
        /// make sure you get the whole thing.)
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            StringBuilder x = new(input[0]);
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (x[i] == x[i + 1] + 32 ||
                    x[i] == x[i + 1] - 32)
                {
                    x.Remove(i, 2);
                    i -= i > 0 ? 2 : 1;
                }
            }

            return x.Length;
        }

        /// <summary>
        /// Time to improve the polymer.
        /// 
        /// One of the unit types is causing problems; it's preventing the polymer from collapsing as much as it should. 
        /// Your goal is to figure out which unit type is causing the most problems, remove all instances of it (regardless of polarity), 
        /// fully react the remaining polymer, and measure its length.
        /// 
        /// For example, again using the polymer dabAcCaCBAcCcaDA from above:
        /// 
        /// Removing all A/a units produces dbcCCBcCcD.Fully reacting this polymer produces dbCBcD, which has length 6.
        /// Removing all B/b units produces daAcCaCAcCcaDA. Fully reacting this polymer produces daCAcaDA, which has length 8.
        /// Removing all C/c units produces dabAaBAaDA. Fully reacting this polymer produces daDA, which has length 4.
        /// Removing all D/d units produces abAcCaCBAcCcaA. Fully reacting this polymer produces abCBAc, which has length 6.
        /// In this example, removing all C/c units was best, producing the answer 4.
        /// 
        /// What is the length of the shortest polymer you can produce by removing all units of exactly one type and fully reacting the result?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<int> r = [];
            for (int i = 0; i < 26; i++)
            {
                StringBuilder x = new(input[0]);
                x.Replace(((char)(65 + i)).ToString(), "");
                x.Replace(((char)(97 + i)).ToString(), "");

                for (int j = 0; j < x.Length - 1; j++)
                {
                    if (x[j] == x[j + 1] + 32 ||
                        x[j] == x[j + 1] - 32)
                    {
                        x.Remove(j, 2);
                        j -= j > 0 ? 2 : 1;
                    }
                }

                r.Add(x.Length);
            }

            return r.Min();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _05_AlchemicalReduction(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_05_AlchemicalReduction));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}