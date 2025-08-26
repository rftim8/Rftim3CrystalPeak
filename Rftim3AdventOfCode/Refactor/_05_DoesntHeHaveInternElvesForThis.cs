using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _05_DoesntHeHaveInternElvesForThis : I_05_DoesntHeHaveInternElvesForThis
    {
        #region Static
        private readonly List<string>? data;

        public _05_DoesntHeHaveInternElvesForThis()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_05_DoesntHeHaveInternElvesForThis));
        }

        /// <summary>
        /// Santa needs help figuring out which strings in his text file are naughty or nice.
        /// A nice string is one with all of the following properties:
        /// It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
        /// It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
        /// It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
        /// 
        /// For example:
        /// 
        /// ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), and none of the disallowed substrings.
        /// aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
        /// jchzalrnumimnmhp is naughty because it has no double letter.
        /// haegwjzuvuyypxyu is naughty because it contains the string xy.
        /// dvszwmarrgswjxmb is naughty because it contains only one vowel.
        /// 
        /// How many strings are nice?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i++)
            {
                int c = 0;
                bool tw = false;

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] is 'a' or 'e' or 'i' or 'o' or 'u') c++;
                    if (input[i].Contains($"{input[i][j]}{input[i][j]}")) tw = true;
                }

                Console.WriteLine($"{input[i]}: {c} -> {tw}");
                if (c >= 3 && tw && !input[i].Contains("ab") && !input[i].Contains("cd") && !input[i].Contains("pq") && !input[i].Contains("xy")) r++;
            }

            return r;
        }

        /// <summary>
        /// Realizing the error of his ways, Santa has switched to a better model of determining whether a string is naughty or nice.
        /// None of the old rules apply, as they are all clearly ridiculous.
        /// Now, a nice string is one with all of the following properties:
        /// 
        /// It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy(xy) or aabcdefgaa(aa), but not like aaa(aa, but it overlaps).
        /// It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi(efe), or even aaa.
        /// 
        /// For example:
        /// 
        /// qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice(qj) and a letter that repeats with exactly one letter between them(zxz).
        /// xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
        /// uurcxstgmygtbstg is naughty because it has a pair(tg) but no repeat with a single letter between them.
        /// ieodomkazucvgmuy is naughty because it has a repeating letter with one between(odo), but no pair that appears twice.
        /// 
        /// How many strings are nice under these new rules?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i++)
            {
                bool sym = false;
                bool rec = false;

                for (int j = 0; j < input[i].Length - 3; j++)
                {
                    string x = input[i][j..(j + 2)];
                    if (input[i][(j + 2)..].Contains(x))
                    {
                        rec = true;
                        break;
                    }
                }

                for (int j = 0; j < input[i].Length - 2; j++)
                {
                    if (input[i][j] == input[i][j + 2])
                    {
                        Console.WriteLine(input[i][j..(j + 3)]);
                        sym = true;
                        break;
                    }
                }

                if (sym && rec) r++;

                Console.WriteLine($"{input[i]}: {sym} -> {rec}");
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

        public _05_DoesntHeHaveInternElvesForThis(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_05_DoesntHeHaveInternElvesForThis));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}