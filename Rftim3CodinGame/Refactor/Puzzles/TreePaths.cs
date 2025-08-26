namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TreePaths
    {
        public TreePaths()
        {
            int v = 2; // index of target node
            const int m = 1; // nr nodes with two children
            int[] p = new int[m] {
                1
            }; // node index
            int[] l = new int[m] {
                2
            }; // left child
            int[] r = new int[m] {
               3
            }; // right child

            Solve(v, m, p, l, r);
        }

        private static void Solve(int v, int m, int[] p, int[] l, int[] r)
        {
            string result = "";

            for (int i = m - 1; i >= 0; i--)
            {
                if (p[i] == v)
                {
                    result = "Root " + result;
                }
                if (l[i] == v)
                {
                    v = p[i];
                    result = "Left " + result;
                }
                if (r[i] == v)
                {
                    v = p[i];
                    result = "Right " + result;
                }
            }

            Console.WriteLine(result.TrimEnd());
        }
    }
}
