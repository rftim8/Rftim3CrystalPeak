using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01630_ArithmeticSubarrays
    {
        /// <summary>
        /// A sequence of numbers is called arithmetic if it consists of at least two elements, 
        /// and the difference between every two consecutive elements is the same. 
        /// More formally, a sequence s is arithmetic if and only if s[i+1] - s[i] == s[1] - s[0] for all valid i.
        /// 
        /// For example, these are arithmetic sequences:
        /// 
        /// 1, 3, 5, 7, 9
        /// 7, 7, 7, 7
        /// 3, -1, -5, -9
        /// The following sequence is not arithmetic:
        /// 
        /// 1, 1, 2, 5, 7
        /// You are given an array of n integers, nums, and two arrays of m integers each, l and r, 
        /// representing the m range queries, where the ith query is the range[l[i], r[i]]. 
        /// All the arrays are 0-indexed.
        /// 
        /// Return a list of boolean elements answer, where answer[i] is true if the subarray nums[l[i]], nums[l[i] + 1], ... , 
        /// nums[r[i]] can be rearranged to form an arithmetic sequence, and false otherwise.
        /// </summary>
        public _01630_ArithmeticSubarrays()
        {
            IList<bool> x = CheckArithmeticSubarrays0([4, 6, 5, 9, 3, 7], [0, 0, 2], [2, 3, 5]);
            RftTerminal.RftReadResult(x);

            IList<bool> x0 = CheckArithmeticSubarrays0([-12, -9, -3, -12, -6, 15, 20, -25, -20, -15, -10], [0, 1, 6, 4, 8, 7], [4, 4, 9, 7, 9, 10]);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<bool> CheckArithmeticSubarrays0(int[] a0, int[] a1, int[] a2) => RftCheckArithmeticSubarrays0(a0, a1, a2);

        private static List<bool> RftCheckArithmeticSubarrays0(int[] nums, int[] l, int[] r)
        {
            List<bool> ans = [];
            for (int i = 0; i < l.Length; i++)
            {
                int[] arr = new int[r[i] - l[i] + 1];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = nums[l[i] + j];
                }

                ans.Add(Check(arr));
            }

            return ans;
        }

        private static bool Check(int[] arr)
        {
            Array.Sort(arr);
            int diff = arr[1] - arr[0];

            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] != diff) return false;
            }

            return true;
        }
    }
}
