namespace Rftim3LeetCode.Temp
{
    public class _00594_LongestHarmoniousSubsequence
    {
        /// <summary>
        /// We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.
        /// Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.
        /// A subsequence of array is a sequence that can be derived from the array by deleting some or no elements without changing the order of the remaining elements.
        /// </summary>
        public _00594_LongestHarmoniousSubsequence()
        {
            Console.WriteLine(FindLHS([1, 3, 2, 2, 5, 2, 3, 7]));
            Console.WriteLine(FindLHS([1, 2, 3, 4]));
            Console.WriteLine(FindLHS([1, 1, 1, 1]));
            Console.WriteLine(FindLHS([1, 2, 2, 1]));
        }

        private static int FindLHS(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                bool valid = false;
                for (int j = i; j < n; j++)
                {
                    if (nums[j] - nums[i] < 2)
                    {
                        if (nums[j] - nums[i] == 1) valid = true;
                        c++;
                    }
                    else
                    {
                        if (valid) r = Math.Max(r, c);
                        break;
                    }
                    if (j == n - 1 && valid) r = Math.Max(r, c);
                }
            }

            return r;
        }

        private static int FindLHS0(int[] nums)
        {
            Array.Sort(nums);
            int l = 0, r = 1;
            int ans = 0;
            while (r < nums.Length)
            {
                int diff = nums[r] - nums[l];
                if (diff == 1) ans = Math.Max(ans, r - l + 1);

                if (diff <= 1) r++;
                else l++;
            }

            return ans;
        }
    }
}
