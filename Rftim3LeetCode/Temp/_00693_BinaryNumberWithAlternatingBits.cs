namespace Rftim3LeetCode.Temp
{
    public class _00693_BinaryNumberWithAlternatingBits
    {
        /// <summary>
        /// Given a positive integer, check whether it has alternating bits: namely, if two adjacent bits will always have different values.
        /// </summary>
        public _00693_BinaryNumberWithAlternatingBits()
        {
            Console.WriteLine(HasAlternatingBits(5));
            Console.WriteLine(HasAlternatingBits(7));
            Console.WriteLine(HasAlternatingBits(11));
        }

        private static bool HasAlternatingBits(int n)
        {
            char[] r = Convert.ToString(n, 2).ToCharArray();

            for (int i = 1; i < r.Length; i++)
            {
                if (r[i - 1] == r[i]) return false;
            }

            return true;
        }

        private static bool HasAlternatingBits0(int n)
        {
            int previous = n % 2;
            n >>= 1;

            while (n != 0)
            {
                if ((previous ^ n % 2) != 1) return false;

                previous = n % 2;
                n >>= 1;
            }

            return true;
        }
    }
}
