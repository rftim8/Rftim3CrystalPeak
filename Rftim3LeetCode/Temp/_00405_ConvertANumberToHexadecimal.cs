using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00405_ConvertANumberToHexadecimal
    {
        /// <summary>
        /// Given an integer num, return a string representing its hexadecimal representation. 
        /// For negative integers, two’s complement method is used.
        /// All the letters in the answer string should be lowercase characters, and there should not be any leading zeros in the answer except for the zero itself.
        /// Note: You are not allowed to use any built-in library method to directly solve this problem.
        /// </summary>
        public _00405_ConvertANumberToHexadecimal()
        {
            Console.WriteLine(ToHex0(26));
            Console.WriteLine(ToHex0(-1));
        }

        public static string ToHex0(int a0) => RftToHex0(a0);

        public static string ToHex1(int a0) => RftToHex1(a0);

        public static string ToHex2(int a0) => RftToHex2(a0);

        public static string ToHex3(int a0) => RftToHex3(a0);

        private static string RftToHex0(int num)
        {
            // convert to =ve num
            // divide by 16, add remainder to answer
            // The limits for int (32 bit) are:
            // int: –2147483648 to 2147483647 => -2^31 to 2^31
            // uint: 0 to 4294967295 => 2^32-1
            // T = O(1) as we can only run the loop a max of 8x
            // S = O(1)

            if (num == 0) return "0";
            uint num1 = (uint)num;

            StringBuilder sb = new();
            char[] values = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'];
            while (num1 > 0)
            {
                sb.Insert(0, values[num1 % 16]);
                num1 /= 16;
            }

            return sb.ToString();
        }

        private static string RftToHex1(int num)
        {
            return Convert.ToString(num, 16);
        }

        private static string RftToHex2(int num)
        {
            return num.ToString("x");
        }

        private static string RftToHex3(int num)
        {
            return $"{num:X}".ToLower();
        }
    }
}
