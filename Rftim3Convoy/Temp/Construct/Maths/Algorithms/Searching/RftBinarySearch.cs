namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Searching
{
    public class RftBinarySearch
    {
        public RftBinarySearch()
        {
            Console.WriteLine(BinarySearch([-1, 0, 3, 5, 9, 12], 9));
        }

        private static int BinarySearch(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;

            int l = 0, r = nums.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target) { return mid; }
                else if (nums[mid] < target) { l = mid + 1; }
                else { r = mid - 1; }
            }

            return -1;
        }
    }
}
