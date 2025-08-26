namespace Rftim3Console.System.AppDomains
{
    internal class RftAppDomain
    {
        public RftAppDomain()
        {
            Console.WriteLine($"App name friendly: {AppDomain.CurrentDomain.FriendlyName}");
            Console.WriteLine($"Target framework: {AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName}");
            Console.WriteLine($"Base directory: {AppDomain.CurrentDomain.BaseDirectory}");
            Console.WriteLine($"App base: {AppDomain.CurrentDomain.SetupInformation.ApplicationBase}");
            Console.WriteLine($"Id: {AppDomain.CurrentDomain.Id}");
        }
    }
}
