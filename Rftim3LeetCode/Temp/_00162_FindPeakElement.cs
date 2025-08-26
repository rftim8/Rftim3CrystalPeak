namespace Rftim3LeetCode.Temp
{
    public class _00162_FindPeakElement
    {
        /// <summary>
        /// A peak element is an element that is strictly greater than its neighbors.
        /// Given a 0-indexed integer array nums, find a peak element, and return its index.If the array contains multiple peaks, return the index to any of the peaks.
        /// You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to be strictly greater than a neighbor that is outside the array.
        /// You must write an algorithm that runs in O(log n) time.
        /// </summary>
        public _00162_FindPeakElement()
        {
            Console.WriteLine(FindPeakElement(new int[] { 1, 2, 3, 1 }));
            Console.WriteLine(FindPeakElement(new int[] { 1, 2, 1, 3, 5, 6, 4 }));
            Console.WriteLine(FindPeakElement(new int[] { 1 }));
            Console.WriteLine(FindPeakElement(new int[] { 2, 1 }));
            Console.WriteLine(FindPeakElement(new int[] { 2, 1, 3 }));
        }

        private static int FindPeakElement(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return 0;

            int l = 0;
            int r = n - 1;
            int mid = (l + r) / 2;

            while (l < r)
            {
                if (nums[mid] < nums[mid + 1]) l = mid + 1;
                else r = mid;
                mid = (l + r) / 2;
            }

            return mid;
        }
    }
}
