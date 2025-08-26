using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00017_LetterCombinationsOfAPhoneNumber
    {
        /// <summary>
        /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
        /// Return the answer in any order.
        /// A mapping of digits to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
        /// </summary>
        public _00017_LetterCombinationsOfAPhoneNumber()
        {
            IList<string> x = LetterCombinationsOfAPhoneNumber0("23");
            RftTerminal.RftReadResult(x);

            IList<string> x0 = LetterCombinationsOfAPhoneNumber0("234");
            RftTerminal.RftReadResult(x0);
        }

        public static IList<string> LetterCombinationsOfAPhoneNumber0(string a0) => RftLetterCombinationsOfAPhoneNumber0(a0);

        private static List<string> RftLetterCombinationsOfAPhoneNumber0(string digits)
        {
            int n = digits.Length;
            List<string> x = [];
            if (n == 0) return x;

            Dictionary<char, string> h = new() {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" }
            };

            return Backtrack(digits, "", x, h);
        }

        private static List<string> Backtrack(string dig, string s, List<string> ans, Dictionary<char, string> h)
        {
            if (string.IsNullOrEmpty(dig))
            {
                ans.Add(s);
                return ans;
            }

            foreach (char i in h[dig[0]])
            {
                Backtrack(dig[1..], s + i, ans, h);
            }

            return ans;
        }
    }
}
