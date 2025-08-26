namespace Rftim3LeetCode.Temp
{
    public class _00416_PartitionEqualSubsetSum
    {
        /// <summary>
        /// Given an integer array nums, return true if you can partition the array into two subsets such 
        /// that the sum of the elements in both subsets is equal or false otherwise.
        /// </summary>
        public _00416_PartitionEqualSubsetSum()
        {
            Console.WriteLine(CanPartition([1, 5, 11, 5]));
            Console.WriteLine(CanPartition([1, 2, 3, 5]));
        }

        private static bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums) sum += num;

            if (sum % 2 != 0) return false;

            int n = nums.Length, m = sum / 2;
            bool[,] dp = new bool[n + 1, m + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (nums[i - 1] > j) dp[i, j] = dp[i - 1, j];
                    else dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                }
            }

            return dp[n, m];
        }

        private static bool CanPartition0(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums) sum += num;

            if (sum % 2 != 0) return false;

            int halfSum = sum / 2;
            bool[] dp = new bool[halfSum + 1];
            dp[0] = true;
            foreach (int num in nums)
            {
                for (int j = halfSum; j >= num; j--) dp[j] = dp[j] || dp[j - num];
            }

            return dp[halfSum];
        }

        private static bool CanPartition1(int[] nums)
        {
            int totalSum = nums.Sum();
            if (nums.Length == 1 || totalSum % 2 != 0) return false;
            int rightAmount = totalSum / 2;

            bool[] possibleSums = new bool[rightAmount + 1];
            possibleSums[0] = true;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = possibleSums.Length - 1; j >= nums[i]; j--)
                {
                    if (possibleSums[j - nums[i]]) possibleSums[j] = true;
                }
            }

            return possibleSums[rightAmount];
        }
    }
}
