using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00394_DecodeString
    {
        /// <summary>
        /// Given an encoded string, return its decoded string.
        /// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.
        /// Note that k is guaranteed to be a positive integer.
        /// You may assume that the input string is always valid; there are no extra white spaces, square brackets are well-formed, etc.
        /// Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k.
        /// For example, there will not be input like 3a or 2[4].
        /// The test cases are generated so that the length of the output will never exceed 105.
        /// </summary>
        public _00394_DecodeString()
        {
            Console.WriteLine(DecodeString("3[a]2[bc]"));
            Console.WriteLine(DecodeString("3[a2[c]]"));
            Console.WriteLine(DecodeString("2[abc]3[cd]ef"));
        }
        private static string DecodeString(string s)
        {
            int n = s.Length;
            int c = 0;
            Stack<char> s1 = new();
            Stack<int> s2 = new();

            for (int i = 0; i < n; i++)
            {
                if (char.IsDigit(s[i])) c = c * 10 + int.Parse(s[i].ToString());
                else if (s[i] == ']')
                {
                    StringBuilder crt = new();

                    while (s1.Peek() != '[')
                    {
                        crt.Append(s1.Pop());
                    }

                    s1.Pop();

                    int j = s2.Pop();

                    while (j-- > 0)
                    {
                        for (int k = crt.Length - 1; k > -1; k--)
                        {
                            s1.Push(crt[k]);
                        }
                    }
                }
                else
                {
                    s1.Push(s[i]);

                    if (s[i] == '[')
                    {
                        s2.Push(c);
                        c = 0;
                    }
                }
            }

            char[] res = new char[s1.Count];

            while (s1.Count != 0)
            {
                res[s1.Count - 1] = s1.Pop();
            }

            return new string(res);
        }
    }
}
