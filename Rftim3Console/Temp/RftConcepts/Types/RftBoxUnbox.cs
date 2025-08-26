namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftBoxUnbox
    {
        public RftBoxUnbox()
        {
            RftExample();
        }

        private static void RftExample()
        {
            int i = 123;
            object o = i;
            int j = (int)o;

            Console.WriteLine(j);
        }
    }
}
