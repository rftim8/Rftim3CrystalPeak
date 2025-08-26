using System.Collections;

namespace Rftim3LeetCode.Temp
{
    public class _00190_ReverseBits
    {
        /// <summary>
        /// Reverse bits of a given 32 bits unsigned integer.
        /// Note:
        /// Note that in some languages, such as Java, there is no unsigned integer type.In this case, both input and output will be given as a signed integer type. 
        /// They should not affect your implementation, as the integer's public binary representation is the same, whether it is signed or unsigned.
        /// In Java, the compiler represents the signed integers using 2's complement notation. 
        /// Therefore, in Example 2 above, the input represents the signed integer -3 and the output represents the signed integer -1073741825.
        /// </summary>
        public _00190_ReverseBits()
        {
            Console.WriteLine(ReverseBits0(43261596));
            Console.WriteLine(ReverseBits0(4294967293));
        }

        public static uint ReverseBits0(uint a0) => RftReverseBits0(a0);

        public static uint ReverseBits1(uint a0) => RftReverseBits1(a0);

        private static uint RftReverseBits0(uint n)
        {
            BitArray a = new(BitConverter.GetBytes(n));
            string r = "";
            foreach (bool item in a)
            {
                r += item ? '1' : '0';
            }

            //IEnumerable<char> y = r.Reverse();
            //string z = string.Join("", y);

            n = Convert.ToUInt32(r, 2);

            return n;
        }

        private static uint RftReverseBits1(uint n)
        {
            uint m = 0;

            for (int i = 0; i < 32; i++, n >>= 1)
            {
                m <<= 1;
                m |= n & 1;
            }

            return m;
        }
    }
}
