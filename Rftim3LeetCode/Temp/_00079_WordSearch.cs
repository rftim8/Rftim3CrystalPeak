namespace Rftim3LeetCode.Temp
{
    public class _00079_WordSearch
    {
        /// <summary>
        /// Given an m x n grid of characters board and a string word, return true if word exists in the grid.
        /// The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring.
        /// The same letter cell may not be used more than once.
        /// </summary>
        public _00079_WordSearch()
        {
            Console.WriteLine(Exist([
                ['A','B','C','E'],
                ['S','F','C','S'],
                ['A','D','E','E']
            ],
            "ABCCED"
            ));

            Console.WriteLine(Exist([
                ['A','B','C','E'],
                ['S','F','C','S'],
                ['A','D','E','E']
            ],
            "SEE"
            ));

            Console.WriteLine(Exist([
                ['A','B','C','E'],
                ['S','F','C','S'],
                ['A','D','E','E']
            ],
            "ABCB"
            ));
        }

        private static bool Exist(char[][] board, string word)
        {
            int n = board.Length;
            int m = board[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        if (Dfs(board, word, i, j)) return true;
                    }
                }
            }

            return false;
        }

        private static bool Dfs(char[][] board, string word, int row, int col)
        {
            if (board[row][col] == word[0])
            {
                if (word.Length == 1) return true;

                char pers = board[row][col];
                board[row][col] = '1';

                if (row + 1 < board.Length && Dfs(board, word[1..], row + 1, col)) return true;
                if (row - 1 >= 0 && Dfs(board, word[1..], row - 1, col)) return true;
                if (col + 1 < board[0].Length && Dfs(board, word[1..], row, col + 1)) return true;
                if (col - 1 >= 0 && Dfs(board, word[1..], row, col - 1)) return true;

                board[row][col] = pers;
            }

            return false;
        }

        private static bool Exist0(char[][] board, string word)
        {
            int m = board.Length, n = board[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Dfs(i, j, 0)) return true;
                }
            }

            return false;

            bool Dfs(int i, int j, int start)
            {
                if (start == word.Length) return true;
                if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != word[start]) return false;

                char c = board[i][j];
                board[i][j] = '~';
                bool result = Dfs(i + 1, j, start + 1) || Dfs(i - 1, j, start + 1)
                           || Dfs(i, j + 1, start + 1) || Dfs(i, j - 1, start + 1);
                board[i][j] = c;

                return result;
            }
        }
    }
}
