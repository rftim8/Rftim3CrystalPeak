namespace Rftim3LeetCode.Temp
{
    public class _02810_FaultyKeyboard
    {
        /// <summary>
        /// Your laptop keyboard is faulty, and whenever you type a character 'i' on it, it reverses the string that you have written. 
        /// Typing other characters works as expected.
        /// You are given a 0-indexed string s, and you type each character of s using your faulty keyboard.
        /// Return the final string that will be present on your laptop screen.
        /// </summary>
        public _02810_FaultyKeyboard()
        {
            Console.WriteLine(FinalString("string"));
            Console.WriteLine(FinalString("poiinter"));
        }

        private static string FinalString(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'i')
                {
                    s = $"{string.Concat(s[..i].Reverse())}{s[(i + 1)..]}";
                    i--;
                }
            }

            return s;
        }

        private static string FinalString0(string s)
        {
            string res = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'i') res = string.Concat(res.Reverse());
                else res += s[i];

            }

            return res;
        }
    }
}
