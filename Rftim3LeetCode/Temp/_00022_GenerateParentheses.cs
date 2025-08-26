using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00022_GenerateParentheses
    {
        /// <summary>
        /// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        /// </summary>
        public _00022_GenerateParentheses()
        {
            IList<string> x = GenerateParenthesis0(1);

            RftTerminal.RftReadResult(x);
        }

        public static IList<string> GenerateParenthesis0(int a0) => RftGenerateParenthesis0(a0);

        public static IList<string> GenerateParenthesis1(int a0) => RftGenerateParenthesis1(a0);

        private static List<string> RftGenerateParenthesis0(int n)
        {
            List<string> ans = [];

            Stack<string> s = new();
            int l = 0, r = 0;
            Backtrack(s, l, r);

            void Backtrack(Stack<string> S, int left = 0, int right = 0)
            {
                if (S.Count == 2 * n)
                {
                    ans.Add(string.Join("", S));
                    return;
                }
                if (left < n)
                {
                    S.Push(")");
                    Backtrack(S, left + 1, right);
                    S.Pop();
                }
                if (right < left)
                {
                    S.Push("(");
                    Backtrack(S, left, right + 1);
                    S.Pop();
                }
            }

            return ans;
        }

        private static List<string> RftGenerateParenthesis1(int n)
        {
            List<string> lst = [];
            Gen(0, 0, "");
            return lst;

            void Gen(int i, int j, string cur)
            {
                if (i >= n && j >= n)
                {
                    lst.Add(cur);
                    return;
                }

                if (j < i) Gen(i, j + 1, $"{cur})");
                if (i < n) Gen(i + 1, j, $"{cur}(");
            }
        }
    }
}
