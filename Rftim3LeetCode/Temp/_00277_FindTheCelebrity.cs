namespace Rftim3LeetCode.Temp
{
    public class _00277_FindTheCelebrity
    {
        public _00277_FindTheCelebrity()
        {
            int[][] x = [[1, 1, 0], [0, 1, 0], [1, 1, 1]];
            Console.WriteLine(FindCelebrity1(x));

            int[][] x0 = [[1, 0, 1], [1, 1, 0], [0, 1, 1]];
            Console.WriteLine(FindCelebrity1(x0));
        }

        public static int FindCelebrity0(int a0) => RftFindCelebrity0(a0);

        public static int FindCelebrity1(int[][] a0) => RftFindCelebrity1(a0);

        private static int RftFindCelebrity1(int[][] a0)
        {
            int n = a0.Length;
            Dictionary<int, int> kvp = [];

            for (int i = 0; i < n; i++)
            {
                kvp[i] = 0;
                kvp[i] += a0[0][i];
                kvp[i] += a0[1][i];
                kvp[i] += a0[2][i];
            }

            int max = kvp.MaxBy(o => o.Value).Value;

            if (kvp.Count(o => o.Value == max) > 1) return -1;

            return kvp.MaxBy(o => o.Value).Key;
        }

        private static int numberOfPeople;

        private static int RftFindCelebrity0(int n)
        {
            numberOfPeople = n;
            for (int i = 0; i < n; i++)
            {
                if (IsCelebrity(i)) return i;
            }

            return -1;
        }

        private static bool IsCelebrity(int i)
        {
            for (int j = 0; j < numberOfPeople; j++)
            {
                if (i == j) continue;
                if (Knows(i, j) || !Knows(j, i)) return false;
            }

            return true;
        }

        private static bool Knows(int a, int b)
        {
            return a == 1 && b == 1;
        }
    }
}
