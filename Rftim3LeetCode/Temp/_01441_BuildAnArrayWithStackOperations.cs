using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01441_BuildAnArrayWithStackOperations
    {
        public _01441_BuildAnArrayWithStackOperations()
        {
            IList<string> x = BuildArray0([1, 3], 3);
            RftTerminal.RftReadResult(x);

            IList<string> x0 = BuildArray0([1, 2, 3], 3);
            RftTerminal.RftReadResult(x0);

            IList<string> x1 = BuildArray0([1, 2], 4);
            RftTerminal.RftReadResult(x1);
        }

        public static IList<string> BuildArray0(int[] a0, int a1) => RftBuildArray0(a0, a1);

        private static List<string> RftBuildArray0(int[] target, int n)
        {
            List<string> r = [];

            int j = 0;
            for (int i = 0; i < target.Length; i++)
            {
                while (j != target[i])
                {
                    r.Add("Push");
                    j++;
                    if (j < target[i]) r.Add("Pop");
                }
            }

            return r;
        }
    }
}
