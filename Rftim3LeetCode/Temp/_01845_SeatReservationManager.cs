using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01845_SeatReservationManager
    {
        /// <summary>
        /// Design a system that manages the reservation state of n seats that are numbered from 1 to n.
        /// 
        /// Implement the SeatManager class:
        /// 
        /// SeatManager(int n) Initializes a SeatManager object that will manage n seats numbered from 1 to n.
        /// All seats are initially available.
        /// int reserve() Fetches the smallest-numbered unreserved seat, reserves it, and returns its number.
        /// void unreserve(int seatNumber) Unreserves the seat with the given seatNumber.
        /// </summary>
        public _01845_SeatReservationManager()
        {
            List<int> x = SeatReservationManager0(
                ["SeatManager", "reserve", "reserve", "unreserve", "reserve", "reserve", "reserve", "reserve", "unreserve"],
                [5, -1, -1, 2, -1, -1, -1, -1, 5]
                );
            RftTerminal.RftReadResult(x);
        }

        public static List<int> SeatReservationManager0(List<string> a0, List<int> a1) => RftSeatReservationManager0(a0, a1);

        public static List<int> SeatReservationManager1(List<string> a0, List<int> a1) => RftSeatReservationManager1(a0, a1);

        private static List<int> RftSeatReservationManager0(List<string> x, List<int> y)
        {
            List<int> r = [];
            SeatManager0 obj = new(y[0]);

            for (int i = 1; i < y.Count; i++)
            {
                if (x[i] == "reserve") r.Add(obj.Reserve());
                else obj.Unreserve(y[i]);
            }

            return r;
        }

        private static List<int> RftSeatReservationManager1(List<string> x, List<int> y)
        {
            List<int> r = [];
            SeatManager1 obj = new(y[0]);

            for (int i = 1; i < y.Count; i++)
            {
                if (x[i] == "reserve") r.Add(obj.Reserve());
                else obj.Unreserve(y[i]);
            }

            return r;
        }

        private class SeatManager0
        {
            private readonly SortedList<int, int> x = [];
            int c = 0;

            public SeatManager0(int _)
            {
                x.Add(0, 0);
                c++;
            }

            public int Reserve()
            {
                x.Add(c, c);
                c++;
                int min = x.First().Value;
                x.Remove(min);

                return min + 1;
            }

            public void Unreserve(int seatNumber)
            {
                x.Add(seatNumber - 1, seatNumber - 1);
            }
        }

        private class SeatManager1
        {
            private readonly PriorityQueue<int, int> pq = new();

            public SeatManager1(int _) => pq.Enqueue(1, 1);

            public int Reserve()
            {
                int reserved = pq.Dequeue();
                if (pq.Count == 0) pq.Enqueue(reserved + 1, reserved + 1);

                return reserved;
            }

            public void Unreserve(int seatNumber) => pq.Enqueue(seatNumber, seatNumber);
        }
    }
}
