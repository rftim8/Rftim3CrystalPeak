namespace Rftim3LeetCode.Temp
{
    public class _00134_GasStation
    {
        /// <summary>
        /// There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].
        /// You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next(i + 1)th station.
        /// You begin the journey with an empty tank at one of the gas stations.
        /// Given two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1. 
        /// If there exists a solution, it is guaranteed to be unique
        /// </summary>
        public _00134_GasStation()
        {
            Console.WriteLine(CanCompleteCircuit([1, 2, 3, 4, 5], [3, 4, 5, 1, 2]));
            Console.WriteLine(CanCompleteCircuit([2, 3, 4], [3, 4, 3]));
        }

        private static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int n = gas.Length;
            int x = 0, l = 0, r = 0, s = 0;
            for (int i = 0; i < n; i++)
            {
                l += gas[i];
                r += cost[i];
            }
            for (int i = 0; i < n; i++)
            {
                s += gas[i] - cost[i];
                if (s < 0)
                {
                    x = i + 1;
                    s = 0;
                }
            }
            if (l < r) return -1;

            return x;
        }
    }
}
