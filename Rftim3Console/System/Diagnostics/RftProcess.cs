using System.Diagnostics;

namespace Rftim3Console.System.Diagnostics
{
    class RftProcess
    {
        public RftProcess()
        {
            using Process? process = new();
            process.StartInfo.FileName = @"<Path.exe>";

            process.Start();
        }
    }
}
