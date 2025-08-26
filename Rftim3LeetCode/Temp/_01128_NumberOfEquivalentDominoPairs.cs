namespace Rftim3LeetCode.Temp
{
    public class _01128_NumberOfEquivalentDominoPairs
    {
        /// <summary>
        /// Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] 
        /// if and only if either (a == c and b == d), or (a == d and b == c) - that is, one domino can be rotated to be equal to another domino.
        /// Return the number of pairs(i, j) for which 0 <= i<j<dominoes.length, and dominoes[i] is equivalent to dominoes[j].
        /// </summary>
        public _01128_NumberOfEquivalentDominoPairs()
        {
            Console.WriteLine(NumEquivDominoPairs(
            [
                [1,2],
                [2,1],
                [3,4],
                [5,6]
            ]));

            Console.WriteLine(NumEquivDominoPairs(
            [
                [1,2],
                [1,2],
                [1,1],
                [1,2],
                [2,2]
            ]));
        }

        private static int NumEquivDominoPairs(int[][] d)
        {
            int n = d.Length;

            Dictionary<(int x, int y), int> r = [];

            for (int i = 0; i < n; i++)
            {
                Array.Sort(d[i]);
                if (r.ContainsKey((d[i][0], d[i][1]))) r[(d[i][0], d[i][1])]++;
                else r[(d[i][0], d[i][1])] = 1;
            }

            int c = 0;
            foreach (KeyValuePair<(int x, int y), int> item in r)
            {
                if (item.Value > 1)
                {
                    int t = 0;
                    for (int i = 0; i < item.Value; i++)
                    {
                        t += i;
                    }
                    c += t;
                }
            }

            return c;
        }

        private static int NumEquivDominoPairs0(int[][] dominoes)
        {
            int[] freqs = new int[100];
            int ans = 0;

            foreach (int[] d in dominoes)
            {
                int domino = d[0] < d[1] ? d[0] * 10 + d[1] : d[1] * 10 + d[0];
                ans += freqs[domino];
                freqs[domino]++;
            }

            return ans;
        }
    }
}
