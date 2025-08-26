namespace Rftim3LeetCode.Temp
{
    public class _02542_MaximumSubsequenceScore
    {
        /// <summary>
        /// You are given two 0-indexed integer arrays nums1 and nums2 of equal length n and a positive integer k. 
        /// You must choose a subsequence of indices from nums1 of length k.
        /// For chosen indices i0, i1, ..., ik - 1, your score is defined as:
        /// The sum of the selected elements from nums1 multiplied with the minimum of the selected elements from nums2.
        /// It can defined simply as: (nums1[i0] + nums1[i1] +...+ nums1[ik - 1]) * min(nums2[i0] , nums2[i1], ... , nums2[ik - 1]).
        /// Return the maximum possible score.
        /// A subsequence of indices of an array is a set that can be derived from the set {0, 1, ..., n-1}
        /// by deleting some or no elements.
        /// </summary>
        public _02542_MaximumSubsequenceScore()
        {
            Console.WriteLine(MaxScore([1, 3, 3, 2], [2, 1, 3, 4], 3));
            Console.WriteLine(MaxScore([4, 2, 3, 1, 1], [7, 5, 10, 9, 6], 1));
        }

        private static long MaxScore(int[] nums1, int[] nums2, int k)
        {
            int n = nums1.Length;
            int[][] pairs = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                pairs[i] = [nums1[i], nums2[i]];
            }
            Array.Sort(pairs, (a, b) => b[1] - a[1]);

            PriorityQueue<int, int> heap = new(Comparer<int>.Create((a, b) => a - b));
            long sum = 0;
            for (int i = 0; i < k; ++i)
            {
                sum += pairs[i][0];
                heap.Enqueue(pairs[i][0], pairs[i][0]);
            }

            long x = sum * pairs[k - 1][1];

            for (int i = k; i < n; ++i)
            {
                sum += pairs[i][0] - heap.Dequeue();
                heap.Enqueue(pairs[i][0], pairs[i][0]);

                x = Math.Max(x, sum * pairs[i][1]);
            }

            return x;
        }

        private static long MaxScore0(int[] nums1, int[] nums2, int k)
        {
            int n = nums1.Length;
            (int num1, int num2)[] nums = new (int num1, int num2)[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = (nums1[i], nums2[i]);
            }

            Array.Sort(nums, (x, y) => y.num2.CompareTo(x.num2));

            PriorityQueue<int, int> topK = new();

            long sum = 0;
            for (int i = 0; i < k; i++)
            {
                topK.Enqueue(nums[i].num1, nums[i].num1);
                sum += nums[i].num1;
            }

            long maxScore = sum * nums[k - 1].num2;

            for (int i = k; i < n; i++)
            {
                sum += nums[i].num1 - topK.Dequeue();
                topK.Enqueue(nums[i].num1, nums[i].num1);
                maxScore = Math.Max(maxScore, sum * nums[i].num2);
            }

            return maxScore;
        }
    }
}
