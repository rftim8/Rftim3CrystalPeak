namespace Rftim3LeetCode.Temp
{
    public class _02717_SemiOrderedPermutation
    {
        /// <summary>
        /// You are given a 0-indexed permutation of n integers nums.
        /// A permutation is called semi-ordered if the first number equals 1 and the last number equals n.
        /// You can perform the below operation as many times as you want until you make nums a semi-ordered permutation:
        /// Pick two adjacent elements in nums, then swap them.
        /// Return the minimum number of operations to make nums a semi-ordered permutation.
        /// A permutation is a sequence of integers from 1 to n of length n containing each number exactly once.
        /// </summary>
        public _02717_SemiOrderedPermutation()
        {
            Console.WriteLine(SemiOrderedPermutation([2, 1, 4, 3]));
            Console.WriteLine(SemiOrderedPermutation([2, 4, 1, 3]));
            Console.WriteLine(SemiOrderedPermutation([1, 3, 4, 2, 5]));
        }

        private static int SemiOrderedPermutation(int[] nums)
        {
            int n = nums.Length;
            if (nums[0] == 1 && nums[^1] == n) return 0;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 1)
                {
                    for (int j = i; j > 0; j--)
                    {
                        (nums[j], nums[j - 1]) = (nums[j - 1], nums[j]);
                        c++;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == n)
                {
                    for (int j = i; j < n - 1; j++)
                    {
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                        c++;
                    }
                }
            }

            return c;
        }
    }
}
