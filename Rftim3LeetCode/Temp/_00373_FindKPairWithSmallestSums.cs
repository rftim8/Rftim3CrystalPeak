using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00373_FindKPairWithSmallestSums
    {
        /// <summary>
        /// You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.
        /// Define a pair(u, v) which consists of one element from the first array and one element from the second array.
        /// Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.
        /// </summary>
        public _00373_FindKPairWithSmallestSums()
        {
            IList<IList<int>> x0 = KSmallestPairs([1, 7, 11], [2, 4, 6], 3);
            IList<IList<int>> x1 = KSmallestPairs([1, 1, 2], [1, 2, 3], 2);
            IList<IList<int>> x2 = KSmallestPairs([1, 2], [3], 3);

            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
        }

        private static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            List<IList<int>> ans = [];
            HashSet<(int, int)> visited = [];

            PriorityQueue<int[], int[]> minHeap = new(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
            minHeap.Enqueue([nums1[0] + nums2[0], 0, 0], [nums1[0] + nums2[0], 0, 0]);
            visited.Add((0, 0));

            while (k-- > 0 && minHeap.Count != 0)
            {
                int[] top = minHeap.Dequeue();
                int i = top[1];
                int j = top[2];

                ans.Add([nums1[i], nums2[j]]);

                if (i + 1 < m && !visited.Contains((i + 1, j)))
                {
                    minHeap.Enqueue([nums1[i + 1] + nums2[j], i + 1, j], [nums1[i + 1] + nums2[j], i + 1, j]);
                    visited.Add((i + 1, j));
                }

                if (j + 1 < n && !visited.Contains((i, j + 1)))
                {
                    minHeap.Enqueue([nums1[i] + nums2[j + 1], i, j + 1], [nums1[i] + nums2[j + 1], i, j + 1]);
                    visited.Add((i, j + 1));
                }
            }

            return ans;
        }

        private static IList<IList<int>> KSmallestPairs0(int[] nums1, int[] nums2, int k)
        {
            bool swap = false;
            if (nums1.Length > nums2.Length)
            {
                (nums2, nums1) = (nums1, nums2);
                swap = true;
            }

            IList<IList<int>> result = new List<IList<int>>(k);
            PriorityQueue<(int, int), int> pq = new(k < nums1.Length ? k : nums1.Length);

            for (int i = 0; i < nums1.Length && i < k; i++)
                pq.Enqueue((i, 0), nums1[i] + nums2[0]);

            while (k-- > 0 && pq.TryPeek(out (int x, int y) t, out int _))
            {
                pq.Dequeue();
                if (swap) result.Add([nums2[t.y], nums1[t.x]]);
                else result.Add([nums1[t.x], nums2[t.y]]);
                if (t.y + 1 < nums2.Length) pq.Enqueue((t.x, t.y + 1), nums1[t.x] + nums2[t.y + 1]);
            }

            return result;
        }
    }
}
