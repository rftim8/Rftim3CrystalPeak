namespace Rftim3LeetCode.Temp
{
    public class _02206_DivideArrayIntoEqualPairs
    {
        /// <summary>
        /// You are given an integer array nums consisting of 2 * n integers.
        /// You need to divide nums into n pairs such that:
        /// Each element belongs to exactly one pair.
        /// The elements present in a pair are equal.
        /// Return true if nums can be divided into n pairs, otherwise return false.
        /// </summary>
        public _02206_DivideArrayIntoEqualPairs()
        {
            Console.WriteLine(DivideArray([3, 2, 3, 2, 2, 2]));
            Console.WriteLine(DivideArray([1, 2, 3, 4]));
        }

        private static bool DivideArray(int[] nums)
        {
            int n = nums.Length;
            if (n % 2 != 0) return false;
            Array.Sort(nums);

            for (int i = 0; i < n; i += 2)
            {
                if (nums[i] != nums[i + 1]) return false;
            }

            return true;
        }
    }
}
