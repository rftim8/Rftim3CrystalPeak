using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00350_IntersectionOfTwoArrays2
    {
        /// <summary>
        /// Given two integer arrays nums1 and nums2, return an array of their intersection. 
        /// Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.
        /// </summary>
        public _00350_IntersectionOfTwoArrays2()
        {
            int[] x = Intersect0(
                [1, 2, 2, 1],
                [2, 2]
                );
            RftTerminal.RftReadResult(x);
        }

        public static int[] Intersect0(int[] a0, int[] a1) => RftIntersect0(a0, a1);

        private static int[] RftIntersect0(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;

            Dictionary<int, int> d1 = [];
            Dictionary<int, int> d2 = [];

            for (int i = 0; i < n; i++)
            {
                d1.TryAdd(nums1[i], 0);
                d1[nums1[i]]++;
            }

            for (int i = 0; i < m; i++)
            {
                d2.TryAdd(nums2[i], 0);
                d2[nums2[i]]++;
            }

            List<int> x = [];

            foreach (KeyValuePair<int, int> pair in d1)
            {
                if (d2.TryGetValue(pair.Key, out int value))
                {
                    int min = Math.Min(pair.Value, value);
                    for (int i = 0; i < min; i++)
                    {
                        x.Add(pair.Key);
                    }
                }
            }

            return [.. x];
        }
    }
}
