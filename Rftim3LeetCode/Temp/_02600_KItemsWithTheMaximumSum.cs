namespace Rftim3LeetCode.Temp
{
    public class _02600_KItemsWithTheMaximumSum
    {
        /// <summary>
        /// There is a bag that consists of items, each item has a number 1, 0, or -1 written on it.
        /// You are given four non-negative integers numOnes, numZeros, numNegOnes, and k.
        /// The bag initially contains:
        /// numOnes items with 1s written on them.
        /// numZeroes items with 0s written on them.
        /// numNegOnes items with -1s written on them.
        /// We want to pick exactly k items among the available items.
        /// Return the maximum possible sum of numbers written on the items.
        /// </summary>
        public _02600_KItemsWithTheMaximumSum()
        {
            Console.WriteLine(KItemsWithMaximumSum(3, 2, 0, 2));
            Console.WriteLine(KItemsWithMaximumSum(3, 2, 0, 4));
        }

        private static int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
        {
            int result = Math.Min(numOnes, k);

            if (k <= numOnes) return result;
            k -= numOnes;

            if (k <= numZeros) return result;
            k -= numZeros;

            result -= Math.Min(numNegOnes, k);

            return result;
        }

        private static int KItemsWithMaximumSum0(int numOnes, int numZeros, int numNegOnes, int k)
        {
            int result = 0;

            for (int index = 0; index < k; index++)
            {
                if (numOnes > 0)
                {
                    result++;
                    numOnes--;
                }
                else if (numZeros > 0) numZeros--;
                else result--;
            }

            return result;
        }
    }
}
