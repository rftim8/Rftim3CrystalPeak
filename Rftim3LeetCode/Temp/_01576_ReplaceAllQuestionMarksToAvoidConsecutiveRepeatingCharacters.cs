namespace Rftim3LeetCode.Temp
{
    public class _01576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharacters
    {
        /// <summary>
        /// Given a string s containing only lowercase English letters and the '?' character, convert all the '?' characters 
        /// into lowercase letters such that the final string does not contain any consecutive repeating characters.
        /// You cannot modify the non '?' characters.
        /// It is guaranteed that there are no consecutive repeating characters in the given string except for '?'.
        /// Return the final string after all the conversions(possibly zero) have been made.
        /// If there is more than one solution, return any of them.
        /// It can be shown that an answer is always possible with the given constraints.
        /// </summary>
        public _01576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharacters()
        {
            Console.WriteLine(ModifyString("?zs"));
            Console.WriteLine(ModifyString("ubv?w"));
        }

        private static string ModifyString(string s)
        {
            int n = s.Length;
            if (n == 1 && s == "?") return "a";
            else if (n == 1 && s != "?") return s;
            char[] r = s.ToCharArray();

            for (int i = 0; i < n; i++)
            {
                if (r[i] == '?')
                {
                    for (int j = 0; j < 26; j++)
                    {
                        char t = (char)(j + 97);
                        if (i == 0)
                        {
                            if (t != r[i + 1])
                            {
                                r[i] = t;
                                break;
                            }
                        }
                        else if (i == n - 1)
                        {
                            if (t != r[i - 1])
                            {
                                r[i] = t;
                                break;
                            }
                        }
                        else
                        {
                            if (t != r[i - 1] && t != r[i + 1])
                            {
                                r[i] = t;
                                break;
                            }
                        }
                    }
                }
            }

            return string.Concat(r);
        }
    }
}
