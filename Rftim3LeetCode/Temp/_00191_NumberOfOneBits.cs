namespace Rftim3LeetCode.Temp
{
    public class _00191_NumberOfOneBits
    {
        /// <summary>
        /// Write a function that takes the binary representation of an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).
        /// Note:
        /// Note that in some languages, such as Java, there is no unsigned integer type.In this case, the input will be given as a signed integer type. 
        /// It should not affect your implementation, as the integer's public binary representation is the same, whether it is signed or unsigned.
        /// In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 3, the input represents the signed integer. -3.
        /// </summary>
        public _00191_NumberOfOneBits()
        {
            Console.WriteLine(HammingWeight0(11));
            Console.WriteLine(HammingWeight0(128));
            Console.WriteLine(HammingWeight0(4294967293));
        }

        public static int HammingWeight0(uint a0) => RftHammingWeight0(a0);

        public static int HammingWeight1(uint a0) => RftHammingWeight1(a0);

        private static int RftHammingWeight0(uint n)
        {
            char[] x = Convert.ToString(n, 2).ToCharArray();

            return x.Where(o => o == '1').Count();
        }

        private static int RftHammingWeight1(uint n)
        {
            int count = 0;

            for (int i = 0; i < 32; i++)
            {
                if ((n & 1 << i) > 0) count++;
            }

            return count;
        }
    }
}
