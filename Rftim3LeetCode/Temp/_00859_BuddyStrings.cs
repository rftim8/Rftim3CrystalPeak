namespace Rftim3LeetCode.Temp
{
    public class _00859_BuddyStrings
    {
        /// <summary>
        /// Given two strings s and goal, return true if you can swap two letters in s so the result is equal to goal, otherwise, return false.
        /// Swapping letters is defined as taking two indices i and j(0-indexed) such that i != j and swapping the characters at s[i] and s[j].
        /// For example, swapping at indices 0 and 2 in "abcd" results in "cbad".
        /// </summary>
        public _00859_BuddyStrings()
        {
            Console.WriteLine(BuddyStrings("ab", "ba"));
            Console.WriteLine(BuddyStrings("ab", "ab"));
            Console.WriteLine(BuddyStrings("aa", "aa"));
            Console.WriteLine(BuddyStrings("abab", "abab"));
        }

        private static bool BuddyStrings(string s, string goal)
        {
            int n = s.Length;
            int m = goal.Length;

            if (n != m) return false;

            int[] alpha0 = new int[26];
            int[] alpha1 = new int[26];
            int c = 0;
            List<(char, char)> y = [];

            for (int i = 0; i < n; i++)
            {
                if (s[i] != goal[i])
                {
                    y.Add((s[i], goal[i]));
                    c++;
                }
                if (c > 2) return false;

                alpha0[s[i] - 97]++;
                alpha1[goal[i] - 97]++;
            }

            if (c == 1) return false;

            if (!alpha0.SequenceEqual(alpha1)) return false;

            return s != goal || alpha0.Where(o => o > 1).Any();
        }

        private static bool BuddyStrings0(string A, string B)
        {
            if (A.Length != B.Length || A.Length < 2) return false;

            if (A.Equals(B))
            {
                HashSet<char> uniqueChars = new(A);

                return uniqueChars.Count < A.Length;
            }
            else
            {
                List<int> diffs = [];

                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] != B[i]) diffs.Add(i);

                    if (diffs.Count > 2) return false;
                }

                return diffs.Count == 2 && A[diffs[0]] == B[diffs[1]] && A[diffs[1]] == B[diffs[0]];
            }
        }

        private static bool BuddyStrings1(string s, string goal)
        {
            if (s.Length != goal.Length) return false;

            HashSet<char> cs = [];
            (char, char)? wrongChar = null;
            bool hasDublicates = false;
            bool swapDone = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (cs.Contains(s[i])) hasDublicates = true;
                else cs.Add(s[i]);

                if (s[i] == goal[i]) continue;
                if (swapDone) return false;
                if (wrongChar == null) wrongChar = (s[i], goal[i]);
                else
                {
                    if (wrongChar?.Item1 == goal[i] && wrongChar?.Item2 == s[i])
                    {
                        swapDone = true;
                        wrongChar = null;
                    }
                    else return false;
                }
            }

            return (hasDublicates || swapDone) && wrongChar == null;
        }
    }
}
























