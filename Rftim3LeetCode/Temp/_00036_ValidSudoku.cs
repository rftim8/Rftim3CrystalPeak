using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00036_ValidSudoku
    {
        /// <summary>
        /// Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
        /// Each row must contain the digits 1-9 without repetition.
        /// Each column must contain the digits 1-9 without repetition.
        /// Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        /// Note:
        /// A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        /// Only the filled cells need to be validated according to the mentioned rules.
        /// </summary>
        public _00036_ValidSudoku()
        {
            Console.WriteLine(ValidSudoku0([
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

            char[][] x = [
                ['.', '.', '.', '.', '5', '.', '.', '1', '.'],
                ['.', '4', '.', '3', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '3', '.', '.', '1'],
                ['8', '.', '.', '.', '.', '.', '.', '2', '.'],
                ['.', '.', '2', '.', '7', '.', '.', '.', '.'],
                ['.', '1', '5', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '2', '.', '.', '.'],
                ['.', '2', '.', '9', '.', '.', '.', '.', '.'],
                ['.', '.', '4', '.', '.', '.', '.', '.', '.']
            ];

            Console.WriteLine(ValidSudoku0(x));

            RftTerminal.RftReadResult<char>(x);
        }

        public static bool ValidSudoku0(char[][] a0) => RftValidSudoku0(a0);

        private static bool RftValidSudoku0(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        // Check row
                        for (int k = 0; k < 9; k++)
                        {
                            if (k != j && board[i][k] == board[i][j]) return false;
                        }
                        // Check column
                        for (int k = 0; k < 9; k++)
                        {
                            if (k != i && board[k][j] == board[i][j]) return false;
                        }

                        if (i >= 0 && i < 3 && j >= 0 && j < 3) if (SudokuSubArray(board, board[i][j], 0, 3, 0, 3, i, j) == false) return false;
                        if (i >= 3 && i < 6 && j >= 0 && j < 3) if (SudokuSubArray(board, board[i][j], 3, 6, 0, 3, i, j) == false) return false;
                        if (i >= 6 && i < 9 && j >= 0 && j < 3) if (SudokuSubArray(board, board[i][j], 6, 9, 0, 3, i, j) == false) return false;
                        if (i >= 0 && i < 3 && j >= 3 && j < 6) if (SudokuSubArray(board, board[i][j], 0, 3, 3, 6, i, j) == false) return false;
                        if (i >= 3 && i < 6 && j >= 3 && j < 6) if (SudokuSubArray(board, board[i][j], 3, 6, 3, 6, i, j) == false) return false;
                        if (i >= 6 && i < 9 && j >= 3 && j < 6) if (SudokuSubArray(board, board[i][j], 6, 9, 3, 6, i, j) == false) return false;
                        if (i >= 0 && i < 3 && j >= 6 && j < 9) if (SudokuSubArray(board, board[i][j], 0, 3, 6, 9, i, j) == false) return false;
                        if (i >= 3 && i < 6 && j >= 6 && j < 9) if (SudokuSubArray(board, board[i][j], 3, 6, 6, 9, i, j) == false) return false;
                        if (i >= 6 && i < 9 && j >= 6 && j < 9) if (SudokuSubArray(board, board[i][j], 6, 9, 6, 9, i, j) == false) return false;
                    }
                }
            }

            return true;
        }

        private static bool SudokuSubArray(char[][] board, char x, int n, int m, int o, int p, int q, int r)
        {
            for (int i = n; i < m; i++)
            {
                for (int j = o; j < p; j++)
                {
                    if (q != i && r != j && board[i][j] == x) return false;
                }
            }

            return true;
        }
    }
}
