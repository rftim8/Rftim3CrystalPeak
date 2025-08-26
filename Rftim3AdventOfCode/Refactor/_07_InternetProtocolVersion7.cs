using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _07_InternetProtocolVersion7 : I_07_InternetProtocolVersion7
    {
        #region Static
        private readonly List<string>? data;

        public _07_InternetProtocolVersion7()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_InternetProtocolVersion7));
        }

        /// <summary>
        /// While snooping around the local network of EBHQ, you compile a list of IP addresses (they're IPv7, of course; IPv6 is much too limited). 
        /// You'd like to figure out which IPs support TLS (transport-layer snooping).
        /// 
        /// An IP supports TLS if it has an Autonomous Bridge Bypass Annotation, or ABBA.
        /// An ABBA is any four-character sequence which consists of a pair of two different characters followed by the reverse of that pair, 
        /// such as xyyx or abba.However, the IP also must not have an ABBA within any hypernet sequences, which are contained by square brackets.
        /// 
        /// For example:
        /// 
        /// abba[mnop] qrst supports TLS (abba outside square brackets).
        /// abcd[bddb] xyyx does not support TLS(bddb is within square brackets, even though xyyx is outside square brackets).
        /// aaaa[qwer] tyui does not support TLS(aaaa is invalid; the interior characters must be different).
        /// ioxxoj[asdfgh] zxcvbn supports TLS(oxxo is outside square brackets, even though it's within a larger string).
        /// How many IPs in your puzzle input support TLS?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                List<string> x = [];
                List<string> y = [];

                string s = string.Empty;
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '[' || item[i] == ']')
                    {
                        if (item[i] == '[') x.Add(s);
                        else y.Add(s);

                        s = string.Empty;
                    }
                    else s += item[i];

                    if (i == item.Length - 1) x.Add(s);
                }

                bool a = false, b = false;
                foreach (string item1 in x)
                {
                    for (int i = 0; i < item1.Length - 3; i++)
                    {
                        if (item1[i] == item1[i + 3] && item1[i + 1] == item1[i + 2] && item1[i] != item1[i + 1]) a = true;
                    }
                }

                foreach (string item1 in y)
                {
                    for (int i = 0; i < item1.Length - 3; i++)
                    {
                        if (item1[i] == item1[i + 3] && item1[i + 1] == item1[i + 2] && item1[i] != item1[i + 1]) b = true;
                    }
                }

                if (a && !b) r++;
            }

            return r;
        }

        /// <summary>
        /// You would also like to know which IPs support SSL (super-secret listening).
        /// 
        /// An IP supports SSL if it has an Area-Broadcast Accessor, or ABA, anywhere in the supernet sequences(outside any square bracketed sections), 
        /// and a corresponding Byte Allocation Block, or BAB, anywhere in the hypernet sequences.
        /// An ABA is any three-character sequence which consists of the same character twice with a different character between them, such as xyx or aba.
        /// A corresponding BAB is the same characters but in reversed positions: yxy and bab, respectively.
        /// For example:
        /// 
        /// aba[bab] xyz supports SSL(aba outside square brackets with corresponding bab within square brackets).
        /// xyx[xyx] xyx does not support SSL(xyx, but no corresponding yxy).
        /// aaa[kek] eke supports SSL(eke in supernet with corresponding kek in hypernet; the aaa sequence is not related, because the interior character must be different).
        /// zazbz[bzb] cdb supports SSL(zaz has no corresponding aza, but zbz has a corresponding bzb, even though zaz and zbz overlap).
        /// How many IPs in your puzzle input support SSL?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                List<string> x = [];
                List<string> y = [];

                string s = string.Empty;
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '[' || item[i] == ']')
                    {
                        if (item[i] == '[') x.Add(s);
                        else y.Add(s);

                        s = string.Empty;
                    }
                    else s += item[i];

                    if (i == item.Length - 1) x.Add(s);
                }

                List<string> z = [];
                foreach (string item1 in x)
                {
                    for (int i = 0; i < item1.Length - 2; i++)
                    {
                        if (item1[i] == item1[i + 2] && item1[i] != item1[i + 1]) z.Add($"{item1[i]}{item1[i + 1]}{item1[i + 2]}");
                    }
                }

                bool a = false;
                foreach (string item1 in z)
                {
                    foreach (string item2 in y)
                    {
                        for (int i = 0; i < item2.Length - 2; i++)
                        {
                            if (item2[i] == item2[i + 2] && item2[i] != item2[i + 1] && item2[i] == item1[1] && item2[i + 1] == item1[0])
                            {
                                Console.WriteLine($"{item2[i]}{item2[i + 1]}{item2[i + 2]}");
                                Console.WriteLine(item);
                                a = true;
                                break;
                            }
                        }
                    }
                }

                if (a) r++;
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

        public _07_InternetProtocolVersion7(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_InternetProtocolVersion7));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}