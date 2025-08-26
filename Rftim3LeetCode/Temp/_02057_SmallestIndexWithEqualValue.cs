namespace Rftim3LeetCode.Temp
{
    public class _02057_SmallestIndexWithEqualValue
    {
        /// <summary>
        /// Given a 0-indexed integer array nums, return the smallest index i of nums such that i mod 10 == nums[i], or -1 if such index does not exist.
        /// x mod y denotes the remainder when x is divided by y.
        /// </summary>
        public _02057_SmallestIndexWithEqualValue()
        {
            Console.WriteLine(SmallestEqual([0, 1, 2]));
            Console.WriteLine(SmallestEqual([4, 3, 2, 1]));
            Console.WriteLine(SmallestEqual([1, 2, 3, 4, 5, 6, 7, 8, 9, 0]));
        }

        private static int SmallestEqual(int[] nums)
        {
            int c = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 10 == nums[i]) c = Math.Min(c, i);
            }

            return c == int.MaxValue ? -1 : c;
        }
    }
}
