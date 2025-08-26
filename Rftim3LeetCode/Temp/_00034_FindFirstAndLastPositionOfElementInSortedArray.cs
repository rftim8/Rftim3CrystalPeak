using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00034_FindFirstAndLastPositionOfElementInSortedArray
    {
        /// <summary>
        /// Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
        /// If target is not found in the array, return [-1, -1].
        /// You must write an algorithm with O(log n) runtime complexity.
        /// </summary>
        public _00034_FindFirstAndLastPositionOfElementInSortedArray()
        {
            int[] x = FindFirstAndLastPositionOfElementInSortedArray0([5, 7, 7, 8, 8, 10], 8);
            int[] x0 = FindFirstAndLastPositionOfElementInSortedArray0([5, 7, 7, 8, 8, 10], 6);
            int[] x1 = FindFirstAndLastPositionOfElementInSortedArray0([], 0);
            int[] x2 = FindFirstAndLastPositionOfElementInSortedArray0([1], 1);
            int[] x3 = FindFirstAndLastPositionOfElementInSortedArray0([2, 2], 3);
            int[] x4 = FindFirstAndLastPositionOfElementInSortedArray0([1, 1, 2], 1);
            int[] x5 = FindFirstAndLastPositionOfElementInSortedArray0([2, 2], 2);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
            RftTerminal.RftReadResult(x3);
            RftTerminal.RftReadResult(x4);
            RftTerminal.RftReadResult(x5);
        }

        public static int[] FindFirstAndLastPositionOfElementInSortedArray0(int[] a0, int a1) => RftFindFirstAndLastPositionOfElementInSortedArray0(a0, a1);

        private static int[] RftFindFirstAndLastPositionOfElementInSortedArray0(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0) return [-1, -1];

            int x = -1, l = 0, r = n - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target)
                {
                    while (mid > 0)
                    {
                        if (nums[mid - 1] == target) mid--;
                        else break;
                    }
                    x = mid;
                    break;
                }
                else if (nums[mid] < target) { l = mid + 1; }
                else { r = mid - 1; }
            }

            if (x == -1) return [-1, -1];
            else
            {
                int[] y = new int[2];
                y[0] = x;

                if (x == n - 1) return [x, x];
                else
                {
                    while (x + 1 < n && nums[x + 1] == target)
                    {
                        x++;
                    }
                    y[1] = x;
                }

                return y;
            }
        }
    }
}
