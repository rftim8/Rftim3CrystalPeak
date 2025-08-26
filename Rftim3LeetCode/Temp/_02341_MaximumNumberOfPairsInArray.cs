using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02341_MaximumNumberOfPairsInArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. In one operation, you may do the following:
        /// Choose two integers in nums that are equal.
        /// Remove both integers from nums, forming a pair.
        /// The operation is done on nums as many times as possible.
        /// Return a 0-indexed integer array answer of size 2 where answer[0] is the number of pairs that are formed and answer[1] 
        /// is the number of leftover integers in nums after doing the operation as many times as possible.
        /// </summary>
        public _02341_MaximumNumberOfPairsInArray()
        {
            int[] x = NumberOfPairs([1, 3, 2, 1, 3, 2, 2]);
            RftTerminal.RftReadResult(x);
            int[] x0 = NumberOfPairs([1, 1]);
            RftTerminal.RftReadResult(x0);
            int[] x1 = NumberOfPairs([0]);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] NumberOfPairs(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> r = [];

            int c = 0, l = 0;
            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(nums[i], out int value)) r[nums[i]] = ++value;
                else r[nums[i]] = 1;
            }

            foreach (KeyValuePair<int, int> item in r)
            {
                l += item.Value % 2;
                c += item.Value / 2;
            }

            return [c, l];
        }
    }
}
