using BenchmarkDotNet.Attributes;

namespace Rftim3Convoy.Data.Services.CP.LeetCode
{
    public class _02463_MinimumTotalDistanceTraveled
    {
        private readonly List<int> robot = [0, 4, 6];
        private readonly int[][] factory = [[2, 2], [6, 2]];

        private readonly List<int> robot0 = [1, -1];
        private readonly int[][] factory0 = [[-2, 1], [2, 1]];

        public _02463_MinimumTotalDistanceTraveled()
        {
            Console.WriteLine(_02463_MinimumTotalDistanceTraveled0(robot, factory));
            Console.WriteLine(_02463_MinimumTotalDistanceTraveled0(robot0, factory0));
        }

        // UnitTest
        public static long _02463_MinimumTotalDistanceTraveled0_Test(IList<int> robot, int[][] factory) => _02463_MinimumTotalDistanceTraveled0(robot, factory);

        // Benchmarking
        [Benchmark]
        public void _02463_MinimumTotalDistanceTraveled0_Benchmark() => _02463_MinimumTotalDistanceTraveled0(robot, factory);

        private static long _02463_MinimumTotalDistanceTraveled0(IList<int> robot, int[][] factory)
        {
            List<int> robot0 = [.. robot];
            robot0.Sort();
            Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));
            List<int> factoryPositions = [];

            foreach (int[] item in factory)
                for (int i = 0; i < item[1]; i++)
                    factoryPositions.Add(item[0]);

            int robotCount = robot0.Count, factoryCount = factoryPositions.Count;

            List<List<long>> dp = [];

            for (int i = 0; i < robotCount + 1; i++)
            {
                List<long> l = new(Enumerable.Repeat<long>(0, factoryCount + 1));
                dp.Add(l);
            }

            for (int i = 0; i < robotCount; i++)
                dp[i][factoryCount] = (long)1e12;

            for (int i = robotCount - 1; i >= 0; i--)
            {
                for (int j = factoryCount - 1; j >= 0; j--)
                {
                    long assign = Math.Abs(robot0[i] - factoryPositions[j]) + dp[i + 1][j + 1];
                    long skip = dp[i][j + 1];
                    dp[i][j] = Math.Min(assign, skip);
                }
            }

            return dp[0][0];
        }
    }
}
