using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00496_NextGreaterElement1
    {
        /// <summary>
        /// The next greater element of some element x in an array is the first greater element that is to the right of x in the same array.
        /// You are given two distinct 0-indexed integer arrays nums1 and nums2, where nums1 is a subset of nums2.
        /// For each 0 <= i<nums1.length, find the index j such that nums1[i] == nums2[j] and determine the next greater element of nums2[j] in nums2.
        /// If there is no next greater element, then the answer for this query is -1.
        /// Return an array ans of length nums1.length such that ans[i] is the next greater element as described above.
        /// </summary>
        public _00496_NextGreaterElement1()
        {
            int[] x = NextGreaterElement0(
                [4, 1, 2],
                [1, 3, 4, 2]
                );
            RftTerminal.RftReadResult(x);

            int[] x0 = NextGreaterElement0(
                [2, 4],
                [1, 2, 3, 4]
                );
            RftTerminal.RftReadResult(x0);
        }

        public static int[] NextGreaterElement0(int[] a0, int[] a1) => RftNextGreaterElement0(a0, a1);

        private static int[] RftNextGreaterElement0(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int[] x = new int[n];
            Array.Fill(x, -1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        for (int k = j; k < m; k++)
                        {
                            if (nums1[i] < nums2[k])
                            {
                                x[i] = nums2[k];
                                break;
                            }
                        }
                    }
                }
            }

            return x;
        }
    }
}
