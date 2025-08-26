using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Security.Cryptography;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _05_HowAboutANiceGameOfChess : I_05_HowAboutANiceGameOfChess
    {
        #region Static
        private readonly List<string>? data;

        public _05_HowAboutANiceGameOfChess()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_05_HowAboutANiceGameOfChess));
        }

        /// <summary>
        /// You are faced with a security door designed by Easter Bunny engineers that seem to have acquired most of their security knowledge by watching hacking movies.
        /// 
        /// The eight-character password for the door is generated one character at a time by finding the MD5 hash of some Door ID(your puzzle input) 
        /// and an increasing integer index(starting with 0).
        /// A hash indicates the next character in the password if its hexadecimal representation starts with five zeroes.
        /// If it does, the sixth character in the hash is the next character of the password.
        /// 
        /// For example, if the Door ID is abc:
        /// 
        /// The first index which produces a hash that starts with five zeroes is 3231929, which we find by hashing abc3231929; 
        /// the sixth character of the hash, and thus the first character of the password, is 1.
        /// 5017308 produces the next interesting hash, which starts with 000008f82..., so the second character of the password is 8.
        /// The third time a hash starts with five zeroes is for abc5278568, discovering the character f.
        /// In this example, after continuing this search a total of eight times, the password is 18f47a30.
        /// 
        /// Given the actual Door ID, what is the password?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            string s = input[0];
            string r = string.Empty;

            int c = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                byte[] x = MD5.HashData(Encoding.UTF8.GetBytes($"{s}{i}"));
                string x0 = Convert.ToHexString(x);
                if (x0[0..5] == "00000")
                {
                    r += x0[5];
                    c++;
                }
                if (c == 8) break;
            }

            return r.ToLower();
        }

        /// <summary>
        /// As the door slides open, you are presented with a second door that uses a slightly more inspired security mechanism. 
        /// Clearly unimpressed by the last version (in what movie is the password decrypted in order?!), the Easter Bunny engineers have worked out a better solution.
        /// 
        /// Instead of simply filling in the password from left to right, the hash now also indicates the position within the password to fill.
        /// You still look for hashes that begin with five zeroes; however, now, the sixth character represents the position(0-7), 
        /// and the seventh character is the character to put in that position.
        /// 
        /// A hash result of 000001f means that f is the second character in the password. 
        /// Use only the first result for each position, and ignore invalid positions.
        /// 
        /// For example, if the Door ID is abc:
        /// 
        /// The first interesting hash is from abc3231929, which produces 0000015...; so, 5 goes in position 1: _5______.
        /// In the previous method, 5017308 produced an interesting hash; however, it is ignored, because it specifies an invalid position(8).
        /// The second interesting hash is at index 5357525, which produces 000004e...; so, e goes in position 4: _5__e___.
        /// You almost choke on your popcorn as the final character falls into place, producing the password 05ace8e3.
        /// 
        /// Given the actual Door ID and this new method, what is the password? Be extra proud of your solution if it uses a cinematic "decrypting" animation.
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string s = input[0];
            char[] r = new char[8];

            int c = 0;
            int i = 0;
            while (c < 8)
            {
                byte[] x = MD5.HashData(Encoding.UTF8.GetBytes($"{s}{i}"));
                string x0 = Convert.ToHexString(x);
                if (x0[0..5] == "00000")
                {
                    if (int.TryParse(x0[5].ToString(), out int t))
                    {
                        if (t < 8)
                        {
                            if (r[t] == 0)
                            {
                                r[t] = x0[6];
                                c++;
                            }
                        }
                    }
                }
                i++;
            }

            return string.Concat(r).ToLower();
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _05_HowAboutANiceGameOfChess(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_05_HowAboutANiceGameOfChess));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}