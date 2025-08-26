namespace Rftim3LeetCode.Temp
{
    public class _01588_SumOfAllOddLengthSubarrays
    {
        /// <summary>
        /// Given an array of positive integers arr, return the sum of all possible odd-length subarrays of arr.
        /// A subarray is a contiguous subsequence of the array.
        /// </summary>
        public _01588_SumOfAllOddLengthSubarrays()
        {
            Console.WriteLine(SumOddLengthSubarrays([1, 4, 2, 5, 3]));
            Console.WriteLine(SumOddLengthSubarrays([1, 2]));
            Console.WriteLine(SumOddLengthSubarrays([10, 11, 12]));
        }

        private static int SumOddLengthSubarrays(int[] arr)
        {
            int n = arr.Length, x = 0;

            for (int i = 0; i < n; ++i)
            {
                int l = i, r = n - i - 1;
                x += arr[i] * (l / 2 + 1) * (r / 2 + 1);
                x += arr[i] * ((l + 1) / 2) * ((r + 1) / 2);
            }

            return x;
        }
    }
}
