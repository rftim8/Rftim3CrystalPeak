namespace Rftim3LeetCode.Temp
{
    public class _00067_AddBinary
    {
        /// <summary>
        /// Given two binary strings a and b, return their sum as a binary string.
        /// </summary>
        public _00067_AddBinary()
        {
            Console.WriteLine(AddBinary0("11", "1"));
            Console.WriteLine(AddBinary0("1010", "1011"));
        }

        public static string AddBinary0(string a0, string a1) => RftAddBinary0(a0, a1);

        private static string RftAddBinary0(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;
            int o = Math.Abs(n - m);

            string x = "";

            bool d = n < m;
            bool c = false;
            int i = 1;
            int min = Math.Min(n, m);

            while (min > 0)
            {
                if (a[^i] == '1' && b[^i] == '1')
                {
                    if (c) x = '1' + x;
                    else
                    {
                        x = '0' + x;
                        c = true;
                    }
                }
                else if (a[^i] == '1' || b[^i] == '1')
                {
                    if (c) x = '0' + x;
                    else
                    {
                        x = '1' + x;
                        c = false;
                    }
                }
                else
                {
                    if (c)
                    {
                        x = '1' + x;
                        c = false;
                    }
                    else
                    {
                        x = '0' + x;
                        c = false;
                    }
                }

                i++;
                min--;
            }

            if (d)
            {
                while (o > 0)
                {
                    if (b[^i] == '1' && c) x = '0' + x;
                    else
                    {
                        if (c)
                        {
                            x = '1' + x;
                            c = false;
                        }
                        else x = b[^i] + x;
                    }

                    i++;
                    o--;
                }
            }
            else
            {
                while (o > 0)
                {
                    if (a[^i] == '1' && c) x = '0' + x;
                    else
                    {
                        if (c)
                        {
                            x = '1' + x;
                            c = false;
                        }
                        else x = a[^i] + x;
                    }

                    i++;
                    o--;
                }
            }

            if (c) x = '1' + x;

            return x;
        }
    }
}
