namespace Rftim3LeetCode.Temp
{
    public class _00914_XOfAKindInADeckOfCards
    {
        /// <summary>
        /// You are given an integer array deck where deck[i] represents the number written on the ith card.
        /// Partition the cards into one or more groups such that:
        /// Each group has exactly x cards where x > 1, and
        /// All the cards in one group have the same integer written on them.
        /// Return true if such partition is possible, or false otherwise.
        /// </summary>
        public _00914_XOfAKindInADeckOfCards()
        {
            Console.WriteLine(HasGroupsSizeX([1, 2, 3, 4, 4, 3, 2, 1]));
            Console.WriteLine(HasGroupsSizeX([1, 1, 1, 2, 2, 2, 3, 3]));
            Console.WriteLine(HasGroupsSizeX([1, 1, 2, 2, 2, 2]));
            Console.WriteLine(HasGroupsSizeX([1, 1, 1, 1, 2, 2, 2, 2, 2, 2]));
            Console.WriteLine(HasGroupsSizeX([0, 0, 0, 0, 1, 1, 2, 2, 3, 3]));
            Console.WriteLine(HasGroupsSizeX([1, 1]));
        }

        private static bool HasGroupsSizeX0(int[] deck)
        {
            int[] count = new int[10000];
            foreach (int c in deck) count[c]++;

            int g = -1;
            for (int i = 0; i < 10000; ++i)
            {
                if (count[i] > 0)
                {
                    if (g == -1) g = count[i];
                    else g = GCD(g, count[i]);
                }
            }

            return g >= 2;
        }

        private static int GCD(int x, int y)
        {
            return x == 0 ? y : GCD(y % x, x);
        }

        private static bool HasGroupsSizeX(int[] deck)
        {
            if (deck.Length == 1) return false;

            var x = deck.GroupBy(o => o).Select(o => new { o.Key, Value = o.Count() });
            int t = -1;

            foreach (var item in x)
            {
                if (item.Value < 1) return false;
                if (t == -1) t = item.Value;
                else t = GCD(t, item.Value);
            }

            return t >= 2;
        }

        private static int GCF(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int LCM(int a, int b)
        {
            return a / GCF(a, b) * b;
        }
    }
}
