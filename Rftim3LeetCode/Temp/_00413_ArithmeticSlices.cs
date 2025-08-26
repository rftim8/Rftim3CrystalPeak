namespace Rftim3LeetCode.Temp
{
    public class _00413_ArithmeticSlices
    {
        /// <summary>
        /// An integer array is called arithmetic if it consists of at least three elements and if the difference between any two consecutive elements is the same.
        /// For example, [1, 3, 5, 7, 9], [7, 7, 7, 7], and[3, -1, -5, -9] are arithmetic sequences.
        /// Given an integer array nums, return the number of arithmetic subarrays of nums.
        /// A subarray is a contiguous subsequence of the array.
        /// </summary>
        public _00413_ArithmeticSlices()
        {
            Console.WriteLine(NumberOfArithmeticSlices([1, 2, 3, 4]));
            Console.WriteLine(NumberOfArithmeticSlices([1]));
        }

        private static int NumberOfArithmeticSlices(int[] nums)
        {
            int n = nums.Length;
            int[] x = new int[n];

            int y = 0;
            for (int i = 2; i < n; i++)
            {
                if (nums[i - 1] - nums[i - 2] == nums[i] - nums[i - 1]) x[i] = x[i - 1] + 1;

                y += x[i];
            }

            return y;
        }

        private static int NumberOfArithmeticSlices0(int[] A)
        {
            int count = 0;
            for (int s = 0; s < A.Length - 2; s++)
            {
                int d = A[s + 1] - A[s];
                for (int e = s + 2; e < A.Length; e++)
                {
                    if (A[e] - A[e - 1] == d) count++;
                    else break;
                }
            }

            return count;
        }
    }
}
