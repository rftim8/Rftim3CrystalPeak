namespace Rftim3LeetCode.Temp
{
    public class _00456_132Pattern
    {
        /// <summary>
        /// Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i], 
        /// nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].
        /// Return true if there is a 132 pattern in nums, otherwise, return false.
        /// </summary>
        public _00456_132Pattern()
        {
            Console.WriteLine(Find132pattern([1, 2, 3, 4]));
            Console.WriteLine(Find132pattern([3, 1, 4, 2]));
            Console.WriteLine(Find132pattern([-1, 3, 2, 0]));
            Console.WriteLine(Find132pattern([3, 5, 0, 3, 4]));
        }

        private static bool Find132pattern(int[] nums)
        {
            int n = nums.Length;
            if (n < 3) return false;

            Stack<int> stack = new();
            int[] min = new int[n];
            min[0] = nums[0];

            for (int i = 1; i < n; i++)
            {
                min[i] = Math.Min(min[i - 1], nums[i]);
            }

            for (int j = n - 1; j >= 0; j--)
            {
                if (nums[j] > min[j])
                {
                    while (stack.Count != 0 && stack.Peek() <= min[j])
                    {
                        stack.Pop();
                    }

                    if (stack.Count != 0 && stack.Peek() < nums[j]) return true;
                    stack.Push(nums[j]);
                }
            }

            return false;
        }

        private static bool Find132pattern0(int[] nums)
        {
            Stack<int> s = new();
            int max2 = int.MinValue;

            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] < max2) return true;

                while (s.Count > 0 && nums[i] > s.Peek())
                {
                    max2 = s.Pop();
                }

                if (s.Count == 0 || s.Peek() != nums[i]) s.Push(nums[i]);
            }

            return false;
        }
    }
}
