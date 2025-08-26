namespace Rftim3LeetCode.Temp
{
    public class _00933_NumberOfRecentCalls
    {
        /// <summary>
        /// You have a RecentCounter class which counts the number of recent requests within a certain time frame.
        /// Implement the RecentCounter class:
        /// RecentCounter() Initializes the counter with zero recent requests.
        /// int ping(int t) Adds a new request at time t, where t represents some time in milliseconds, 
        /// and returns the number of requests that has happened in the past 3000 milliseconds(including the new request). 
        /// Specifically, return the number of requests that have happened in the inclusive range[t - 3000, t].
        /// It is guaranteed that every call to ping uses a strictly larger value of t than the previous call.
        /// </summary>
        public _00933_NumberOfRecentCalls()
        {
            RecentCounter obj = new();
            int param_1 = obj.Ping(1);
            Console.WriteLine(param_1);
            int param_2 = obj.Ping(100);
            Console.WriteLine(param_2);
            int param_3 = obj.Ping(3001);
            Console.WriteLine(param_3);
            int param_4 = obj.Ping(3002);
            Console.WriteLine(param_4);
        }

        private class RecentCounter
        {
            private readonly LinkedList<int> slideWindow;

            public RecentCounter()
            {
                slideWindow = new();
            }

            public int Ping(int t)
            {
                slideWindow.AddLast(t);

                while (slideWindow.First() < t - 3000)
                {
                    slideWindow.RemoveFirst();
                }

                return slideWindow.Count;
            }
        }
    }
}
