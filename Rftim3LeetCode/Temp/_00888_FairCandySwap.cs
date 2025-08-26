using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00888_FairCandySwap
    {
        /// <summary>
        /// Alice and Bob have a different total number of candies. 
        /// You are given two integer arrays aliceSizes and bobSizes where aliceSizes[i] is the number of candies of the ith box of candy 
        /// that Alice has and bobSizes[j] is the number of candies of the jth box of candy that Bob has.
        /// Since they are friends, they would like to exchange one candy box each so that after the exchange, 
        /// they both have the same total amount of candy.The total amount of candy a person has is the sum of the number of candies in each box they have.
        /// Return an integer array answer where answer[0] is the number of candies in the box that Alice must exchange, 
        /// and answer[1] is the number of candies in the box that Bob must exchange. 
        /// If there are multiple answers, you may return any one of them. 
        /// It is guaranteed that at least one answer exists.
        /// </summary>
        public _00888_FairCandySwap()
        {
            int[] x = FairCandySwap(
                [1, 1],
                [2, 2]
            );

            int[] x0 = FairCandySwap(
                [1, 2],
                [2, 3]
            );

            int[] x1 = FairCandySwap(
                [2],
                [1, 3]
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
        {
            int sa = 0, sb = 0;

            foreach (int x in aliceSizes) sa += x;
            foreach (int x in bobSizes) sb += x;

            int delta = (sb - sa) / 2;

            HashSet<int> setB = [.. bobSizes];

            foreach (int x in aliceSizes)
            {
                if (setB.Contains(x + delta)) return [x, x + delta];
            }

            return [];
        }

        private static int[] FairCandySwap0(int[] aliceSizes, int[] bobSizes)
        {
            int[] result = new int[2];

            int aliceSum = aliceSizes.Sum();
            int bobSum = bobSizes.Sum();

            int diff = (bobSum - aliceSum) / 2;

            HashSet<int> bobset = [.. bobSizes];

            foreach (int aliceVal in aliceSizes)
            {
                int valToLookFor = aliceVal + diff;

                if (bobset.Contains(valToLookFor))
                {
                    result[0] = aliceVal;
                    result[1] = valToLookFor;

                    return result;
                }
            }

            return result;
        }
    }
}
