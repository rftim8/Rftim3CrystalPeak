namespace Rftim3LeetCode.Temp
{
    public class _00062_UniquePaths
    {
        /// <summary>
        /// There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). 
        /// The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.
        /// Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.
        /// The test cases are generated so that the answer will be less than or equal to 2 * 109.
        /// </summary>
        public _00062_UniquePaths()
        {
            Console.WriteLine(UniquePaths(3, 7));
            Console.WriteLine(UniquePaths(3, 2));
        }

        private static int UniquePaths(int m, int n)
        {
            int[,] x = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) x[i, j] = 1;
                    else x[i, j] = x[i - 1, j] + x[i, j - 1];
                }
            }

            return x[m - 1, n - 1];
        }
    }
}
