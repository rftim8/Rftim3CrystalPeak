namespace Rftim3LeetCode.Temp
{
    public class _00455_AssignCookies
    {
        /// <summary>
        /// Assume you are an awesome parent and want to give your children some cookies. 
        /// But, you should give each child at most one cookie.
        /// Each child i has a greed factor g[i], which is the minimum size of a cookie that the child will be content with; 
        /// and each cookie j has a size s[j]. If s[j] >= g[i], we can assign the cookie j to the child i, and the child i will be content.
        /// Your goal is to maximize the number of your content children and output the maximum number.
        /// </summary>
        public _00455_AssignCookies()
        {
            Console.WriteLine(FindContentChildren0(
                [1, 2, 3],
                [1, 1]
                ));

            Console.WriteLine(FindContentChildren0(
                [1, 2],
                [1, 2, 3]
                ));
        }

        public static int FindContentChildren0(int[] a0, int[] a1) => RftFindContentChildren0(a0, a1);

        public static int FindContentChildren1(int[] a0, int[] a1) => RftFindContentChildren1(a0, a1);

        private static int RftFindContentChildren0(int[] g, int[] s)
        {
            int m = s.Length;
            if (m == 0) return 0;

            int n = g.Length;

            Array.Sort(g);
            Array.Sort(s);

            int c = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (s[i] >= g[j])
                    {
                        c++;
                        g[j] = int.MaxValue;
                        break;
                    }
                }
            }

            return c;
        }

        private static int RftFindContentChildren1(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int i = 0;
            int j = 0;

            while (i < g.Length && j < s.Length)
            {

                if (g[i] <= s[j])
                {
                    i++;
                    j++;
                }
                else j++;
            }

            return i;
        }
    }
}
