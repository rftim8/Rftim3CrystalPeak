using System.Numerics;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00043_MultiplyStrings
    {
        /// <summary>
        /// Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
        /// Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
        /// </summary>
        public _00043_MultiplyStrings()
        {
            Console.WriteLine(MultiplyStrings0("2", "3"));
            Console.WriteLine(MultiplyStrings0("123", "456"));
            Console.WriteLine(MultiplyStrings0("9", "99"));
            Console.WriteLine(MultiplyStrings0("99", "9"));
            Console.WriteLine(MultiplyStrings0("123456789", "987654321"));
            Console.WriteLine(MultiplyStrings0("401716832807512840963", "167141802233061013023557397451289113296441069"));
            Console.WriteLine(MultiplyStrings0("500238825698990292381312765074025160144624723742", "60974249908865105026646412538664653190280198809433017"));
        }

        public static string MultiplyStrings0(string a0, string a1) => RftMultiplyStrings0(a0, a1);

        private static string RftMultiplyStrings0(string num1, string num2)
        {
            int n = num1.Length;
            int m = num2.Length;

            if (n < m)
            {
                (m, n) = (n, m);
                (num2, num1) = (num1, num2);
            }

            BigInteger x = 0;
            int c = 0;

            for (int i = m - 1; i > -1; i--)
            {
                string y = "";
                int carry = 0;
                if (num2[i] > 0)
                {
                    for (int j = n - 1; j > -1; j--)
                    {
                        int z = int.Parse(num2[i].ToString()) * int.Parse(num1[j].ToString()) + carry;
                        carry = z / 10;
                        y = (z % 10).ToString() + y;
                    }
                }
                if (carry > 0) y = carry.ToString() + y;
                x += BigInteger.Parse(y) * BigInteger.Pow(10, c);
                c++;
            }

            return x.ToString();
        }

        private static string MultiplyStrings1(string num1, string num2)
        {
            int n1 = num1.Length;
            int n2 = num2.Length;
            int[] result = new int[n1 + n2];

            for (int i = n1 - 1; i >= 0; i--)
            {
                for (int j = n2 - 1; j >= 0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int sum = result[i + j + 1] + mul;

                    result[i + j + 1] = sum % 10;
                    result[i + j] += sum / 10;
                }
            }

            StringBuilder sb = new();
            foreach (int num in result)
            {
                if (!(sb.Length == 0 && num == 0)) sb.Append(num);
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
