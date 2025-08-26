namespace Rftim3LeetCode.Temp
{
    public class _01425_ConstrainedSubsequenceSum
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return the maximum sum of a non-empty subsequence of that array such that 
        /// for every two consecutive integers in the subsequence, nums[i] and nums[j], where i < j, the condition j - i <= k is satisfied.
        /// A subsequence of an array is obtained by deleting some number of elements(can be zero) from the array, leaving the remaining elements in their original order.
        /// </summary>
        public _01425_ConstrainedSubsequenceSum()
        {
            Console.WriteLine(ConstrainedSubsetSum0([10, 2, -10, 5, 20], 2));
            Console.WriteLine(ConstrainedSubsetSum0([-1, -2, -3], 1));
            Console.WriteLine(ConstrainedSubsetSum0([10, -2, -10, -5, 20], 2));
        }

        public static int ConstrainedSubsetSum0(int[] a0, int a1) => RftConstrainedSubsetSum0(a0, a1);

        public static int ConstrainedSubsetSum1(int[] a0, int a1) => RftConstrainedSubsetSum1(a0, a1);

        public static int ConstrainedSubsetSum2(int[] a0, int a1) => RftConstrainedSubsetSum2(a0, a1);

        // Heap / Priority Queue
        private static int RftConstrainedSubsetSum0(int[] nums, int k)
        {
            PriorityQueue<int[], int[]> heap = new(Comparer<int[]>.Create((a, b) =>
            {
                return b[0] - a[0];
            }));

            heap.Enqueue([nums[0], 0], [nums[0], 0]);
            int ans = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                while (i - heap.Peek()[1] > k)
                {
                    heap.Dequeue();
                }

                int curr = Math.Max(0, heap.Peek()[0]) + nums[i];
                ans = Math.Max(ans, curr);
                heap.Enqueue([curr, i], [curr, i]);
            }

            return ans;
        }

        // Dictionary
        private static int RftConstrainedSubsetSum1(int[] nums, int k)
        {
            SortedDictionary<int, int> window = new()
            {
                { 0, 0 }
            };

            int[] dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = nums[i] + window.Last().Key;

                if (!window.TryGetValue(dp[i], out int value)) window[dp[i]] = 1;
                else window[dp[i]] = ++value;

                if (i >= k)
                {
                    if (window.ContainsKey(dp[i - k])) window[dp[i - k]]--;
                    else window[dp[i - k]] = -1;

                    if (window[dp[i - k]] == 0) window.Remove(dp[i - k]);
                }
            }

            int ans = int.MinValue;
            foreach (int num in dp)
            {
                ans = Math.Max(ans, num);
            }

            return ans;
        }

        // Monotonic Dequeue
        private static int RftConstrainedSubsetSum2(int[] nums, int k)
        {
            LinkedList<int> queue = new();
            int[] dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (queue.Count != 0 && i - queue.First() > k) queue.RemoveFirst();

                dp[i] = (queue.Count != 0 ? dp[queue.First()] : 0) + nums[i];
                while (queue.Count != 0 && dp[queue.Last()] < dp[i])
                {
                    queue.RemoveLast();
                }

                if (dp[i] > 0) queue.AddLast(i);
            }

            int ans = int.MinValue;
            foreach (int num in dp)
            {
                ans = Math.Max(ans, num);
            }

            return ans;
        }
    }
}
