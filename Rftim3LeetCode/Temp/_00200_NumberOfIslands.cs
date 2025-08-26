namespace Rftim3LeetCode.Temp
{
    public class _00200_NumberOfIslands
    {
        /// <summary>
        /// Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
        /// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
        /// You may assume all four edges of the grid are all surrounded by water.
        /// </summary>
        public _00200_NumberOfIslands()
        {
            Console.WriteLine(NumIslands([
                ['1','1','1','1','0'],
                ['1','1','0','1','0'],
                ['1','1','0','0','0'],
                ['0','0','0','0','0']
            ]));

            Console.WriteLine(NumIslands([
                ['1','1','0','0','0'],
                ['1','1','0','0','0'],
                ['0','0','1','0','0'],
                ['0','0','0','1','1']
            ]));
        }

        private static int NumIslands(char[][] grid)
        {
            int old = '1';
            int c = 0;

            Stack<(int y, int x)> st = new();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        st.Push((i, j));
                        c++;
                    }

                    while (st.Count > 0)
                    {
                        (int y, int x) = st.Pop();

                        if (y < 0 || x < 0 || y >= grid.Length || x >= grid[0].Length) continue;
                        if (grid[y][x] != old || grid[y][x] == '2') continue;

                        grid[y][x] = '2';

                        st.Push((y - 1, x));
                        st.Push((y + 1, x));
                        st.Push((y, x - 1));
                        st.Push((y, x + 1));
                    }
                }
            }

            return c;
        }
    }
}
