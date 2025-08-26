using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01886_DetermineWhetherMatrixCanBeObtainedByRotation
    {
        /// <summary>
        /// Given two n x n binary matrices mat and target, return true if it is possible to make mat equal to target by rotating mat in 90-degree increments, or false otherwise.
        /// </summary>
        public _01886_DetermineWhetherMatrixCanBeObtainedByRotation()
        {
            Console.WriteLine(FindRotation(
                [
                    [0,1],
                    [1,0]
                ],
                [
                    [1,0],
                    [0,1]
                ]
            ));

            Console.WriteLine(FindRotation(
                [
                    [0,1],
                    [1,1]
                ],
                [
                    [1,0],
                    [0,1]
                ]
            ));

            Console.WriteLine(FindRotation(
                [
                    [0,0],
                    [0,1]
                ],
                [
                    [0,0],
                    [1,0]
                ]
            ));
        }

        private static bool FindRotation(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            int t = 4;

            while (t > 0)
            {
                int c = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (mat[i][j] == target[i][j]) c++;
                    }
                }
                if (c == n * n) return true;

                int[][] x = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    x[i] = new int[n];
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        x[i][j] = target[n - j - 1][i];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        target[i][j] = x[i][j];
                    }
                }
                RftTerminal.RftReadResult<int>(mat);
                RftTerminal.RftReadResult<int>(target);
                t--;
            }

            return false;
        }

        private static bool FindRotation0(int[][] mat, int[][] target)
        {
            int n = mat.Length - 1;
            bool one = true;
            bool two = true;
            bool three = true;
            bool four = true;

            for (int r = 0; r <= n; r++)
            {
                for (int c = 0; c <= n; c++)
                {
                    if (mat[r][c] != target[n - c][r]) one = false;
                    if (mat[r][c] != target[n - r][n - c]) two = false;
                    if (mat[r][c] != target[c][n - r]) three = false;
                    if (mat[r][c] != target[r][c]) four = false;
                }
            }

            return one || two || three || four;
        }
    }
}
