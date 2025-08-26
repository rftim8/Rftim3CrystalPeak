namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Searching.DFS
{
    public class RftDFS
    {
        private static readonly int r = 3;
        private static readonly int c = 3;

        private static readonly int[] dr = [0, 1, 0, -1];
        private static readonly int[] dc = [-1, 0, 1, 0];

        // Stack, Backtracking
        public RftDFS()
        {
            Dfs(new int[,] {
                { -1,2,3 },
                { 0,9,8 },
                { 1,0,1 }
            });
        }

        private static void Dfs(int[,] grid)
        {
            bool[,] vis = new bool[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    vis[i, j] = false;
                }
            }

            DFS(0, 0, grid, vis);
        }

        private static bool IsValid(bool[,] vis, int row, int col)
        {
            if (row < 0 || col < 0 || row >= r || col >= c) return false;
            if (vis[row, col]) return false;
            return true;
        }

        private static void DFS(int row, int col, int[,] grid, bool[,] vis)
        {
            Stack<(int, int)> st = new();
            st.Push((row, col));

            while (st.Count > 0)
            {
                (int y, int x) = st.Pop();

                if (!IsValid(vis, y, x)) continue;

                vis[y, x] = true;

                Console.Write(grid[y, x] + " ");

                for (int i = 0; i < 4; i++)
                {
                    int adjx = y + dr[i];
                    int adjy = x + dc[i];
                    st.Push((adjx, adjy));
                }
            }
        }
    }
}
