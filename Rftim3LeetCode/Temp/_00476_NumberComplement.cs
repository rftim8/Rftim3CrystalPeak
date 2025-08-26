namespace Rftim3LeetCode.Temp
{
    public class _00476_NumberComplement
    {
        /// <summary>
        /// The complement of an integer is the integer you get when you flip all the 0's to 1's and all the 1's to 0's in its binary representation.
        /// For example, The integer 5 is "101" in binary and its complement is "010" which is the integer 2.
        /// Given an integer num, return its complement.
        /// </summary>
        public _00476_NumberComplement()
        {
            Console.WriteLine(FindComplement0(5));
            Console.WriteLine(FindComplement0(1));
        }

        public static int FindComplement0(int a0) => RftFindComplement0(a0);

        private static int RftFindComplement0(int num)
        {
            char[] x = Convert.ToString(num, 2).ToCharArray();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == '1') x[i] = '0';
                else x[i] = '1';
            }

            return Convert.ToInt32(string.Concat(x), 2);
        }
    }
}
