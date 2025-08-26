using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00942_DIStringMatch
    {
        /// <summary>
        /// A permutation perm of n + 1 integers of all the integers in the range [0, n] can be represented as a string s of length n where:
        /// s[i] == 'I' if perm[i] < perm[i + 1], and
        /// s[i] == 'D' if perm[i] > perm[i + 1].
        /// Given a string s, reconstruct the permutation perm and return it.If there are multiple valid permutations perm, return any of them.
        /// </summary>
        public _00942_DIStringMatch()
        {
            int[] x = DiStringMatch("IDID");
            int[] x0 = DiStringMatch("III");
            int[] x1 = DiStringMatch("DDI");

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] DiStringMatch(string s)
        {
            int n = s.Length;
            int lo = 0, hi = n;
            int[] ans = new int[n + 1];

            for (int i = 0; i < n; ++i)
            {
                if (s[i] == 'I') ans[i] = lo++;
                else ans[i] = hi--;
            }

            ans[n] = lo;

            return ans;
        }
    }
}
