using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00930_BinarySubarraysWithSum
    {
        /// <summary>
        /// Given a binary array nums and an integer goal, return the number of non-empty subarrays with a sum goal.
        /// A subarray is a contiguous part of the array.
        /// </summary>
        public _00930_BinarySubarraysWithSum()
        {
            Console.WriteLine(BinarySubarraysWithSum1([1, 0, 1, 0, 1], 2));
            Console.WriteLine(BinarySubarraysWithSum1([0, 0, 0, 0, 0], 0));
        }

        public static int BinarySubarraysWithSum0(int[] a0, int a1) => RftBinarySubarraysWithSum0(a0, a1);

        public static int BinarySubarraysWithSum1(int[] a0, int a1) => RftBinarySubarraysWithSum1(a0, a1);

        private static int RftBinarySubarraysWithSum0(int[] nums, int goal)
        {
            int n = nums.Length;
            int res = 0;

            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = i; j < n; j++)
                {
                    if (c + nums[j] == goal) res++;
                    else if (c + nums[j] > goal) break;

                    c += nums[j];
                }
            }

            return res;
        }

        private static int RftBinarySubarraysWithSum1(int[] nums, int goal)
        {
            int n = nums.Length;
            int[] presum = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                presum[i + 1] = presum[i] + nums[i];
            }

            int[] count = new int[n + 1];
            int cnt = 0;

            foreach (int i in presum)
            {
                RftTerminal.RftReadResult(count);
                cnt += count[i];

                if (i + goal >= 0 && i + goal <= n) count[i + goal]++;
            }

            return cnt;
        }
    }
}
