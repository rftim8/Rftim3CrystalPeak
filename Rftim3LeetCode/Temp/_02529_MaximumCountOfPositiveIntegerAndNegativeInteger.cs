namespace Rftim3LeetCode.Temp
{
    public class _02529_MaximumCountOfPositiveIntegerAndNegativeInteger
    {
        /// <summary>
        /// Given an array nums sorted in non-decreasing order, return the maximum between the number of positive integers and the number of negative integers.
        /// In other words, if the number of positive integers in nums is pos and the number of negative integers is neg, then return the maximum of pos and neg.
        /// Note that 0 is neither positive nor negative.
        /// </summary>
        public _02529_MaximumCountOfPositiveIntegerAndNegativeInteger()
        {
            Console.WriteLine(MaximumCount([-2, -1, -1, 1, 2, 3]));
            Console.WriteLine(MaximumCount([-3, -2, -1, 0, 0, 1, 2]));
            Console.WriteLine(MaximumCount([5, 20, 66, 1314]));
        }

        private static int MaximumCount(int[] nums)
        {
            int n = nums.Length;
            int l = 0, r = 0;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] != 0)
                {
                    if (nums[i] < 0) l++;
                    else r++;
                }
            }

            return Math.Max(l, r);
        }
    }
}
