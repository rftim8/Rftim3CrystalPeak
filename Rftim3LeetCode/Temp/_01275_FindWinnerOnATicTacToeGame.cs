namespace Rftim3LeetCode.Temp
{
    public class _01275_FindWinnerOnATicTacToeGame
    {
        /// <summary>
        /// Tic-tac-toe is played by two players A and B on a 3 x 3 grid. The rules of Tic-Tac-Toe are:
        /// Players take turns placing characters into empty squares ' '.
        /// The first player A always places 'X' characters, while the second player B always places 'O' characters.
        /// 'X' and 'O' characters are always placed into empty squares, never on filled ones.
        /// The game ends when there are three of the same (non-empty) character filling any row, column, or diagonal.
        ///         The game also ends if all squares are non-empty.
        ///         No more moves can be played if the game is over.
        /// Given a 2D integer array moves where moves[i] = [rowi, coli] indicates that the ith move will be played on grid[rowi][coli].
        /// return the winner of the game if it exists(A or B). 
        /// In case the game ends in a draw return "Draw".
        /// If there are still movements to play return "Pending".
        /// You can assume that moves is valid(i.e., it follows the rules of Tic-Tac-Toe), the grid is initially empty, and A will play first.
        /// </summary>
        public _01275_FindWinnerOnATicTacToeGame()
        {
            Console.WriteLine(Tictactoe(
            [
                [0,0],
                [2,0],
                [1,1],
                [2,1],
                [2,2]
            ]));
            Console.WriteLine(Tictactoe(
            [
                [0,0],
                [1,1],
                [0,1],
                [0,2],
                [1,0],
                [2,0]
            ]));
        }

        private static string Tictactoe(int[][] moves)
        {
            if (moves.Length < 5) return "Pending";

            int[] row = new int[3], col = new int[3];
            int diag1 = 0, diag2 = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                int x = moves[i][0], y = moves[i][1];
                int inc = i % 2 == 0 ? 1 : -1;
                row[x] += inc;
                col[y] += inc;
                if (x == y) diag1 += inc;
                if (x + y == 2) diag2 += inc;

                if (Math.Abs(row[x]) == 3 || Math.Abs(col[y]) == 3 || Math.Abs(diag1) == 3 || Math.Abs(diag2) == 3) return i % 2 == 0 ? "A" : "B";
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }

        private static string Tictactoe0(int[][] moves)
        {
            if (moves.Length < 5) return "Pending";

            int[][] winCombinations =
            [
                [0,1,2], [3,4,5], [6,7,8],
                [0,4,8], [2,4,6],
                [0,3,6], [1,4,7], [2,5,8]
            ];

            int[] x = new int[9];
            int[] o = new int[9];
            bool xMove = true;

            foreach (int[] move in moves)
            {
                int index = move[0] + move[1] * 3;
                if (xMove) x[index] = 1;
                else o[index] = 1;
                xMove = !xMove;
            }

            foreach (int[] combination in winCombinations)
            {
                if (combination.All(i => x[i] == 1)) return "A";
                if (combination.All(i => o[i] == 1)) return "B";
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }
    }
}
