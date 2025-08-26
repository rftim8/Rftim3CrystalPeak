namespace Rftim3LeetCode.Temp
{
    public class _00376_WiggleSubsequence
    {
        /// <summary>
        /// A wiggle sequence is a sequence where the differences between successive numbers strictly alternate between positive and negative. 
        /// The first difference (if one exists) may be either positive or negative. A sequence with one element and a sequence with two non-equal 
        /// elements are trivially wiggle sequences.
        /// For example, [1, 7, 4, 9, 2, 5] is a wiggle sequence because the differences(6, -3, 5, -7, 3) alternate between positive and negative.
        /// In contrast, [1, 4, 7, 2, 5] and[1, 7, 4, 5, 5] are not wiggle sequences.The first is not because its first two differences are positive,
        /// and the second is not because its last difference is zero.
        /// A subsequence is obtained by deleting some elements(possibly zero) from the original sequence, leaving the remaining elements in their original order.
        /// Given an integer array nums, return the length of the longest wiggle subsequence of nums.
        /// </summary>
        public _00376_WiggleSubsequence()
        {
            Console.WriteLine(WiggleMaxLength([1, 7, 4, 9, 2, 5]));
            Console.WriteLine(WiggleMaxLength([1, 17, 5, 10, 13, 15, 10, 5, 16, 8]));
            Console.WriteLine(WiggleMaxLength([1, 2, 3, 4, 5, 6, 7, 8, 9]));
        }

        private static int WiggleMaxLength(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return n;

            int[] up = new int[n];
            int[] down = new int[n];
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j]) up[i] = Math.Max(up[i], down[j] + 1);
                    else if (nums[i] < nums[j]) down[i] = Math.Max(down[i], up[j] + 1);
                }
            }

            return 1 + Math.Max(down[n - 1], up[n - 1]);
        }

        private static int WiggleMaxLength0(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return n;

            int[] up = new int[n];
            int[] down = new int[n];
            up[0] = down[0] = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    up[i] = down[i - 1] + 1;
                    down[i] = down[i - 1];
                }
                else if (nums[i] < nums[i - 1])
                {
                    down[i] = up[i - 1] + 1;
                    up[i] = up[i - 1];
                }
                else
                {
                    down[i] = down[i - 1];
                    up[i] = up[i - 1];
                }
            }
            return Math.Max(down[n - 1], up[n - 1]);
        }

        private static int WiggleMaxLength1(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return n;

            int down = 1, up = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1]) up = down + 1;
                else if (nums[i] < nums[i - 1]) down = up + 1;
            }

            return Math.Max(down, up);
        }

        private static int WiggleMaxLength2(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return n;

            int prevdiff = nums[1] - nums[0];
            int count = prevdiff != 0 ? 2 : 1;
            for (int i = 2; i < n; i++)
            {
                int diff = nums[i] - nums[i - 1];
                if (diff > 0 && prevdiff <= 0 || diff < 0 && prevdiff >= 0)
                {
                    count++;
                    prevdiff = diff;
                }
            }

            return count;
        }

        private static int WiggleMaxLength3(int[] nums)
        {
            int lastSign = 0;
            int result = nums.Length;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int diffSign = Math.Sign(nums[i + 1] - nums[i]);
                if (diffSign == 0 || diffSign == lastSign) result--;
                else lastSign = diffSign;
            }

            return result;
        }
    }
}
