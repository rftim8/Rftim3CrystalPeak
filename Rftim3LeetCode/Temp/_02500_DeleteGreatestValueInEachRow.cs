namespace Rftim3LeetCode.Temp
{
    public class _02500_DeleteGreatestValueInEachRow
    {
        /// <summary>
        /// You are given an m x n matrix grid consisting of positive integers.
        /// Perform the following operation until grid becomes empty:
        /// Delete the element with the greatest value from each row.
        /// If multiple such elements exist, delete any of them.
        /// Add the maximum of deleted elements to the answer.
        /// Note that the number of columns decreases by one after each operation.
        /// Return the answer after performing the operations described above.
        /// </summary>
        public _02500_DeleteGreatestValueInEachRow()
        {
            Console.WriteLine(DeleteGreatestValue(
            [
                [1,2,4],
                [3,3,1]
            ]));
            Console.WriteLine(DeleteGreatestValue(
            [
                [10]
            ]));
        }

        private static int DeleteGreatestValue(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int r = 0;
            HashSet<int> q = [];
            for (int k = 0; k < m; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    int t = 0, c = -1;
                    for (int j = 0; j < m; j++)
                    {
                        if (grid[i][j] > c)
                        {
                            t = j;
                            c = grid[i][j];
                        }
                    }
                    q.Add(grid[i][t]);
                    grid[i][t] = -1;
                }

                r += q.Max();
                q = [];
            }

            return r;
        }
    }
}
