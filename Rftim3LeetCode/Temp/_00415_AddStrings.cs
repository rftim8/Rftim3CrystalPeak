namespace Rftim3LeetCode.Temp
{
    public class _00415_AddStrings
    {
        /// <summary>
        /// Given two non-negative integers, num1 and num2 represented as string, return the sum of num1 and num2 as a string.
        /// You must solve the problem without using any built-in library for handling large integers(such as BigInteger). 
        /// You must also not convert the inputs to integers directly.
        /// </summary>
        public _00415_AddStrings()
        {
            Console.WriteLine(AddStrings0("11", "123"));
            Console.WriteLine(AddStrings0("456", "77"));
            Console.WriteLine(AddStrings0("0", "0"));
        }

        public static string AddStrings0(string a0, string a1) => RftAddStrings0(a0, a1);

        private static string RftAddStrings0(string num1, string num2)
        {
            int n = num1.Length;
            int m = num2.Length;

            if (n < m)
            {
                (n, m) = (m, n);
                (num1, num2) = (num2, num1);
            }

            string x = "";
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                int a = int.Parse(num1[^i].ToString());
                int b = i <= m ? int.Parse(num2[^i].ToString()) : 0;
                x = ((a + b + c) % 10).ToString() + x;
                c = (a + b + c) / 10;
                if (i == n && c != 0) x = c.ToString() + x;
            }

            return x;
        }
    }
}
