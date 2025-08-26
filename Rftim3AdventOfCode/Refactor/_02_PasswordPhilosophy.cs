using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _02_PasswordPhilosophy : I_02_PasswordPhilosophy
    {
        #region Static
        private readonly List<string>? data;

        public _02_PasswordPhilosophy()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_02_PasswordPhilosophy));
        }

        /// <summary>
        /// Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via toboggan.
        /// 
        /// The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day. 
        /// "Something's wrong with our computers; we can't log in!" You ask if you can take a look.
        /// 
        /// Their password database seems to be a little corrupted: some of the passwords wouldn't have been allowed by the 
        /// Official Toboggan Corporate Policy that was in effect when they were chosen.
        /// 
        /// To try to debug the problem, they have created a list (your puzzle input) of passwords(according to the corrupted database)
        /// and the corporate policy when that password was set.
        /// For example, suppose you have the following list:
        /// 
        /// 1-3 a: abcde
        /// 1-3 b: cdefg
        /// 2-9 c: ccccccccc
        /// 
        /// Each line gives the password policy and then the password.
        /// The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.
        /// For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.
        /// 
        /// In the above example, 2 passwords are valid.The middle password, cdefg, is not; it contains no instances of b, but needs at least 1. 
        /// The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.
        /// 
        /// How many passwords are valid according to their policies?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                int a = int.Parse(item.Split('-')[0]);
                int b = int.Parse(item.Split(' ')[0].Split('-')[1]);
                string l = item.Split(':')[0].Split(' ')[1];
                string p = item.Split(' ')[^1];

                int c = 0;

                foreach (char item1 in p)
                {
                    if (item1.ToString() == l) c++;
                }

                if (c >= a && c <= b) r++;
            }

            return r;
        }

        /// <summary>
        /// While it appears you validated the passwords correctly, they don't seem to be what the Official Toboggan Corporate Authentication System is expecting.
        /// 
        /// The shopkeeper suddenly realizes that he just accidentally explained the password policy rules from his old job at the sled rental place down the street! 
        /// The Official Toboggan Corporate Policy actually works a little differently.
        /// Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. 
        /// (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter.
        /// Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
        /// Given the same example list from above:
        /// 
        /// 1-3 a: abcde is valid: position 1 contains a and position 3 does not.
        /// 1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
        /// 2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
        /// How many passwords are valid according to the new interpretation of the policies?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                int a = int.Parse(item.Split('-')[0]);
                int b = int.Parse(item.Split(' ')[0].Split('-')[1]);
                string l = item.Split(':')[0].Split(' ')[1];
                string p = item.Split(' ')[^1];

                if (p[a - 1].ToString() == l && p[b - 1].ToString() != l ||
                    p[a - 1].ToString() != l && p[b - 1].ToString() == l)
                    r++;
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
        
        public _02_PasswordPhilosophy(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_02_PasswordPhilosophy));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}