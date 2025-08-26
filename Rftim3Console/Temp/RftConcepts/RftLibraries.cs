using C = System.Console;

namespace Rftim3Console.Temp.RftConcepts
{
    public class RftLibraries
    {
        public RftLibraries()
        {
            string? s = C.ReadLine();
            if (s is not null)
            {
                foreach (string v in s.Split("-"))
                {
                    C.Write((char)(v[3] * 10 + v[4] - 528 + (49 > v[1] ? 97 : 50 > v[1] ? 65 : 48)));
                }
            }
        }
    }
}
