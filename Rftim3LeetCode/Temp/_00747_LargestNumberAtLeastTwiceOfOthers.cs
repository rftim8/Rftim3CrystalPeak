namespace Rftim3LeetCode.Temp
{
    public class _00747_LargestNumberAtLeastTwiceOfOthers
    {
        /// <summary>
        /// You are given an integer array nums where the largest integer is unique.
        /// Determine whether the largest element in the array is at least twice as much as every other number in the array.
        /// If it is, return the index of the largest element, or return -1 otherwise.
        /// </summary>
        public _00747_LargestNumberAtLeastTwiceOfOthers()
        {
            Console.WriteLine(DominantIndex([3, 6, 1, 0]));
            Console.WriteLine(DominantIndex([1, 2, 3, 4]));
            Console.WriteLine(DominantIndex([0, 0, 0, 1]));
        }

        private static int DominantIndex(int[] nums)
        {
            int c = -1;
            int max = nums.Max();
            int half = max / 2;

            for (int i = 0; i < nums.Length; i++)
            {
                int x = nums[i];
                if (x > half && x != max) return -1;
                if (x == max) c = i;
            }

            return c;
        }
    }
}
