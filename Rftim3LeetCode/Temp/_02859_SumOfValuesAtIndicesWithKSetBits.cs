namespace Rftim3LeetCode.Temp
{
    public class _02859_SumOfValuesAtIndicesWithKSetBits
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and an integer k.
        /// Return an integer that denotes the sum of elements in nums whose corresponding indices have exactly k set bits in their binary representation.
        /// The set bits in an integer are the 1's present when it is written in binary.
        /// For example, the binary representation of 21 is 10101, which has 3 set bits.
        /// </summary>
        public _02859_SumOfValuesAtIndicesWithKSetBits()
        {
            Console.WriteLine(SumIndicesWithKSetBits([5, 10, 1, 5, 2], 1));
            Console.WriteLine(SumIndicesWithKSetBits([4, 3, 2, 1], 2));
        }

        private static int SumIndicesWithKSetBits(IList<int> nums, int k)
        {
            int c = 0;
            int i = 0;
            foreach (int item in nums)
            {
                string x = Convert.ToString(i, 2);
                if (x.Count(o => o == '1') == k) c += item;
                i++;
            }

            return c;
        }

        private static int SumIndicesWithKSetBits0(IList<int> nums, int k)
        {
            int ans = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                int temp = i, count = 0;
                while (temp != 0)
                {
                    if (temp % 2 == 1) count++;
                    temp /= 2;
                }
                if (count == k) ans += nums[i];
            }

            return ans;
        }
    }
}
