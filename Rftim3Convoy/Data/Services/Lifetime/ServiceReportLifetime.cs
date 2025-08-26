using Rftim3Convoy.Data.Services.Algorithms.Searching.Binary;

namespace Rftim3Convoy.Data.Services.Lifetime
{
    public sealed class ServiceReportLifetime(
        IBinarySearch binarySearch)
    {
        private readonly IBinarySearch binarySearch = binarySearch;

        public void ServiceReportLifetimeDetails(string lifetimeDetails)
        {
            Console.WriteLine(lifetimeDetails);

            ServiceLog(binarySearch);
        }

        private static void ServiceLog<T>(T service) where T : IServiceReportLifetime
        {
            Console.WriteLine($"\t{typeof(T).Name}: {service.Id} -> {service.Lifetime}");
        }
    }
}
