namespace Rftim3LeetCode.Temp
{
    public class _00561_ArrayPartition
    {
        /// <summary>
        /// Given an integer array nums of 2n integers, group these integers into n pairs (a1, b1), (a2, b2), ..., (an, bn) such that the sum of min(ai, bi) for all i is maximized. 
        /// Return the maximized sum.
        /// </summary>
        public _00561_ArrayPartition()
        {
            Console.WriteLine(ArrayPairSum([1, 4, 3, 2]));
            Console.WriteLine(ArrayPairSum([6, 2, 6, 5, 1, 2]));
        }

        private static int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int r = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i % 2 == 0) r += Math.Min(nums[i], nums[i + 1]);
            }

            return r;
        }
    }
}
