namespace Rftim3LeetCode.Temp
{
    public class _02855_MinimumRightShiftsToSortTheArray
    {
        /// <summary>
        /// You are given a 0-indexed array nums of length n containing distinct positive integers. 
        /// Return the minimum number of right shifts required to sort nums and -1 if this is not possible.
        /// A right shift is defined as shifting the element at index i to index(i + 1) % n, for all indices.
        /// </summary>
        public _02855_MinimumRightShiftsToSortTheArray()
        {
            Console.WriteLine(MinimumRightShifts([3, 4, 5, 1, 2]));
            Console.WriteLine(MinimumRightShifts([1, 3, 5]));
            Console.WriteLine(MinimumRightShifts([2, 1, 4]));
        }

        private static int MinimumRightShifts(IList<int> nums)
        {
            int n = nums.Count;
            int c = 0;
            while (nums[0] > nums[^1])
            {
                int t = nums[^1];
                nums.RemoveAt(n - 1);
                nums.Insert(0, t);
                c++;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] > nums[i + 1]) return -1;
            }

            return c;
        }
    }
}
