namespace Rftim3LeetCode.Temp
{
    public class _01189_MaximumNumberOfBalloons
    {
        /// <summary>
        /// Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.
        /// You can use each character in text at most once.Return the maximum number of instances that can be formed.
        /// </summary>
        public _01189_MaximumNumberOfBalloons()
        {
            Console.WriteLine(MaxNumberOfBalloons("nlaebolko"));
            Console.WriteLine(MaxNumberOfBalloons("loonbalxballpoon"));
            Console.WriteLine(MaxNumberOfBalloons("leetcode"));
        }

        private static int MaxNumberOfBalloons(string text)
        {
            int n = text.Length;
            Dictionary<char, int> r = new()
            {
                ['b'] = 0,
                ['a'] = 0,
                ['l'] = 0,
                ['o'] = 0,
                ['n'] = 0
            };

            for (int i = 0; i < n; i++)
            {
                if (r.ContainsKey(text[i])) r[text[i]]++;
            }

            int m = r['b'];

            int c = 0;
            for (int i = 1; i <= m; i++)
            {
                if (r['a'] >= i &&
                    r['n'] >= i &&
                    r['l'] >= 2 * i &&
                    r['o'] >= 2 * i
                    )
                    c++;
            }

            return c;
        }
    }
}
