namespace Rftim3LeetCode.Temp
{
    public class _02405_OptimalPartitionOfString
    {
        /// <summary>
        /// Given a string s, partition the string into one or more substrings such that the characters in each substring are unique. 
        /// That is, no letter appears in a single substring more than once.
        /// Return the minimum number of substrings in such a partition.
        /// Note that each character should belong to exactly one substring in a partition.
        /// </summary>
        public _02405_OptimalPartitionOfString()
        {
            Console.WriteLine(PartitionString("abacaba"));
            Console.WriteLine(PartitionString("ssssss"));
        }

        private static int PartitionString(string s)
        {
            int n = s.Length;
            int x = 0;

            HashSet<char> y = [];
            for (int i = 0; i < n; i++)
            {
                if (!y.Contains(s[i])) y.Add(s[i]);
                else
                {
                    x++;
                    y.Clear();
                    y.Add(s[i]);
                }
            }
            if (y.Count != 0) x++;

            return x;
        }
    }
}
