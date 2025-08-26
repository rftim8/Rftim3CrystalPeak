using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02643_RowWithMaximumOnes
    {
        /// <summary>
        /// Given a m x n binary matrix mat, find the 0-indexed position of the row that contains the maximum count of ones, and the number of ones in that row.
        /// In case there are multiple rows that have the maximum count of ones, the row with the smallest row number should be selected.
        /// Return an array containing the index of the row, and the number of ones in it.
        /// </summary>
        public _02643_RowWithMaximumOnes()
        {
            int[] x = RowAndMaximumOnes([
                [0, 1],
                [1, 0]
            ]);
            RftTerminal.RftReadResult(x);
            int[] x0 = RowAndMaximumOnes([
                [0, 0, 0],
                [0, 1, 1]
            ]);
            RftTerminal.RftReadResult(x0);
            int[] x1 = RowAndMaximumOnes([
                [0, 0],
                [1, 1],
                [0, 0]
            ]);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] RowAndMaximumOnes(int[][] mat)
        {
            int r = 0, j = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                int t = mat[i].Count(o => o == 1);
                if (t > r)
                {
                    r = t;
                    j = i;
                }
            }

            return [j, r];
        }
    }
}
