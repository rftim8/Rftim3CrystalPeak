namespace Rftim3LeetCode.Temp
{
    public class _01437_CheckIfAllOnesAreAtLeastLengthKPlacesAway
    {
        /// <summary>
        /// Given an binary array nums and an integer k, return true if all 1's are at least k places away from each other, otherwise return false.
        /// </summary>
        public _01437_CheckIfAllOnesAreAtLeastLengthKPlacesAway()
        {
            Console.WriteLine(KLengthApart([1, 0, 0, 0, 1, 0, 0, 1], 2));
            Console.WriteLine(KLengthApart([1, 0, 0, 1, 0, 1], 2));
            Console.WriteLine(KLengthApart([1, 1, 1], 2));
            Console.WriteLine(KLengthApart([1, 1, 1, 0], 3));
            Console.WriteLine(KLengthApart([0, 1, 1, 1], 3));
            Console.WriteLine(KLengthApart([0, 0, 0], 2));
            Console.WriteLine(KLengthApart([1, 1, 1, 1, 1], 0));
        }

        private static bool KLengthApart(int[] nums, int k)
        {
            int count = k;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    if (count < k) return false;

                    count = 0;
                }
                else ++count;
            }

            return true;
        }
    }
}
