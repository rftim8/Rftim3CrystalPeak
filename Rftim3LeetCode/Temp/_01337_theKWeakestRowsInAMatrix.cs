using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01337_TheKWeakestRowsInAMatrix
    {
        /// <summary>
        /// You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's (representing civilians). 
        /// The soldiers are positioned in front of the civilians. 
        /// That is, all the 1's will appear to the left of all the 0's in each row.
        /// A row i is weaker than a row j if one of the following is true:
        /// The number of soldiers in row i is less than the number of soldiers in row j.
        /// Both rows have the same number of soldiers and i<j.
        /// Return the indices of the k weakest rows in the matrix ordered from weakest to strongest.
        /// </summary>
        public _01337_TheKWeakestRowsInAMatrix()
        {
            int[] x = TheKWeakestRowsInAMatrix0([
                [1, 1, 0, 0, 0],
                [1, 1, 1, 1, 0],
                [1, 0, 0, 0, 0],
                [1, 1, 0, 0, 0],
                [1, 1, 1, 1, 1]
            ], 3);
            RftTerminal.RftReadResult(x);
        }

        public static int[] TheKWeakestRowsInAMatrix0(int[][] a0, int a1) => RftTheKWeakestRowsInAMatrix0(a0, a1);

        private static int[] RftTheKWeakestRowsInAMatrix0(int[][] mat, int k)
        {
            int n = mat.Length;
            int m = mat[0].Length;
            int[] x = new int[k];
            List<(int, int)> y = [];

            for (int i = 0; i < n; i++)
            {
                y.Add((i, mat[i].Count(o => o == 1)));
            }

            y = [.. y.OrderBy(o => o.Item2)];

            for (int i = 0; i < k; i++)
            {
                x[i] = y[i].Item1;
            }

            return x;
        }
    }
}