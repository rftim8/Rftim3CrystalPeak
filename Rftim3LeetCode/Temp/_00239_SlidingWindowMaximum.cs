using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00239_SlidingWindowMaximum
    {
        /// <summary>
        /// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. 
        /// You can only see the k numbers in the window. 
        /// Each time the sliding window moves right by one position.
        /// Return the max sliding window.
        /// </summary>
        public _00239_SlidingWindowMaximum()
        {
            int[] x = MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3);
            int[] x0 = MaxSlidingWindow([1], 1);
            int[] x1 = MaxSlidingWindow([1, -1], 1);
            int[] x2 = MaxSlidingWindow([-6, -10, -7, -1, -9, 9, -8, -4, 10, -5, 2, 9, 0, -7, 7, 4, -2, -10, 8, 7], 7);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
        }

        // Monotonic dequeue
        private static int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            LinkedList<int> dq = new();
            int[] r = new int[n - k + 1];
            int j = 0;

            for (int i = 0; i < k; i++)
            {
                while (dq.Count != 0 && nums[i] >= nums[dq.Last!.Value])
                {
                    dq.RemoveLast();
                }
                dq.AddLast(i);
            }
            r[j] = nums[dq.First!.Value];
            j++;

            for (int i = k; i < n; i++, j++)
            {
                if (dq.First.Value == i - k) dq.RemoveFirst();
                while (dq.Count != 0 && nums[i] >= nums[dq.Last!.Value])
                {
                    dq.RemoveLast();
                }

                dq.AddLast(i);
                r[j] = nums[dq.First.Value];
            }

            return r;
        }
    }
}
