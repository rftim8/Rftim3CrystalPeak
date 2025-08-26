namespace Rftim3Console.System.OperatingSystems
{
    internal class RftOperatingSystem
    {
        public RftOperatingSystem()
        {
            Console.WriteLine($"Is Windows: {OperatingSystem.IsWindows()}");
            Console.WriteLine($"Is Android: {OperatingSystem.IsAndroid()}");
            Console.WriteLine($"Is Browser: {OperatingSystem.IsBrowser()}");
            Console.WriteLine($"Is FreeBSD: {OperatingSystem.IsFreeBSD()}");
            Console.WriteLine($"Is IOS: {OperatingSystem.IsIOS()}");
            Console.WriteLine($"Is Linux: {OperatingSystem.IsLinux()}");
            Console.WriteLine($"Is MacCatalyst: {OperatingSystem.IsMacCatalyst()}");
            Console.WriteLine($"Is MacOS: {OperatingSystem.IsMacOS()}");
            Console.WriteLine($"Is TvOS: {OperatingSystem.IsTvOS()}");
            Console.WriteLine($"Is WatchOS: {OperatingSystem.IsWatchOS()}");
        }
    }
}
