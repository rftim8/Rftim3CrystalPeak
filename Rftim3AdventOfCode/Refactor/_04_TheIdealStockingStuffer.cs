using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Security.Cryptography;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _04_TheIdealStockingStuffer : I_04_TheIdealStockingStuffer
    {
        #region Static
        private readonly List<string>? data;

        public _04_TheIdealStockingStuffer()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_04_TheIdealStockingStuffer));
        }

        /// <summary>
        /// Santa needs help mining some AdventCoins(very similar to bitcoins) to use as gifts for all the economically forward-thinking little girls and boys.
        /// To do this, he needs to find MD5 hashes which, in hexadecimal, start with at least five zeroes.
        /// The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. 
        /// 
        /// To mine AdventCoins, you must find Santa the lowest positive number(no leading zeroes: 1, 2, 3, ...) that produces such a hash.
        /// 
        /// For example:
        /// 
        /// If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes(000001dbbfa...), and it is the lowest such number to do so.
        /// If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; 
        /// that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string data = input[0];
            int r = 0;

            for (int i = 0; i < int.MaxValue; i++)
            {
                string s = CreateMD5(data + i.ToString());

                if (s[..5] == "00000")
                {
                    Console.WriteLine($"MD5 hash: {s}");
                    return i;
                }
            }

            return r;
        }

        /// <summary>
        /// Now find one that starts with six zeroes.
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string data = input[0];
            int r = 0;

            for (int i = 0; i < int.MaxValue; i++)
            {
                string s = CreateMD5(data + i.ToString());

                if (s[..6] == "000000")
                {
                    Console.WriteLine($"MD5 hash: {s}");
                    return i;
                }
            }

            return r;
        }

        private static string CreateMD5(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = MD5.HashData(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _04_TheIdealStockingStuffer(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_04_TheIdealStockingStuffer));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}