namespace Rftim3LeetCode.Temp
{
    public class _01347_MinimumNumberOfStepsToMakeStringsAnagram
    {
        /// <summary>
        /// You are given two strings of the same length s and t. 
        /// In one step you can choose any character of t and replace it with another character.
        /// 
        /// Return the minimum number of steps to make t an anagram of s.
        /// 
        /// An Anagram of a string is a string that contains the same characters with a different(or the same) ordering.
        /// </summary>
        public _01347_MinimumNumberOfStepsToMakeStringsAnagram()
        {
            Console.WriteLine(MinSteps0("bab", "aba"));
            Console.WriteLine(MinSteps0("leetcode", "practice"));
            Console.WriteLine(MinSteps0("anagram", "mangaar"));
        }

        public static int MinSteps0(string a0, string a1) => RftMinSteps0(a0, a1);

        private static int RftMinSteps0(string s, string t)
        {
            int n = s.Length;
            int r = 0;
            int[] a0 = new int[26];
            int[] a1 = new int[26];

            for (int i = 0; i < n; i++)
            {
                a0[s[i] - 97]++;
                a1[t[i] - 97]++;
            }

            for (int i = 0; i < a0.Length; i++)
            {
                if (a0[i] > a1[i]) r += a0[i] - a1[i];
            }

            return r;
        }
    }
}