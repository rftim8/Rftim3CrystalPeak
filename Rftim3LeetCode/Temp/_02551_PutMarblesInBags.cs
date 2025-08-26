namespace Rftim3LeetCode.Temp
{
    public class _02551_PutMarblesInBags
    {
        /// <summary>
        /// You have k bags. You are given a 0-indexed integer array weights where weights[i] is the weight of the ith marble. 
        /// You are also given the integer k.
        /// Divide the marbles into the k bags according to the following rules:
        /// No bag is empty.
        /// If the ith marble and jth marble are in a bag, then all marbles with an index between the ith and jth indices should also be in that same bag.
        /// If a bag consists of all the marbles with an index from i to j inclusively, then the cost of the bag is weights[i] + weights[j].
        /// The score after distributing the marbles is the sum of the costs of all the k bags.
        /// Return the difference between the maximum and minimum scores among marble distributions.
        /// </summary>
        public _02551_PutMarblesInBags()
        {
            Console.WriteLine(PutMarbles([1, 3, 5, 1], 2));
            Console.WriteLine(PutMarbles([1, 3], 2));
        }

        // Sorting
        private static long PutMarbles(int[] weights, int k)
        {
            int n = weights.Length;
            int[] pairWeights = new int[n - 1];
            for (int i = 0; i < n - 1; ++i)
            {
                pairWeights[i] = weights[i] + weights[i + 1];
            }

            Array.Sort(pairWeights, 0, n - 1);

            long answer = 0L;
            for (int i = 0; i < k - 1; ++i)
            {
                answer += pairWeights[n - 2 - i] - pairWeights[i];
            }

            return answer;
        }
    }
}
