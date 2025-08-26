namespace Rftim3LeetCode.Temp
{
    public class _01165_SingleRowKeyboard
    {
        /// <summary>
        /// There is a special keyboard with all keys in a single row.
        /// 
        /// Given a string keyboard of length 26 indicating the layout of the keyboard(indexed from 0 to 25). 
        /// Initially, your finger is at index 0. 
        /// To type a character, you have to move your finger to the index of the desired character.
        /// The time taken to move your finger from index i to index j is |i - j|.
        /// 
        /// You want to type a string word.
        /// Write a function to calculate how much time it takes to type it with one finger.
        /// </summary>
        public _01165_SingleRowKeyboard()
        {
            Console.WriteLine(SingleRowKeyboard0("abcdefghijklmnopqrstuvwxyz", "cba")); // 4
            Console.WriteLine(SingleRowKeyboard0("pqrstuvwxyzabcdefghijklmno", "leetcode")); // 73
        }

        public static int SingleRowKeyboard0(string a0, string a1) => RftSingleRowKeyboard0(a0, a1);

        public static int SingleRowKeyboard1(string a0, string a1) => RftSingleRowKeyboard1(a0, a1);

        private static int RftSingleRowKeyboard0(string keyboard, string word)
        {
            int res = 0, c = 0;

            foreach (char item in word)
            {
                int t = keyboard.IndexOf(item);
                if (t > c)
                {
                    res += t - c;
                    c = t;
                }
                else if (t < c)
                {
                    res += c - t;
                    c = t;
                }
                else res += 0;
            }

            return res;
        }

        private static int RftSingleRowKeyboard1(string keyboard, string word)
        {

            Dictionary<char, int> kb = keyboard.ToCharArray().Select((a, i) => new { a, i }).ToDictionary(t => t.a, t => t.i);
            int ans = 0;
            int pos = 0;
            for (int i = 0; i < word.Length; i++)
            {
                ans += Math.Abs(kb[word[i]] - pos);
                pos = kb[word[i]];
            }
            return ans;
        }
    }
}
