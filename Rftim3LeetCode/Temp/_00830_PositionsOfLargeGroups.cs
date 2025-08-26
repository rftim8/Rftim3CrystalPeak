using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00830_PositionsOfLargeGroups
    {
        /// <summary>
        /// In a string s of lowercase letters, these letters form consecutive groups of the same character.
        /// For example, a string like s = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z", and "yy".
        /// A group is identified by an interval[start, end], where start and end denote the start and end indices(inclusive) of the group.
        /// In the above example, "xxxx" has the interval[3, 6].
        /// A group is considered large if it has 3 or more characters.
        /// Return the intervals of every large group sorted in increasing order by start index.
        /// </summary>
        public _00830_PositionsOfLargeGroups()
        {
            IList<IList<int>> x = LargeGroupPositions("abbxxxxzzy");
            IList<IList<int>> x0 = LargeGroupPositions("abc");
            IList<IList<int>> x1 = LargeGroupPositions("abcdddeeeeaabbbcd");

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static IList<IList<int>> LargeGroupPositions(string s)
        {
            int n = s.Length;
            List<IList<int>> r = [];

            char t = s[0];
            int c = 1;
            int l = 0;
            for (int i = 1; i < n; i++)
            {
                if (t == s[i]) c++;
                else
                {
                    if (c >= 3) r.Add([l, i - 1]);
                    l = i;
                    t = s[i];
                    c = 1;
                }

                if (i == n - 1)
                {
                    if (t == s[i] && c >= 3) r.Add([l, i]);
                }
            }

            return r;
        }

        private static IList<IList<int>> LargeGroupPositions0(string s)
        {
            List<IList<int>> ans = [];
            for (int i = 0; i < s.Length; i++)
            {
                int count = 1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j]) count++;
                    else break;
                }

                if (count >= 3)
                {
                    ans.Add([i, i + count - 1]);
                    i += count - 1;
                }
            }

            return ans;
        }
    }
}
