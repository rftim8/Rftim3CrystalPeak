namespace Rftim3LeetCode.Temp
{
    public class _01812_DetermineColorOfAChessboardSquare
    {
        /// <summary>
        /// You are given coordinates, a string that represents the coordinates of a square of the chessboard. 
        /// Below is a chessboard for your reference.
        /// Return true if the square is white, and false if the square is black.
        /// The coordinate will always represent a valid chessboard square.
        /// The coordinate will always have the letter first, and the number second.
        /// </summary>
        public _01812_DetermineColorOfAChessboardSquare()
        {
            Console.WriteLine(SquareIsWhite("a1"));
            Console.WriteLine(SquareIsWhite("h3"));
            Console.WriteLine(SquareIsWhite("c7"));
        }

        private static bool SquareIsWhite0(string coordinates)
        {
            if (coordinates[0] % 2 == 0 && coordinates[1] % 2 == 0) return false;
            else if (coordinates[0] % 2 == 0 && coordinates[1] % 2 != 0) return true;
            else if (coordinates[0] % 2 != 0 && coordinates[1] % 2 != 0) return false;
            else return true;
        }

        private static bool SquareIsWhite(string coordinates)
        {
            return coordinates[0] % 2 == 0 ^ coordinates[1] % 2 == 0;
        }
    }
}
