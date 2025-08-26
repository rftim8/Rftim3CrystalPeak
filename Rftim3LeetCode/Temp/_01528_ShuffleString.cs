namespace Rftim3LeetCode.Temp
{
    public class _01528_ShuffleString
    {
        /// <summary>
        /// You are given a string s and an integer array indices of the same length. 
        /// The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        /// Return the shuffled string.
        /// </summary>
        public _01528_ShuffleString()
        {
            Console.WriteLine(RestoreString("codeleet", [4, 5, 6, 7, 0, 2, 1, 3]));
            Console.WriteLine(RestoreString("abc", [0, 1, 2]));
        }

        private static string RestoreString(string s, int[] indices)
        {
            int n = s.Length;
            char[] r = new char[n];

            for (int i = 0; i < n; i++)
            {
                r[indices[i]] = s[i];
            }

            return string.Concat(r);
        }
    }
}
