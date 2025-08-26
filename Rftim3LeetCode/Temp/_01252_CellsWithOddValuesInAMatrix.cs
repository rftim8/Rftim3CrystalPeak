namespace Rftim3LeetCode.Temp
{
    public class _01252_CellsWithOddValuesInAMatrix
    {
        /// <summary>
        /// There is an m x n matrix that is initialized to all 0's. 
        /// There is also a 2D array indices where each indices[i] = [ri, ci] represents a 0-indexed location to perform some increment operations on the matrix.
        /// For each location indices[i], do both of the following:
        /// Increment all the cells on row ri.
        /// Increment all the cells on column ci.
        /// Given m, n, and indices, return the number of odd-valued cells in the matrix after applying the increment to all locations in indices.
        /// </summary>
        public _01252_CellsWithOddValuesInAMatrix()
        {
            Console.WriteLine(OddCells(
                2,
                3,
                [
                    [0,1],
                    [1,1]
                ]
            ));
            Console.WriteLine(OddCells(
                2,
                2,
                [
                    [1,1],
                    [0,0]
                ]
            ));
        }

        private static int OddCells(int m, int n, int[][] indices)
        {
            int c = 0;
            int[][] r = new int[m][];

            for (int i = 0; i < m; i++)
            {
                r[i] = new int[n];
            }

            for (int i = 0; i < indices.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    r[indices[i][0]][j]++;
                }
                for (int k = 0; k < m; k++)
                {
                    r[k][indices[i][1]]++;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (r[i][j] % 2 != 0) c++;
                }
            }

            return c;
        }

        private static int OddCells0(int m, int n, int[][] indices)
        {
            int[] row = new int[m];
            int[] col = new int[n];

            foreach (int[] pair in indices)
            {
                row[pair[0]]++;
                col[pair[1]]++;
            }

            int odd = 0;

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if ((row[r] + col[c]) % 2 == 1) odd++;
                }
            }

            return odd;
        }
    }
}
