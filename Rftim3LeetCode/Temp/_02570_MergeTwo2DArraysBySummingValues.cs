using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02570_MergeTwo2DArraysBySummingValues
    {
        /// <summary>
        /// You are given two 2D integer arrays nums1 and nums2.
        /// nums1[i] = [idi, vali] indicate that the number with the id idi has a value equal to vali.
        /// nums2[i] = [idi, vali] indicate that the number with the id idi has a value equal to vali.
        /// Each array contains unique ids and is sorted in ascending order by id.
        /// Merge the two arrays into one array that is sorted in ascending order by id, respecting the following conditions:
        /// Only ids that appear in at least one of the two arrays should be included in the resulting array.
        /// Each id should be included only once and its value should be the sum of the values of this id in the two arrays.
        /// If the id does not exist in one of the two arrays then its value in that array is considered to be 0.
        /// Return the resulting array. 
        /// The returned array must be sorted in ascending order by id.
        /// </summary>
        public _02570_MergeTwo2DArraysBySummingValues()
        {
            int[][] x = MergeArrays(
                [
                    [1,2],
                    [2,3],
                    [4,5],
                ],
                [
                    [1,4],
                    [3,2],
                    [4,1]
                ]
            );
            RftTerminal.RftReadResult<int>(x);
            int[][] x0 = MergeArrays(
                [
                    [2,4],
                    [3,6],
                    [5,5]
                ],
                [
                    [1,3],
                    [4,3]
                ]
            );
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.ContainsKey(nums1[i][0])) r[nums1[i][0]] += nums1[i][1];
                else r[nums1[i][0]] = nums1[i][1];
            }
            for (int i = 0; i < m; i++)
            {
                if (r.ContainsKey(nums2[i][0])) r[nums2[i][0]] += nums2[i][1];
                else r[nums2[i][0]] = nums2[i][1];
            }

            int[][] x = new int[r.Count][];
            int j = 0;
            foreach (KeyValuePair<int, int> item in r.OrderBy(o => o.Key))
            {
                x[j] = [item.Key, item.Value];
                j++;
            }

            return x;
        }
    }
}
