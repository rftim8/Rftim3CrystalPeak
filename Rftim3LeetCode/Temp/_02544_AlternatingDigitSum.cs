namespace Rftim3LeetCode.Temp
{
    public class _02544_AlternatingDigitSum
    {
        /// <summary>
        /// You are given a positive integer n. 
        /// Each digit of n has a sign according to the following rules:
        /// The most significant digit is assigned a positive sign.
        /// Each other digit has an opposite sign to its adjacent digits.
        /// Return the sum of all digits with their corresponding sign.
        /// </summary>
        public _02544_AlternatingDigitSum()
        {
            Console.WriteLine(AlternateDigitSum(521));
            Console.WriteLine(AlternateDigitSum(111));
            Console.WriteLine(AlternateDigitSum(886996));
            Console.WriteLine(AlternateDigitSum(10));
        }

        private static int AlternateDigitSum(int n)
        {
            int r = 0;
            int[] x = n.ToString().Select(o => int.Parse(o.ToString())).ToArray();

            bool s = true;
            for (int i = 0; i < x.Length; i++)
            {
                if (s)
                {
                    r += x[i];
                    s = false;
                }
                else
                {
                    r -= x[i];
                    s = true;
                }
            }

            return r;
        }

        private static int AlternateDigitSum0(int n)
        {
            int sign = 1;
            int result = 0;

            foreach (char digit in n.ToString())
            {
                result += sign * (digit - '0');
                sign *= -1;
            }

            return result;
        }
    }
}
