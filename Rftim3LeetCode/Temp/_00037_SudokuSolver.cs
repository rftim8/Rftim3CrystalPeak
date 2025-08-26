namespace Rftim3LeetCode.Temp
{
    public class _00037_SudokuSolver
    {
        /// <summary>
        /// Write a program to solve a Sudoku puzzle by filling the empty cells.
        /// A sudoku solution must satisfy all of the following rules:
        /// Each of the digits 1-9 must occur exactly once in each row.
        /// Each of the digits 1-9 must occur exactly once in each column.
        /// Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
        /// The '.' character indicates empty cells.
        /// </summary>
        public _00037_SudokuSolver()
        {
            Console.WriteLine(SudokuSolver0(
            [
                ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9']
            ]));
        }

        public static bool SudokuSolver0(char[][] a0) => RftSudokuSolver0(a0);

        private static bool RftSudokuSolver0(char[][] board)
        {
            return Backtrack(board);
        }

        private static bool Backtrack(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValid(board, i, j, c))
                            {
                                board[i][j] = c;
                                if (Backtrack(board)) return true;

                                board[i][j] = '.';
                            }
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsValid(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == c || board[i][col] == c) return false;

                int r0 = 3 * (row / 3);
                int c0 = 3 * (col / 3);

                if (board[r0 + i / 3][c0 + i % 3] == c) return false;
            }

            return true;
        }
    }
}
