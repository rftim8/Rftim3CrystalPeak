namespace Rftim3LeetCode.Temp
{
    public class _01150_CheckIfANumberIsMajorityElementInASortedArray
    {
        /// <summary>
        /// Given an integer array nums sorted in non-decreasing order and an integer target, 
        /// return true if target is a majority element, or false otherwise.
        /// 
        /// A majority element in an array nums is an element that appears more than nums.length / 2 times in the array.
        /// </summary>
        public _01150_CheckIfANumberIsMajorityElementInASortedArray()
        {
            Console.WriteLine(CheckIfANumberIsMajorityElementInASortedArray0([2, 4, 5, 5, 5, 5, 5, 6, 6], 5)); // true
            Console.WriteLine(CheckIfANumberIsMajorityElementInASortedArray0([10, 100, 101, 101], 101)); // false
        }

        public static bool CheckIfANumberIsMajorityElementInASortedArray0(int[] a0, int a1) => RftCheckIfANumberIsMajorityElementInASortedArray0(a0, a1);

        private static bool RftCheckIfANumberIsMajorityElementInASortedArray0(int[] nums, int target)
        {
            int n = nums.Length / 2;
            Dictionary<int, int> kvp = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (kvp.TryGetValue(nums[i], out int value)) kvp[nums[i]] = ++value;
                else kvp[nums[i]] = 1;
            }

            return kvp.ContainsKey(target) && kvp[target] > n;
        }
    }
}
