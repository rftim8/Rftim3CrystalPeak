using System.Text.RegularExpressions;

namespace Rftim3CodinGame.Puzzles
{
    public partial class IPv6Shortener
    {
        public IPv6Shortener()
        {
            string ip0 = "2001:0000:3c4d:0015:0000:0000:0db8:1a2b";
            string ip1 = "0000:0000:0000:0000:0000:0000:0000:0001";
            string ip2 = "0000:aaaa:a000:0000:000a:0030:0000:0000";
            string ip3 = "0000:0000:0100:0000:0000:0004:aaaa:0000";

            Solve0(ip0);
            Solve0(ip1);
            Solve0(ip2);
            Solve0(ip3);
        }

        private static void Solve(string ip)
        {
            //Console.WriteLine(IPAddress.Parse(ip)); // 100% ?

            string x = "";
            List<string> blocks = ip.Split(':').ToList();
            int n = blocks.Count;

            for (int i = 0; i < n; i++)
            {
                int m = blocks[i].Length;
                for (int j = 0; j < m; j++)
                {
                    if (blocks[i][j] == '0')
                    {
                        blocks[i] = blocks[i][1..];
                        m--;
                        j--;
                    }
                    else break;
                }
            }

            int c0 = 0;
            List<int> indices = new();
            int c1 = 0, y = -1, z = -1;
            for (int i = 0; i < n; i++)
            {
                if (blocks[i] == "")
                {
                    indices.Add(i);
                    c0++;
                    if (i == n - 1 && c0 > 1)
                    {
                        if (c0 > c1)
                        {
                            y = indices.First();
                            z = indices.Last();
                            c1 = c0;
                            indices.Clear();
                        }
                    }
                }
                else
                {
                    if (c0 > c1 && c0 > 1)
                    {
                        y = indices.First();
                        z = indices.Last();
                        c1 = c0;
                    }
                    indices.Clear();
                    c0 = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (blocks[i] == "")
                {
                    if (i < y || i > z)
                    {
                        if (i == n - 1) x += $"0";
                        else x += $"0:";
                    }
                    if (i == z) x += $"::";
                }
                else
                {
                    if (i == n - 1) x += $"{blocks[i]}";
                    else x += $"{blocks[i]}:";
                }
            }

            Console.WriteLine(x.Replace(":::", "::"));
        }

        private static void Solve0(string ip)
        {
            // Regex version
            Regex zeroesBlock = ZeroBlocks();
            Regex leadingZeroes = LeadingZeroes();

            Match? max = zeroesBlock.Matches(ip).OrderByDescending(m => m.Length).FirstOrDefault();
            if (max != null) ip = $"{ip[..max.Index]}::{ip[(max.Index + max.Length)..]}";

            Console.WriteLine(leadingZeroes.Replace(ip, ":"));
        }

        [GeneratedRegex("(:?0000:?){2,}")]
        private static partial Regex ZeroBlocks();

        [GeneratedRegex("(:|^)0{1,3}")]
        private static partial Regex LeadingZeroes();
    }
}
