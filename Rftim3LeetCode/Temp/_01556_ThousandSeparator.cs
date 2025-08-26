namespace Rftim3LeetCode.Temp
{
    public class _01556_ThousandSeparator
    {
        /// <summary>
        /// Given an integer n, add a dot (".") as the thousands separator and return it in string format.
        /// </summary>
        public _01556_ThousandSeparator()
        {
            Console.WriteLine(ThousandSeparator(987));
            Console.WriteLine(ThousandSeparator(1234));
            Console.WriteLine(ThousandSeparator(123456789));
        }

        private static string ThousandSeparator(int n)
        {
            if (n < 10) return n.ToString();
            string r = "";

            int c = 1;
            while (n > 0)
            {
                r = $"{n % 10}{r}";
                n /= 10;
                if (c % 3 == 0 && n > 0) r = $".{r}";
                c++;
            }

            return r;
        }
    }
}
