namespace Rftim3LeetCode.Temp
{
    public class _01631_PathWithMinimumEffort
    {
        /// <summary>
        /// You are a hiker preparing for an upcoming hike. 
        /// You are given heights, a 2D array of size rows x columns, where heights[row][col] represents the height of cell (row, col). 
        /// You are situated in the top-left cell, (0, 0), and you hope to travel to the bottom-right cell, (rows-1, columns-1) (i.e., 0-indexed). 
        /// You can move up, down, left, or right, and you wish to find a route that requires the minimum effort.
        /// A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.
        /// Return the minimum effort required to travel from the top-left cell to the bottom-right cell.
        /// </summary>
        public _01631_PathWithMinimumEffort()
        {
            Console.WriteLine(MinimumEffortPath(
            [
                [1,2,2],
                [3,8,2],
                [5,3,5]
            ]));

            Console.WriteLine(MinimumEffortPath(
            [
                [1,2,2],
                [3,8,4],
                [5,3,5]
            ]));

            Console.WriteLine(MinimumEffortPath(
            [
                [1,2,1,1,1],
                [1,2,1,2,1],
                [1,2,1,2,1],
                [1,2,1,2,1],
                [1,1,1,2,1]
            ]));
        }

        private static int MinimumEffortPath(int[][] heights)
        {
            int m = heights.Length;
            int n = heights[0].Length;

            int[,] minDisArr = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    minDisArr[i, j] = int.MaxValue;
                }
            }

            minDisArr[0, 0] = 0;

            PriorityQueue<(int x, int y), int> qu = new();
            qu.Enqueue((0, 0), 0);


            int[] dX = [-1, 1, 0, 0];
            int[] dY = [0, 0, -1, 1];

            while (qu.Count > 0)
            {
                (int x, int y) = qu.Dequeue();

                if (x == m - 1 && y == n - 1) break;

                for (int d = 0; d < 4; d++)
                {
                    int a = x + dX[d];
                    int b = y + dY[d];

                    if (a < 0 || a >= m || b < 0 || b >= n) continue;

                    int wt = Math.Max(minDisArr[x, y], Math.Abs(heights[a][b] - heights[x][y]));

                    if (minDisArr[a, b] > wt)
                    {
                        minDisArr[a, b] = wt;
                        qu.Enqueue((a, b), wt);
                    }
                }
            }

            return minDisArr[m - 1, n - 1];
        }

        private static int MinimumEffortPath0(int[][] heights)
        {
            Span<(int r, int c)> dirs = [
                (0, 1),
                (0, -1),
                (1, 0),
                (-1, 0)
            ];
            int m = heights.Length;
            int n = heights[0].Length;
            int[,] t = new int[m, n];

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    t[r, c] = int.MaxValue;
                }
            }

            t[0, 0] = 0;
            PriorityQueue<(int row, int col), int> heap = new();
            heap.Enqueue((0, 0), t[0, 0]);

            while (heap.TryDequeue(out (int row, int col) cell, out int w))
            {
                (int r, int c) = cell;
                if (t[r, c] < w) continue;
                if (r == m - 1 && c == n - 1) return w;
                foreach ((int r, int c) d in dirs)
                {
                    int nr = r + d.r;
                    int nc = c + d.c;
                    if (0 <= nr && nr < m && 0 <= nc && nc < n)
                    {
                        int nw = Math.Max(w, Math.Abs(heights[nr][nc] - heights[r][c]));
                        if (t[nr, nc] > nw)
                        {
                            t[nr, nc] = nw;
                            heap.Enqueue((nr, nc), nw);
                        }
                    }
                }
            }

            return 0;
        }

        // Priority Queue
        private static readonly int[] dirs = [0, 1, 0, -1, 0];

        private static int MinimumEffortPath1(int[][] heights)
        {
            int r = heights.Length;
            int c = heights[0].Length;
            bool[,] visited = new bool[r, c];
            SortedSet<(int H, int X, int Y)> pq =
            [
                (0, 0, 0)
            ];
            while (pq.Count > 0)
            {
                (int H, int X, int Y) cur = pq.Min;

                if (cur.X == r - 1 && cur.Y == c - 1) return cur.H;

                visited[cur.X, cur.Y] = true;
                pq.Remove(cur);

                for (int d = 0; d < 4; d++)
                {
                    int nx = cur.X + dirs[d];
                    int ny = cur.Y + dirs[d + 1];

                    if (nx < 0 || nx == r || ny < 0 || ny == c || visited[nx, ny]) continue;

                    int nh = Math.Max(cur.H, Math.Abs(heights[cur.X][cur.Y] - heights[nx][ny]));
                    pq.Add((nh, nx, ny));
                }
            }

            return 0;
        }

        // Dijkstra + Priority Queue
        private static int MinimumEffortPath2(int[][] heights)
        {
            int rows = heights.Length;
            int columns = heights[0].Length;

            PriorityQueue<(int row, int column), int> queue = new();
            Dictionary<(int, int), int> visited = [];

            queue.Enqueue((0, 0), 0);
            visited.Add((0, 0), 0);

            while (queue.TryDequeue(out (int row, int column) coordinate, out int diff))
            {
                (int i, int j) = coordinate;
                if (i == rows - 1 && j == columns - 1) return diff;

                int height = heights[i][j];
                foreach ((int newI, int newJ) in new[] { (i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1) })
                {
                    if (newI < 0 || newI > rows - 1 || newJ < 0 || newJ > columns - 1) continue;

                    int newHeight = heights[newI][newJ];
                    int newDiff = Math.Max(diff, Math.Abs(newHeight - height));

                    if (!visited.ContainsKey((newI, newJ)) || visited[(newI, newJ)] > newDiff)
                    {
                        queue.Enqueue((newI, newJ), newDiff);
                        visited[(newI, newJ)] = newDiff;
                    }
                }
            }

            return -1;
        }
    }
}
