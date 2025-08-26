namespace Rftim3LeetCode.Temp
{
    public class _01846_MaximumElementAfterDecreasingAndRearranging
    {
        /// <summary>
        /// You are given an array of positive integers arr. Perform some operations (possibly none) on arr so that it satisfies these conditions:
        /// 
        /// The value of the first element in arr must be 1.
        /// The absolute difference between any 2 adjacent elements must be less than or equal to 1. 
        /// In other words, abs(arr[i] - arr[i - 1]) <= 1 for each i where 1 <= i<arr.length (0-indexed). abs(x) is the absolute value of x.
        /// There are 2 types of operations that you can perform any number of times:
        /// 
        /// Decrease the value of any element of arr to a smaller positive integer.
        /// Rearrange the elements of arr to be in any order.
        /// Return the maximum possible value of an element in arr after performing the operations to satisfy the conditions.
        /// </summary>
        public _01846_MaximumElementAfterDecreasingAndRearranging()
        {
            Console.WriteLine(MaximumElementAfterDecrementingAndRearranging0([2, 2, 1, 2, 1]));
            Console.WriteLine(MaximumElementAfterDecrementingAndRearranging0([100, 1, 1000]));
            Console.WriteLine(MaximumElementAfterDecrementingAndRearranging0([1, 2, 3, 4, 5]));
        }

        public static int MaximumElementAfterDecrementingAndRearranging0(int[] a0) => RftMaximumElementAfterDecrementingAndRearranging0(a0);

        private static int RftMaximumElementAfterDecrementingAndRearranging0(int[] arr)
        {
            int n = arr.Length;
            Array.Sort(arr);

            arr[0] = 1;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] - arr[i - 1] > 1) arr[i] = arr[i - 1] + 1;
            }

            return arr[^1];
        }
    }
}
