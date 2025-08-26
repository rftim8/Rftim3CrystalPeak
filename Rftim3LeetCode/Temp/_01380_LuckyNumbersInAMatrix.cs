using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01380_LuckyNumbersInAMatrix
    {
        /// <summary>
        /// Given an m x n matrix of distinct numbers, return all lucky numbers in the matrix in any order.
        /// A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column.
        /// </summary>
        public _01380_LuckyNumbersInAMatrix()
        {
            IList<int> x = LuckyNumbers([
                [3,7,8],
                [9,11,13],
                [15,16,17]
            ]);
            IList<int> x0 = LuckyNumbers([
                [1,10,4,2],
                [9,3,8,7],
                [15,16,17,12]
            ]);
            IList<int> x1 = LuckyNumbers([
                [7,8],
                [1,2]
            ]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> LuckyNumbers(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            List<int> r = [];
            for (int i = 0; i < n; i++)
            {
                int c = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    c = Math.Min(c, matrix[i][j]);
                }
                r.Add(c);
            }

            List<int> x = [];
            for (int i = 0; i < m; i++)
            {
                int c = int.MinValue;
                for (int j = 0; j < n; j++)
                {
                    c = Math.Max(c, matrix[j][i]);
                }
                if (r.Contains(c)) x.Add(c);
            }

            return x;
        }
    }
}
