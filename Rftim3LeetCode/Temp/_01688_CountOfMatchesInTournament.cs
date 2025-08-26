namespace Rftim3LeetCode.Temp
{
    public class _01688_CountOfMatchesInTournament
    {
        /// <summary>
        /// You are given an integer n, the number of teams in a tournament that has strange rules:
        /// If the current number of teams is even, each team gets paired with another team.
        /// A total of n / 2 matches are played, and n / 2 teams advance to the next round.
        /// If the current number of teams is odd, one team randomly advances in the tournament, and the rest gets paired.
        /// A total of (n - 1) / 2 matches are played, and(n - 1) / 2 + 1 teams advance to the next round.
        /// Return the number of matches played in the tournament until a winner is decided.
        /// </summary>
        public _01688_CountOfMatchesInTournament()
        {
            Console.WriteLine(NumberOfMatches(7));
            Console.WriteLine(NumberOfMatches(14));
        }

        private static int NumberOfMatches(int n)
        {
            int c = 0;

            while (n > 1)
            {
                c += n / 2;
                if (n % 2 == 0) n /= 2;
                else n = n / 2 + 1;
            }

            return c;
        }
    }
}
