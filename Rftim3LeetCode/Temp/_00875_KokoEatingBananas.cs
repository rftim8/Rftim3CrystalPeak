namespace Rftim3LeetCode.Temp
{
    public class _00875_KokoEatingBananas
    {
        /// <summary>
        /// Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
        /// Koko can decide her bananas-per-hour eating speed of k.Each hour, she chooses some pile of bananas and eats k bananas from that pile.
        /// If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
        /// Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
        /// Return the minimum integer k such that she can eat all the bananas within h hours.
        /// </summary>
        public _00875_KokoEatingBananas()
        {
            Console.WriteLine(MinEatingSpeed([3, 6, 7, 11], 8));
            Console.WriteLine(MinEatingSpeed([30, 11, 23, 4, 20], 5));
            Console.WriteLine(MinEatingSpeed([30, 11, 23, 4, 20], 6));
            Console.WriteLine(MinEatingSpeed([312884470], 312884469));
            Console.WriteLine(MinEatingSpeed([1000000000], 2));
        }

        private static int MinEatingSpeed(int[] piles, int h)
        {
            int n = piles.Length;
            Array.Sort(piles);

            int l = 1;
            int r = piles[^1];

            while (l < r)
            {
                int mid = l + (r - l) / 2;
                int x = 0;

                for (int i = 0; i < n; i++)
                {
                    int pi = piles[i];
                    x += pi / mid + (pi % mid > 0 ? 1 : 0);
                }

                if (x > h) l = mid + 1;
                else r = mid;
            }

            return l;
        }
    }
}
