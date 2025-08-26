using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00349_IntersectionOfTwoArrays
    {
        /// <summary>
        /// Given two integer arrays nums1 and nums2, return an array of their intersection. 
        /// Each element in the result must be unique and you may return the result in any order.
        /// </summary>
        public _00349_IntersectionOfTwoArrays()
        {
            int[] x = Intersection0(
                [1, 2, 2, 1],
                [2, 2]
                );
            RftTerminal.RftReadResult(x);
        }

        public static int[] Intersection0(int[] a0, int[] a1) => RftIntersection0(a0, a1);

        public static int[] Intersection1(int[] a0, int[] a1) => RftIntersection1(a0, a1);

        private static int[] RftIntersection0(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;

            if (n < m) return Solve(nums1, n, nums2, m);
            else return Solve(nums2, m, nums1, n);
        }

        private static int[] Solve(int[] a, int a0, int[] b, int b0)
        {
            HashSet<int> x = [];

            for (int i = 0; i < a0; i++)
            {
                for (int j = 0; j < b0; j++)
                {
                    if (a[i] == b[j])
                    {
                        if (!x.Contains(a[i])) x.Add(a[i]);
                        break;
                    }
                }
            }

            return [.. x];
        }

        private static int[] RftIntersection1(int[] nums1, int[] nums2)
        {
            List<int> results = [];

            Array.Sort(nums1);
            int number = nums1[0] - 1;

            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums1[i] != number)
                {
                    number = nums1[i];

                    if (nums2.Contains(nums1[i])) results.Add(nums1[i]);
                }
            }

            return [.. results];
        }
    }
}
