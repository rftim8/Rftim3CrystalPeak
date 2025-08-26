using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00118_PascalsTriangle
    {
        /// <summary>
        /// Given an integer numRows, return the first numRows of Pascal's triangle.
        /// In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
        /// </summary>
        public _00118_PascalsTriangle()
        {
            IList<IList<int>> x = Generate0(5);
            RftTerminal.RftReadResult(x);

            IList<IList<int>> x0 = Generate0(1);
            RftTerminal.RftReadResult(x0);

        }

        public static IList<IList<int>> Generate0(int a0) => RftGenerate0(a0);

        public static IList<IList<int>> Generate1(int a0) => RftGenerate1(a0);

        private static IList<IList<int>> RftGenerate0(int numRows)
        {
            IList<IList<int>> n = [];

            for (int i = 0; i < numRows; i++)
            {
                n.Add(GetRow(i));
            }

            return n;
        }

        private static List<int> GetRow(int rowIndex)
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

        public static IList<IList<int>> RftGenerate1(int numRows)
        {
            int[][] triangle = new int[numRows][];

            if (numRows == 0) return [[]];

            for (int i = 0; i < numRows; i++)
            {
                triangle[i] = new int[i + 1];
                triangle[i][0] = triangle[i][i] = 1;

                for (int j = 1; j < i; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }

            return triangle;
        }
    }
}
