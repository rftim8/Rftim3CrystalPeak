namespace Rftim3LeetCode.Temp
{
    public class _02558_TakeGiftsFromTheRichestPile
    {
        /// <summary>
        /// You are given an integer array gifts denoting the number of gifts in various piles. 
        /// Every second, you do the following:
        /// Choose the pile with the maximum number of gifts.
        /// If there is more than one pile with the maximum number of gifts, choose any.
        /// Leave behind the floor of the square root of the number of gifts in the pile.
        /// Take the rest of the gifts.
        /// Return the number of gifts remaining after k seconds.
        /// </summary>
        public _02558_TakeGiftsFromTheRichestPile()
        {
            Console.WriteLine(PickGifts([25, 64, 9, 4, 100], 4));
            Console.WriteLine(PickGifts([1, 1, 1, 1], 4));
        }

        private static long PickGifts(int[] gifts, int k)
        {
            for (int i = 0; i < k; i++)
            {
                Array.Sort(gifts);
                gifts[^1] = (int)Math.Floor(Math.Sqrt(gifts[^1]));
            }

            return gifts.Sum(o => (long)o);
        }
    }
}
