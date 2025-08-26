namespace Rftim3LeetCode.Temp
{
    public class _01945_SumOfDigitsOfStringAfterConvert
    {
        /// <summary>
        /// You are given a string s consisting of lowercase English letters, and an integer k.
        /// First, convert s into an integer by replacing each letter with its position in the alphabet(i.e., replace 'a' with 1, 'b' with 2, ..., 'z' with 26). 
        /// Then, transform the integer by replacing it with the sum of its digits.
        /// Repeat the transform operation k times in total.
        /// For example, if s = "zbax" and k = 2, then the resulting integer would be 8 by the following operations:
        /// Convert: "zbax" ➝ "(26)(2)(1)(24)" ➝ "262124" ➝ 262124
        /// Transform #1: 262124 ➝ 2 + 6 + 2 + 1 + 2 + 4 ➝ 17
        /// Transform #2: 17 ➝ 1 + 7 ➝ 8
        /// Return the resulting integer after performing the operations described above.
        /// </summary>
        public _01945_SumOfDigitsOfStringAfterConvert()
        {
            Console.WriteLine(GetLucky("iiii", 1));
            Console.WriteLine(GetLucky("leetcode", 2));
            Console.WriteLine(GetLucky("zbax", 2));
        }

        private static int GetLucky(string s, int k)
        {
            string t = "";
            char[] r = s.ToCharArray();

            for (int j = 0; j < r.Length; j++)
            {
                t += r[j] - 96;
            }

            for (int i = 0; i < k; i++)
            {
                int c = 0;
                for (int j = 0; j < t.Length; j++)
                {
                    c += int.Parse(t[j].ToString());
                }
                t = c.ToString();
                _ = t.ToCharArray();
            }

            return int.Parse(t);
        }
    }
}
