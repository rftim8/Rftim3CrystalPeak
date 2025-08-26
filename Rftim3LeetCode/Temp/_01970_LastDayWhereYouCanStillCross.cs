namespace Rftim3LeetCode.Temp
{
    public class _01970_LastDayWhereYouCanStillCross
    {
        /// <summary>
        /// There is a 1-based binary matrix where 0 represents land and 1 represents water. 
        /// You are given integers row and col representing the number of rows and columns in the matrix, respectively.
        /// Initially on day 0, the entire matrix is land.
        /// However, each day a new cell becomes flooded with water.
        /// You are given a 1-based 2D array cells, where cells[i] = [ri, ci] represents that on the ith day, 
        /// the cell on the rith row and cith column(1-based coordinates) will be covered with water(i.e., changed to 1).
        /// You want to find the last day that it is possible to walk from the top to the bottom by only walking on land cells.
        /// You can start from any cell in the top row and end at any cell in the bottom row.
        /// You can only travel in the four cardinal directions(left, right, up, and down).
        /// Return the last day where it is possible to walk from the top to the bottom by only walking on land cells.
        /// </summary>
        public _01970_LastDayWhereYouCanStillCross()
        {
            Console.WriteLine(LatestDayToCross(2, 2,
            [
                [1,1],
                [2,1],
                [1,2],
                [2,2]
            ]));
            Console.WriteLine(LatestDayToCross(2, 2,
            [
                [1,1],
                [1,2],
                [2,1],
                [2,2]
            ]));
            Console.WriteLine(LatestDayToCross(3, 3,
            [
                [1,1],
                [2,1],
                [3,3],
                [2,2],
                [1,1],
                [1,3],
                [2,3],
                [3,2],
                [3,1]
            ]));
        }

        #region BS + BFS
        private static readonly int[][] directions = [
            [1, 0],
            [-1, 0],
            [0, 1],
            [0, -1]
        ];

        private static bool CanCross(int row, int col, int[][] cells, int day)
        {
            int[][] grid = new int[row][];
            for (int i = 0; i < row; i++)
            {
                grid[i] = new int[col];
            }

            Queue<int[]> queue = new();

            for (int i = 0; i < day; i++)
            {
                grid[cells[i][0] - 1][cells[i][1] - 1] = 1;
            }

            for (int i = 0; i < col; i++)
            {
                if (grid[0][i] == 0)
                {
                    queue.Enqueue([0, i]);
                    grid[0][i] = -1;
                }
            }

            while (queue.Count != 0)
            {
                int[] cur = queue.Dequeue();
                int r = cur[0], c = cur[1];
                if (r == row - 1) return true;

                foreach (int[] dir in directions)
                {
                    int newRow = r + dir[0];
                    int newCol = c + dir[1];
                    if (newRow >= 0 && newRow < row && newCol >= 0 && newCol < col && grid[newRow][newCol] == 0)
                    {
                        grid[newRow][newCol] = -1;
                        queue.Enqueue([newRow, newCol]);
                    }
                }
            }

            return false;
        }

        private static int LatestDayToCross(int row, int col, int[][] cells)
        {
            int left = 1;
            int right = row * col;

            while (left < right)
            {
                int mid = right - (right - left) / 2;
                if (CanCross(row, col, cells, mid)) left = mid;
                else right = mid - 1;
            }

            return left;
        }
        #endregion

        #region BS + DFS
        private static readonly int[][] directions1 = [
            [1, 0],
            [-1, 0],
            [0, 1],
            [0, -1]
        ];

        private static bool CanCross1(int row, int col, int[][] cells, int day)
        {
            int[][] grid = new int[row][];
            for (int i = 0; i < row; i++)
            {
                grid[i] = new int[col];
            }

            for (int i = 0; i < day; ++i)
            {
                int r = cells[i][0] - 1, c = cells[i][1] - 1;
                grid[r][c] = 1;
            }

            for (int i = 0; i < day; ++i)
            {
                grid[cells[i][0] - 1][cells[i][1] - 1] = 1;
            }

            for (int i = 0; i < col; ++i)
            {
                if (grid[0][i] == 0 && Dfs(grid, 0, i, row, col)) return true;
            }

            return false;
        }

        private static bool Dfs(int[][] grid, int r, int c, int row, int col)
        {
            if (r < 0 || r >= row || c < 0 || c >= col || grid[r][c] != 0) return false;
            if (r == row - 1) return true;

            grid[r][c] = -1;
            foreach (int[] dir in directions1)
            {
                int newR = r + dir[0], newC = c + dir[1];
                if (Dfs(grid, newR, newC, row, col)) return true;
            }

            return false;
        }

        private static int LatestDayToCross1(int row, int col, int[][] cells)
        {
            int left = 1, right = row * col;
            while (left < right)
            {
                int mid = right - (right - left) / 2;
                if (CanCross(row, col, cells, mid)) left = mid;
                else right = mid - 1;
            }

            return left;
        }
        #endregion

        #region DSU land cells
        private class DSU
        {
            private readonly int[] root;
            private readonly int[] size;

            public DSU(int n)
            {
                root = new int[n];
                for (int i = 0; i < n; i++)
                {
                    root[i] = i;
                }
                size = new int[n];
                Array.Fill(size, 1);
            }

            public int Find(int x)
            {
                if (root[x] != x) root[x] = Find(root[x]);

                return root[x];
            }

            public void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);
                if (rootX == rootY) return;

                if (size[rootX] > size[rootY]) (rootY, rootX) = (rootX, rootY);

                root[rootX] = rootY;
                size[rootY] += size[rootX];
            }
        }

        private static int LatestDayToCross2(int row, int col, int[][] cells)
        {
            DSU dsu = new(row * col + 2);
            int[][] grid = new int[row][];
            for (int i = 0; i < row; i++)
            {
                grid[i] = new int[col];
            }

            int[][] directions = [
                [0, 1],
                [0, -1],
                [1, 0],
                [-1, 0]
            ];

            for (int i = cells.Length - 1; i >= 0; i--)
            {
                int r = cells[i][0] - 1, c = cells[i][1] - 1;
                grid[r][c] = 1;
                int index1 = r * col + c + 1;
                foreach (int[] d in directions)
                {
                    int newR = r + d[0], newC = c + d[1];
                    int index2 = newR * col + newC + 1;
                    if (newR >= 0 && newR < row && newC >= 0 && newC < col && grid[newR][newC] == 1) dsu.Union(index1, index2);
                }
                if (r == 0) dsu.Union(0, index1);
                if (r == row - 1) dsu.Union(row * col + 1, index1);
                if (dsu.Find(0) == dsu.Find(row * col + 1)) return i;
            }

            return -1;
        }
        #endregion

        #region DSU water cells
        private static int LatestDayToCross3(int row, int col, int[][] cells)
        {
            DSU dsu = new(row * col + 2);
            int[][] grid = new int[row][];
            for (int i = 0; i < row; i++)
            {
                grid[i] = new int[col];
            }

            int[][] directions = [
                [0, 1],
                [0, -1],
                [1, 0],
                [-1, 0],
                [1, 1],
                [1, -1],
                [-1, 1],
                [-1, -1]
            ];

            for (int i = 0; i < row * col; ++i)
            {
                int r = cells[i][0] - 1, c = cells[i][1] - 1;
                grid[r][c] = 1;
                int index1 = r * col + c + 1;
                foreach (int[] d in directions)
                {
                    int newR = r + d[0], newC = c + d[1];
                    int index2 = newR * col + newC + 1;
                    if (newR >= 0 && newR < row && newC >= 0 && newC < col && grid[newR][newC] == 1) dsu.Union(index1, index2);
                }
                if (c == 0) dsu.Union(0, index1);
                if (c == col - 1) dsu.Union(row * col + 1, index1);
                if (dsu.Find(0) == dsu.Find(row * col + 1)) return i;
            }

            return -1;
        }
        #endregion
    }
}
