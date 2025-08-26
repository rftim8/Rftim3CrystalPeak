namespace Rftim3Convoy.Temp.Construct.Games.TicTacToe
{
    public class RftMainTicTacToe
    {
        // Constants
        private static byte rftPlayerCurrent = 1;
        private static byte rftRound = 0;
        private static sbyte rftPlayerWin = 0;

        // Variables
        private static byte[,]? rftBoard;

        /// <summary>
        /// TicTacToe
        /// <para>A game where players have to mark a straight line horizontaly, verticaly or diagonaly</para>
        /// </summary>
        public RftMainTicTacToe()
        {
            RftPlayGame(3, 2);
        }

        private static void RftPlayGame(byte rftBoardSize, byte rftPlayersCount)
        {
            #region Load
            RftLoadBoard(rftBoardSize);
            RftLoadPlayers();
            #endregion

            #region Play
            RftGameStart(rftBoardSize, rftPlayersCount);
            RftGameEnd();
            #endregion
        }

        #region Load
        private static void RftLoadBoard(byte rftBoardSize)
        {
            rftBoard = new byte[rftBoardSize, rftBoardSize];
        }

        private static void RftLoadPlayers()
        {
            Console.WriteLine($"Player: {rftPlayerCurrent} input!");
        }
        #endregion

        #region Play
        private static void RftGameStart(byte rftBoardSize, byte rftPlayersCount)
        {
            RftBoardView(rftBoardSize);

            while (rftPlayerWin == 0)
            {
                // Input row
                Console.Write($"row = ");
                byte row = rftBoardSize;
                while (row == rftBoardSize) row = RftCheckInput(rftBoardSize, Console.ReadLine());

                // Input column
                Console.Write($"column = ");
                byte column = rftBoardSize;
                while (column == rftBoardSize) column = RftCheckInput(rftBoardSize, Console.ReadLine());

                // Check valid mark
                if (rftBoard![row, column] == 0)
                {
                    rftBoard[row, column] = rftPlayerCurrent;
                    rftPlayerCurrent++;
                    rftRound++;
                    if (rftPlayerCurrent > rftPlayersCount) rftPlayerCurrent = 1;
                }
                else Console.WriteLine($"Error: row: {row} -> column: {column} is taken!");

                Console.Clear();

                // Check game status
                rftPlayerWin = RftCheckStatus(rftBoardSize);
                if (rftRound == rftBoardSize * rftBoardSize && rftPlayerWin == 0) rftPlayerWin = -1;

                // Redraw board
                if (rftPlayerWin == 0) Console.WriteLine($"Player: {rftPlayerCurrent} input!");
                RftBoardView(rftBoardSize);
            }
        }

        private static void RftBoardView(byte rftBoardSize)
        {
            RftPrint(rftBoard!, rftBoardSize);
        }

        private static void RftGameEnd()
        {
            Console.WriteLine(rftPlayerWin == -1 ? "DRAW!" : $"Player: {rftPlayerWin} won!");
        }

        /// <summary>
        /// Checking if there's a winner:
        /// <br>0 - no winner, game continues</br>
        /// <br>1,2 - winner</br>
        /// </summary>
        /// <returns>Winner</returns>
        private static sbyte RftCheckStatus(byte rftBoardSize)
        {
            for (sbyte i = 1; i < rftBoardSize; i++)
            {
                byte diag0 = 0, diag1 = 0;
                for (byte j = 0; j < rftBoardSize; j++)
                {
                    // Check diagonals
                    if (rftBoard![j, j] == i) diag0++;
                    if (rftBoard[rftBoardSize - 1 - j, j] == i) diag1++;

                    byte horiz = 0, vert = 0;
                    for (byte k = 0; k < rftBoardSize; k++)
                    {
                        // Check horizontal and vertical
                        if (rftBoard[j, k] == i) horiz++;
                        if (rftBoard[k, j] == i) vert++;
                    }

                    if (horiz == rftBoardSize ||
                        vert == rftBoardSize ||
                        diag0 == rftBoardSize ||
                        diag1 == rftBoardSize)
                    {
                        return i;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Check if input is a valid coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static byte RftCheckInput(byte rftBoardSize, string? coordinate)
        {
            if (byte.TryParse(coordinate, out byte result))
            {
                if (result >= 0 && result < rftBoardSize) return result;
                else return rftBoardSize;
            }
            else return rftBoardSize;
        }
        #endregion

        #region Random player turn
        /// <summary>
        /// Check if player is valid
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private static void RftInputPlayer(byte row, byte column)
        {
            ConsoleKeyInfo key = new();
            Console.Write($"Enter player: ");
            while (key.Key is not ConsoleKey.D1 and not ConsoleKey.D2)
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        rftBoard![row, column] = 1;
                        break;
                    case ConsoleKey.D2:
                        rftBoard![row, column] = 2;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        public static void RftPrint(byte[,] array, byte size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{array![i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
