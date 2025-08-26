using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00166_FractionToRecurringDecimal
    {
        /// <summary>
        /// Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
        /// If the fractional part is repeating, enclose the repeating part in parentheses.
        /// If multiple answers are possible, return any of them.
        /// It is guaranteed that the length of the answer string is less than 104 for all the given inputs.
        /// </summary>
        public _00166_FractionToRecurringDecimal()
        {
            Console.WriteLine(FractionToDecimal(1, 2));
            Console.WriteLine(FractionToDecimal(2, 1));
            Console.WriteLine(FractionToDecimal(4, 333));
        }

        private static string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0) return "0";

            StringBuilder sb = new();
            if (numerator < 0 ^ denominator < 0) sb.Append('-');

            long l = Math.Abs((long)numerator);
            long r = Math.Abs((long)denominator);

            sb.Append(l / r);

            long rem = l % r;
            if (rem == 0) return sb.ToString();

            sb.Append('.');

            Dictionary<long, int> d = [];
            while (rem != 0)
            {
                if (d.TryGetValue(rem, out int value))
                {
                    sb.Insert(value, "(");
                    sb.Append(')');
                    break;
                }

                d[rem] = sb.Length;
                rem *= 10;
                sb.Append(rem / r);
                rem %= r;
            }

            return sb.ToString();
        }
    }
}
