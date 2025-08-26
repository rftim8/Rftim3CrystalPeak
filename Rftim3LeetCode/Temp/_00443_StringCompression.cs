namespace Rftim3LeetCode.Temp
{
    public class _00443_StringCompression
    {
        /// <summary>
        /// Given an array of characters chars, compress it using the following algorithm:
        /// Begin with an empty string s.For each group of consecutive repeating characters in chars:
        /// If the group's length is 1, append the character to s.
        /// Otherwise, append the character followed by the group's length.
        /// The compressed string s should not be returned separately, but instead, be stored in the input character array chars.
        /// Note that group lengths that are 10 or longer will be split into multiple characters in chars.
        /// After you are done modifying the input array, return the new length of the array.
        /// You must write an algorithm that uses only constant extra space.
        /// </summary>
        public _00443_StringCompression()
        {
            Console.WriteLine(Compress(['a', 'a', 'b', 'b', 'c', 'c', 'c']));
            Console.WriteLine(Compress(['a']));
            Console.WriteLine(Compress(['a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b']));
        }

        private static int Compress(char[] chars)
        {
            string s = "";
            int n = chars.Length;
            if (n == 1) return 1;

            char c = chars[0];
            int t = 1;

            int m = 0;
            for (int i = 1; i < n; i++)
            {
                if (c == chars[i]) t++;
                else
                {
                    if (t == 1)
                    {
                        chars[m] = c;
                        m++;
                        s += $"{c}";
                        c = chars[i];
                    }
                    else
                    {
                        string u = t.ToString();
                        chars[m] = c;
                        m++;
                        for (int j = 0; j < u.Length; j++)
                        {
                            chars[m] = u[j];
                            m++;
                        }
                        s += $"{c}{t}";
                        t = 1;
                        c = chars[i];
                    }
                }
                if (i == n - 1)
                {
                    if (t == 1)
                    {
                        chars[m] = c;
                        m++;
                        s += $"{c}";
                        c = chars[i];
                    }
                    else
                    {
                        string u = t.ToString();
                        chars[m] = c;
                        m++;

                        for (int j = 0; j < u.Length; j++)
                        {
                            chars[m] = u[j];
                            m++;
                        }
                        s += $"{c}{t}";
                        t = 1;
                        c = chars[i];
                    }
                }
            }

            return s.Length;
        }
    }
}
