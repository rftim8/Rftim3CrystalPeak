using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _04_HighEntropyPassphrases : I_04_HighEntropyPassphrases
    {
        #region Static
        private readonly List<string>? data;

        public _04_HighEntropyPassphrases()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_04_HighEntropyPassphrases));
        }

        /// <summary>
        /// A new system policy has been put in place that requires all accounts to use a passphrase instead of simply a password.
        /// A passphrase consists of a series of words (lowercase letters) separated by spaces.
        /// 
        /// To ensure security, a valid passphrase must contain no duplicate words.
        /// 
        /// For example:
        /// 
        /// aa bb cc dd ee is valid.
        /// aa bb cc dd aa is not valid - the word aa appears more than once.
        /// aa bb cc dd aaa is valid - aa and aaa count as different words.
        /// 
        /// The system's full passphrase list is available as your puzzle input. How many passphrases are valid?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                int a = item.Split(' ').Count();
                int b = item.Split(' ').Distinct().Count();

                if (a == b) r++;
            }

            return r;
        }

        /// <summary>
        /// For added security, yet another system policy has been put in place. 
        /// Now, a valid passphrase must contain no two words that are anagrams of each other - that is, 
        /// a passphrase is invalid if any word's letters can be rearranged to form any other word in the passphrase.
        /// 
        /// For example:
        /// 
        /// abcde fghij is a valid passphrase.
        /// abcde xyz ecdab is not valid - the letters from the third word can be rearranged to form the first word.
        /// a ab abc abd abf abj is a valid passphrase, because all letters need to be used when forming another word.
        ///         iiii oiii ooii oooi oooo is valid.
        /// oiii ioii iioi iiio is not valid - any of these words can be rearranged to form any other word.
        /// Under this new system policy, how many passphrases are valid?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                List<string> a = [.. item.Split(' ', StringSplitOptions.RemoveEmptyEntries)];
                int n = a.Count;

                int c0 = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (a[i].Length == a[j].Length && a[i].ToCharArray().Order().SequenceEqual(a[j].ToCharArray().Order()))
                        {
                            Console.WriteLine($"{a[i]} {a[j]}");
                            c0++;
                            break;
                        }
                    }
                }

                if (c0 == 0) r++;
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _04_HighEntropyPassphrases(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_04_HighEntropyPassphrases));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}