namespace Rftim3LeetCode.Temp
{
    public class _01750_MinimumLengthOfStringAfterDeletingSimilarEnds
    {
        /// <summary>
        /// Given a string s consisting only of characters 'a', 'b', and 'c'. 
        /// You are asked to apply the following algorithm on the string any number of times:
        /// 
        /// Pick a non-empty prefix from the string s where all the characters in the prefix are equal.
        /// Pick a non-empty suffix from the string s where all the characters in this suffix are equal.
        /// The prefix and the suffix should not intersect at any index.
        /// The characters from the prefix and suffix must be the same.
        /// Delete both the prefix and the suffix.
        /// Return the minimum length of s after performing the above operation any number of times (possibly zero times).
        /// </summary>
        public _01750_MinimumLengthOfStringAfterDeletingSimilarEnds()
        {
            Console.WriteLine(MinimumLengthOfStringAfterDeletingSimilarEnds0("ca"));
            Console.WriteLine(MinimumLengthOfStringAfterDeletingSimilarEnds0("cabaabac"));
            Console.WriteLine(MinimumLengthOfStringAfterDeletingSimilarEnds0("aabccabba"));
            Console.WriteLine(MinimumLengthOfStringAfterDeletingSimilarEnds0("abbbbbbbbbbbbbbbbbbba"));
            Console.WriteLine(MinimumLengthOfStringAfterDeletingSimilarEnds0("bbbbbbbbbbbbbbbbbbbbbbbbbbbabbbbbbbbbbbbbbbccbcbcbccbbabbb"));
        }

        public static int MinimumLengthOfStringAfterDeletingSimilarEnds0(string a0) => RftMinimumLengthOfStringAfterDeletingSimilarEnds0(a0);

        public static int MinimumLengthOfStringAfterDeletingSimilarEnds1(string a0) => RftMinimumLengthOfStringAfterDeletingSimilarEnds1(a0);

        private static int RftMinimumLengthOfStringAfterDeletingSimilarEnds0(string s)
        {
            int n = s.Length;
            if (n == 1) return 1;

            int l = 0, r = n - 1;
            char crt = ' ';
            while (l < r)
            {
                if (s[l] == s[r]) crt = s[l];
                else
                {
                    if (crt == ' ') return r - l + 1;
                }

                if (s[l] == crt) l++;
                if (s[r] == crt) r--;

                if (s[l] != crt && s[r] != crt)
                {
                    if (s[l] != s[r]) return r - l + 1;
                    else
                    {
                        if (l == r) return 1;
                    }
                }
            }

            return 0;
        }

        private static int RftMinimumLengthOfStringAfterDeletingSimilarEnds1(string s)
        {
            int i = 0, j = s.Length - 1;
            while (i < j && s[i] == s[j])
            {
                char c = s[i];
                while (i <= j && s[i] == c)
                {
                    i++;
                }

                while (j >= i && s[j] == c)
                {
                    j--;
                }
            }

            return i <= j ? j - i + 1 : 0;
        }
    }
}
