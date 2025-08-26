using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceSingleton
{
    public interface IServiceSingletonExample : IServiceReportLifetime
    {
        ServiceLifetime IServiceReportLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
