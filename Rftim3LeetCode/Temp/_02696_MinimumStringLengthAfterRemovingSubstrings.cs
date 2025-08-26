namespace Rftim3LeetCode.Temp
{
    public class _02696_MinimumStringLengthAfterRemovingSubstrings
    {
        /// <summary>
        /// You are given a string s consisting only of uppercase English letters.
        /// You can apply some operations to this string where, in one operation, you can remove any occurrence of one of the substrings "AB" or "CD" from s.
        /// Return the minimum possible length of the resulting string that you can obtain.
        /// Note that the string concatenates after removing the substring and could produce new "AB" or "CD" substrings.
        /// </summary>
        public _02696_MinimumStringLengthAfterRemovingSubstrings()
        {
            Console.WriteLine(MinLength("ABFCACDB"));
            Console.WriteLine(MinLength("ACBBD"));
        }

        private static int MinLength(string s)
        {
            List<char> r = [.. s];

            bool f = true;
            while (f)
            {
                f = false;
                for (int i = 0; i < r.Count - 1; i++)
                {
                    if (r[i] == 'A' && r[i + 1] == 'B' ||
                        r[i] == 'C' && r[i + 1] == 'D')
                    {
                        r.RemoveAt(i + 1);
                        r.RemoveAt(i);
                        f = true;
                    }
                }
            }

            return r.Count > 0 ? r.Count : 0;
        }
    }
}
