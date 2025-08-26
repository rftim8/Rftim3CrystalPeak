namespace Rftim3LeetCode.Temp
{
    public class _01091_ShortestPathInBinaryMatrix
    {
        /// <summary>
        /// Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. 
        /// If there is no clear path, return -1.
        /// A clear path in a binary matrix is a path from the top-left cell(i.e., (0, 0)) to the bottom-right cell(i.e., (n - 1, n - 1)) such that:
        /// All the visited cells of the path are 0.
        /// All the adjacent cells of the path are 8-directionally connected(i.e., they are different and they share an edge or a corner).
        /// The length of a clear path is the number of visited cells of this path.
        /// </summary>
        public _01091_ShortestPathInBinaryMatrix()
        {
            Console.WriteLine(ShortestPathInBinaryMatrix0([
                [0, 1],
                [1, 0]
            ]));

            Console.WriteLine(ShortestPathInBinaryMatrix0([
                [0, 0, 0],
                [1, 1, 0],
                [1, 1, 0]
            ]));

            Console.WriteLine(ShortestPathInBinaryMatrix0([
                [0, 0, 0],
                [0, 0, 0],
                [0, 0, 0]
            ]));
        }

        public static int ShortestPathInBinaryMatrix0(int[][] a0) => RftShortestPathInBinaryMatrix0(a0);

        private static int RftShortestPathInBinaryMatrix0(int[][] grid)
        {
            int n = grid.Length;
            if (grid[0][0] != 0) return -1;

            int x = 0;

            Queue<(int, int)> q = new();
            q.Enqueue((0, 0));

            bool[,] visited = new bool[n, n];
            visited[0, 0] = true;

            int[,] dirs = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
            int m = dirs.Length / 2;

            while (q.Count != 0)
            {
                x++;
                int z = q.Count;
                for (int i = 0; i < z; i++)
                {
                    (int, int) y = q.Dequeue();
                    if (y.Item1 == n - 1 && y.Item2 == n - 1) return x;

                    for (int j = 0; j < m; j++)
                    {
                        int nextRow = y.Item1 + dirs[j, 0];
                        int nextCol = y.Item2 + dirs[j, 1];

                        if (nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n && !visited[nextRow, nextCol] && grid[nextRow][nextCol] == 0)
                        {
                            q.Enqueue((nextRow, nextCol));
                            visited[nextRow, nextCol] = true;
                        }
                    }
                }
            }

            return -1;
        }
    }
}