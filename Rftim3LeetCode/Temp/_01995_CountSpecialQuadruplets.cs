namespace Rftim3LeetCode.Temp
{
    public class _01995_CountSpecialQuadruplets
    {
        /// <summary>
        /// Given a 0-indexed integer array nums, return the number of distinct quadruplets (a, b, c, d) such that:
        ///nums[a] + nums[b] + nums[c] == nums[d], and
        ///a<b < c<d
        /// </summary>
        public _01995_CountSpecialQuadruplets()
        {
            Console.WriteLine(CountQuadruplets([1, 2, 3, 6]));
            Console.WriteLine(CountQuadruplets([3, 3, 6, 4, 5]));
            Console.WriteLine(CountQuadruplets([1, 1, 1, 3, 5]));
            Console.WriteLine(CountQuadruplets([9, 6, 8, 23, 39, 23]));
        }

        private static int CountQuadruplets(int[] nums)
        {
            int n = nums.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        for (int l = k + 1; l < n; l++)
                        {
                            if (nums[i] + nums[j] + nums[k] == nums[l]) c++;
                        }
                    }
                }
            }

            return c;
        }
    }
}
