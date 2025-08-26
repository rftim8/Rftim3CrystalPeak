using System.Collections;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class MimeType
    {
        public MimeType()
        {
            int n = 4;
            int q = 7;
            string[] ext = { "png", "TIFF", "css", "TXT" };
            string[] mt = { "image/ png", "image/ TIFF", "text/ css", "text/ plain" };
            string[] fname1 = { "example.TXT", "referecnce.txt", "strangename.tiff", "resolv.CSS", "matrix.TiFF", "lanDsCape.Png", "extract.cSs" };

            Solve(n, q, ext, mt, fname1);
        }

        private static void Solve(int n, int q, string[] ext, string[] mt, string[] fname1)
        {
            Hashtable ht = new();

            for (int i = 0; i < n; i++) ht.Add(ext[i].ToUpper(), mt[i]);

            for (int i = 0; i < q; i++)
            {
                bool flag = false;
                string fname = fname1[i];
                if (fname.Contains('.') && fname.Last() != '.')
                {
                    string y = fname.Split('.').Last().ToUpper();
                    if (ht.ContainsKey(y))
                    {
                        Console.WriteLine(ht[y]);
                        flag = true;
                    }
                }
                else flag = false;

                if (!flag) Console.WriteLine("UNKNOWN");
            }
        }
    }
}
