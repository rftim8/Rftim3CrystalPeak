using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00348_DesignTicTacToe
    {
        /// <summary>
        /// Assume the following rules are for the tic-tac-toe game on an n x n board between two players:
        /// 
        /// A move is guaranteed to be valid and is placed on an empty block.
        /// Once a winning condition is reached, no more moves are allowed.
        /// A player who succeeds in placing n of their marks in a horizontal, vertical, or diagonal row wins the game.
        /// Implement the TicTacToe class:
        /// TicTacToe(int n) Initializes the object the size of the board n.
        /// int move(int row, int col, int player) Indicates that the player with id player plays at the cell(row, col) of the board.
        /// The move is guaranteed to be a valid move, and the two players alternate in making moves.Return
        /// 0 if there is no winner after the move,
        /// 1 if player 1 is the winner after the move, or
        /// 2 if player 2 is the winner after the move.
        /// </summary>
        public _00348_DesignTicTacToe()
        {
            List<object?> x = DesignTicTacToe0(
                ["TicTacToe", "move", "move", "move", "move", "move", "move", "move"],
                [[3], [0, 0, 1], [0, 2, 2], [2, 2, 1], [1, 1, 2], [2, 0, 1], [1, 0, 2], [2, 1, 1]]
                );
            RftTerminal.RftReadResult(x);
        }

        public static List<object?> DesignTicTacToe0(string[] a0, int[][] a1) => RftDesignTicTacToe0(a0, a1);

        public static List<object?> DesignTicTacToe1(string[] a0, int[][] a1) => RftDesignTicTacToe1(a0, a1);

        public static List<object?> DesignTicTacToe2(string[] a0, int[][] a1) => RftDesignTicTacToe2(a0, a1);

        private static List<object?> RftDesignTicTacToe0(string[] a0, int[][] a1)
        {
            List<object?> res = [null];

            TicTacToe x = new(a1[0][0]);
            for (int i = 1; i < a1.Length; i++)
            {
                switch (a0[i])
                {
                    case "move":
                        int t = x.Move(a1[i][0], a1[i][1], a1[i][2]);
                        res.Add(t);
                        break;
                    default:
                        break;
                }
            }

            return res;
        }

        private static List<object?> RftDesignTicTacToe1(string[] a0, int[][] a1)
        {
            List<object?> res = [null];

            TicTacToe1 x = new(a1[0][0]);
            for (int i = 1; i < a1.Length; i++)
            {
                switch (a0[i])
                {
                    case "move":
                        int t = x.Move(a1[i][0], a1[i][1], a1[i][2]);
                        res.Add(t);
                        break;
                    default:
                        break;
                }
            }

            return res;
        }

        private static List<object?> RftDesignTicTacToe2(string[] a0, int[][] a1)
        {
            List<object?> res = [null];

            TicTacToe2 x = new(a1[0][0]);
            for (int i = 1; i < a1.Length; i++)
            {
                switch (a0[i])
                {
                    case "move":
                        int t = x.Move(a1[i][0], a1[i][1], a1[i][2]);
                        res.Add(t);
                        break;
                    default:
                        break;
                }
            }

            return res;
        }

        private class TicTacToe
        {
            private readonly int[][] board;
            private readonly int n;

            public TicTacToe(int n)
            {
                board = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    board[i] = new int[n];
                }

                this.n = n;
            }

            public int Move(int row, int col, int player)
            {
                board[row][col] = player;

                if (CheckRow(row, player) ||
                    CheckColumn(col, player) ||
                    row == col && CheckDiagonal(player) ||
                    col == n - row - 1 && CheckAntiDiagonal(player))
                {
                    return player;
                }

                return 0;
            }

            private bool CheckDiagonal(int player)
            {
                for (int row = 0; row < n; row++)
                {
                    if (board[row][row] != player) return false;
                }

                return true;
            }

            private bool CheckAntiDiagonal(int player)
            {
                for (int row = 0; row < n; row++)
                {
                    if (board[row][n - row - 1] != player) return false;
                }

                return true;
            }

            private bool CheckColumn(int col, int player)
            {
                for (int row = 0; row < n; row++)
                {
                    if (board[row][col] != player) return false;
                }

                return true;
            }

            private bool CheckRow(int row, int player)
            {
                for (int col = 0; col < n; col++)
                {
                    if (board[row][col] != player) return false;
                }

                return true;
            }
        }

        private class TicTacToe1(int n)
        {
            private readonly int[] rows = new int[n];
            private readonly int[] cols = new int[n];
            private int diagonal;
            private int antiDiagonal;

            public int Move(int row, int col, int player)
            {
                int currentPlayer = player == 1 ? 1 : -1;
                rows[row] += currentPlayer;
                cols[col] += currentPlayer;

                if (row == col) diagonal += currentPlayer;
                if (col == cols.Length - row - 1) antiDiagonal += currentPlayer;

                int n = rows.Length;
                if (Math.Abs(rows[row]) == n ||
                    Math.Abs(cols[col]) == n ||
                    Math.Abs(diagonal) == n ||
                    Math.Abs(antiDiagonal) == n)
                {
                    return player;
                }

                return 0;
            }
        }

        private class TicTacToe2(int n)
        {
            private readonly int n = n;
            private readonly int[] rowSums = new int[n];
            private readonly int[] colSums = new int[n];
            private int leftToRightDiagSum;
            private int rightToLeftDiagSum;

            public int Move(int row, int col, int player)
            {
                int moveValue = player == 1 ? 1 : -1;

                rowSums[row] += moveValue;
                if (Math.Abs(rowSums[row]) == n) return rowSums[row] > 0 ? 1 : 2;

                colSums[col] += moveValue;
                if (Math.Abs(colSums[col]) == n) return colSums[col] > 0 ? 1 : 2;

                if (row == col)
                {
                    leftToRightDiagSum += moveValue;
                    if (Math.Abs(leftToRightDiagSum) == n) return leftToRightDiagSum > 0 ? 1 : 2;
                }

                if (row + col == n - 1)
                {
                    rightToLeftDiagSum += moveValue;
                    if (Math.Abs(rightToLeftDiagSum) == n) return rightToLeftDiagSum > 0 ? 1 : 2;
                }

                return 0;
            }
        }
    }
}
