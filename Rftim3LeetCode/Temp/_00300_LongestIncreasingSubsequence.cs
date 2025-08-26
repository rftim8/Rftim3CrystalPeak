namespace Rftim3LeetCode.Temp
{
    public class _00300_LongestIncreasingSubsequence
    {
        /// <summary>
        /// Given an integer array nums, return the length of the longest strictly increasing subsequence.
        /// </summary>
        public _00300_LongestIncreasingSubsequence()
        {
            Console.WriteLine(LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
            Console.WriteLine(LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 }));
            Console.WriteLine(LengthOfLIS(new int[] { 7, 7, 7, 7, 7, 7, 7 }));
        }

        private static int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return n;

            int[] x = new int[n];
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                int index = Array.BinarySearch(x, 0, c, nums[i]);
                if (index < 0) index = ~index;
                x[index] = nums[i];
                if (index == c) c++;
            }

            return c;
        }

        private static int LengthOfLIS0(int[] nums)
        {
            IList<int> x = new List<int>
            {
                nums[0]
            };

            foreach (int item in nums)
            {
                if (item > x[x.Count - 1]) x.Add(item);
                else
                {
                    int j = 0;
                    while (x[j] < item)
                    {
                        j++;
                    }

                    x[j] = item;
                }
            }

            return x.Count;
        }
    }
}
