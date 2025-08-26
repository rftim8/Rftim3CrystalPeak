namespace Rftim3LeetCode.Temp
{
    public class _00246_StrobogrammaticNumber
    {
        /// <summary>
        /// Given a string num which represents an integer, return true if num is a strobogrammatic number.
        /// 
        /// A strobogrammatic number is a number that looks the same when rotated 180 degrees(looked at upside down).
        /// </summary>
        public _00246_StrobogrammaticNumber()
        {
            Console.WriteLine(StrobogrammaticNumber0("69"));
            Console.WriteLine(StrobogrammaticNumber0("88"));
            Console.WriteLine(StrobogrammaticNumber0("962"));
        }

        public static bool StrobogrammaticNumber0(string a0) => RftStrobogrammaticNumber0(a0);

        private static bool RftStrobogrammaticNumber0(string num)
        {
            int n = num.Length;
            char[] a0 = new char[n];
            for (int i = 0; i < n; i++)
            {
                char t = num[n - i - 1];
                if (t == '9') a0[i] = '6';
                else if (t == '6') a0[i] = '9';
                else if (t == '8' || t == '1') a0[i] = t;
                else return false;
            }

            return num.SequenceEqual(a0);
        }
    }
}
