namespace Rftim3Console.System.Environments
{
    internal class RftEnvironment
    {
        public RftEnvironment()
        {
            Console.WriteLine($"Username: {Environment.UserName}");
            Console.WriteLine($"User domain name: {Environment.UserDomainName}");
            Console.WriteLine($"Machine Name: {Environment.MachineName}");
            Console.WriteLine($"OS version: {Environment.OSVersion}");
            Console.WriteLine($"Platform: {Environment.OSVersion.Platform}");
            Console.WriteLine($"Version: {Environment.OSVersion.Version}");
            string servicePack = string.IsNullOrEmpty(Environment.OSVersion.ServicePack) ? "N/A" : Environment.OSVersion.ServicePack;
            Console.WriteLine($"Service Pack: {servicePack}");
            Console.WriteLine($"x64 OS: {Environment.Is64BitOperatingSystem}");
            Console.WriteLine($"System directory: {Environment.SystemDirectory}");
            Console.WriteLine($"Process ID: {Environment.ProcessId}");
            Console.WriteLine($"Thread ID: {Environment.CurrentManagedThreadId}");
            Console.WriteLine($"x64 bit process: {Environment.Is64BitProcess}");
            Console.WriteLine($"Version: {Environment.Version}");
            Console.WriteLine($"Major: {Environment.Version.Major}");
            Console.WriteLine($"Major revision: {Environment.Version.MajorRevision}");
            Console.WriteLine($"Minor: {Environment.Version.Minor}");
            Console.WriteLine($"Minor revision: {Environment.Version.MinorRevision}");
            Console.WriteLine($"Build: {Environment.Version.Build}");
            Console.WriteLine($"Revision: {Environment.Version.Revision}");
            Console.WriteLine($"User interactive: {Environment.UserInteractive}");
            Console.WriteLine($"Process path: {Environment.ProcessPath}");
            Console.WriteLine($"Current directory: {Environment.CurrentDirectory}");
        }
    }
}
