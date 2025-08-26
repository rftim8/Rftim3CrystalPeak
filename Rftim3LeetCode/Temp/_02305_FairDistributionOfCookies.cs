namespace Rftim3LeetCode.Temp
{
    public class _02305_FairDistributionOfCookies
    {
        /// <summary>
        /// You are given an integer array cookies, where cookies[i] denotes the number of cookies in the ith bag. 
        /// You are also given an integer k that denotes the number of children to distribute all the bags of cookies to. 
        /// All the cookies in the same bag must go to the same child and cannot be split up.
        /// The unfairness of a distribution is defined as the maximum total cookies obtained by a single child in the distribution.
        /// Return the minimum unfairness of all distributions.
        /// </summary>
        public _02305_FairDistributionOfCookies()
        {
            Console.WriteLine(DistributeCookies([8, 15, 10, 20, 8], 2));
            Console.WriteLine(DistributeCookies([6, 1, 3, 2, 2, 4, 1, 2], 3));
        }

        private static int DistributeCookies(int[] cookies, int k)
        {
            int[] distribute = new int[k];

            return Dfs(0, distribute, cookies, k, k);
        }

        private static int Dfs(int i, int[] distribute, int[] cookies, int k, int zeroCount)
        {
            if (cookies.Length - i < zeroCount) return int.MaxValue;

            if (i == cookies.Length)
            {
                int unfairness = int.MinValue;
                foreach (int value in distribute)
                {
                    unfairness = Math.Max(unfairness, value);
                }

                return unfairness;
            }

            int answer = int.MaxValue;
            for (int j = 0; j < k; ++j)
            {
                zeroCount -= distribute[j] == 0 ? 1 : 0;
                distribute[j] += cookies[i];

                answer = Math.Min(answer, Dfs(i + 1, distribute, cookies, k, zeroCount));

                distribute[j] -= cookies[i];
                zeroCount += distribute[j] == 0 ? 1 : 0;
            }

            return answer;
        }
    }
}
