using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00119_PascalsTriangle2
    {
        /// <summary>
        ///               1
        ///            1      1
        ///           1   2    1
        ///          1 3      3 1
        ///         1 4   6    4 1
        ///        1 5 10    10 5 1
        ///       1 6 15  20  15 6 1
        ///      1 7 21 35  35 21 7 1
        ///     1 8 28 56 70 56 28 8 1
        /// Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.
        /// In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
        /// </summary>

        public _00119_PascalsTriangle2()
        {
            List<int> x = GetRow0(3);
            RftTerminal.RftReadResult(x);

            List<int> x0 = GetRow0(0);
            RftTerminal.RftReadResult(x0);

            List<int> x1 = GetRow0(1);
            RftTerminal.RftReadResult(x1);
        }

        public static List<int> GetRow0(int a0) => RftGetRow0(a0);

        public static List<int> GetRow1(int a0) => RftGetRow1(a0);

        private static List<int> RftGetRow0(int rowIndex)
        {
            List<int> x = [1];

            int n = rowIndex / 2;
            int c = x[0];
            for (int i = 0; i < n; i++)
            {
                c = (int)Math.Round(c * ((double)(rowIndex - i) / (i + 1)));
                x.Add(c);
            }
            if (rowIndex % 2 == 0)
            {
                for (int i = x.Count - 2; i > -1; i--)
                {
                    x.Add(x[i]);
                }
            }
            else
            {
                for (int i = x.Count - 1; i > -1; i--)
                {
                    x.Add(x[i]);
                }
            }

            return x;
        }

        private static List<int> RftGetRow1(int rowIndex)
        {
            List<int> row = [1];
            for (int k = 1; k <= rowIndex; k++)
            {
                long temp = row[k - 1];
                temp *= rowIndex + 1 - k;
                temp /= k;
                row.Add((int)temp);
            }

            return row;
        }
    }
}
