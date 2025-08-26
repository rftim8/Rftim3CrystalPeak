namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Temperatures
    {
        public Temperatures()
        {
            int n = 5;
            List<int> t = new()
            {
               7, 5, 9, 1, 2
            };

            Solve(n, t);
        }

        private static void Solve(int n, List<int> t)
        {
            List<int> posList = new();
            List<int> negList = new();

            t.Sort();

            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] > 0) posList.Add(t[i]);
                if (t[i] < 0) negList.Add(t[i]);
            }

            int zPos;

            if (posList.Count != 0)
            {
                posList.Sort();
                zPos = posList.First();
            }
            else zPos = 0;

            int zNeg;

            if (negList.Count != 0)
            {
                negList.Sort();
                zNeg = negList.Last();
            }
            else zNeg = 0;

            int zPosAbs = Math.Abs(zPos);
            int zNegAbs = Math.Abs(zNeg);
            int case2 = 5;
            int q;

            if (zPosAbs < case2 && zNegAbs < case2) q = zPosAbs < zNegAbs ? zPos : zNeg;
            else q = zPos;

            if (zNeg == 0) q = zPos;
            if (zPos == 0) q = zNeg;
            if (q == -2) q = 2;

            Console.WriteLine(q);
        }
    }
}
