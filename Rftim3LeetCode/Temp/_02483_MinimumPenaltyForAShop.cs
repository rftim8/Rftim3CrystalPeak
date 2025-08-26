namespace Rftim3LeetCode.Temp
{
    public class _02483_MinimumPenaltyForAShop
    {
        /// <summary>
        /// You are given the customer visit log of a shop represented by a 0-indexed string customers consisting only of characters 'N' and 'Y':
        /// if the ith character is 'Y', it means that customers come at the ith hour
        /// whereas 'N' indicates that no customers come at the ith hour.
        /// If the shop closes at the jth hour(0 <= j <= n), the penalty is calculated as follows:
        /// For every hour when the shop is open and no customers come, the penalty increases by 1.
        /// For every hour when the shop is closed and customers come, the penalty increases by 1.
        /// Return the earliest hour at which the shop must be closed to incur a minimum penalty.
        /// Note that if a shop closes at the jth hour, it means the shop is closed at the hour j.
        /// </summary>
        public _02483_MinimumPenaltyForAShop()
        {
            Console.WriteLine(BestClosingTime("YYNY"));
            Console.WriteLine(BestClosingTime("NNNN"));
            Console.WriteLine(BestClosingTime("YYYY"));
        }

        private static int BestClosingTime(string customers)
        {
            int curPenalty = 0;
            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i] == 'Y') curPenalty++;
            }

            int minPenalty = curPenalty;
            int earliestHour = 0;

            for (int i = 0; i < customers.Length; i++)
            {
                char ch = customers[i];

                if (ch == 'Y') curPenalty--;
                else curPenalty++;

                if (curPenalty < minPenalty)
                {
                    earliestHour = i + 1;
                    minPenalty = curPenalty;
                }
            }

            return earliestHour;
        }

        private static int BestClosingTime0(string customers)
        {
            int penalty = 0;
            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i] == 'N') penalty++;
            }

            int min = penalty;
            int min_index = customers.Length;
            for (int i = customers.Length; i > 0; i--)
            {
                if (customers[i - 1] == 'Y') penalty++;
                else penalty--;
                if (min >= penalty)
                {
                    min = penalty;
                    min_index = i - 1;
                }
            }

            return min_index;
        }
    }
}
