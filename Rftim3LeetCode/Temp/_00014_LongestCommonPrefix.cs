namespace Rftim3LeetCode.Temp
{
    public class _00014_LongestCommonPrefix
    {
        /// <summary>
        /// Write a function to find the longest common prefix string amongst an array of strings.
        /// If there is no common prefix, return an empty string "".
        /// </summary>
        public _00014_LongestCommonPrefix()
        {
            Console.WriteLine(LongestCommonPrefix0(["flower", "flow", "flight"]));
            Console.WriteLine(LongestCommonPrefix0(["dog", "racecar", "car"]));
        }

        public static string LongestCommonPrefix0(string[] a0) => RftLongestCommonPrefix0(a0);

        private static string RftLongestCommonPrefix0(string[] strs)
        {
            string x = "";
            int y = strs.Length;
            int z = strs[0].Length;
            for (int i = 1; i < strs.Length; i++)
            {
                int a = strs[i].Length;
                if (a < z) z = a;
            }
            string temp = "";

            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    temp += strs[j][i];
                }

                if (temp.Split(temp[0]).Length == y + 1) x += temp[0];
                else return x;

                temp = "";
            }

            return x;
        }
    }
}
