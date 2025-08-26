using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01030_MatrixCellsInDistanceOrder
    {
        /// <summary>
        /// You are given four integers row, cols, rCenter, and cCenter. 
        /// There is a rows x cols matrix and you are on the cell with the coordinates (rCenter, cCenter).
        /// Return the coordinates of all cells in the matrix, sorted by their distance from(rCenter, cCenter) from the smallest distance to the largest distance.
        /// You may return the answer in any order that satisfies this condition.
        /// The distance between two cells (r1, c1) and (r2, c2) is |r1 - r2| + |c1 - c2|.
        /// </summary>
        public _01030_MatrixCellsInDistanceOrder()
        {
            int[][] x = AllCellsDistOrder(1, 2, 0, 0);
            int[][] x0 = AllCellsDistOrder(2, 2, 0, 1);
            int[][] x1 = AllCellsDistOrder(2, 3, 1, 2);

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
            RftTerminal.RftReadResult<int>(x1);
        }

        private static int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            List<((int y, int x), int d)> r = new();

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    r.Add(((i, j), Math.Abs(j - rCenter) + Math.Abs(i - cCenter)));
                }
            }

            r.Sort((a, b) => a.d.CompareTo(b.d));

            int[][] a = new int[rows * cols][];
            for (int i = 0; i < rows * cols; i++)
            {
                a[i] = [r[i].Item1.x, r[i].Item1.y];
            }

            return a;
        }

        private static int[][] AllCellsDistOrder0(int rows, int cols, int rCenter, int cCenter)
        {
            int[][] matrix = new int[rows * cols][];
            int[] keys = new int[rows * cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i * cols + j] = [i, j];
                    keys[i * cols + j] = Math.Abs(rCenter - i) + Math.Abs(cCenter - j);
                }
            }
            Array.Sort(keys, matrix);

            return matrix;
        }
    }
}
