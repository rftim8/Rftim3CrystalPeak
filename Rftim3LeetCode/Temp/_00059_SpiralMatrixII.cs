using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00059_SpiralMatrixII
    {
        /// <summary>
        /// Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.
        /// </summary>
        public _00059_SpiralMatrixII()
        {
            int[][] x = SpiralMatrixII0(3);

            RftTerminal.RftReadResult<int>(x);
        }

        public static int[][] SpiralMatrixII0(int a0) => RftSpiralMatrixII0(a0);

        private static int[][] RftSpiralMatrixII0(int n)
        {
            int[][] x = new int[n][];

            for (int i = 0; i < n; i++)
            {
                x[i] = new int[n];
            }

            int c = 1;
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = i; j < n - i; j++)
                {
                    x[i][j] = c++;
                }

                for (int j = i + 1; j < n - i; j++)
                {
                    x[j][n - i - 1] = c++;
                }

                for (int j = n - i - 2; j >= i; j--)
                {
                    x[n - i - 1][j] = c++;
                }

                for (int j = n - i - 2; j > i; j--)
                {
                    x[j][i] = c++;
                }
            }

            return x;
        }
    }
}
