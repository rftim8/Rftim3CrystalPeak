using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _11_CorporatePolicy : I_11_CorporatePolicy
    {
        #region Static
        private readonly List<string>? data;

        public _11_CorporatePolicy()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_11_CorporatePolicy));
        }

        /// <summary>
        /// Santa's previous password expired, and he needs help choosing a new one.
        /// To help him remember his new password after the old one expires, Santa has devised a method of coming up with a password based on the previous one.
        /// Corporate policy dictates that passwords must be exactly eight lowercase letters(for security reasons), 
        /// so he finds his new password by incrementing his old password string repeatedly until it is valid.
        /// Incrementing is just like counting with numbers: xx, xy, xz, ya, yb, and so on.
        /// Increase the rightmost letter one step; if it was z, it wraps around to a, and repeat with the next letter to the left until one doesn't wrap around.
        /// Unfortunately for Santa, a new Security-Elf recently started, and he has imposed some additional password requirements:
        /// 
        /// Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz.They cannot skip letters; abd doesn't count.
        /// Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
        /// Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
        /// 
        /// For example:
        /// 
        /// hijklmmn meets the first requirement (because it contains the straight hij) but fails the second requirement requirement(because it contains i and l).
        /// abbceffg meets the third requirement(because it repeats bb and ff) but fails the first requirement.
        /// abbcegjk fails the third requirement, because it only has one double letter(bb).
        /// The next password after abcdefgh is abcdffaa.
        /// The next password after ghijklmn is ghjaabcc, because you eventually skip all the passwords that start with ghi..., since i is not allowed.
        /// 
        /// Given Santa's current password (your puzzle input), what should his next password be?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            string data = input[0];
            string chars = "abcdefghjkmnpqrstuvwxyz";
            int[] c = new int[8];

            for (int i = 0; i < c.Length; i++)
            {
                c[i] = chars.IndexOf(data[i]);
            }

            for (int i = 0; i < 10000000; i++)
            {
                string rec = string.Empty;

                #region Increment password
                if (c[7] + 1 > chars.Length - 1)
                {
                    c[7] = 0;
                    if (c[6] + 1 > chars.Length - 1)
                    {
                        c[6] = 0;
                        if (c[5] + 1 > chars.Length - 1)
                        {
                            c[5] = 0;
                            if (c[4] + 1 > chars.Length - 1)
                            {
                                c[4] = 0;
                                if (c[3] + 1 > chars.Length - 1)
                                {
                                    c[3] = 0;
                                    if (c[2] + 1 > chars.Length - 1)
                                    {
                                        c[2] = 0;
                                        if (c[1] + 1 > chars.Length - 1)
                                        {
                                            c[1] = 0;
                                            if (c[0] + 1 > chars.Length - 1) c[0] = 0;
                                            else c[0]++;
                                        }
                                        else c[1]++;
                                    }
                                    else c[2]++;
                                }
                                else c[3]++;
                            }
                            else c[4]++;
                        }
                        else c[5]++;
                    }
                    else c[6]++;
                }
                else c[7]++;
                #endregion

                for (int j = 0; j < c.Length; j++)
                {
                    rec += chars.ElementAt(c[j]);
                }

                bool three = false;
                for (int j = 0; j < c.Length - 2; j++)
                {
                    if (c[j] == c[j + 1] - 1 && c[j] == c[j + 2] - 2) three = true;
                }

                bool pair = false;
                for (int j = 0; j < rec.Length - 1; j++)
                {
                    if (rec[j] == rec[j + 1])
                    {
                        for (int k = j + 1; k < rec.Length - 1; k++)
                        {
                            if (rec[k] == rec[k + 1] && rec[j] != rec[k])
                            {
                                pair = true;
                                k = rec.Length;
                                j = rec.Length;
                            }
                        }
                    }
                }

                if (three && pair)
                {
                    return rec;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Santa's password expired again. What's the next one?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string data = input[0];
            string chars = "abcdefghjkmnpqrstuvwxyz";
            int[] c = new int[8];

            for (int i = 0; i < c.Length; i++)
            {
                c[i] = chars.IndexOf(data[i]);
            }

            int v = 1;
            for (int i = 0; i < 10000000; i++)
            {
                string rec = string.Empty;

                #region Increment password
                if (c[7] + 1 > chars.Length - 1)
                {
                    c[7] = 0;
                    if (c[6] + 1 > chars.Length - 1)
                    {
                        c[6] = 0;
                        if (c[5] + 1 > chars.Length - 1)
                        {
                            c[5] = 0;
                            if (c[4] + 1 > chars.Length - 1)
                            {
                                c[4] = 0;
                                if (c[3] + 1 > chars.Length - 1)
                                {
                                    c[3] = 0;
                                    if (c[2] + 1 > chars.Length - 1)
                                    {
                                        c[2] = 0;
                                        if (c[1] + 1 > chars.Length - 1)
                                        {
                                            c[1] = 0;
                                            if (c[0] + 1 > chars.Length - 1) c[0] = 0;
                                            else c[0]++;
                                        }
                                        else c[1]++;
                                    }
                                    else c[2]++;
                                }
                                else c[3]++;
                            }
                            else c[4]++;
                        }
                        else c[5]++;
                    }
                    else c[6]++;
                }
                else c[7]++;
                #endregion

                for (int j = 0; j < c.Length; j++)
                {
                    rec += chars.ElementAt(c[j]);
                }

                bool three = false;
                for (int j = 0; j < c.Length - 2; j++)
                {
                    if (c[j] == c[j + 1] - 1 && c[j] == c[j + 2] - 2) three = true;
                }

                bool pair = false;
                for (int j = 0; j < rec.Length - 1; j++)
                {
                    if (rec[j] == rec[j + 1])
                    {
                        for (int k = j + 1; k < rec.Length - 1; k++)
                        {
                            if (rec[k] == rec[k + 1] && rec[j] != rec[k])
                            {
                                pair = true;
                                k = rec.Length;
                                j = rec.Length;
                            }
                        }
                    }
                }

                if (three && pair)
                {
                    Console.WriteLine($"Valid password nr {v}: {rec}");
                    v++;
                }
            }

            return string.Empty;
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _11_CorporatePolicy(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_11_CorporatePolicy));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}