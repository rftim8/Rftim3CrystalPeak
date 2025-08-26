using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02300_SuccessfulPairsOfSpellsAndPotions
    {
        /// <summary>
        /// You are given two positive integer arrays spells and potions, of length n and m respectively, where spells[i] represents 
        /// the strength of the ith spell and potions[j] represents the strength of the jth potion.
        /// You are also given an integer success.A spell and potion pair is considered successful if the product of their strengths is at least success.
        /// Return an integer array pairs of length n where pairs[i] is the number of potions that will form a successful pair with the ith spell.
        /// </summary>
        public _02300_SuccessfulPairsOfSpellsAndPotions()
        {
            int[] x = SuccessfulPairs([5, 1, 3], [1, 2, 3, 4, 5], 7);
            int[] x0 = SuccessfulPairs([40, 11, 24, 28, 40, 22, 26, 38, 28, 10, 31, 16, 10, 37, 13, 21, 9, 22, 21, 18, 34, 2, 40, 40, 6, 16, 9, 14, 14, 15, 37, 15, 32, 4, 27, 20, 24, 12, 26, 39, 32, 39, 20, 19, 22, 33, 2, 22, 9, 18, 12, 5],
                [31, 40, 29, 19, 27, 16, 25, 8, 33, 25, 36, 21, 7, 27, 40, 24, 18, 26, 32, 25, 22, 21, 38, 22, 37, 34, 15, 36, 21, 22, 37, 14, 31, 20, 36, 27, 28, 32, 21, 26, 33, 37, 27, 39, 19, 36, 20, 23, 25, 39, 40],
                600);
            int[] x1 = SuccessfulPairs(
                [36, 36, 22, 11, 35, 21, 4, 25, 30, 35, 31, 10, 8, 39, 7, 22, 18, 9, 23, 30, 9, 37, 22, 7, 36, 40, 17, 37, 38, 27, 6, 15, 1, 15, 7, 31, 36, 29, 9, 15, 3, 37, 15, 17, 25, 35, 9, 21, 5, 17, 25, 8, 18, 25, 7, 19, 4, 33, 9, 5, 29, 13, 9, 18, 5, 10, 31, 6, 7, 24, 13, 11, 8, 19, 2],
                [30, 11, 5, 20, 19, 36, 39, 24, 20, 37, 33, 22, 32, 28, 36, 24, 40, 27, 36, 37, 38, 23, 39, 11, 40, 19, 37, 32, 25, 29, 28, 37, 31, 36, 32, 40, 38, 22, 17, 38, 20, 33, 29, 17, 36, 33, 35, 25, 28, 18, 17, 19, 40, 27, 40, 28, 40, 40, 40, 39, 17, 34, 36, 11, 22, 29, 22, 35, 35, 22, 18, 34],
                135
                );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            int n = spells.Length;
            int m = potions.Length;
            Array.Sort(potions);

            int[] x = new int[n];

            for (int i = 0; i < n; i++)
            {
                int l = 0, r = m;

                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if ((long)spells[i] * potions[mid] >= success) r = mid;
                    else l = mid + 1;
                }

                x[i] = m - l;
            }

            return x;
        }

        // O(n*m)
        private static int[] SuccessfulPairs1(int[] spells, int[] potions, long success)
        {
            int n = spells.Length;
            int m = potions.Length;
            int[] y = new int[n];
            long[] x = new long[m];
            Array.Sort(potions);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    x[j] = (long)spells[i] * potions[j];
                }

                int index = Array.BinarySearch(x, success);

                if (index < 0) index = ~index;
                else
                {
                    if (index > 0) while (x[index - 1] == success) index--;
                }

                y[i] = m - index;
            }

            return y;
        }
    }
}
