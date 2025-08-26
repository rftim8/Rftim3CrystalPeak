namespace Rftim3LeetCode.Temp
{
    public class _00605_CanPlaceFlowers
    {
        /// <summary>
        /// You have a long flowerbed in which some of the plots are planted, and some are not.
        /// However, flowers cannot be planted in adjacent plots.
        /// Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n,
        /// return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.
        /// </summary>
        public _00605_CanPlaceFlowers()
        {
            Console.WriteLine(CanPlaceFlowers([1, 0, 0, 0, 1], 1));
            Console.WriteLine(CanPlaceFlowers([1, 0, 0, 0, 1], 2));
            Console.WriteLine(CanPlaceFlowers([1, 0, 1, 0, 1, 0, 1], 1));
        }

        private static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int m = flowerbed.Length;

            for (int i = 0; i < m; i++)
            {
                if (flowerbed[i] == 0)
                {
                    if (i == 0)
                    {
                        if (m == 1) return true;
                        else if (flowerbed[i + 1] == 0)
                        {
                            flowerbed[i] = 1;
                            n--;
                        }
                    }
                    else if (i == m - 1)
                    {
                        if (flowerbed[i - 1] == 0)
                        {
                            flowerbed[i] = 1;
                            n--;
                        }
                    }
                    else
                    {
                        if (flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0)
                        {
                            flowerbed[i] = 1;
                            n--;
                        }
                    }
                }
            }

            return n <= 0;
        }

        public static bool CanPlaceFlowers0(int[] flowerbed, int n)
        {
            int numberOfPlaceableBeds = 0;

            for (int i = 0; i < flowerbed.Length; i++)
            {
                if ((i == 0 || flowerbed[i - 1] == 0) && flowerbed[i] == 0 && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    numberOfPlaceableBeds++;
                }
            }

            return numberOfPlaceableBeds >= n;
        }
    }
}
