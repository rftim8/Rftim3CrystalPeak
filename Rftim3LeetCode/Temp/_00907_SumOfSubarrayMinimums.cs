namespace Rftim3LeetCode.Temp
{
    public class _00907_SumOfSubarrayMinimums
    {
        /// <summary>
        /// Given an array of integers arr, find the sum of min(b), where b ranges over every (contiguous) subarray of arr. 
        /// Since the answer may be large, return the answer modulo 109 + 7.
        /// </summary>
        public _00907_SumOfSubarrayMinimums()
        {
            Console.WriteLine(SumSubarrayMins0([3, 1, 2, 4]));
            Console.WriteLine(SumSubarrayMins0([11, 81, 94, 43, 3]));
        }

        public static int SumSubarrayMins0(int[] a0) => RftSumSubarrayMins0(a0);

        public static int SumSubarrayMins1(int[] a0) => RftSumSubarrayMins1(a0);

        public static int SumSubarrayMins2(int[] a0) => RftSumSubarrayMins2(a0);

        private static int RftSumSubarrayMins0(int[] arr)
        {
            int n = arr.Length;
            long r = 0;
            long mod = 1_000_000_007;

            for (int i = 0; i < n; i++)
            {
                long t = int.MaxValue;
                for (int j = i; j < n; j++)
                {
                    t = Math.Min(t, arr[j]);
                    r += t;
                }
            }

            return (int)(r % mod);
        }

        private static int RftSumSubarrayMins1(int[] arr)
        {
            Stack<int> stack = new();
            int n = arr.Length, MOD = (int)1e9 + 7;
            long res = 0;

            for (int i = 0; i <= n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= (i == n ? 0 : arr[i]))
                {
                    int mid = stack.Pop();
                    int left = stack.Count == 0 ? -1 : stack.Peek();
                    int right = i;
                    res = (res + (long)arr[mid] * (right - mid) * (mid - left)) % MOD;
                }

                stack.Push(i);
            }

            return (int)res;
        }

        private static int RftSumSubarrayMins2(int[] arr)
        {
            Stack<int> stack = new();
            int MOD = 1000000007;
            long count = 0;

            for (int i = 0; i <= arr.Length; i++)
            {
                while (stack.Count > 0 && (i == arr.Length || arr[stack.Peek()] >= arr[i]))
                {
                    int mid = stack.Pop();
                    int leftBoundary = stack.Count > 0 ? stack.Peek() : -1;
                    int rightBoundary = i;

                    long ans = (rightBoundary - mid) * (mid - leftBoundary) % MOD;

                    count += ans * arr[mid] % MOD;
                    count %= MOD;
                }
                stack.Push(i);
            }

            return (int)count;
        }
    }
}