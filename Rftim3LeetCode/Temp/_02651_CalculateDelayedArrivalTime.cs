namespace Rftim3LeetCode.Temp
{
    public class _02651_CalculateDelayedArrivalTime
    {
        /// <summary>
        /// You are given a positive integer arrivalTime denoting the arrival time of a train in hours, and another positive integer delayedTime denoting the amount of delay in hours.
        /// Return the time when the train will arrive at the station.
        /// Note that the time in this problem is in 24-hours format.
        /// </summary>
        public _02651_CalculateDelayedArrivalTime()
        {
            Console.WriteLine(FindDelayedArrivalTime(15, 5));
            Console.WriteLine(FindDelayedArrivalTime(13, 11));
            Console.WriteLine(FindDelayedArrivalTime(13, 15));
        }

        private static int FindDelayedArrivalTime(int arrivalTime, int delayedTime)
        {
            int n = arrivalTime + delayedTime;
            if (n > 23)
            {
                if (n == 24) return 0;
                else return n - 24;
            }
            else return n;
        }
    }
}
