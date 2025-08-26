namespace Rftim3LeetCode.Temp
{
    public class _01814_CountNicePairsInAnArray
    {
        /// <summary>
        /// You are given an array nums that consists of non-negative integers. Let us define rev(x) as the reverse of the non-negative integer x. 
        /// For example, rev(123) = 321, and rev(120) = 21. A pair of indices (i, j) is nice if it satisfies all of the following conditions:
        /// 
        /// 0 <= i<j<nums.length
        /// nums[i] + rev(nums[j]) == nums[j] + rev(nums[i])
        /// Return the number of nice pairs of indices.Since that number can be too large, return it modulo 109 + 7.
        /// </summary>
        public _01814_CountNicePairsInAnArray()
        {
            Console.WriteLine(CountNicePairs0([42, 11, 1, 97]));
            Console.WriteLine(CountNicePairs0([13, 10, 35, 24, 76]));
        }

        public static int CountNicePairs0(int[] a0) => RftCountNicePairs0(a0);

        private static int RftCountNicePairs0(int[] nums)
        {
            Dictionary<int, int> dic = [];
            int ans = 0;
            int MOD = (int)1e9 + 7;
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = nums[i] - Rev(nums[i]), freq = dic.GetValueOrDefault(diff, 0);
                ans = (ans + freq) % MOD;

                if (!dic.ContainsKey(diff)) dic.Add(diff, freq + 1);
                else dic[diff] = freq + 1;
            }

            return ans;
        }

        private static int Rev(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }

            return result;
        }
    }
}
