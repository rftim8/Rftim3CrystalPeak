namespace Rftim3LeetCode.Temp
{
    public class _00374_GuessNumberHigherOrLower
    {
        /// <summary>
        /// We are playing the Guess Game. The game is as follows:
        /// I pick a number from 1 to n.You have to guess which number I picked.
        /// Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.
        /// You call a pre-defined API int guess(int num), which returns three possible results:
        /// -1: Your guess is higher than the number I picked (i.e.num > pick).
        /// 1: Your guess is lower than the number I picked(i.e.num<pick).
        /// 0: your guess is equal to the number I picked(i.e.num == pick).
        /// Return the number that I picked.
        /// </summary>
        public _00374_GuessNumberHigherOrLower()
        {
            Console.WriteLine(GuessNumber0(10, 6));
            Console.WriteLine(GuessNumber0(1, 1));
            Console.WriteLine(GuessNumber0(2, 1));
        }

        public static int GuessNumber0(int a0, int a1) => RftGuessNumber0(a0, a1);

        private static int RftGuessNumber0(int n, int m)
        {
            int left = 0;
            int right = n;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (Guess(mid, m) == 0) return mid;
                else if (Guess(mid, m) == 1) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        private static int Guess(int n, int m)
        {
            if (n == m) return 0;
            else if (n > m) return -1;
            else return 1;
        }
    }
}
