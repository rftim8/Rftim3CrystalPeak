namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftTuple
    {
        public RftTuple()
        {
            RftExample();
        }

        private static void RftExample()
        {
            (int t1, string t2) = (1, "");
            (int t1, string t2) t0 = (1, "a");

            while (t1 < 10)
            {
                t2 += t0.t2;
                t1++;
            }

            Console.WriteLine(t2);
        }
    }
}
