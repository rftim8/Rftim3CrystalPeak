namespace Rftim3LeetCode.Temp
{
    public class _01218_LongestArithmeticSubsequenceOfGivenDifference
    {
        /// <summary>
        /// Given an integer array arr and an integer difference, return the length of the longest subsequence in arr which is an arithmetic sequence 
        /// such that the difference between adjacent elements in the subsequence equals difference.
        /// A subsequence is a sequence that can be derived from arr by deleting some or no elements without changing the order of the remaining elements.
        /// </summary>
        public _01218_LongestArithmeticSubsequenceOfGivenDifference()
        {
            Console.WriteLine(LongestSubsequence([1, 2, 3, 4], 1));
            Console.WriteLine(LongestSubsequence([1, 3, 5, 7], 1));
            Console.WriteLine(LongestSubsequence([1, 5, 7, 8, 5, 3, 4, 2, 1], -2));
            Console.WriteLine(LongestSubsequence([4, 12, 10, 0, -2, 7, -8, 9, -9, -12, -12, 8, 8], 0));
            Console.WriteLine(LongestSubsequence([18, 3, 2, -14, 1, 18, 2, -5, -6, 12, 5, -18, -14, -20, 1, -5, 4, 18, 4, 10, -3, 2, 19, -1, 14], 17));
            Console.WriteLine(LongestSubsequence([5, 3, 5, 1], -2));
        }

        private static int LongestSubsequence0(int[] arr, int difference)
        {
            int n = arr.Length;

            int r = 1;
            HashSet<int> x = [];
            int i = 0;
            while (i < n)
            {
                if (!x.Contains(arr[i]))
                {
                    int t = arr[i], c = 1;
                    x.Add(t);
                    int j = i + 1;

                    while (j < n)
                    {
                        if (t == arr[j] - difference)
                        {
                            x.Add(arr[j]);
                            t = arr[j];
                            c++;
                        }

                        j++;
                    }
                    if (c > r) r = c;
                }
                i++;
            }

            return r;
        }

        private static int LongestSubsequence(int[] arr, int diff)
        {
            Dictionary<int, int> dict = [];
            int max = 1;

            foreach (int n in arr)
            {
                max = Math.Max(max, dict[n] = dict.GetValueOrDefault(n - diff) + 1);
            }

            return max;
        }
    }
}
