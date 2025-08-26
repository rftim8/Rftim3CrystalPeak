namespace Rftim3LeetCode.Temp
{
    public class _02413_SmallestEvenMultiple
    {
        /// <summary>
        /// Given a positive integer n, return the smallest positive integer that is a multiple of both 2 and n.
        /// </summary>
        public _02413_SmallestEvenMultiple()
        {
            Console.WriteLine(SmallestEvenMultiple(5));
            Console.WriteLine(SmallestEvenMultiple(6));
        }

        private static int SmallestEvenMultiple(int n)
        {
            int i = n;
            while (i % n != 0 || i % 2 != 0)
            {
                i++;
            }

            return i;
        }
    }
}
