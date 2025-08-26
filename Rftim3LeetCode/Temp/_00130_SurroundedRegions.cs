namespace Rftim3LeetCode.Temp
{
    public class _00130_SurroundedRegions
    {
        /// <summary>
        /// Given an m x n matrix board containing 'X' and 'O', capture all regions that are 4-directionally surrounded by 'X'.
        /// A region is captured by flipping all 'O's into 'X's in that surrounded region.
        /// </summary>
        public _00130_SurroundedRegions()
        {
            Solve(new char[4][] {
                new char[] { 'X','X','X','X' },
                new char[] { 'X','O','O','X' },
                new char[] { 'X','X','O','X' },
                new char[] { 'X','O','X','X' }
            });
            Console.WriteLine();
            Solve(new char[3][] {
                new char[] { 'O','O','O' },
                new char[] { 'O','O','O' },
                new char[] { 'O','O','O' }
            });
            Console.WriteLine();
            Solve(new char[1][] {
                new char[] { 'X' }
            });
            Console.WriteLine();
            Solve(new char[4][] {
                new char[] { 'X','O','X','O','X','O' },
                new char[] { 'O','X','O','X','O','X' },
                new char[] { 'X','O','X','O','X','O' },
                new char[] { 'O','X','O','X','O','X' }
            });
        }

        private static void Solve(char[][] board)
        {
            int n = board.Length;
            int m = board[0].Length;
            if (n != 1)
            {
                Stack<(int, int)> x = new();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (board[i][j] == 'O')
                        {
                            x.Push((i, j));

                            char[][] z = new char[n][];
                            for (int k = 0; k < n; k++)
                            {
                                z[k] = new char[m];
                                Array.Copy(board[k], z[k], m);
                            }

                            int a = 0;

                            while (x.Any())
                            {
                                (int, int) y = x.Pop();

                                if (y.Item1 < 0 || y.Item2 < 0 || y.Item1 >= n || y.Item2 >= m) continue;
                                if (z[y.Item1][y.Item2] != 'O') continue;

                                if (y.Item1 == 0 || y.Item2 == 0 || y.Item1 == n - 1 || y.Item2 == m - 1) a = 1;
                                z[y.Item1][y.Item2] = 'X';

                                x.Push((y.Item1 + 1, y.Item2));
                                x.Push((y.Item1 - 1, y.Item2));
                                x.Push((y.Item1, y.Item2 + 1));
                                x.Push((y.Item1, y.Item2 - 1));
                            }

                            if (a == 0)
                            {
                                for (int k = 0; k < n; k++)
                                {
                                    Array.Copy(z[k], board[k], m);
                                }
                            }
                        }
                    }
                }
            }

            foreach (char[] item in board)
            {
                foreach (char item1 in item)
                {
                    Console.Write($"{item1} ");
                }
                Console.WriteLine();
            }
        }

        private static void Solve0(char[][]? board)
        {
            if (board is null || board.Length == 0) return;

            int m = board.Length;
            int n = board[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 || i == m - 1 || j == 0 || j == n - 1) && board[i][j] == 'O') BFS(board, i, j);
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O') board[i][j] = 'X';
                    if (board[i][j] == 'M') board[i][j] = 'O';
                }
            }
        }
        private static void BFS(char[][] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length) return;

            if (board[i][j] == 'O')
            {
                board[i][j] = 'M';
                BFS(board, i - 1, j);
                BFS(board, i, j - 1);
                BFS(board, i + 1, j);
                BFS(board, i, j + 1);
            }
            else return;
        }
    }
}
