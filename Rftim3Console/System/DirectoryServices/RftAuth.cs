using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Runtime.Versioning;

namespace Rftim3Console.System.DirectoryServices
{
    [SupportedOSPlatform("windows")]
    public class RftAuth
    {
        public RftAuth()
        {
            //RftADAuthenticateUser($"WinNT://{Environment.MachineName},Computer", "tester0", "12345");
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private static bool RftADAuthenticateUser(string path, string user, string pswd)
        {
            DirectoryEntry directoryEntry = new(path, user, pswd, AuthenticationTypes.Secure);
            try
            {
                foreach (string strAttrName in directoryEntry.Properties.PropertyNames)
                {
                    Console.WriteLine($"{strAttrName}\n");
                }

                DirectorySearcher ds = new(directoryEntry);
                ds.FindOne();
                Console.WriteLine("Succeeded");
                return true;
            }
            catch (DirectoryServicesCOMException)
            {
                Console.WriteLine("Error");
                return false;
            }
        }
    }
}
