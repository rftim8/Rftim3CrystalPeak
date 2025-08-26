namespace Rftim3LeetCode.Temp
{
    public class _01544_MakeTheStringGreat
    {
        /// <summary>
        /// Given a string s of lower and upper case English letters.
        /// A good string is a string which doesn't have two adjacent characters s[i] and s[i + 1] where:
        /// 0 <= i <= s.length - 2
        /// s[i] is a lower-case letter and s[i + 1] is the same letter but in upper-case or vice-versa.
        /// To make the string good, you can choose two adjacent characters that make the string bad and remove them.
        /// You can keep doing this until the string becomes good.
        /// Return the string after making it good.The answer is guaranteed to be unique under the given constraints.
        /// Notice that an empty string is also good.
        /// </summary>
        public _01544_MakeTheStringGreat()
        {
            Console.WriteLine(MakeGood("leEeetcode"));
            Console.WriteLine(MakeGood("abBAcC"));
            Console.WriteLine(MakeGood("s"));
            Console.WriteLine(MakeGood("djrDdRJD"));
        }

        private static string MakeGood(string s)
        {
            if (s.Length == 1) return s;
            List<char> r = [.. s];

            for (int i = 0; i < r.Count - 1; i++)
            {
                if (char.IsUpper(r[i]) && char.IsLower(r[i + 1]) && r[i].ToString() == r[i + 1].ToString().ToUpper() ||
                    char.IsLower(r[i]) && char.IsUpper(r[i + 1]) && r[i].ToString() == r[i + 1].ToString().ToLower())
                {
                    Console.WriteLine($"{r[i]}: {r[i + 1]}");
                    r.RemoveAt(i + 1);
                    r.RemoveAt(i);
                    i = -1;
                }
            }

            return string.Concat(r);
        }

        private static string MakeGood0(string s)
        {
            Stack<char> stack = new();

            foreach (char c in s)
            {
                if (stack.Count > 0)
                {
                    if (stack.Peek() == c + 32 ||
                       stack.Peek() == c - 32)
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(c);
            }

            return new string(stack.ToArray().Reverse().ToArray());
        }
    }
}
