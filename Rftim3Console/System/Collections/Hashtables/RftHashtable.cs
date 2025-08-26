using System.Collections;

namespace Rftim3Console.System.Collections.Hashtables
{
    class RftHashtable
    {
        private static readonly string[] a = ["a", "b", "c"];
        private static readonly string[] b = ["x", "y", "z"];
        private static readonly Hashtable ht = [];

        public RftHashtable()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            for (int i = 0; i < 3; i++)
            {
                ht.Add(a[i], b[i]);
            }

            if (ht.ContainsKey("b")) Console.WriteLine($"{ht["b"]}");

            if (ht.ContainsValue("y")) Console.WriteLine($"true");

            foreach (var item in ht)
            {
                Console.WriteLine($"{ht[item]}");
            }
        }
    }
}
