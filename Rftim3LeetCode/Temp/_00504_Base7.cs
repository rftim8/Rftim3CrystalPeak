using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00504_Base7
    {
        /// <summary>
        /// Given an integer num, return a string of its base 7 representation.
        /// </summary>
        public _00504_Base7()
        {
            Console.WriteLine(ConvertToBaseSeven0(100));
            Console.WriteLine(ConvertToBaseSeven0(-7));
        }

        public static string ConvertToBaseSeven0(int a0) => RftConvertToBaseSeven0(a0);

        public static string ConvertToBaseSeven1(int a0) => RftConvertToBaseSeven1(a0);

        private static string RftConvertToBaseSeven0(int num)
        {
            return num < 0 ? $"-{Int32ToString(Math.Abs(num), 7)}" : Int32ToString(num, 7);
        }

        private static string Int32ToString(int value, int toBase)
        {
            string result = string.Empty;
            do
            {
                result = "0123456789ABCDEF"[value % toBase] + result;
                value /= toBase;
            }
            while (value > 0);

            return result;
        }

        private static string RftConvertToBaseSeven1(int num)
        {
            if (num == 0) return "0";

            StringBuilder sb = new();
            int n = Math.Abs(num);
            while (n > 0)
            {
                int b7 = n % 7;
                sb.Insert(0, b7);
                n /= 7;
            }

            if (num < 0) sb.Insert(0, '-');

            return sb.ToString();
        }
    }
}
