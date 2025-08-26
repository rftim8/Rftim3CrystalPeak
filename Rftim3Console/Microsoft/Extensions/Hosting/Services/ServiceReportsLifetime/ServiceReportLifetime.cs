using Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceScoped;
using Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceSingleton;
using Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceTransient;

namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime
{
    public sealed class ServiceReportLifetime(
        IServiceScopedExample serviceScopedExample,
        IServiceSingletonExample serviceSingletonExample,
        IServiceTransientExample serviceTransientExample)
    {
        private readonly IServiceScopedExample serviceScopedExample = serviceScopedExample;
        private readonly IServiceSingletonExample serviceSingletonExample = serviceSingletonExample;
        private readonly IServiceTransientExample serviceTransientExample = serviceTransientExample;

        public void ServiceReportLifetimeDetails(string lifetimeDetails)
        {
            Console.WriteLine(lifetimeDetails);

            ServiceLog(serviceScopedExample, "Changes only with lifetime");
            ServiceLog(serviceSingletonExample, "Always the same");
            ServiceLog(serviceTransientExample, "Always different");
        }

        private static void ServiceLog<T>(T service, string message) where T : IServiceReportLifetime
        {
            Console.WriteLine($"    {typeof(T).Name}: {service.Id} ({message})");
        }
    }
}
