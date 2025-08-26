namespace Rftim3LeetCode.Temp
{
    public class _02395_FindSubarraysWithEqualSum
    {
        /// <summary>
        /// Given a 0-indexed integer array nums, determine whether there exist two subarrays of length 2 with equal sum. 
        /// Note that the two subarrays must begin at different indices.
        /// Return true if these subarrays exist, and false otherwise.
        /// A subarray is a contiguous non-empty sequence of elements within an array.
        /// </summary>
        public _02395_FindSubarraysWithEqualSum()
        {
            Console.WriteLine(FindSubarrays([4, 2, 4]));
            Console.WriteLine(FindSubarrays([1, 2, 3, 4, 5]));
            Console.WriteLine(FindSubarrays([0, 0, 0]));
        }

        private static bool FindSubarrays(int[] nums)
        {
            HashSet<int> exists = [];

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (!exists.Add(nums[i] + nums[i + 1])) return true;
            }

            return false;
        }
    }
}
