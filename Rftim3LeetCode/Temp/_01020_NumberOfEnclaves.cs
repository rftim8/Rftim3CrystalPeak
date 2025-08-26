namespace Rftim3LeetCode.Temp
{
    public class _01020_NumberOfEnclaves
    {
        /// <summary>
        /// You are given an m x n binary matrix grid, where 0 represents a sea cell and 1 represents a land cell.
        /// A move consists of walking from one land cell to another adjacent(4-directionally) land cell or walking off the boundary of the grid.
        /// Return the number of land cells in grid for which we cannot walk off the boundary of the grid in any number of moves.
        /// </summary>
        public _01020_NumberOfEnclaves()
        {
            Console.WriteLine(NumEnclaves([
                [0,0,0,0],
                [1,0,1,0],
                [0,1,1,0],
                [0,0,0,0]
            ]));

            Console.WriteLine(NumEnclaves([
                [0,1,1,0],
                [0,0,1,0],
                [0,0,1,0],
                [0,0,0,0]
            ]));
        }

        private static int NumEnclaves(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int c = 0;

            Stack<(int, int)> st = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        st.Push((i, j));

                        bool enclave = true;
                        int d = 0;

                        while (st.Count != 0)
                        {
                            (int y, int x) = st.Pop();

                            if (x < 0 || y < 0 || x >= m || y >= n)
                            {
                                enclave = false;
                                continue;
                            }
                            if (grid[y][x] != 1) continue;

                            grid[y][x] = 2;
                            d++;

                            st.Push((y - 1, x));
                            st.Push((y + 1, x));
                            st.Push((y, x - 1));
                            st.Push((y, x + 1));
                        }

                        if (enclave) c += d;
                    }
                }
            }

            return c;
        }
    }
}
