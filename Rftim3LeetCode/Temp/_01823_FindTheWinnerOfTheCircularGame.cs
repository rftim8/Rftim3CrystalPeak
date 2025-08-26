namespace Rftim3LeetCode.Temp
{
    public class _01823_FindTheWinnerOfTheCircularGame
    {
        /// <summary>
        /// There are n friends that are playing a game. The friends are sitting in a circle and are numbered from 1 to n in clockwise order. 
        /// More formally, moving clockwise from the ith friend brings you to the (i+1)th friend for 1 <= i < n, and moving clockwise from the 
        /// nth friend brings you to the 1st friend.
        /// The rules of the game are as follows:
        /// Start at the 1st friend.
        /// Count the next k friends in the clockwise direction including the friend you started at.The counting wraps around the circle and may count some friends more than once.
        /// The last friend you counted leaves the circle and loses the game.
        /// If there is still more than one friend in the circle, go back to step 2 starting from the friend immediately clockwise of the friend who just lost and repeat.
        /// Else, the last friend in the circle wins the game.
        /// Given the number of friends, n, and an integer k, return the winner of the game.
        /// </summary>
        public _01823_FindTheWinnerOfTheCircularGame()
        {
            Console.WriteLine(FindTheWinner(5, 2));
            Console.WriteLine();
            Console.WriteLine(FindTheWinner(6, 5));
        }

        private static int FindTheWinner(int n, int k)
        {
            List<int> x = Enumerable.Range(1, n).ToList();

            int index = 0;
            while (x.Count > 1)
            {
                index = (index + k - 1) % x.Count;
                Console.WriteLine(x[index]);
                x.RemoveAt(index);
            }

            return x[0];
        }

        private static int FindTheWinner0(int n, int k)
        {
            return Circle(n, k) + 1;
        }

        private static int Circle(int n, int k)
        {
            int result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = (result + k) % i;
            }

            return result;
        }
    }
}
