using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00229_MajorityElement2
    {
        /// <summary>
        /// Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.
        /// </summary>
        public _00229_MajorityElement2()
        {
            IList<int> x = MajorityElement([3, 2, 3]);
            RftTerminal.RftReadResult(x);
            IList<int> x0 = MajorityElement([1]);
            RftTerminal.RftReadResult(x0);
            IList<int> x1 = MajorityElement([1, 2]);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> MajorityElement(int[] nums)
        {
            int n = nums.Length;
            double t = n / 3d;
            List<int> r = [];

            Dictionary<int, int> d = [];
            for (int i = 0; i < n; i++)
            {
                if (d.TryGetValue(nums[i], out int value)) { if (value != -1) d[nums[i]] = ++value; }
                else d[nums[i]] = 1;

                if (d[nums[i]] > t)
                {
                    r.Add(nums[i]);
                    d[nums[i]] = -1;
                }
            }

            return r;
        }
    }
}
