namespace Rftim3LeetCode.Temp
{
    public class _02147_NumberOfWaysToDivideALongCorridor
    {
        /// <summary>
        /// Along a long library corridor, there is a line of seats and decorative plants. 
        /// You are given a 0-indexed string corridor of length n consisting of letters 'S' and 'P' where each 'S' represents a seat and each 'P' represents a plant.
        /// 
        /// One room divider has already been installed to the left of index 0, and another to the right of index n - 1. 
        /// Additional room dividers can be installed.For each position between indices i - 1 and i (1 <= i <= n - 1), at most one divider can be installed.
        /// Divide the corridor into non-overlapping sections, where each section has exactly two seats with any number of plants.
        /// There may be multiple ways to perform the division.
        /// Two ways are different if there is a position with a room divider installed in the first way but not in the second way.
        /// Return the number of ways to divide the corridor.
        /// Since the answer may be very large, return it modulo 109 + 7. If there is no way, return 0.
        /// </summary>
        public _02147_NumberOfWaysToDivideALongCorridor()
        {
            Console.WriteLine(NumberOfWays0("SSPPSPS"));
            Console.WriteLine(NumberOfWays0("PPSPSP"));
            Console.WriteLine(NumberOfWays0("S"));
        }

        private static readonly int MOD = 1_000_000_007;

        private static int Count(int index, int seats, string corridor, Dictionary<(int, int), int> cache)
        {
            if (index == corridor.Length) return seats == 2 ? 1 : 0;

            if (cache.ContainsKey((index, seats))) return cache[(index, seats)];

            int result;
            if (seats == 2)
            {
                if (corridor[index] == 'S') result = Count(index + 1, 1, corridor, cache);
                else result = (Count(index + 1, 0, corridor, cache) + Count(index + 1, 2, corridor, cache)) % MOD;
            }
            else
            {
                if (corridor[index] == 'S') result = Count(index + 1, seats + 1, corridor, cache);
                else result = Count(index + 1, seats, corridor, cache);
            }

            cache.Add((index, seats), result);

            return result;
        }

        // Top-Down DP
        public static int NumberOfWays0(string a0) => RftNumberOfWays0(a0);

        public static int NumberOfWays1(string a0) => RftNumberOfWays1(a0);

        public static int NumberOfWays2(string a0) => RftNumberOfWays2(a0);

        public static int NumberOfWays3(string a0) => RftNumberOfWays3(a0);

        public static int NumberOfWays4(string a0) => RftNumberOfWays4(a0);

        private static int RftNumberOfWays0(string corridor)
        {
            Dictionary<(int, int), int> cache = [];

            return Count(0, 0, corridor, cache);
        }

        // Bottom-Up DP
        private static int RftNumberOfWays1(string corridor)
        {
            int[][] count = new int[corridor.Length + 1][];
            for (int i = 0; i < corridor.Length + 1; i++)
            {
                count[i] = new int[3];
            }

            count[corridor.Length][0] = 0;
            count[corridor.Length][1] = 0;
            count[corridor.Length][2] = 1;

            for (int index = corridor.Length - 1; index >= 0; index--)
            {
                if (corridor[index] == 'S')
                {
                    count[index][0] = count[index + 1][1];
                    count[index][1] = count[index + 1][2];
                    count[index][2] = count[index + 1][1];
                }
                else
                {
                    count[index][0] = count[index + 1][0];
                    count[index][1] = count[index + 1][1];
                    count[index][2] = (count[index + 1][0] + count[index + 1][2]) % MOD;
                }
            }

            return count[0][0];
        }

        // Bottom-Up DP Space-Optimized
        private static int RftNumberOfWays2(string corridor)
        {
            int zero = 0;
            int one = 0;
            int two = 1;

            foreach (char thing in corridor.ToCharArray())
            {
                if (thing == 'S')
                {
                    zero = one;
                    (two, one) = (one, two);
                }
                else two = (two + zero) % MOD;
            }

            return zero;
        }

        // Combinatorics
        private static int RftNumberOfWays3(string corridor)
        {
            List<int> indices = [];
            for (int index = 0; index < corridor.Length; index++)
            {
                if (corridor[index] == 'S') indices.Add(index);
            }

            if (indices.Count == 0 || indices.Count % 2 == 1) return 0;

            long count = 1;

            int previousPairLast = 1;
            int currentPairFirst = 2;
            while (currentPairFirst < indices.Count)
            {
                count *= indices[currentPairFirst] - indices[previousPairLast];
                count %= MOD;
                previousPairLast += 2;
                currentPairFirst += 2;
            }

            return (int)count;
        }

        // Combinatorics Space Optimized
        private static int RftNumberOfWays4(string corridor)
        {
            long count = 1;
            int seats = 0;

            int previousPairLast = -1;

            for (int index = 0; index < corridor.Length; index++)
            {
                if (corridor[index] == 'S')
                {
                    seats += 1;

                    if (seats == 2)
                    {
                        previousPairLast = index;
                        seats = 0;
                    }

                    else if (seats == 1 && previousPairLast != -1)
                    {
                        count *= index - previousPairLast;
                        count %= MOD;
                    }
                }
            }

            if (seats == 1 || previousPairLast == -1) return 0;

            return (int)count;
        }
    }
}
