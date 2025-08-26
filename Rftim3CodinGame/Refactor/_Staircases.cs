using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.CodinGame.Data;
using Rftim3Convoy.Services.Static.CP.CodinGame.Data;

namespace Rftim3CodinGame.Refactor
{
    public class _Staircases : I_Staircases
    {
        #region Static
        private readonly List<string>? data;

        public _Staircases()
        {
            data = RftCodinGameStaticData.Input_Test(testType: false, problemName: nameof(_Staircases));
        }

        /// <summary>
        ///
        /// </summary>
        [Benchmark]
        public List<string> Solution() => Solution_0(data!);

        private static List<string> Solution_0(List<string> input)
        {
            List<string> result = [];
            foreach (string item in input)
            {
                int n = int.Parse(item);
                long partitions = StrictPartition.GetStrictPartitions(n) - 1;
                result.Add(partitions.ToString());
            }

            return result;
        }
        #endregion

        #region UnitTest
        public static List<string> Solution_Test(List<string> data) => Solution_0(data);
        #endregion

        #region Host
        private readonly IRftCodinGameHostData? RftCodinGameHostData;

        public _Staircases(IHost host)
        {
            RftCodinGameHostData = host.Services.GetRequiredService<IRftCodinGameHostData>();
            data = RftCodinGameHostData.Input_Test(problemName: nameof(_Staircases));
        }

        public void PrintSolution()
        {
            List<string> l = Solution();
            foreach (string item in l)
            {
                Console.WriteLine($"{item} ");
            }
        }
        #endregion
    }

    public static class StrictPartition
    {
        private static readonly Dictionary<(int, int), long> memo = [];

        public static long GetStrictPartitions(int n)
        {
            return GetPartitions(n, n);
        }

        private static long GetPartitions(int n, int max)
        {
            if (n == 0)
                return 1;

            if (memo.ContainsKey((n, max)))
                return memo[(n, max)];

            long count = 0;
            for (int i = Math.Min(max, n); i >= 1; i--)
            {
                count += GetPartitions(n - i, i - 1);
            }

            memo[(n, max)] = count;
            return count;
        }
    }
}