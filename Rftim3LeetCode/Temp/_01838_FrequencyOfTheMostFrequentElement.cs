namespace Rftim3LeetCode.Temp
{
    public class _01838_FrequencyOfTheMostFrequentElement
    {
        /// <summary>
        /// The frequency of an element is the number of times it occurs in an array.
        /// 
        /// You are given an integer array nums and an integer k.In one operation, you can choose an index of nums and increment the element at that index by 1.
        /// 
        /// Return the maximum possible frequency of an element after performing at most k operations.
        /// </summary>
        public _01838_FrequencyOfTheMostFrequentElement()
        {
            Console.WriteLine(MaxFrequency0([1, 2, 4], 5));
            Console.WriteLine(MaxFrequency0([1, 4, 8, 13], 5));
            Console.WriteLine(MaxFrequency0([3, 9, 6], 2));
        }

        public static int MaxFrequency0(int[] a0, int a1) => RftMaxFrequency0(a0, a1);

        private static int RftMaxFrequency0(int[] nums, int k)
        {
            Array.Sort(nums);
            int left = 0;
            int ans = 0;
            long curr = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                int target = nums[right];
                curr += target;

                while ((right - left + 1) * target - curr > k)
                {
                    curr -= nums[left];
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);
            }

            return ans;
        }
    }
}
