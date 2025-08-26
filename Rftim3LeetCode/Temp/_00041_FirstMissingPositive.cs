namespace Rftim3LeetCode.Temp
{
    public class _00041_FirstMissingPositive
    {
        /// <summary>
        /// Given an unsorted integer array nums, return the smallest missing positive integer.
        /// You must implement an algorithm that runs in O(n) time and uses O(1) auxiliary space.
        /// </summary>
        public _00041_FirstMissingPositive()
        {
            Console.WriteLine(FirstMissingPositive0([1, 2, 0]));
            Console.WriteLine(FirstMissingPositive0([3, 4, -1, 1]));
            Console.WriteLine(FirstMissingPositive0([7, 8, 9, 11, 12]));
        }

        public static int FirstMissingPositive0(int[] a0) => RftFirstMissingPositive0(a0);

        private static int RftFirstMissingPositive0(int[] nums)
        {
            HashSet<int> r = new(nums);
            int t = 1;
            for (int i = 0; i < r.Count; i++, t++)
            {
                if (!r.Contains(t)) return t;
            }

            return t;
        }
    }
}
