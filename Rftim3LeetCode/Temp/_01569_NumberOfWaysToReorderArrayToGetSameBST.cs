namespace Rftim3LeetCode.Temp
{
    public class _01569_NumberOfWaysToReorderArrayToGetSameBST
    {
        /// <summary>
        /// Given an array nums that represents a permutation of integers from 1 to n. 
        /// We are going to construct a binary search tree (BST) by inserting the elements of nums in order into an initially empty BST. 
        /// Find the number of different ways to reorder nums so that the constructed BST is identical to that formed from the original array nums.
        /// For example, given nums = [2,1,3], we will have 2 as the root, 1 as a left child, and 3 as a right child.
        /// The array[2, 3, 1] also yields the same BST but[3, 2, 1] yields a different BST.
        /// Return the number of ways to reorder nums such that the BST formed is identical to the original BST formed from nums.
        /// Since the answer may be very large, return it modulo 109 + 7.
        /// </summary>
        public _01569_NumberOfWaysToReorderArrayToGetSameBST()
        {
            Console.WriteLine(NumOfWays([2, 1, 3]));
            Console.WriteLine(NumOfWays([3, 4, 5, 1, 2]));
            Console.WriteLine(NumOfWays([1, 2, 3]));
        }

        private static readonly long mod = (long)1e9 + 7;
        private static long[][]? table;

        private static int NumOfWays(int[] nums)
        {
            int m = nums.Length;

            table = new long[m][];

            for (int i = 0; i < m; ++i)
            {
                table[i] = new long[m];
                table[i][0] = table[i][i] = 1;
            }

            for (int i = 2; i < m; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    table[i][j] = (table[i - 1][j - 1] + table[i - 1][j]) % mod;
                }
            }

            List<int> arrList = [.. nums];

            return (int)((Dfs(arrList) - 1) % mod);
        }

        private static long Dfs(List<int> nums)
        {
            int m = nums.Count;
            if (m < 3) return 1;

            List<int> leftNodes = [];
            List<int> rightNodes = [];
            for (int i = 1; i < m; ++i)
            {
                if (nums[i] < nums[0]) leftNodes.Add(nums[i]);
                else rightNodes.Add(nums[i]);
            }
            long leftWays = Dfs(leftNodes) % mod;
            long rightWays = Dfs(rightNodes) % mod;

            return table is not null ? leftWays * rightWays % mod * table[m - 1][leftNodes.Count] % mod : -1;
        }
    }
}
