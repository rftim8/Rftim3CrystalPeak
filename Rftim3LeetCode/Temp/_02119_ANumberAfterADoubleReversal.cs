namespace Rftim3LeetCode.Temp
{
    public class _02119_ANumberAfterADoubleReversal
    {
        /// <summary>
        /// Reversing an integer means to reverse all its digits.
        /// For example, reversing 2021 gives 1202. Reversing 12300 gives 321 as the leading zeros are not retained.
        /// Given an integer num, reverse num to get reversed1, then reverse reversed1 to get reversed2. 
        /// Return true if reversed2 equals num.Otherwise return false.
        /// </summary>
        public _02119_ANumberAfterADoubleReversal()
        {
            Console.WriteLine(ANumberAfterADoubleReversal0(526));
            Console.WriteLine(ANumberAfterADoubleReversal0(1000));
            Console.WriteLine(ANumberAfterADoubleReversal0(0));
        }

        public static bool ANumberAfterADoubleReversal0(int a0) => RftANumberAfterADoubleReversal0(a0);

        private static bool RftANumberAfterADoubleReversal0(int num)
        {
            if (num == 0) return true;

            string r = "";
            int t = num;

            while (t > 0)
            {
                r += t % 10;
                t /= 10;
            }

            int x = int.Parse(r);
            r = "";

            while (x > 0)
            {
                r += x % 10;
                x /= 10;
            }

            return int.Parse(r) == num;
        }
    }
}