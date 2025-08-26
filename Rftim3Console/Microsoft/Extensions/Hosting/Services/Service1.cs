using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime;

namespace Rftim3Console.Microsoft.Extensions.Hosting.Services
{
    public class Service1
    {
        public Service1(IHost host)
        {
            ServiceLifetimeExemplify(host.Services, "Lifetime 1");
            ServiceLifetimeExemplify(host.Services, "Lifetime 2");
        }

        private static void ServiceLifetimeExemplify(IServiceProvider hostProvider, string lifetime)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            ServiceReportLifetime logger = provider.GetRequiredService<ServiceReportLifetime>();
            logger.ServiceReportLifetimeDetails($"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");

            Console.WriteLine("...");

            logger = provider.GetRequiredService<ServiceReportLifetime>();
            logger.ServiceReportLifetimeDetails($"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");

            Console.WriteLine();
        }
    }
}
