namespace Rftim3LeetCode.Temp
{
    public class _01582_SpecialPositionsInABinaryMatrix
    {
        /// <summary>
        /// Given an m x n binary matrix mat, return the number of special positions in mat.
        /// A position(i, j) is called special if mat[i][j] == 1 and all other elements in row i and column j are 0 (rows and columns are 0-indexed).
        /// </summary>
        public _01582_SpecialPositionsInABinaryMatrix()
        {
            Console.WriteLine(NumSpecial(
            [
                [1,0,0],
                [0,0,1],
                [1,0,0]
            ]));
            Console.WriteLine(NumSpecial(
            [
                [1,0,0],
                [0,1,0],
                [0,0,1]
            ]));
        }

        private static int NumSpecial(int[][] mat)
        {
            int n = mat.Length;
            int m = mat[0].Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        int l = i - 1, r = j, d = 0;
                        // south
                        while (l > -1)
                        {
                            if (mat[l][r] == 1) d++;
                            l--;
                        }
                        if (d > 0) break;
                        l = i + 1;
                        // north
                        while (l < n)
                        {
                            if (mat[l][r] == 1) d++;
                            l++;
                        }
                        if (d > 0) break;
                        l = i;
                        r = j - 1;
                        // west
                        while (r > -1)
                        {
                            if (mat[l][r] == 1) d++;
                            r--;
                        }
                        if (d > 0) break;
                        r = j + 1;
                        // east
                        while (r < m)
                        {
                            if (mat[l][r] == 1) d++;
                            r++;
                        }
                        if (d > 0) break;
                        c++;
                    }
                }
            }

            return c;
        }

        private static int NumSpecial0(int[][] mat)
        {
            int count = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                if (mat[i].Count(s => s == 1) == 1)
                {
                    for (int j = 0; j < mat[0].Length; j++)
                    {
                        if (mat[i][j] == 1)
                        {
                            bool check = true;
                            for (int k = 0; k < mat.Length; k++)
                            {
                                if (k == i) continue;
                                else if (mat[k][j] != 0)
                                {
                                    check = false;
                                    break;
                                }
                            }
                            if (check == true) count++;
                            break;
                        }
                    }
                }
            }

            return count;
        }
    }
}
