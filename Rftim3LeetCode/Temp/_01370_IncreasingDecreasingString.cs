namespace Rftim3LeetCode.Temp
{
    public class _01370_IncreasingDecreasingString
    {
        /// <summary>
        /// You are given a string s. Reorder the string using the following algorithm:
        /// Pick the smallest character from s and append it to the result.
        /// Pick the smallest character from s which is greater than the last appended character to the result and append it.
        /// Repeat step 2 until you cannot pick more characters.
        /// Pick the largest character from s and append it to the result.
        /// Pick the largest character from s which is smaller than the last appended character to the result and append it.
        /// Repeat step 5 until you cannot pick more characters.
        /// Repeat the steps from 1 to 6 until you pick all characters from s.
        /// In each step, If the smallest or the largest character appears more than once you can choose any occurrence and append it to the result.
        /// Return the result string after sorting s with this algorithm.
        /// </summary>
        public _01370_IncreasingDecreasingString()
        {
            Console.WriteLine(SortString("aaaabbbbcccc"));
            Console.WriteLine(SortString("rat"));
        }

        private static string SortString(string s)
        {
            int n = s.Length;
            if (n == 1) return s;

            char[] x = s.ToCharArray();
            Array.Sort(x);

            Dictionary<char, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(x[i], out int value)) r[x[i]] = ++value;
                else r[x[i]] = 1;
            }

            string t = "";
            bool a = false;
            while (r.Sum(o => o.Value) > 0)
            {
                string w = "";
                foreach (KeyValuePair<char, int> item in r.ToList())
                {
                    if (item.Value > 0)
                    {
                        if (a == false) w += item.Key;
                        else w = item.Key + w;
                        r[item.Key]--;
                    }
                }
                if (a == false) a = true;
                else a = false;
                t += w;
            }

            return t;
        }
    }
}
