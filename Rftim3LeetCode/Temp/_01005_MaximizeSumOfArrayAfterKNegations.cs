namespace Rftim3LeetCode.Temp
{
    public class _01005_MaximizeSumOfArrayAfterKNegations
    {
        /// <summary>
        /// Given an integer array nums and an integer k, modify the array in the following way:
        /// choose an index i and replace nums[i] with -nums[i].
        /// You should apply this process exactly k times. You may choose the same index i multiple times.
        /// Return the largest possible sum of the array after modifying it in this way.
        /// </summary>
        public _01005_MaximizeSumOfArrayAfterKNegations()
        {
            Console.WriteLine(LargestSumAfterKNegations([4, 2, 3], 1));
            Console.WriteLine(LargestSumAfterKNegations([3, -1, 0, 2], 3));
            Console.WriteLine(LargestSumAfterKNegations([2, -3, -1, 5, -4], 2));
            Console.WriteLine(LargestSumAfterKNegations([-4, -2, -3], 4));
        }

        private static int LargestSumAfterKNegations(int[] nums, int k)
        {
            int n = nums.Length;
            Array.Sort(nums);

            if (nums.Min() >= 0)
            {
                nums[0] *= (int)Math.Pow(-1, k);
                return nums.Sum();
            }
            else
            {
                int i = 0;
                while (k > 0 && nums[i] < 0 && i < n - 1)
                {
                    nums[i] *= -1;
                    i++;
                    k--;
                }

                Array.Sort(nums);
                if (k > 0) nums[0] *= (int)Math.Pow(-1, k);
            }

            return nums.Sum();
        }
    }
}
