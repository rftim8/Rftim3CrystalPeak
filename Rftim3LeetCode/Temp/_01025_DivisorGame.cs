namespace Rftim3LeetCode.Temp
{
    public class _01025_DivisorGame
    {
        /// <summary>
        /// Alice and Bob take turns playing a game, with Alice starting first.
        /// Initially, there is a number n on the chalkboard.On each player's turn, that player makes a move consisting of:
        /// Choosing any x with 0 < x<n and n % x == 0.
        /// Replacing the number n on the chalkboard with n - x.
        /// Also, if a player cannot make a move, they lose the game.
        /// Return true if and only if Alice wins the game, assuming both players play optimally.
        public _01025_DivisorGame()
        {
            Console.WriteLine(DivisorGame(2));
            Console.WriteLine(DivisorGame(3));
        }

        private static bool DivisorGame(int n)
        {
            return n % 2 == 0;
        }
    }
}
