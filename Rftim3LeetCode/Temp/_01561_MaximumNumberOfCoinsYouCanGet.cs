namespace Rftim3LeetCode.Temp
{
    public class _01561_MaximumNumberOfCoinsYouCanGet
    {
        /// <summary>
        /// There are 3n piles of coins of varying size, you and your friends will take piles of coins as follows:
        /// 
        /// In each step, you will choose any 3 piles of coins(not necessarily consecutive).
        /// Of your choice, Alice will pick the pile with the maximum number of coins.
        /// You will pick the next pile with the maximum number of coins.
        /// Your friend Bob will pick the last pile.
        /// Repeat until there are no more piles of coins.
        /// Given an array of integers piles where piles[i] is the number of coins in the ith pile.
        /// 
        /// Return the maximum number of coins that you can have.
        /// </summary>
        public _01561_MaximumNumberOfCoinsYouCanGet()
        {
            Console.WriteLine(MaxCoins0([2, 4, 1, 2, 7, 8]));
            Console.WriteLine(MaxCoins0([2, 4, 5]));
            Console.WriteLine(MaxCoins0([9, 8, 7, 6, 5, 1, 2, 3, 4]));
        }

        public static int MaxCoins0(int[] a0) => RftMaxCoins0(a0);

        private static int RftMaxCoins0(int[] piles)
        {
            int n = piles.Length;
            Array.Sort(piles);

            int l = n - 2, c = 0;
            int i = n / 3;
            while (i > 0)
            {
                c += piles[l];
                l -= 2;
                i--;
            }

            return c;
        }
    }
}
