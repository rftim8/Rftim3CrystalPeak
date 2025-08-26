namespace Rftim3LeetCode.Temp
{
    public class _01974_MinimumTimeToTypeWordUsingSpecialTypewriter
    {
        /// <summary>
        /// There is a special typewriter with lowercase English letters 'a' to 'z' arranged in a circle with a pointer. 
        /// A character can only be typed if the pointer is pointing to that character. 
        /// The pointer is initially pointing to the character 'a'.
        /// Each second, you may perform one of the following operations:
        /// Move the pointer one character counterclockwise or clockwise.
        /// Type the character the pointer is currently on.
        /// Given a string word, return the minimum number of seconds to type out the characters in word.
        /// </summary>
        public _01974_MinimumTimeToTypeWordUsingSpecialTypewriter()
        {
            Console.WriteLine(MinTimeToType("abc"));
            Console.WriteLine(MinTimeToType("bza"));
            Console.WriteLine(MinTimeToType("zjpc"));
        }

        private static int MinTimeToType(string word)
        {
            int n = word.Length;

            int c = 0, r = 0;
            for (int i = 0; i < n; i++)
            {
                int d = word[i] - 97;
                if (c == d) r++;
                else
                {
                    if (c <= d)
                    {
                        if (d - c >= 13) r += c + (26 - d);
                        else r += d - c;
                    }
                    else
                    {
                        if (c - d >= 13) r += 26 - c + d;
                        else r += c - d;
                    }

                    c = d;
                    r++;
                }
            }

            return r;
        }

        private static int MinTimeToType0(string word)
        {
            (int r, char prev) = (word.Length, 'a');

            foreach (char item in word)
            {
                int dist = Math.Abs(item - prev);

                r += Math.Min(dist, 26 - dist);

                prev = item;
            }

            return r;
        }
    }
}