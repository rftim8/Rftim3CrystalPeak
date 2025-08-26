namespace Rftim3LeetCode.Temp
{
    public class _02352_EqualRowAndColumnPairs
    {
        /// <summary>
        /// Given a 0-indexed n x n integer matrix grid, return the number of pairs (ri, cj) such that row ri and column cj are equal.
        /// A row and column pair is considered equal if they contain the same elements in the same order(i.e., an equal array).
        /// </summary>
        public _02352_EqualRowAndColumnPairs()
        {
            Console.WriteLine(EqualPairs(
            [
                [3,2,1],
                [1,7,6],
                [2,7,7]
            ]));

            Console.WriteLine(EqualPairs(
            [
                [3,1,2,2],
                [1,4,4,5],
                [2,4,2,2],
                [2,4,2,2]
            ]));
        }

        private static int EqualPairs(int[][] grid)
        {
            int n = grid.Length, r = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int c = 0;
                    for (int k = 0; k < n; k++)
                    {
                        if (grid[i][k] == grid[k][j]) c++;
                        else break;
                    }
                    if (c == n) r++;
                }
            }

            return r;
        }
    }
}
