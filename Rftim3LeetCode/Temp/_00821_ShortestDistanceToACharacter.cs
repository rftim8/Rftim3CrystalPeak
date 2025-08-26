using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00821_ShortestDistanceToACharacter
    {
        /// <summary>
        /// Given a string s and a character c that occurs in s, return an array of integers answer where 
        /// answer.length == s.length and answer[i] is the distance from index i to the closest occurrence of character c in s.
        /// The distance between two indices i and j is abs(i - j), where abs is the absolute value function.
        /// </summary>
        public _00821_ShortestDistanceToACharacter()
        {
            int[] x = ShortestToChar("loveleetcode", 'e');
            int[] x0 = ShortestToChar("aaab", 'b');
            int[] x1 = ShortestToChar("islxy", 'i');

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] ShortestToChar(string s, char c)
        {
            int n = s.Length;
            int[] x = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (s[i] == c) x[i] = 0;
                else
                {
                    bool left = s[..i].Contains(c), right = s[i..].Contains(c);

                    int l = i, l0 = 0;
                    if (left)
                    {
                        while (l >= 0)
                        {
                            if (s[l] != c) l0++;
                            else break;
                            l--;
                        }
                    }

                    int r = i, r0 = 0;
                    if (right)
                    {
                        while (r < n)
                        {
                            if (s[r] != c) r0++;
                            else break;
                            r++;
                        }
                    }

                    if (!left) x[i] = r0;
                    else if (!right) x[i] = l0;
                    else x[i] = Math.Min(l0, r0);
                }
            }

            return x;
        }

        private static int[] ShortestToChar0(string s, char c)
        {
            List<int> list = [];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c) list.Add(i);
            }

            int n = s.Length;
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i > list[0] && list.Count > 1)
                {
                    if (Math.Abs(list[0] - i) > Math.Abs(list[1] - i)) list.RemoveAt(0);
                }

                result[i] = Math.Abs(list[0] - i);
            }

            return result;
        }
    }
}
