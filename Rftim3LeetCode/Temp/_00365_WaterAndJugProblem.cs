namespace Rftim3LeetCode.Temp
{
    public class _00365_WaterAndJugProblem
    {
        /// <summary>
        /// You are given two jugs with capacities jug1Capacity and jug2Capacity liters. There is an infinite amount of water supply available. 
        /// Determine whether it is possible to measure exactly targetCapacity liters using these two jugs.
        /// If targetCapacity liters of water are measurable, you must have targetCapacity liters of water contained within one or both buckets by the end.
        /// Operations allowed:
        /// Fill any of the jugs with water.
        /// Empty any of the jugs.
        /// Pour water from one jug into another till the other jug is completely full, or the first jug itself is empty.
        /// </summary>
        public _00365_WaterAndJugProblem()
        {
            Console.WriteLine(WaterAndJugProblem0(3, 5, 4));
            Console.WriteLine(WaterAndJugProblem0(2, 6, 5));
            Console.WriteLine(WaterAndJugProblem0(1, 2, 3));
        }

        public static bool WaterAndJugProblem0(int a0, int a1, int a2) => RftWaterAndJugProblem0(a0, a1, a2);

        private static bool RftWaterAndJugProblem0(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (targetCapacity == 0) return true;
            if (targetCapacity > jug1Capacity + jug2Capacity) return false;

            int gcd = GCD(jug1Capacity, jug2Capacity);

            if (targetCapacity % gcd == 0) return true;

            return false;
        }

        private static int GCD(int x, int y)
        {
            if (y == 0) return x;

            return GCD(y, x % y);
        }
    }
}