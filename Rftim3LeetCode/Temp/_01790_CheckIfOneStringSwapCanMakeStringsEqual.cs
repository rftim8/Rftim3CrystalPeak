namespace Rftim3LeetCode.Temp
{
    public class _01790_CheckIfOneStringSwapCanMakeStringsEqual
    {
        /// <summary>
        /// You are given two strings s1 and s2 of equal length. 
        /// A string swap is an operation where you choose two indices in a string (not necessarily different) and swap the characters at these indices.
        /// Return true if it is possible to make both strings equal by performing at most one string swap on exactly one of the strings.
        /// Otherwise, return false.
        /// </summary>
        public _01790_CheckIfOneStringSwapCanMakeStringsEqual()
        {
            Console.WriteLine(AreAlmostEqual("bank", "kanb"));
            Console.WriteLine(AreAlmostEqual("attack", "defend"));
            Console.WriteLine(AreAlmostEqual("kelb", "kelb"));
        }

        private static bool AreAlmostEqual(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;

            if (n != m) return false;

            int c = 0;
            (char, char) l = (' ', ' ');
            (char, char) r = (' ', ' ');
            for (int i = 0; i < n; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (c == 0)
                    {
                        l.Item1 = s1[i];
                        l.Item2 = s2[i];
                    }
                    else
                    {
                        r.Item1 = s1[i];
                        r.Item2 = s2[i];
                    }
                    c++;
                }
                if (c > 2) return false;
            }

            if (l.Item1 != r.Item2 || l.Item2 != r.Item1) return false;

            return true;
        }
    }
}
