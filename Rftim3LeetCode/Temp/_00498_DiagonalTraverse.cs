using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00498_DiagonalTraverse
    {
        /// <summary>
        /// Given an m x n matrix mat, return an array of all the elements of the array in a diagonal order.
        /// </summary>
        public _00498_DiagonalTraverse()
        {
            int[] x = FindDiagonalOrder([
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ]);

            int[] x0 = FindDiagonalOrder([
                [1,2],
                [3,4]
            ]);

            int[] x1 = FindDiagonalOrder([
                [1,2,3,4],
                [5,6,7,8],
                [9,10,11,12],
                [13,14,15,16]
            ]);

            int[] x2 = FindDiagonalOrderCompact([
                [1,2,3,4,5],
                [6,7,8,9,10],
                [11,12,13,14,15],
                [16,17,18,19,20],
                [21,22,23,24,25]
            ]);

            int[] x3 = FindDiagonalOrder([
                [1]
            ]);

            int[] x4 = FindDiagonalOrder([
                [2,3]
            ]);

            int[] x5 = FindDiagonalOrder([
                [1,2],
                [3,4],
                [5,6]
            ]);

            int[] x6 = FindDiagonalOrder([
                [2,3,4],
                [5,6,7],
                [8,9,10],
                [11,12,13],
                [14,15,16]
            ]);

            int[] x7 = FindDiagonalOrder([
                [3],
                [2],
                [1],
                [4]
            ]);

            int[] x8 = FindDiagonalOrder([
                [3,2,1,4]
            ]);

            int[] x9 = FindDiagonalOrder([
                [1],
                [2],
                [3],
                [4],
                [5],
                [6],
                [7],
                [8],
                [9],
                [10]
            ]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
            RftTerminal.RftReadResult(x3);
            RftTerminal.RftReadResult(x4);
            RftTerminal.RftReadResult(x5);
            RftTerminal.RftReadResult(x6);
            RftTerminal.RftReadResult(x7);
            RftTerminal.RftReadResult(x8);
            RftTerminal.RftReadResult(x9);
        }

        private static int[] FindDiagonalOrder(int[][] mat)
        {
            int c = 0;
            int n = mat.Length;
            int m = mat[0].Length;
            foreach (int[] item in mat)
            {
                c += item.Length;
            }
            int[] z = new int[c];
            int nDiag = n + m - 1;

            int t = 0;
            int yl = 0;
            int xl = 0;
            int yr = 0;
            int xr = 0;
            for (int i = 0; i < nDiag; i++)
            {
                if (i % 2 == 0)
                {
                    if (i == 0)
                    {
                        z[t] = mat[0][0];
                        t++;
                    }
                    else
                    {
                        if (yr + 2 < n)
                        {
                            yr += 2;
                            for (int j = 0; j < i + 1; j++)
                            {
                                if (j < m && yr - j > -1)
                                {
                                    z[t] = mat[yr - j][xr + j];
                                    t++;
                                }
                                else break;
                            }
                        }
                        else if (yr + 1 < n && m > 1)
                        {
                            xr += 1;
                            yr += 1;
                            for (int j = 0; j < nDiag - i; j++)
                            {
                                if (j < m && yr - j > -1)
                                {
                                    z[t] = mat[yr - j][xr + j];
                                    t++;
                                }
                                else break;
                            }
                        }
                        else
                        {
                            if (xr + 2 < m)
                            {
                                xr += 2;
                                for (int j = 0; j < nDiag - i; j++)
                                {
                                    if (j < m && yr - j > -1)
                                    {
                                        z[t] = mat[yr - j][xr + j];
                                        t++;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        if (n == 1 && m > 1)
                        {
                            xl += 1;
                            z[t] = mat[yl][xl];
                            t++;
                        }
                        else if (m == 1 && n > 1)
                        {
                            yl += 1;
                            z[t] = mat[yl][xl];
                            t++;
                        }
                        else
                        {
                            xl += 1;
                            for (int j = 0; j < i + 1; j++)
                            {
                                if (j < n && xl - j > -1)
                                {
                                    z[t] = mat[yl + j][xl - j];
                                    t++;
                                }
                                else break;
                            }
                        }
                    }
                    else
                    {
                        if (xl + 2 < m)
                        {
                            xl += 2;
                            for (int j = 0; j < i + 1; j++)
                            {
                                if (j < n && xl - j > -1)
                                {
                                    z[t] = mat[yl + j][xl - j];
                                    t++;
                                }
                                else break;
                            }
                        }
                        else if (xl + 1 < m && n > 1)
                        {
                            xl += 1;
                            yl += 1;
                            for (int j = 0; j < nDiag - i; j++)
                            {
                                if (j < n && xl - j > -1)
                                {
                                    z[t] = mat[yl + j][xl - j];
                                    t++;
                                }
                                else break;
                            }
                        }
                        else
                        {
                            if (yl + 2 < n)
                            {
                                yl += 2;
                                for (int j = 0; j < nDiag - i; j++)
                                {
                                    if (j < n && xl - j > -1)
                                    {
                                        z[t] = mat[yl + j][xl - j];
                                        t++;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                }
            }

            return z;
        }

        private static int[] FindDiagonalOrderCompact(int[][] mat)
        {
            List<int> res = [];
            int y = 0;
            int x = 0;

            while (x < mat.Length - 1 || y < mat[0].Length - 1)
            {
                res.Add(mat[x][y]);
                if ((x + y) % 2 == 0)
                {
                    if (y < mat[0].Length - 1)
                    {
                        y++;
                        if (x > 0) x--;
                    }
                    else x++;
                }
                else
                {
                    if (x < mat.Length - 1)
                    {
                        x++;
                        if (y > 0) y--;
                    }
                    else y++;
                }
            }
            res.Add(mat[x][y]);

            return [.. res];
        }
    }
}
