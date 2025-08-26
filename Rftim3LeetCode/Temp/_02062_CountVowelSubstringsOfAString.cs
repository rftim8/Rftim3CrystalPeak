namespace Rftim3LeetCode.Temp
{
    public class _02062_CountVowelSubstringsOfAString
    {
        /// <summary>
        /// A substring is a contiguous (non-empty) sequence of characters within a string.
        /// A vowel substring is a substring that only consists of vowels('a', 'e', 'i', 'o', and 'u') and has all five vowels present in it.
        /// Given a string word, return the number of vowel substrings in word.
        /// </summary>
        public _02062_CountVowelSubstringsOfAString()
        {
            Console.WriteLine(CountVowelSubstrings("aeiouu"));
            Console.WriteLine(CountVowelSubstrings("unicornarihan"));
            Console.WriteLine(CountVowelSubstrings("cuaieuouac"));
        }

        private static int CountVowelSubstrings(string word)
        {
            int n = word.Length;
            char[] v = ['a', 'e', 'i', 'o', 'u'];

            int r = 0;
            for (int j = 0; j < n; j++)
            {
                bool a = false, e = false, i = false, o = false, u = false;
                if (v.Contains(word[j]))
                {
                    switch (word[j])
                    {
                        case 'a':
                            a = true;
                            break;
                        case 'e':
                            e = true;
                            break;
                        case 'i':
                            i = true;
                            break;
                        case 'o':
                            o = true;
                            break;
                        case 'u':
                            u = true;
                            break;
                        default:
                            break;
                    }
                    for (int k = j + 1; k < n; k++)
                    {
                        if (v.Contains(word[k]))
                        {
                            switch (word[k])
                            {
                                case 'a':
                                    a = true;
                                    break;
                                case 'e':
                                    e = true;
                                    break;
                                case 'i':
                                    i = true;
                                    break;
                                case 'o':
                                    o = true;
                                    break;
                                case 'u':
                                    u = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else break;

                        if (a && e && i && o && u) r++;
                    }
                }
            }

            return r;
        }
    }
}
