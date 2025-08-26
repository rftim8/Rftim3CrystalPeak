using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02200_FindAllKDistantIndicesInAnArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and two integers key and k. 
        /// A k-distant index is an index i of nums for which there exists at least one index j such that |i - j| <= k and nums[j] == key.
        /// Return a list of all k-distant indices sorted in increasing order.
        /// </summary>
        public _02200_FindAllKDistantIndicesInAnArray()
        {
            IList<int> x = FindKDistantIndices([3, 4, 9, 1, 3, 9, 5], 9, 1);
            RftTerminal.RftReadResult(x);
            IList<int> x0 = FindKDistantIndices([2, 2, 2, 2, 2], 2, 2);
            RftTerminal.RftReadResult(x0);
        }

        private static List<int> FindKDistantIndices(int[] nums, int key, int k)
        {
            int n = nums.Length;
            List<int> res = [];
            if (n == 0) return res;

            HashSet<int> set = [];
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == key)
                {
                    int start = i - k < 0 ? 0 : i - k;
                    int end = i + k >= n ? n - 1 : i + k;
                    for (int j = start; j <= end; j++)
                    {
                        set.Add(j);
                    }
                }
            }

            return [.. set];
        }

        private static List<int> FindKDistantIndices0(int[] nums, int key, int k)
        {
            List<int> distant_index = [];
            List<int> temp = [.. nums];
            List<int> keys_index = [];

            while (temp.Contains(key))
            {
                keys_index.Add(temp.IndexOf(key));
                temp[temp.IndexOf(key)] = key - 1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < keys_index.Count; j++)
                {
                    if (Math.Abs(i - keys_index[j]) <= k)
                    {
                        distant_index.Add(i);
                        break;
                    }
                }
            }

            return distant_index;
        }
    }
}
