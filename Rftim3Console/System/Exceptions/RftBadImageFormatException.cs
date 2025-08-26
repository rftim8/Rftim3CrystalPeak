using System.Reflection;

namespace Rftim3Console.System.Exceptions
{
    public class RftBadImageFormatException
    {
        public RftBadImageFormatException()
        {
            // Windows DLL (non-.NET assembly)
            string filePath = Environment.ExpandEnvironmentVariables("%windir%");
            if (!filePath.Trim().EndsWith('\\')) filePath += @"\";
            filePath += @"System32\Kernel32.dll";

            try
            {
                Assembly assem = Assembly.LoadFile(filePath);
            }
            catch (BadImageFormatException e)
            {
                Console.WriteLine($"Unable to load {filePath}.");
                Console.WriteLine(e.Message[..(e.Message.IndexOf('.') + 1)]);
            }
        }
    }
}
