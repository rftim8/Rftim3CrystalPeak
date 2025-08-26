namespace Rftim3LeetCode.Temp
{
    public class _01155_NumberOfDiceRollsWithTargetSum
    {
        /// <summary>
        /// You have n dice, and each die has k faces numbered from 1 to k.
        /// 
        /// Given three integers n, k, and target, return the number of possible ways(out of the kn total ways) to roll the dice, 
        /// so the sum of the face-up numbers equals target.Since the answer may be too large, return it modulo 109 + 7.
        /// </summary>
        public _01155_NumberOfDiceRollsWithTargetSum()
        {
            Console.WriteLine(NumRollsToTarget0(1, 6, 3));
            Console.WriteLine(NumRollsToTarget0(2, 6, 7));
            Console.WriteLine(NumRollsToTarget0(30, 30, 500));
        }

        public static int NumRollsToTarget0(int a0, int a1, int a2) => RftNumRollsToTarget0(a0, a1, a2);

        private static int RftNumRollsToTarget0(int n, int k, int target)
        {
            int mod = 1000000007;
            int[] dp = new int[target + 1];
            dp[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                int[] t = new int[target + 1];
                for (int j = 1; j <= k; j++)
                {
                    for (var l = j; l <= target; l++)
                    {
                        t[l] = (t[l] + dp[l - j]) % mod;
                    }
                }

                dp = t;
            }

            return dp[target];
        }
    }
}
