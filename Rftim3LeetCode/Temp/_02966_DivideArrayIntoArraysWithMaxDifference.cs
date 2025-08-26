using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02966_DivideArrayIntoArraysWithMaxDifference
    {
        /// <summary>
        /// You are given an integer array nums of size n and a positive integer k.
        /// 
        /// Divide the array into one or more arrays of size 3 satisfying the following conditions:
        /// 
        /// Each element of nums should be in exactly one array.
        /// The difference between any two elements in one array is less than or equal to k.
        /// Return a 2D array containing all the arrays.If it is impossible to satisfy the conditions, return an empty array.
        /// And if there are multiple answers, return any of them.
        /// </summary>
        public _02966_DivideArrayIntoArraysWithMaxDifference()
        {
            int[][] a0 = DivideArrayIntoArraysWithMaxDifference0([1, 3, 4, 8, 7, 9, 3, 5, 1], 2);
            RftTerminal.RftReadResult<int>(a0);

            int[][] a1 = DivideArrayIntoArraysWithMaxDifference0([1, 3, 3, 2, 7, 3], 3);
            RftTerminal.RftReadResult<int>(a1);
        }

        public static int[][] DivideArrayIntoArraysWithMaxDifference0(int[] a0, int a1) => RftDivideArrayIntoArraysWithMaxDifference0(a0, a1);

        public static int[][] DivideArrayIntoArraysWithMaxDifference1(int[] a0, int a1) => RftDivideArrayIntoArraysWithMaxDifference1(a0, a1);

        private static int[][] RftDivideArrayIntoArraysWithMaxDifference0(int[] nums, int k)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int m = n / 3;
            int[][] res = new int[m][];

            int c = 0;
            for (int i = 0; i < n - 2; i += 3)
            {
                if (nums[i + 2] - nums[i] > k) return [];
                else res[c] = [nums[i], nums[i + 1], nums[i + 2]];

                c++;
            }

            return res;
        }

        private static int[][] RftDivideArrayIntoArraysWithMaxDifference1(int[] nums, int k)
        {
            Array.Sort(nums);

            int[][] res = new int[nums.Length / 3][];
            int c = 0;
            for (int i = 0; i < nums.Length; i += 3)
            {
                if (nums[i + 2] - nums[i] <= k)
                {
                    res[c] = [nums[i], nums[i + 1], nums[i + 2]];
                    c++;
                }

                else return [];
            }

            return res;
        }
    }
}
