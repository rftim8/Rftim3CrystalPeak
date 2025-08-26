namespace Rftim3LeetCode.Temp
{
    public class _00629_KInversePairsArray
    {
        /// <summary>
        ///For an integer array nums, an inverse pair is a pair of integers [i, j] where 0 <= i < j < nums.length and nums[i] > nums[j].
        /// 
        /// Given two integers n and k, return the number of different arrays consist of numbers from 1 to n such that there are exactly k inverse pairs.
        /// Since the answer can be huge, return it modulo 109 + 7.
        /// </summary>
        public _00629_KInversePairsArray()
        {
            Console.WriteLine(KInversePairsArray0(3, 0));
            Console.WriteLine(KInversePairsArray0(3, 1));
        }

        public static int KInversePairsArray0(int a0, int a1) => RftKInversePairsArray0(a0, a1);

        private static int RftKInversePairsArray0(int n, int k)
        {
            int[] dp = new int[k + 1];
            int M = 1000000007;
            for (int i = 1; i <= n; i++)
            {
                int[] temp = new int[k + 1];
                temp[0] = 1;
                for (int j = 1; j <= k; j++)
                {
                    int val = (dp[j] + M - (j - i >= 0 ? dp[j - i] : 0)) % M;
                    temp[j] = (temp[j - 1] + val) % M;
                }
                dp = temp;
            }

            return (dp[k] + M - (k > 0 ? dp[k - 1] : 0)) % M;
        }
    }
}
