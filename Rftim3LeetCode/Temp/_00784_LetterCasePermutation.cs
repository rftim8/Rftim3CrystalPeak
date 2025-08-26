using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00784_LetterCasePermutation
    {
        private static List<string> r;

        /// <summary>
        /// Given a string s, you can transform every letter individually to be lowercase or uppercase to create another string.
        /// Return a list of all possible strings we could create.Return the output in any order.
        /// </summary>
        public _00784_LetterCasePermutation()
        {
            IList<string> x = LetterCasePermutation("a1b2");

            RftTerminal.RftReadResult(x);
        }

        private static List<string> LetterCasePermutation(string s)
        {
            string s0 = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i])) s0 += s[i];
            }
            s0 = s0.ToLower();
            r = [];
            Permute(s0, s);

            return r;
        }

        private static void Permute(string input, string s)
        {
            int n = input.Length;
            int max = 1 << n;

            for (int i = 0; i < max; i++)
            {
                char[] combo = input.ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    if ((i >> j & 1) == 1) combo[j] = (char)(combo[j] - 32);
                }

                char[] orig = s.ToCharArray();
                int k = 0;

                for (int l = 0; l < orig.Length; l++)
                {
                    if (char.IsLetter(orig[l]))
                    {
                        orig[l] = combo[k];
                        k++;
                    }
                }

                r.Add(string.Join("", orig));
            }
        }
    }
}
