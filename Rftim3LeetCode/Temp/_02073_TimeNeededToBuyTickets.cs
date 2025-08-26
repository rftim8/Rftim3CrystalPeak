namespace Rftim3LeetCode.Temp
{
    public class _02073_TimeNeededToBuyTickets
    {
        /// <summary>
        /// There are n people in a line queuing to buy tickets, where the 0th person is at the front of the line and the (n - 1)th person is at the back of the line.
        /// You are given a 0-indexed integer array tickets of length n where the number of tickets that the ith person would like to buy is tickets[i].
        /// Each person takes exactly 1 second to buy a ticket.A person can only buy 1 ticket at a time and has to go back to the end of the line(which happens instantaneously) in order to buy more tickets.If a person does not have any tickets left to buy, the person will leave the line.
        /// Return the time taken for the person at position k (0-indexed) to finish buying tickets.
        /// </summary>
        public _02073_TimeNeededToBuyTickets()
        {
            Console.WriteLine(TimeRequiredToBuy([2, 3, 2], 2));
            Console.WriteLine(TimeRequiredToBuy([5, 1, 1, 1], 0));
            Console.WriteLine(TimeRequiredToBuy([84, 49, 5, 24, 70, 77, 87, 8], 3));
        }
        private static int TimeRequiredToBuy(int[] tickets, int k)
        {
            int n = tickets[k];
            int m = tickets.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (tickets[j] > 0)
                    {
                        tickets[j]--;
                        c++;
                        if (i == n - 1 && j == k) break;
                    }
                }
            }

            return c;
        }
    }
}
