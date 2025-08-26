namespace Rftim3LeetCode.Temp
{
    public class _00007_ReverseInteger
    {
        /// <summary>
        /// Given a signed 32-bit integer x, return x with its digits reversed.
        /// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
        /// Assume the environment does not allow you to store 64-bit integers(signed or unsigned).
        /// </summary>
        public _00007_ReverseInteger()
        {
            Console.WriteLine(ReverseInteger0(123));
            Console.WriteLine(ReverseInteger0(-123));
            Console.WriteLine(ReverseInteger0(120));
        }

        public static int ReverseInteger0(int a0) => RftReverseInteger0(a0);

        private static int RftReverseInteger0(int x)
        {
            bool n = x < 0;
            if (n) x *= -1;

            string r = "";
            while (x > 0)
            {
                r += x % 10;
                x /= 10;
            }

            if (int.TryParse(r, out int y)) return n ? -y : y;
            else return 0;
        }
    }
}
