namespace Rftim3LeetCode.Temp
{
    public class _01848_MinimumDistanceToTheTargetElement
    {
        /// <summary>
        /// Given an integer array nums (0-indexed) and two integers target and start, find an index i such that nums[i] == target and abs(i - start) is minimized. 
        /// Note that abs(x) is the absolute value of x.
        /// Return abs(i - start).
        /// It is guaranteed that target exists in nums.
        /// </summary>
        public _01848_MinimumDistanceToTheTargetElement()
        {
            Console.WriteLine(GetMinDistance([1, 2, 3, 4, 5], 5, 3));
            Console.WriteLine(GetMinDistance([1], 1, 0));
            Console.WriteLine(GetMinDistance([1, 1, 1, 1, 1, 1, 1, 1, 1, 1], 1, 0));
        }

        private static int GetMinDistance(int[] nums, int target, int start)
        {
            int n = nums.Length;
            HashSet<int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (nums[i] == target) r.Add(Math.Abs(i - start));
            }

            return r.Min();
        }

        private static int GetMinDistance0(int[] nums, int target, int start)
        {
            int minDistance = int.MaxValue;

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] == target) minDistance = Math.Min(minDistance, Math.Abs(i - start));
            }

            return minDistance;
        }
    }
}
