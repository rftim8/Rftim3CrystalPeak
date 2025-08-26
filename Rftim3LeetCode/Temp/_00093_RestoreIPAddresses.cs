using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00093_RestoreIPAddresses
    {
        /// <summary>
        /// A valid IP address consists of exactly four integers separated by single dots. 
        /// Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.
        /// For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.
        /// Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. 
        /// You are not allowed to reorder or remove any digits in s.
        /// You may return the valid IP addresses in any order.
        /// </summary>
        public _00093_RestoreIPAddresses()
        {
            IList<string> x = RestoreIpAddresses("25525511135");
            RftTerminal.RftReadResult(x);
            IList<string> x0 = RestoreIpAddresses("0000");
            RftTerminal.RftReadResult(x0);
            IList<string> x1 = RestoreIpAddresses("101023");
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> RestoreIpAddresses(string s)
        {
            List<string> l = [];
            List<string> r = [];

            Solve(l, r, s, 0);

            return l;
        }

        private static void Solve(IList<string> l, IList<string> r, string s, int t)
        {
            if (r.Count == 4 && t == s.Length)
            {
                l.Add(string.Join(".", r));

                return;
            }

            if (s.Length - t > (4 - r.Count) * 3) return;

            for (int i = t; i < t + 4 && i < s.Length; i++)
            {
                string ip = s.Substring(t, i - t + 1);
                if (int.Parse(ip) > 255 || int.Parse(ip).ToString() != ip) return;

                r.Add(ip);
                Solve(l, r, s, i + 1);
                r.RemoveAt(r.Count - 1);
            }
        }
    }
}
