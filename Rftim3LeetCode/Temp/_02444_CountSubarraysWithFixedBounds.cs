namespace Rftim3LeetCode.Temp
{
    public class _02444_CountSubarraysWithFixedBounds
    {
        /// <summary>
        /// You are given an integer array nums and two integers minK and maxK.
        /// A fixed-bound subarray of nums is a subarray that satisfies the following conditions:
        /// The minimum value in the subarray is equal to minK.
        /// The maximum value in the subarray is equal to maxK.
        /// Return the number of fixed-bound subarrays.
        /// A subarray is a contiguous part of an array.
        /// </summary>
        public _02444_CountSubarraysWithFixedBounds()
        {
            Console.WriteLine(CountSubarrays([1, 3, 5, 2, 7, 5], 1, 5));
            Console.WriteLine(CountSubarrays([1, 1, 1, 1], 1, 1));
            Console.WriteLine(CountSubarrays(
                [5, 10, 20, 20, 15, 20, 5, 20, 8, 20, 5, 7, 12, 9, 8],
                5,
                20
            ));
        }

        private static long CountSubarrays(int[] nums, int minK, int maxK)
        {
            long result = 0;
            int x = 0;
            int l = -1;
            int r = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minK || nums[i] > maxK)
                {
                    l = -1;
                    r = -1;
                    x = i + 1;
                }

                if (nums[i] == minK) l = i;
                if (nums[i] == maxK) r = i;

                Console.WriteLine($"{l} : {r} -> {x}");

                if (l <= r)
                {
                    if (l - x + 1 > 0) result += l - x + 1;
                }
                else if (l >= r)
                {
                    if (r - x + 1 > 0) result += r - x + 1;
                }
            }

            return result;
        }
    }
}
