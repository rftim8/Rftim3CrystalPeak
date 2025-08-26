namespace Rftim3LeetCode.Temp
{
    public class _02187_MinimumTimeToCompleteTrips
    {
        /// <summary>
        /// You are given an array time where time[i] denotes the time taken by the ith bus to complete one trip.
        /// Each bus can make multiple trips successively; that is, the next trip can start immediately after completing the current trip.
        /// Also, each bus operates independently; that is, the trips of one bus do not influence the trips of any other bus.
        /// You are also given an integer totalTrips, which denotes the number of trips all buses should make in total.
        /// Return the minimum time required for all buses to complete at least totalTrips trips.
        /// </summary>
        public _02187_MinimumTimeToCompleteTrips()
        {
            Console.WriteLine(MinimumTime([1, 2, 3], 5));
        }

        // Binary Search
        private static long MinimumTime(int[] time, int totalTrips)
        {
            int n = time.Length;
            Array.Sort(time);
            if (time.Length == 1) return (long)time[0] * totalTrips;

            long l = time[0];
            long c = l * totalTrips;
            long r = c;

            while (l <= r)
            {
                long mid = l + (r - l + 1) / 2;
                long x = 0;
                for (int i = 0; i < n; i++)
                {
                    x += mid / time[i];
                }

                if (x >= totalTrips)
                {
                    c = Math.Min(c, mid);
                    r = mid - 1;
                }
                else l = mid + 1;
            }

            return c;
        }

        // Brute Force
        private static long MinimumTime0(int[] time, int totalTrips)
        {
            Array.Sort(time);
            int n = time.Length;
            long c = 0;
            int[] trips = new int[n];
            Array.Copy(time, trips, n);

            while (totalTrips > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    trips[i]--;
                    if (trips[i] == 0)
                    {
                        trips[i] = time[i];
                        totalTrips--;
                    }
                }
                c++;
            }

            return c;
        }
    }
}
