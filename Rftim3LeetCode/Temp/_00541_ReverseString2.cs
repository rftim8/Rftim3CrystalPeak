namespace Rftim3LeetCode.Temp
{
    public class _00541_ReverseString2
    {
        /// <summary>
        /// Given a string s and an integer k, reverse the first k characters for every 2k characters counting from the start of the string.
        /// If there are fewer than k characters left, reverse all of them.
        /// If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and leave the other as original.
        /// </summary>
        public _00541_ReverseString2()
        {
            Console.WriteLine(ReverseStr0("abcdefg", 2));
            Console.WriteLine(ReverseStr0("abcd", 2));
        }

        public static string ReverseStr0(string a0, int a1) => RftReverseStr0(a0, a1);

        public static string ReverseStr1(string a0, int a1) => RftReverseStr1(a0, a1);

        private static string RftReverseStr0(string s, int k)
        {
            int n = s.Length;
            if (k >= n) return string.Concat(s.Reverse());

            string r = string.Empty;

            int l = 0;
            bool a = true;
            while (l < n)
            {
                if (l + k <= n)
                {
                    if (a)
                    {
                        r += string.Concat(s[l..(l + k)].Reverse());
                        a = false;
                    }
                    else
                    {
                        r += s[l..(l + k)];
                        a = true;
                    }
                }
                else
                {
                    if (a) r += string.Concat(s[l..n].Reverse());
                    else r += s[l..n];
                }

                l += k;
            }

            return r;
        }

        private static string RftReverseStr1(string s, int k)
        {
            char[] charArray = s.ToCharArray();
            int stringLength = s.Length;
            for (int i = 0; i < stringLength; i += 2 * k)
            {
                int start = i;
                int end = Math.Min(i + k - 1, stringLength - 1);
                while (start < end)
                {
                    (charArray[end], charArray[start]) = (charArray[start], charArray[end]);
                    start++;
                    end--;
                }
            }

            return new string(charArray);
        }
    }
}
