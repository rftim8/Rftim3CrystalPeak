namespace Rftim3LeetCode.Temp
{
    public class _00096_UniqueBinarySearchTrees
    {
        /// <summary>
        /// Given an integer n, return the number of structurally unique BST's (binary search trees) which has exactly n nodes of unique values from 1 to n.
        /// </summary>
        public _00096_UniqueBinarySearchTrees()
        {
            Console.WriteLine(NumTrees(3));
            Console.WriteLine(NumTrees(4));
            Console.WriteLine(NumTrees(5));
            Console.WriteLine(NumTrees(6));
            Console.WriteLine(NumTrees(7));
        }

        private static int NumTrees(int n)
        {
            int[] c = new int[n + 1];

            c[0] = 1;
            c[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    c[i] += c[j - 1] * c[i - j];
                }
            }

            return c[n];
        }
    }
}
