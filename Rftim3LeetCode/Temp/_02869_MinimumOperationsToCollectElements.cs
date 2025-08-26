namespace Rftim3LeetCode.Temp
{
    public class _02869_MinimumOperationsToCollectElements
    {
        /// <summary>
        /// You are given an array nums of positive integers and an integer k.
        /// 
        /// In one operation, you can remove the last element of the array and add it to your collection.
        /// 
        /// Return the minimum number of operations needed to collect elements 1, 2, ..., k.
        /// </summary>
        public _02869_MinimumOperationsToCollectElements()
        {
            Console.WriteLine(MinOperations0([3, 1, 5, 4, 2], 2));
            Console.WriteLine(MinOperations0([3, 1, 5, 4, 2], 5));
            Console.WriteLine(MinOperations0([3, 2, 5, 3, 1], 3));
        }

        public static int MinOperations0(IList<int> a0, int a1) => RftMinOperations0(a0, a1);

        public static int MinOperations1(IList<int> a0, int a1) => RftMinOperations1(a0, a1);

        private static int RftMinOperations0(IList<int> nums, int k)
        {
            HashSet<int> x = [.. Enumerable.Range(1, k)];
            int n = nums.Count;

            int r = 0;
            for (int i = n - 1; i > -1; i--)
            {
                if (x.Contains(nums[i])) x.Remove(nums[i]);

                r++;

                if (x.Count == 0) return r;
            }

            return r;
        }

        private static int RftMinOperations1(IList<int> nums, int k)
        {
            List<int> list = [];
            for (int i = 1; i <= k; i++)
            {
                list.Add(i);
            }

            int length = nums.Count - 1;

            while (list.Count > 0 && length >= 0)
            {
                list.Remove(nums[length]);
                length--;
            }

            return nums.Count - length - 1;
        }
    }
}
