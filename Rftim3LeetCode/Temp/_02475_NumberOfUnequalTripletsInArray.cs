namespace Rftim3LeetCode.Temp
{
    public class _02475_NumberOfUnequalTripletsInArray
    {
        /// <summary>
        /// You are given a 0-indexed array of positive integers nums. 
        /// Find the number of triplets (i, j, k) that meet the following conditions:
        /// 0 <= i<j<k<nums.length
        /// nums[i], nums[j], and nums[k] are pairwise distinct.
        /// In other words, nums[i] != nums[j], nums[i] != nums[k], and nums[j] != nums[k].
        /// Return the number of triplets that meet the conditions.
        /// </summary>
        public _02475_NumberOfUnequalTripletsInArray()
        {
            Console.WriteLine(UnequalTriplets([4, 4, 2, 4, 3]));
            Console.WriteLine(UnequalTriplets([1, 1, 1, 1, 1]));
        }

        private static int UnequalTriplets(int[] nums)
        {
            int n = nums.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (nums[i] != nums[j] && nums[j] != nums[k] && nums[i] != nums[k]) c++;
                    }
                }
            }

            return c;
        }
    }
}
