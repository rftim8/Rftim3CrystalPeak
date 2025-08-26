namespace Rftim3LeetCode.Temp
{
    public class _01396_DesignUndergroundSystem
    {
        /// <summary>
        /// An underground railway system is keeping track of customer travel times between different stations.
        /// They are using this data to calculate the average time it takes to travel from one station to another.
        /// Implement the UndergroundSystem class:
        /// void checkIn(int id, string stationName, int t)
        /// A customer with a card ID equal to id, checks in at the station stationName at time t.
        /// A customer can only be checked into one place at a time.
        /// void checkOut(int id, string stationName, int t)
        /// A customer with a card ID equal to id, checks out from the station stationName at time t.
        /// double getAverageTime(string startStation, string endStation)
        /// Returns the average time it takes to travel from startStation to endStation.
        /// The average time is computed from all the previous traveling times from startStation to endStation that happened directly, 
        /// meaning a check in at startStation followed by a check out from endStation.
        /// The time it takes to travel from startStation to endStation may be different from the time it takes to travel from endStation to startStation.
        /// There will be at least one customer that has traveled from startStation to endStation before getAverageTime is called.
        /// You may assume all calls to the checkIn and checkOut methods are consistent.
        /// If a customer checks in at time t1 then checks out at time t2, then t1 < t2.
        /// All events happen in chronological order.
        /// </summary>
        public _01396_DesignUndergroundSystem()
        {
            UndergroundSystem obj = new();
            obj.CheckIn(45, "Leyton", 3);
            obj.CheckIn(32, "Paradise", 8);
            obj.CheckIn(27, "Leyton", 10);
            obj.CheckOut(45, "Waterloo", 15);  // Customer 45 "Leyton" -> "Waterloo" in 15-3 = 12
            obj.CheckOut(27, "Waterloo", 20);  // Customer 27 "Leyton" -> "Waterloo" in 20-10 = 10
            obj.CheckOut(32, "Cambridge", 22); // Customer 32 "Paradise" -> "Cambridge" in 22-8 = 14
            Console.WriteLine(obj.GetAverageTime("Paradise", "Cambridge")); // return 14.00000. One trip "Paradise" -> "Cambridge", (14) / 1 = 14
            Console.WriteLine(obj.GetAverageTime("Leyton", "Waterloo"));    // return 11.00000. Two trips "Leyton" -> "Waterloo", (10 + 12) / 2 = 11
            obj.CheckIn(10, "Leyton", 24);
            Console.WriteLine(obj.GetAverageTime("Leyton", "Waterloo"));    // return 11.00000
            obj.CheckOut(10, "Waterloo", 38);  // Customer 10 "Leyton" -> "Waterloo" in 38-24 = 14
            Console.WriteLine(obj.GetAverageTime("Leyton", "Waterloo"));    // return 12.00000. Three trips "Leyton" -> "Waterloo", (10 + 12 + 14) / 3 = 12
        }

        private class UndergroundSystem
        {
            private readonly Dictionary<int, (string stationName, int time)> kvp0;
            private readonly Dictionary<string, (int time, int cnt)> kvp1;

            public UndergroundSystem()
            {
                kvp0 = [];
                kvp1 = [];
            }

            public void CheckIn(int id, string stationName, int t)
            {
                kvp0[id] = (stationName, t);
            }

            public void CheckOut(int id, string stationName, int t)
            {
                (string stationName, int time) checkInInfo = kvp0[id];

                string route = checkInInfo.stationName + "->" + stationName;
                if (!kvp1.ContainsKey(route)) kvp1.Add(route, (0, 0));

                kvp1[route] = (kvp1[route].time + t - checkInInfo.time, kvp1[route].cnt + 1);
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                string route = startStation + "->" + endStation;

                if (!kvp1.TryGetValue(route, out (int time, int cnt) value)) return 0;
                else return value.time * 1.0 / value.cnt;
            }
        }
    }
}
