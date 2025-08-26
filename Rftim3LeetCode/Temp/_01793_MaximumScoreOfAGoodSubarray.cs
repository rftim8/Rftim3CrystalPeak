namespace Rftim3LeetCode.Temp
{
    public class _01793_MaximumScoreOfAGoodSubarray
    {
        /// <summary>
        /// You are given an array of integers nums (0-indexed) and an integer k.
        /// The score of a subarray(i, j) is defined as min(nums[i], nums[i + 1], ..., nums[j]) * (j - i + 1).
        /// A good subarray is a subarray where i <= k <= j.
        /// Return the maximum possible score of a good subarray.
        /// </summary>
        public _01793_MaximumScoreOfAGoodSubarray()
        {
            Console.WriteLine(MaximumScore0([1, 4, 3, 7, 4, 5], 3));
            Console.WriteLine(MaximumScore0([5, 5, 4, 5, 4, 1, 1, 1], 0));
        }

        // Greedy
        public static int MaximumScore0(int[] a0, int a1) => RftMaximumScore0(a0, a1);

        public static int MaximumScore1(int[] a0, int a1) => RftMaximumScore1(a0, a1);

        public static int MaximumScore2(int[] a0, int a1) => RftMaximumScore2(a0, a1);

        private static int RftMaximumScore0(int[] nums, int k)
        {
            int n = nums.Length;
            int left = k;
            int right = k;
            int ans = nums[k];
            int currMin = nums[k];

            while (left > 0 || right < n - 1)
            {
                if ((left > 0 ? nums[left - 1] : 0) < (right < n - 1 ? nums[right + 1] : 0))
                {
                    right++;
                    currMin = Math.Min(currMin, nums[right]);
                }
                else
                {
                    left--;
                    currMin = Math.Min(currMin, nums[left]);
                }

                ans = Math.Max(ans, currMin * (right - left + 1));
            }

            return ans;
        }

        // Monotonic Stack
        private static int RftMaximumScore1(int[] nums, int k)
        {
            int n = nums.Length;
            int[] left = new int[n];
            Array.Fill(left, -1);
            Stack<int> stack = new();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count != 0 && nums[stack.Peek()] > nums[i])
                {
                    left[stack.Pop()] = i;
                }

                stack.Push(i);
            }

            int[] right = new int[n];
            Array.Fill(right, n);
            stack = new();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count != 0 && nums[stack.Peek()] > nums[i])
                {
                    right[stack.Pop()] = i;
                }

                stack.Push(i);
            }

            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                if (left[i] < k && right[i] > k) ans = Math.Max(ans, nums[i] * (right[i] - left[i] - 1));
            }

            return ans;
        }

        // Binary Search
        private static int RftMaximumScore2(int[] nums, int k)
        {
            int ans = Solve(nums, k);
            for (int i = 0; i < nums.Length / 2; i++)
            {
                (nums[nums.Length - i - 1], nums[i]) = (nums[i], nums[nums.Length - i - 1]);
            }

            return Math.Max(ans, Solve(nums, nums.Length - k - 1));
        }

        private static int Solve(int[] nums, int k)
        {
            int n = nums.Length;
            int[] left = new int[k];
            int currMin = int.MaxValue;
            for (int i = k - 1; i >= 0; i--)
            {
                currMin = Math.Min(currMin, nums[i]);
                left[i] = currMin;
            }

            List<int> right = [];
            currMin = int.MaxValue;
            for (int i = k; i < n; i++)
            {
                currMin = Math.Min(currMin, nums[i]);
                right.Add(currMin);
            }

            int ans = 0;
            for (int j = 0; j < right.Count; j++)
            {
                currMin = right[j];
                int i = BinarySearch(left, currMin);
                int size = k + j - i + 1;
                ans = Math.Max(ans, currMin * size);
            }

            return ans;
        }

        private static int BinarySearch(int[] nums, int num)
        {
            int left = 0;
            int right = nums.Length;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] < num) left = mid + 1;
                else right = mid;
            }

            return left;
        }
    }
}
