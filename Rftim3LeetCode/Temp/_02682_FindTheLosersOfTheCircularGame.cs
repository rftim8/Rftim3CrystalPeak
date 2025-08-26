using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02682_FindTheLosersOfTheCircularGame
    {
        /// <summary>
        /// There are n friends that are playing a game. The friends are sitting in a circle and are numbered from 1 to n in clockwise order. 
        /// More formally, moving clockwise from the ith friend brings you to the (i+1)th friend for 1 <= i < n, and moving clockwise from the nth friend brings you to the 1st friend.
        /// The rules of the game are as follows:
        /// 1st friend receives the ball.
        /// After that, 1st friend passes it to the friend who is k steps away from them in the clockwise direction.
        /// After that, the friend who receives the ball should pass it to the friend who is 2 * k steps away from them in the clockwise direction.
        /// After that, the friend who receives the ball should pass it to the friend who is 3 * k steps away from them in the clockwise direction, and so on and so forth.
        /// In other words, on the ith turn, the friend holding the ball should pass it to the friend who is i* k steps away from them in the clockwise direction.
        /// The game is finished when some friend receives the ball for the second time.
        /// The losers of the game are friends who did not receive the ball in the entire game.
        /// Given the number of friends, n, and an integer k, return the array answer, which contains the losers of the game in the ascending order.
        /// </summary>
        public _02682_FindTheLosersOfTheCircularGame()
        {
            int[] x = CircularGameLosers(5, 2);
            RftTerminal.RftReadResult(x);
            int[] x0 = CircularGameLosers(4, 4);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] CircularGameLosers(int n, int k)
        {
            HashSet<int> winners = [];

            for (int index = 1, factor = 1;
                 winners.Add(index);
                 index = (index - 1 + k * factor++) % n + 1)
                ;

            return [.. Enumerable
               .Range(1, n)
               .Except(winners)
               .OrderBy(item => item)];
        }

        private static int[] CircularGameLosers0(int n, int k)
        {
            bool[] game = new bool[n];

            for (int i = 0, j = 0; !game[i]; i = (i + ++j * k) % n)
            {
                game[i] = true;
            }

            List<int> losers = [];
            for (int i = 0; i < game.Length; i++)
            {
                if (!game[i]) losers.Add(i + 1);
            }

            return [.. losers];
        }
    }
}
