using System.Security.Cryptography;
using System.Text;

namespace Rftim3Console.System.Security.RftCryptography
{
    public class RftMD5
    {
        private static readonly string s = "123123asdasf";

        public RftMD5()
        {
            RftMD5ASCII(s);
            RftMD5UTF8(s);
        }

        private static void RftMD5ASCII(string s)
        {
            byte[] x = MD5.HashData(Encoding.ASCII.GetBytes(s));
            string x0 = Encoding.ASCII.GetString(x);
            Console.WriteLine(x0);
        }

        private static void RftMD5UTF8(string s)
        {
            UTF8Encoding y = new();
            string y0 = Convert.ToBase64String(MD5.HashData(y.GetBytes(s)));
            Console.WriteLine(y0);
        }
    }
}
