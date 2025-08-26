using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02482_DifferenceBetweenOnesAndZerosInRowAndColumn
    {
        /// <summary>
        /// You are given a 0-indexed m x n binary matrix grid.
        /// 
        /// A 0-indexed m x n difference matrix diff is created with the following procedure:
        /// 
        /// Let the number of ones in the ith row be onesRowi.
        /// Let the number of ones in the jth column be onesColj.
        /// Let the number of zeros in the ith row be zerosRowi.
        /// Let the number of zeros in the jth column be zerosColj.
        /// diff[i][j] = onesRowi + onesColj - zerosRowi - zerosColj
        /// Return the difference matrix diff.
        /// </summary>
        public _02482_DifferenceBetweenOnesAndZerosInRowAndColumn()
        {
            int[][] x = OnesMinusZeros0([[0, 1, 1], [1, 0, 1], [0, 0, 1]]);
            RftTerminal.RftReadResult<int>(x);

            int[][] x0 = OnesMinusZeros0([[1, 1, 1], [1, 1, 1]]);
            RftTerminal.RftReadResult<int>(x0);
        }


        public static int[][] OnesMinusZeros0(int[][] a0) => RftOnesMinusZeros0(a0);

        public static int[][] OnesMinusZeros1(int[][] a0) => RftOnesMinusZeros1(a0);

        private static int[][] RftOnesMinusZeros0(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int[] rows = new int[n];
            for (int i = 0; i < n; i++)
            {
                rows[i] = grid[i].Sum();
            }

            int[] cols = new int[m];
            for (int i = 0; i < m; i++)
            {
                int t = 0;
                for (int j = 0; j < n; j++)
                {
                    t += grid[j][i];
                }
                cols[i] = t;
            }

            int[][] r = new int[n][];
            for (int i = 0; i < n; i++)
            {
                r[i] = new int[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i][j] = rows[i] + cols[j] - (m - rows[i]) - (n - cols[j]);
                }
            }

            return r;
        }

        private static int[][] RftOnesMinusZeros1(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            int[] onesRows = new int[m], onesCols = new int[n];
            int[] zerosRows = new int[m], zerosCols = new int[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        onesRows[i]++;
                        onesCols[j]++;
                    }
                    else
                    {
                        zerosRows[i]++;
                        zerosCols[j]++;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = onesRows[i] + onesCols[j] - zerosRows[i] - zerosCols[j];
                }
            }

            return grid;
        }
    }
}
