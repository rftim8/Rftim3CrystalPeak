using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00542_01Matrix
    {
        /// <summary>
        /// Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
        /// The distance between two adjacent cells is 1.
        /// </summary>
        public _00542_01Matrix()
        {
            int[][] x = UpdateMatrix(
            [
                [0,0,0],
                [0,1,0],
                [1,1,1]
            ]);

            int[][] x0 = UpdateMatrix(
            [
                [0],
                [0],
                [0],
                [0],
                [0]
            ]);

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] UpdateMatrix(int[][] mat)
        {
            if (mat == null || mat.Length == 0) return [];

            int n = mat.Length;
            int m = mat[0].Length;

            int[] dr = [0, 1, 0, -1];
            int[] dc = [-1, 0, 1, 0];

            Queue<(int, int)> q = new();
            HashSet<(int, int)> v = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        q.Enqueue((i, j));
                        v.Add((i, j));
                    }
                }
            }

            int d = 1;

            while (q.Count > 0)
            {
                int s = q.Count;
                for (int i = 0; i < s; i++)
                {
                    (int, int) c = q.Dequeue();

                    for (int j = 0; j < 4; j++)
                    {
                        int nr = c.Item1 + dr[j];
                        int nc = c.Item2 + dc[j];
                        if (nr > -1 && nr < n && nc > -1 && nc < m && !v.Contains((nr, nc)))
                        {
                            mat[nr][nc] = d;
                            q.Enqueue((nr, nc));
                            v.Add((nr, nc));
                        }
                    }
                }
                d++;
            }

            return mat;
        }
    }
}
