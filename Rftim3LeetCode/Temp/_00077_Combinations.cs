using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00077_Combinations
    {
        private static List<IList<int>>? r;
        private static int level;

        /// <summary>
        /// Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].
        /// You may return the answer in any order.
        /// </summary>
        public _00077_Combinations()
        {
            IList<IList<int>> x = Combine(4, 2);

            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> Combine(int n, int k)
        {
            int[] c = Enumerable.Repeat(0, 20).ToArray();
            r = [];
            level = -1;

            Combo(1, n, k, c);

            return r;
        }

        private static void Combo(int k, int n, int m, int[] c)
        {
            if (k - 1 == m)
            {
                r?.Add([]);
                level++;
                for (int i = 1; i <= m; i++)
                {
                    r?[level].Add(c[i]);
                }
            }
            else
            {
                for (int i = c[k - 1] + 1; i <= n - m + k; i++)
                {
                    c[k] = i;
                    Combo(k + 1, n, m, c);
                }
            }
        }
    }
}
