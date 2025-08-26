namespace Rftim3LeetCode.Temp
{
    public class _00724_FindPivotIndex
    {
        /// <summary>
        /// Given an array of integers nums, calculate the pivot index of this array.
        /// The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.
        /// If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left.This also applies to the right edge of the array.
        /// Return the leftmost pivot index.If no such index exists, return -1.
        /// </summary>
        public _00724_FindPivotIndex()
        {
            Console.WriteLine(PivotIndex([1, 7, 3, 6, 5, 6]));
            Console.WriteLine(PivotIndex([1, 2, 3]));
            Console.WriteLine(PivotIndex([2, 1, -1]));
            Console.WriteLine(PivotIndex([-1, -1, -1, -1, -1, 0]));
            Console.WriteLine(PivotIndex([-1, -1, 0, 1, 1, 0]));
            Console.WriteLine(PivotIndex([-1, -1, -1, 1, 1, 1]));
        }

        private static int PivotIndex(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return 0;
            int c = -1;

            int l = 0;
            int r = nums[1..].Sum();
            for (int i = 0; i < n; i++)
            {
                if (i == 0 && r == 0) return i;
                else
                {
                    if (l == r) return i;
                }
                if (i < n - 1)
                {
                    l += nums[i];
                    r -= nums[i + 1];
                }

                if (i == n - 1 && l == 0) return i;
            }

            return c;
        }
    }
}
