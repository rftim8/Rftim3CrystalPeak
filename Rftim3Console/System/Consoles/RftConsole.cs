using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Rftim3Console.System.Consoles
{
    public class RftConsole
    {
        public RftConsole()
        {
            _ = GetVersion();
        }

        public static async Task<string> GetVersion()
        {
            bool isWin = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            string tool = isWin ? "powershell" : "bash";
            string args = isWin ? "Get-ChildItem" : "ls -la";
            using Process process = new();
            ProcessStartInfo startInfo = new()
            {
                FileName = tool,
                Arguments = args,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            process.StartInfo = startInfo;

            // Start the process
            process.Start();

            string x = process.StandardOutput.ReadToEnd();
            await Console.Out.WriteLineAsync(x);
            string error = "";

            using (StreamReader s = process.StandardError)
            {
                error = s.ReadToEnd();
                await Console.Out.WriteLineAsync(error);
                await process.WaitForExitAsync();
            }

            return x;
        }
    }
}
